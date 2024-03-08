param(
	[String]$InputObjFile
)

. ./utils.ps1

ActivateVenv

$input = $InputObjFile
$output = if ($InputObjFile.EndsWith(".obj")) { $InputObjFile -replace ".obj", ".fbx" } else { "${InputObjFile}.fbx" }
Write-Host "Converting '$input' to '$output'"
python .\blenderConvert.py -- $input $output