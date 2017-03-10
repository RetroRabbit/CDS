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

$outputPathServer = $outputPath + "\updates"
$outputPathServerPublish = $outputPathServer + "\publish"
$outputFilePathServer = $outputPathServerPublish + "\files"
$outputFilePathServerWeb = $outputFilePathServer + "\bin"
$outputZipPublishServer = $outputPath +"\updates\publish\"+ $version + ".zip"
$outputZipServer = $outputPath +"\updates\publish\"+ $version + ".zip"

$outputPathClient = $outputPath + "\client" 
$outputZipClient = $outputFilePathServer + "\" + $version + ".zip"

#Create Temp location for files to Zip
if (!(Test-Path $outputFilePathServer)){
	New-Item -ItemType directory -Path $outputFilePathServer
}else {
	Remove-item $outputFilePathServer
}
New-Item -ItemType directory -Path $outputFilePathServerWeb

#Copy files to Temp location
Copy-Item "$drop\CDS.Update.Service\bin\Release\*.dll" $outputFilePathServer
Copy-Item "$drop\CDS.Update.Service\bin\Release\*.exe" $outputFilePathServer
Copy-Item "$drop\CDS.Web.DataService\bin\*.dll" $outputFilePathServerWeb
Copy-Item "$drop\CDS.Web.DataService\*.svc" $outputFilePathServer
Copy-Item "$drop\CDS.Client.Desktop\bin\Release\*.dll" $outputFilePathServer
Copy-Item "$drop\CDS.Client.Desktop\bin\Release\*.exe" $outputFilePathServer

#Create Zip file for Client Publish
[io.compression.zipfile]::CreateFromDirectory($outputPathClient, $outputZipClient) 
Write-Host "Created second zip file $outputZipClient"
Remove-item $outputPathClient -recurse 

#Create Zip file for Temp location 
[io.compression.zipfile]::CreateFromDirectory($outputFilePathServer, $outputZipServer) 

Remove-Item $outputFilePathServer -recurse 
 