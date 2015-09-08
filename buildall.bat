@echo off
if not exist "Build" mkdir "Build"
set unity="C:\Program Files\Unity\Editor\Unity.exe"
echo Located unity at %unity%
echo Building...
%unity% -batchmode -nographics -logFile Build/buildlog.txt -buildWindowsPlayer Build/Win32/ADarkDawn.exe -buildWindows64Player Build/Win64/ADarkDawn.exe -buildLinuxUniversalPlayer Build/Linux/ADarkDawn -buildOSX64Player Build/MacOSX/ADarkDawn.app -quit