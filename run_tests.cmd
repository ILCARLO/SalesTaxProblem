echo off
packages\xunit.runner.console.2.1.0\tools\xunit.console SalesTaxProblem.Tests\bin\Debug\SalesTaxProblem.Tests.dll -parallel all -noshadow -verbose
IF %ERRORLEVEL% EQU 0 GOTO no_error
pause
:no_error