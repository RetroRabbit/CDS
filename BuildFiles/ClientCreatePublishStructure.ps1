Add-Type -assembly "system.io.compression.filesystem"

if($Env:BUILD -eq 'Local')
{
	$drop = $Env:BUILD_ARTIFACTSTAGINGDIRECTORY+'\CDSDesktop'
}
else
{
	$drop = "C:\a\1\a\drop"
}
$version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo("$drop\CDS.Client.Desktop\bin\Release\CDS.Client.Desktop.exe").FileVersion
$outputPath = "$drop\$version"

$outputPathClient = $outputPath + "\client"
$outputPathClientPublish = $outputPathClient + "\publish"
$outputFilePathClient = $outputPathClientPublish + "\files"
$outputZipPublishClient = $outputPath +"\client\publish\"+ $version + ".zip"
$outputZipClient = $outputPath +"\updates\publish\files\"+ $version + ".zip"

#Create Temp location for files to Zip
if (!(Test-Path $outputFilePathClient)){
	Write-Host "Created directory $outputFilePathClient"
	New-Item -ItemType directory -Path $outputFilePathClient
} else {
	Remove-item $outputFilePathClient
} 

#Copy files to Temp location
Copy-Item "$drop\CDS.Client.Desktop\bin\Release\*.dll" $outputFilePathClient
Copy-Item "$drop\CDS.Client.Desktop\bin\Release\*.exe" $outputFilePathClient
Copy-Item "$drop\CDS.Update.Service\bin\Release\*.dll" $outputFilePathClient
Copy-Item "$drop\CDS.Update.Service\bin\Release\*.exe" $outputFilePathClient

#Create Zip file for Temp location 
[io.compression.zipfile]::CreateFromDirectory($outputFilePathClient, $outputZipPublishClient) 
Write-Host "Created first zip file $outputZipPublishClient"
Remove-item $outputFilePathClient -recurse 
 


