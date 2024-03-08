using System.Xml.Serialization;

namespace SweetHomeToArrAsset
{// using System.Xml.Serialization;
 // XmlSerializer serializer = new XmlSerializer(typeof(Home));
 // using (StringReader reader = new StringReader(xml))
 // {
 //    var test = (Home)serializer.Deserialize(reader);
 // }

    public interface IFbxConvertible
    {
        public string Model { get; set; }

        public string FbxModel { get; set; }
    }

    [XmlRoot(ElementName = "observerCamera")]
    public class ObserverCamera
    {

        [XmlAttribute(AttributeName = "attribute")]
        public string Attribute { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "lens")]
        public string Lens { get; set; }

        [XmlAttribute(AttributeName = "x")]
        public double X { get; set; }

        [XmlAttribute(AttributeName = "y")]
        public double Y { get; set; }

        [XmlAttribute(AttributeName = "z")]
        public double Z { get; set; }

        [XmlAttribute(AttributeName = "yaw")]
        public double Yaw { get; set; }

        [XmlAttribute(AttributeName = "pitch")]
        public double Pitch { get; set; }

        [XmlAttribute(AttributeName = "fieldOfView")]
        public double FieldOfView { get; set; }

        [XmlAttribute(AttributeName = "time")]
        public double Time { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "texture")]
    public class Texture
    {

        [XmlAttribute(AttributeName = "attribute")]
        public string Attribute { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "width")]
        public double Width { get; set; }

        [XmlAttribute(AttributeName = "height")]
        public double Height { get; set; }

        [XmlAttribute(AttributeName = "leftToRightOriented")]
        public bool LeftToRightOriented { get; set; }

        [XmlAttribute(AttributeName = "image")]
        public int Image { get; set; }
    }

    [XmlRoot(ElementName = "environment")]
    public class Environment
    {

        [XmlElement(ElementName = "observerCamera")]
        public List<ObserverCamera> ObserverCamera { get; set; }

        [XmlElement(ElementName = "texture")]
        public Texture Texture { get; set; }

        [XmlAttribute(AttributeName = "groundColor")]
        public string GroundColor { get; set; }

        [XmlAttribute(AttributeName = "skyColor")]
        public string SkyColor { get; set; }

        [XmlAttribute(AttributeName = "lightColor")]
        public string LightColor { get; set; }

        [XmlAttribute(AttributeName = "observerCameraElevationAdjusted")]
        public bool ObserverCameraElevationAdjusted { get; set; }
    }

    [XmlRoot(ElementName = "camera")]
    public class Camera
    {

        [XmlAttribute(AttributeName = "attribute")]
        public string Attribute { get; set; }

        [XmlAttribute(AttributeName = "lens")]
        public string Lens { get; set; }

        [XmlAttribute(AttributeName = "x")]
        public double X { get; set; }

        [XmlAttribute(AttributeName = "y")]
        public double Y { get; set; }

        [XmlAttribute(AttributeName = "z")]
        public double Z { get; set; }

        [XmlAttribute(AttributeName = "yaw")]
        public double Yaw { get; set; }

        [XmlAttribute(AttributeName = "pitch")]
        public double Pitch { get; set; }

        [XmlAttribute(AttributeName = "fieldOfView")]
        public double FieldOfView { get; set; }

        [XmlAttribute(AttributeName = "time")]
        public double Time { get; set; }
    }

    [XmlRoot(ElementName = "pieceOfFurniture")]
    public class PieceOfFurniture : IFbxConvertible
    {

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "model")]
        public string Model { get; set; }

        public string FbxModel { get; set; }

        [XmlAttribute(AttributeName = "x")]
        public double X { get; set; }

        [XmlAttribute(AttributeName = "y")]
        public double Y { get; set; }

        [XmlAttribute(AttributeName = "angle")]
        public double Angle { get; set; }

        [XmlAttribute(AttributeName = "width")]
        public double Width { get; set; }

        [XmlAttribute(AttributeName = "depth")]
        public double Depth { get; set; }

        [XmlAttribute(AttributeName = "height")]
        public double Height { get; set; }

        [XmlAttribute(AttributeName = "modelSize")]
        public int ModelSize { get; set; }

        [XmlAttribute(AttributeName = "movable")]
        public bool Movable { get; set; }

        [XmlAttribute(AttributeName = "elevation")]
        public double Elevation { get; set; }

        [XmlAttribute(AttributeName = "color")]
        public string Color { get; set; }

        [XmlAttribute(AttributeName = "modelMirrored")]
        public bool ModelMirrored { get; set; }

        [XmlAttribute(AttributeName = "shininess")]
        public double Shininess { get; set; }

        [XmlAttribute(AttributeName = "modelRotation")]
        public string ModelRotation { get; set; }

        [XmlAttribute(AttributeName = "modelCenteredAtOrigin")]
        public bool ModelCenteredAtOrigin { get; set; }

        [XmlAttribute(AttributeName = "catalogId")]
        public string CatalogId { get; set; }
    }

    [XmlRoot(ElementName = "doorOrWindow")]
    public class DoorOrWindow : IFbxConvertible
    {

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "model")]
        public string Model { get; set; }

        public string FbxModel { get; set; }

        [XmlAttribute(AttributeName = "x")]
        public double X { get; set; }

        [XmlAttribute(AttributeName = "y")]
        public double Y { get; set; }

        [XmlAttribute(AttributeName = "elevation")]
        public double Elevation { get; set; }

        [XmlAttribute(AttributeName = "angle")]
        public double Angle { get; set; }

        [XmlAttribute(AttributeName = "width")]
        public double Width { get; set; }

        [XmlAttribute(AttributeName = "depth")]
        public double Depth { get; set; }

        [XmlAttribute(AttributeName = "height")]
        public double Height { get; set; }

        [XmlAttribute(AttributeName = "modelSize")]
        public int ModelSize { get; set; }

        [XmlAttribute(AttributeName = "movable")]
        public bool Movable { get; set; }

        [XmlAttribute(AttributeName = "cutOutShape")]
        public string CutOutShape { get; set; }

        [XmlAttribute(AttributeName = "modelMirrored")]
        public bool ModelMirrored { get; set; }

        [XmlAttribute(AttributeName = "catalogId")]
        public string CatalogId { get; set; }

        [XmlAttribute(AttributeName = "color")]
        public string Color { get; set; }
    }

    [XmlRoot(ElementName = "light")]
    public class Light : IFbxConvertible
    {

        [XmlAttribute(AttributeName = "catalogId")]
        public string CatalogId { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "model")]
        public string Model { get; set; }

        public string FbxModel { get; set; }

        [XmlAttribute(AttributeName = "x")]
        public double X { get; set; }

        [XmlAttribute(AttributeName = "y")]
        public double Y { get; set; }

        [XmlAttribute(AttributeName = "elevation")]
        public double Elevation { get; set; }

        [XmlAttribute(AttributeName = "width")]
        public double Width { get; set; }

        [XmlAttribute(AttributeName = "depth")]
        public double Depth { get; set; }

        [XmlAttribute(AttributeName = "height")]
        public double Height { get; set; }

        [XmlAttribute(AttributeName = "modelSize")]
        public int ModelSize { get; set; }

        [XmlAttribute(AttributeName = "movable")]
        public bool Movable { get; set; }

        [XmlAttribute(AttributeName = "angle")]
        public double Angle { get; set; }

        [XmlAttribute(AttributeName = "deformable")]
        public bool Deformable { get; set; }

        [XmlAttribute(AttributeName = "texturable")]
        public bool Texturable { get; set; }
    }

    [XmlRoot(ElementName = "wall")]
    public class Wall
    {

        [XmlElement(ElementName = "texture")]
        public Texture Texture { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "wallAtStart")]
        public string WallAtStart { get; set; }

        [XmlAttribute(AttributeName = "wallAtEnd")]
        public string WallAtEnd { get; set; }

        [XmlAttribute(AttributeName = "xStart")]
        public double XStart { get; set; }

        [XmlAttribute(AttributeName = "yStart")]
        public double YStart { get; set; }

        [XmlAttribute(AttributeName = "xEnd")]
        public double XEnd { get; set; }

        [XmlAttribute(AttributeName = "yEnd")]
        public double YEnd { get; set; }

        [XmlAttribute(AttributeName = "height")]
        public double Height { get; set; }

        [XmlAttribute(AttributeName = "thickness")]
        public double Thickness { get; set; }

        [XmlAttribute(AttributeName = "rightSideColor")]
        public string RightSideColor { get; set; }

        [XmlAttribute(AttributeName = "leftSideColor")]
        public string LeftSideColor { get; set; }
    }

    [XmlRoot(ElementName = "point")]
    public class Point
    {

        [XmlAttribute(AttributeName = "x")]
        public double X { get; set; }

        [XmlAttribute(AttributeName = "y")]
        public double Y { get; set; }
    }

    [XmlRoot(ElementName = "room")]
    public class Room
    {

        [XmlElement(ElementName = "point")]
        public List<Point> Point { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "nameXOffset")]
        public double NameXOffset { get; set; }

        [XmlAttribute(AttributeName = "nameYOffset")]
        public double NameYOffset { get; set; }

        [XmlAttribute(AttributeName = "areaVisible")]
        public bool AreaVisible { get; set; }

        [XmlAttribute(AttributeName = "areaXOffset")]
        public double AreaXOffset { get; set; }

        [XmlAttribute(AttributeName = "areaYOffset")]
        public double AreaYOffset { get; set; }

        [XmlAttribute(AttributeName = "floorColor")]
        public string FloorColor { get; set; }

        [XmlAttribute(AttributeName = "ceilingColor")]
        public string CeilingColor { get; set; }

        [XmlElement(ElementName = "texture")]
        public Texture Texture { get; set; }
    }

    [XmlRoot(ElementName = "home")]
    public class Home
    {

        [XmlElement(ElementName = "environment")]
        public Environment Environment { get; set; }

        [XmlElement(ElementName = "observerCamera")]
        public List<ObserverCamera> ObserverCamera { get; set; }

        [XmlElement(ElementName = "camera")]
        public List<Camera> Camera { get; set; }

        [XmlElement(ElementName = "pieceOfFurniture")]
        public List<PieceOfFurniture> PieceOfFurniture { get; set; }

        [XmlElement(ElementName = "doorOrWindow")]
        public List<DoorOrWindow> DoorOrWindow { get; set; }

        [XmlElement(ElementName = "light")]
        public List<Light> Light { get; set; }

        [XmlElement(ElementName = "wall")]
        public List<Wall> Wall { get; set; }

        [XmlElement(ElementName = "room")]
        public List<Room> Room { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }

        [XmlAttribute(AttributeName = "exportFlags")]
        public int ExportFlags { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "wallHeight")]
        public double WallHeight { get; set; }
    }


}
