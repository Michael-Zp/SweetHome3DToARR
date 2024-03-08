
using CliWrap.Buffered;
using Newtonsoft.Json;
using SweetHomeToArrAsset;
using System.Diagnostics;
using System.IO.Compression;
using System.Numerics;
using System.Xml;
using System.Xml.Serialization;

public class Program
{
    public enum ErrorCodes
    {
        PathToMainZipEmpty = 1,
        MainZipPathHasNoDirectory,
        SubZipFileNotFound,
        XmlDescriptorFileNotFound,
        PythonSetupFailed,
        ConversionToFbxFailed,
        ConversionToArrAssetFailed,
        XmlDescriptorFileWasEmpty,
        HomeNodeNotFoundInXmlFile,
        XmlDocumentElementIsNull
    }

    public static async Task<int> Main(string[] args)
    {
        Stopwatch sw = Stopwatch.StartNew();

        void PrintTiming(string label)
        {
            Console.WriteLine($"Step '{label}' finished in {sw.Elapsed.TotalSeconds} seconds");
            sw.Restart();
        }

        string mainZipFilePath = "J:/Programming/SweetHome3DExporter/SweetHomeToArrAsset/Data/userGuideExample.zip";
        if (args.Length >= 1)
        {
            mainZipFilePath = args[0];
        }

        if (string.IsNullOrEmpty(mainZipFilePath))
        {
            return (int)ErrorCodes.PathToMainZipEmpty;
        }

        string outputPath = Path.GetDirectoryName(mainZipFilePath) ?? "";

        if (string.IsNullOrEmpty(outputPath))
        {
            return (int)ErrorCodes.MainZipPathHasNoDirectory;
        }

        PrintTiming("Setup");

        // Unzip the main zip
        string mainZipExtractionPath = Path.Join(outputPath, DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss"), "mainZipExtracted");
        using (var mainZipFile = ZipFile.OpenRead(mainZipFilePath))
        {
            mainZipFile.ExtractToDirectory(mainZipExtractionPath);
        }

        PrintTiming("Unzip main zip");

        // Unzip the sub zip
        string subZipFilePath = string.Empty;
        foreach (string fileName in Directory.GetFiles(mainZipExtractionPath))
        {
            FileInfo fi = new(fileName);
            if (fi.Extension.Contains("zip"))
            {
                subZipFilePath = fileName;
            }
        }

        if (string.IsNullOrEmpty(subZipFilePath))
        {
            return (int)ErrorCodes.SubZipFileNotFound;
        }

        string subZipExtractionPath = Path.Join(mainZipExtractionPath, "subZipExtractionPath");
        using (var subZipFile = ZipFile.OpenRead(subZipFilePath))
        {
            subZipFile.ExtractToDirectory(subZipExtractionPath);
        }

        PrintTiming("Unzip sub zip");

        // Find xml descriptor file

        string xmlDescriptorFile = Directory.GetFiles(subZipExtractionPath, "*.xml", SearchOption.TopDirectoryOnly).FirstOrDefault();

        if (string.IsNullOrEmpty(xmlDescriptorFile))
        {
            return (int)ErrorCodes.XmlDescriptorFileNotFound;
        }

        string xmlContent = File.ReadAllText(xmlDescriptorFile);

        if (string.IsNullOrEmpty(xmlContent))
        {
            return (int)ErrorCodes.XmlDescriptorFileWasEmpty;
        }

        // Find all models in xml doc

        XmlSerializer serializer = new XmlSerializer(typeof(Home));
        Home? home;
        using (XmlReader reader = XmlReader.Create(xmlDescriptorFile))
        {
            home = (Home?)serializer.Deserialize(reader);
        }

        if (home == null)
        {
            return (int)ErrorCodes.HomeNodeNotFoundInXmlFile;
        }

        PrintTiming("Find all models");

        // Convert all models to fbx
        //      Python venv
        //      Python activate
        //      Python install deps

        BufferedCommandResult setupPythonResult = await CliWrap.Cli.Wrap("powershell.exe").WithArguments(["./setupPython.ps1"]).ExecuteBufferedAsync();

        if (!setupPythonResult.IsSuccess)
        {
            return (int)ErrorCodes.PythonSetupFailed;
        }

        Console.WriteLine("-------");
        Console.WriteLine("StdOut:");
        Console.WriteLine(setupPythonResult.StandardOutput);
        Console.WriteLine("StdErr:");
        Console.WriteLine(setupPythonResult.StandardError);
        Console.WriteLine("-------");

        PrintTiming("Setup python");

        List<Task<BufferedCommandResult>> tasks = new();
        CancellationTokenSource cts = new();

        List<IFbxConvertible> convertibleModels = [];

        foreach (PieceOfFurniture pieceOfFurniture in home.PieceOfFurniture)
        {
            convertibleModels.Add(pieceOfFurniture);
        }

        foreach (Light light in home.Light)
        {
            convertibleModels.Add(light);
        }

        foreach (DoorOrWindow doorOrWindow in home.DoorOrWindow)
        {
            convertibleModels.Add(doorOrWindow);
        }

        Dictionary<Task, IFbxConvertible> inputMap = [];

        foreach (IFbxConvertible convertible in convertibleModels)
        {
            Task<BufferedCommandResult> task = CliWrap.Cli.Wrap("powershell.exe").WithArguments(["./convert.ps1", Path.Combine(subZipExtractionPath, convertible.Model)]).ExecuteBufferedAsync(cts.Token);
            tasks.Add(task);
            inputMap.Add(task, convertible);
        }

        while (tasks.Count != 0)
        {
            Task<BufferedCommandResult> finishedTask = await Task.WhenAny(tasks);
            BufferedCommandResult fbxConversionResult = await finishedTask;

            if (!fbxConversionResult.IsSuccess)
            {
                cts.Cancel();
                await Task.WhenAny(Task.WhenAll(tasks), Task.Delay(TimeSpan.FromSeconds(2)));
                return (int)ErrorCodes.ConversionToFbxFailed;
            }

            Console.WriteLine("-------");
            Console.WriteLine("StdOut:");
            Console.WriteLine(fbxConversionResult.StandardOutput);
            Console.WriteLine("StdErr:");
            Console.WriteLine(fbxConversionResult.StandardError);
            Console.WriteLine("-------");

            tasks.Remove(finishedTask);

            inputMap[finishedTask].FbxModel = inputMap[finishedTask].Model.EndsWith(".obj") ? inputMap[finishedTask].Model.Replace(".obj", ".fbx") : inputMap[finishedTask].Model + ".fbx";
        }

        PrintTiming("Convert to fbx");

        // Convert all models to arrAsset
        // Local
        foreach (IFbxConvertible convertible in convertibleModels)
        {
            Console.WriteLine($"Invoke Impala on {convertible.FbxModel}");
        }

        PrintTiming("Convert to arrAsset");

        // (int)ErrorCodes.ConversionToArrAssetFailed;

        return 0;
    }
}
