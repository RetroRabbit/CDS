@echo off
echo user desktopbuild> %3
echo CDS0nl1n3>> %3
IF NOT [%1]==[] (
	echo cd %2>> %3
) 
echo bin>> %3
echo put %1>> %3
echo quit>> %3
REM ftp -n -s:%3 www.cdsonline.co.za
REM del %3