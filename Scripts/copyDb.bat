@echo off

:: Copies the database file from the bin of the deoplyment project to the wpf project.
:: This is only done for Debug since all Release builds will be manually composed.

echo Copying database
robocopy "..\MoonMissing.Data.Deploy\bin\Debug\net6.0" "..\MoonMissing\bin\Debug\net6.0-windows" "MoonMissing.db"
echo Done
pause
exit