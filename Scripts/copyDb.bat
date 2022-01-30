@echo off

echo Copying database
robocopy "..\MoonMissing.Data.Deploy\bin\Debug\net6.0" "..\MoonMissing\bin\Debug\net6.0-windows" "MoonMissing.db"
echo Done
pause
exit