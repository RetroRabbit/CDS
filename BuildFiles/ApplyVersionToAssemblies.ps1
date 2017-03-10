##-----------------------------------------------------------------------
## <copyright file="ApplyVersionToAssemblies.ps1">(c) http://TfsBuildExtensions.codeplex.com/. This source is subject to the Microsoft Permissive License. See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx. All other rights reserved.</copyright>
##-----------------------------------------------------------------------
# Look for a 0.0.0.0 pattern in the build number. 
# If found use it to version the assemblies.
#
# For example, if the 'Build number format' build process parameter 
# $(BuildDefinitionName)_$(Year:yyyy).$(Month).$(DayOfMonth)$(Rev:.r)
# then your build numbers come out like this:
# "Build HelloWorld_2013.07.19.1"
# This script would then apply version 2013.07.19.1 to your assemblies.
	 
# Disable parameter
# Convenience option so you can debug this script or disable it in 
# your build definition without having to remove it from
# the 'Post-build script path' build process parameter.
param([switch]$Disable)
if ($PSBoundParameters.ContainsKey('Disable'))
{
	Write-Host "Script disabled; no actions will be taken on the files."
}

function Get-ExtendedDate
{
	 $a = get-date
	  add-member -MemberType scriptmethod -name GetDayOfYear `
		 -value {get-date -uformat %V} -inputobject $a
	 $a
} 

# Regular expression pattern to find the version in the build number 
# and then apply it to the assemblies
$VersionRegex = "\d+\.\d+\.\d+\.\d+"

 $date = Get-Date
 $year		= Get-Date -format yy
 $month      = $date.Month
 $hours		= Get-Date -format HH
 $day		= $date.Day
 #$rev	    = $date.Day + $hours + $date.Minute
 
 $major			= 3 
 $minor			= $year
 $buildNumber	= (Get-Date).DayofYear #(Get-ExtendedDate).getDayOfYear()
 $revision		= ((Get-Date).Ticks -as [String]).SubString(6,4)
 #https://msdn.microsoft.com/Library/vs/alm/Build/scripts/variables
 #
 #if(-not $Env:BUILD -or $Env:BUILD -eq 'Local')
 #{
 #	$Env:BUILD = 'Local'
 #	$Env:BUILD_DEFINITIONNAME = 'Live_Release_local'
 #	$Env:BUILD_SOURCESDIRECTORY = 'C:\SolutionsOnline\repos\CDSolutions'
 #	$Env:BUILD_BUILDNUMBER = $Env:BUILD_DEFINITIONNAME + '_'+$major+'.'+$minor+'.'+$buildNumber+'.'+$revision
 #	$Env:BUILD_ARTIFACTSTAGINGDIRECTORY =  'C:\SolutionsOnline\repos\CDSolutions'
 #}
 #else
 #{
   $Env:BUILD_ARTIFACTSTAGINGDIRECTORY = 'C:\a\1\a\drop'
 #}
# If this script is not running on a build server, remind user to 
# set environment variables so that this script can be debugged
if(-not $Env:BUILD -and -not ($Env:BUILD_SOURCESDIRECTORY -and $Env:BUILD_BUILDNUMBER))
{
	Write-Error "You must set the following environment variables"
	Write-Error "to test this script interactively."
	Write-Host '$Env:BUILD_SOURCESDIRECTORY - For example, enter something like:'
	Write-Host '$Env:BUILD_SOURCESDIRECTORY = "C:\code\FabrikamTFVC\HelloWorld"'
	Write-Host '$Env:BUILD_BUILDNUMBER - For example, enter something like:'
	Write-Host '$Env:BUILD_BUILDNUMBER = "Build HelloWorld_0000.00.00.0"'
	exit 1
}
	
# Make sure path to source code directory is available
if (-not $Env:BUILD_SOURCESDIRECTORY)
{
	Write-Error ("BUILD_SOURCESDIRECTORY environment variable is missing.")
	exit 1
}
elseif (-not (Test-Path $Env:BUILD_SOURCESDIRECTORY))
{
	Write-Error "BUILD_SOURCESDIRECTORY does not exist: $Env:BUILD_SOURCESDIRECTORY"
	exit 1
}
Write-Host "BUILD_SOURCESDIRECTORY: $Env:BUILD_SOURCESDIRECTORY"

# Make sure there is a build number
if (-not $Env:BUILD_BUILDNUMBER)
{
	Write-Error ("BUILD_BUILDNUMBER environment variable is missing.")
	exit 1
}
Write-Host "BUILD_BUILDNUMBER: $Env:BUILD_BUILDNUMBER"
	
# Get and validate the version data
$VersionData = [regex]::matches($Env:BUILD_BUILDNUMBER,$VersionRegex)
switch($VersionData.Count)
{
   0		
      { 
         Write-Error "Could not find version number data in BUILD_BUILDNUMBER."
         exit 1
      }
   1 {}
   default 
      { 
         Write-Warning "Found more than instance of version data in BUILD_BUILDNUMBER." 
         Write-Warning "Will assume first instance is version."
      }
}
$NewVersion = $VersionData[0]
Write-Host "Version: $NewVersion"
	
# Apply the version to the assembly property files
$files = gci $Env:BUILD_SOURCESDIRECTORY -recurse -include "*Properties*","CDSDesktop" | 
	?{ $_.PSIsContainer } | 
	foreach { gci -Path $_.FullName -Recurse -include AssemblyInfo.* }
if($files)
{
	Write-Host "Will apply $NewVersion to $($files.count) files."
	
	foreach ($file in $files) {
			
			
		if(-not $Disable)
		{
			$filecontent = Get-Content($file)
			attrib $file -r
			$filecontent -replace $VersionRegex, $NewVersion | Out-File $file
			Write-Host $file.FullName" - version applied"
		}
	}
}
else
{
	Write-Warning "Found no files."
} 

if($Env:BUILD -eq 'Local')
{
	$drop = $Env:BUILD_ARTIFACTSTAGINGDIRECTORY+'\CDSDesktop'
	$version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo("$drop\CDS.Client.Desktop\bin\Release\CDS.Client.Desktop.exe").FileVersion
	$outputPath = "$drop\$version" 
	
	If(Test-Path $outputPath ) {
		Remove-item $outputPath -recurse
	}
	
	Write-Host "Building Solution"
	cmd /c 'C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\devenv.exe' C:\SolutionsOnline\repos\CDSolutions\CDSDesktop\CDSDesktop.sln /build Release
}