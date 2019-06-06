#we specify the directory where all files that we want to upload  
if($Env:BUILD -eq 'Local')
{
	$drop = $Env:BUILD_ARTIFACTSTAGINGDIRECTORY+'\CDSDesktop'
	$buildFiles = $Env:BUILD_ARTIFACTSTAGINGDIRECTORY+'\BuildFiles'
}
else
{
	$drop = "C:\a\1\a\drop"
	$buildFiles = 'C:\a\1\s\BuildFiles'
}
$version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo("$drop\CDS.Client.Desktop\bin\Release\CDS.Client.Desktop.exe").FileVersion
$dir = "$drop\$version"

# Config
$username = "desktopbuild"
$password = "CDS0nl1n3"
$ftpURL = "ftp://www.cdsonline.co.za/"
 
$files = Get-ChildItem $dir"\updates\*" -Include *.xml
foreach($file in $files){
	$fileName = $file.Name
	$path = $file.FullName
	
	#cmd.exe /c "$buildFiles\FTPdatStructure.bat $path . $buildFiles\PublishXMLBatch.dat"
    cmd.exe /c "$buildFiles\CDS.Util.Upload.exe -up $path www.cdsonline.co.za $username $password"
	 
 }

$ftpURL = $ftpURL+"publish/"
 
$files = Get-ChildItem $dir"\updates\publish\*" -Include *.zip
foreach($file in $files){
	$fileName = $file.Name
	$path = $file.FullName
	
    #cmd.exe /c "$buildFiles\FTPdatStructure.bat $path \publish $buildFiles\PublishXMLZIP.dat"
	cmd.exe /c "$buildFiles\CDS.Util.Upload.exe -up $path www.cdsonline.co.za/publish $username $password"
 }