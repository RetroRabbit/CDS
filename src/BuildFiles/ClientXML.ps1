if($Env:BUILD -eq 'Local')
{
	$drop = $Env:BUILD_ARTIFACTSTAGINGDIRECTORY+'\CDSDesktop'
}
else
{
	Write-Host 'NOT BE HERE'
	$drop = "C:\a\1\a\drop"
}

$version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo("$drop\CDS.Client.Desktop\bin\Release\CDS.Client.Desktop.exe").FileVersion
$timestamp = Get-Date
$releaseNotes = "Release notes should come from somewhere"
$outputPath = "$drop\$version" 
$outputZipClient = $outputPath +"\client\publish\"+ $version + ".zip"
 
[System.XML.XMLDocument]$oXMLDocument=New-Object System.XML.XMLDocument

[System.XML.XMLElement]$oXMLRoot=$oXMLDocument.CreateElement("applicationUpdate")
$oXMLDocument.appendChild($oXMLRoot)

[System.XML.XMLElement]$oXMLUpdate=$oXMLRoot.appendChild($oXMLDocument.CreateElement("update"))

[System.XML.XMLElement]$oXMLVersion=$oXMLUpdate.appendChild($oXMLDocument.CreateElement("version"))
[System.XML.XMLElement]$oXMLReleaseNotes=$oXMLUpdate.appendChild($oXMLDocument.CreateElement("releaseNotes"))
[System.XML.XMLElement]$oXMLReleaseNotesDate=$oXMLReleaseNotes.appendChild($oXMLDocument.CreateElement("date"))
[System.XML.XMLElement]$oXMLReleaseNotesNote=$oXMLReleaseNotes.appendChild($oXMLDocument.CreateElement("note"))
[System.XML.XMLElement]$oXMLUpdateLaunchArgs=$oXMLUpdate.appendChild($oXMLDocument.CreateElement("launchArgs"))
[System.XML.XMLElement]$oXMLUpdateMd5=$oXMLUpdate.appendChild($oXMLDocument.CreateElement("md5"))

$oXMLVersion.InnerText = $version
$oXMLReleaseNotesDate.InnerText = $timestamp.ToString("yyyy/MM/dd HH:mm")
$oXMLReleaseNotesNote.InnerText = $releaseNotes
$oXMLUpdateMd5.InnerText =  (Get-FileHash $outputZipClient -Algorithm MD5).Hash

#Client Service Update Section
[System.XML.XMLElement]$oXMLApplicationDesktop=$oXMLUpdate.appendChild($oXMLDocument.CreateElement("application"))
$oXMLApplicationDesktop.SetAttribute("appID","CDS Update Service")
[System.XML.XMLElement]$oXMLApplicationDesktopType=$oXMLApplicationDesktop.appendChild($oXMLDocument.CreateElement("type"))
$oXMLApplicationDesktopType.InnerText = "Service"
[System.XML.XMLElement]$oXMLApplicationDesktopFiles=$oXMLApplicationDesktop.appendChild($oXMLDocument.CreateElement("files"))

$destination = ""
$files = Get-ChildItem "$drop\CDS.Update.Service\bin\Release\*" -Include *.exe,*.dll
foreach($file in $files){
    $content = $file.Name
	$path = $file.FullName
	
	$hash = Get-FileHash $path -Algorithm MD5
	
	[System.XML.XMLElement]$oXMLApplicationDesktopFile=$oXMLApplicationDesktopFiles.appendChild($oXMLDocument.CreateElement("file"))
	[System.XML.XMLElement]$oXMLApplicationDesktopFileName=$oXMLApplicationDesktopFile.appendChild($oXMLDocument.CreateElement("name"))
	[System.XML.XMLElement]$oXMLApplicationDesktopFileDestination=$oXMLApplicationDesktopFile.appendChild($oXMLDocument.CreateElement("destination"))
	[System.XML.XMLElement]$oXMLApplicationDesktopFileMd5=$oXMLApplicationDesktopFile.appendChild($oXMLDocument.CreateElement("md5"))
	$oXMLApplicationDesktopFileName.InnerText = $content
	$oXMLApplicationDesktopFileDestination.InnerText = $destination
	$oXMLApplicationDesktopFileMd5.InnerText = $hash.Hash
}

#Client Desktop Update Section
[System.XML.XMLElement]$oXMLApplicationDesktop=$oXMLUpdate.appendChild($oXMLDocument.CreateElement("application"))
$oXMLApplicationDesktop.SetAttribute("appID","CDS Client Desktop")
[System.XML.XMLElement]$oXMLApplicationDesktopType=$oXMLApplicationDesktop.appendChild($oXMLDocument.CreateElement("type"))
$oXMLApplicationDesktopType.InnerText = "Desktop"
[System.XML.XMLElement]$oXMLApplicationDesktopFiles=$oXMLApplicationDesktop.appendChild($oXMLDocument.CreateElement("files"))

$destination = "..\..\Desktop\Client\Enterprise\"
$files = Get-ChildItem "$drop\CDS.Client.Desktop\bin\Release\*" -Include *.exe,*.dll
foreach($file in $files){
    $content = $file.Name
	$path = $file.FullName
	
	$hash = Get-FileHash $path -Algorithm MD5
	
	[System.XML.XMLElement]$oXMLApplicationDesktopFile=$oXMLApplicationDesktopFiles.appendChild($oXMLDocument.CreateElement("file"))
	[System.XML.XMLElement]$oXMLApplicationDesktopFileName=$oXMLApplicationDesktopFile.appendChild($oXMLDocument.CreateElement("name"))
	[System.XML.XMLElement]$oXMLApplicationDesktopFileDestination=$oXMLApplicationDesktopFile.appendChild($oXMLDocument.CreateElement("destination"))
	[System.XML.XMLElement]$oXMLApplicationDesktopFileMd5=$oXMLApplicationDesktopFile.appendChild($oXMLDocument.CreateElement("md5"))
	$oXMLApplicationDesktopFileName.InnerText = $content
	$oXMLApplicationDesktopFileDestination.InnerText = $destination
	$oXMLApplicationDesktopFileMd5.InnerText = $hash.Hash
}
if (!(Test-Path "$drop\$version\client\publish")){
	New-Item -ItemType directory -Path "$drop\$version\client\publish"
}
# Save File
$oXMLDocument.Save("$drop\$version\client\publish.xml")
Write-Host "Created server XML file $drop\$version\client\publish.xml"
