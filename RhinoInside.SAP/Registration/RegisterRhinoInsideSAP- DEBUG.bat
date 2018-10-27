@echo off
setlocal ENABLEDELAYEDEXPANSION
echo.
echo   Install stuff remotely
echo.
echo   Note:  Machines that are unplugged, not connected to the network,
echo          or on a different subnet will not play ball
echo          When run as administrator from a remote machine
echo.
:RETRY


SET regasmpath="C:\Windows\Microsoft.NET\Framework\v4.0.30319"
SET dllpath="C:\Users\EErtugrul\Documents\GitHub\RhinoInsideSAP\RhinoInside.SAP\RhinoInside.SAP.Sphere\bin\Debug"
%regasmpath%\regasm /codebase /tlb /verbose %dllpath%\RhinoInside.SAP.Sphere.dll


:END
endlocal
PAUSE