# Welcome to the Sales Tax Project


## Overview
This project has been created in a Windows operating system using Visual Studio 2017.
The solution provided is composed by three projects:
1. SalestaxProblem: This is the core dll which contains all the logic
2. SalesTaxProblem.Console: This is a simple console app that can be run in order to see in Console the output provided by the core dll
3. SalesTaxProblem.Tests: This is the test dll in which there are the tests used to verify the validity of the solution

## How To
This project has been written in Visual Studio 2017. 
A version of it has to be installed in order to check and modify the code.
If you want to clean and rebuild (or change it) VS2017 is needed. An alternative is to use [msbuild.exe](https://msdn.microsoft.com/it-it/library/dd393574.aspx)

### Run the console app without Visual Studio
**Windows is needed**
1. From File System go to `{FOLDERNAME}\SalesTaxProblem.Console\bin\Debug`
2. double click on `SalesTaxProblem.Console.exe`

A command line is opened and the output is show for the three kind of input provided

#### Clean and compile solution without Visual Studio
1. You have to install **Microsoft .NET Framework 4.5.2**
2. Locate the folder in wich the .NET Framework is present and check for `MSBuild.exe` (I can find it in C:\Program Files (x86)\MSBuild\14.0\Bin). If you have problem locating this program have a look [here](https://social.msdn.microsoft.com/Forums/windowsapps/en-US/23a7dc5d-c337-4eed-8af4-c016def5516e/location-of-msbuildexe?forum=msbuild)
3. Clean the project
	* From the folder where you found MsBuild.exe open a cmd and run the following command: `MSBuild.exe "{FOLDER}\SalesTaxProblem.sln" /t:Clean
	* From the same command line run the following command `MSBuild.exe "{FOLDER}\SalesTaxProblem.sln" /t:rebuild
	You now have cleaned and rebuilded the solution


### Run tests
**From Visual Studio**
1. Go to the project named `SalesTaxProblem.Tests`
2. Open the file named `SalesTaxProblemTests.cs`
3. Right click on it an select on the contextual menu `Run Tests`. A VS windows should appear and three green light should be shown.

**Without Visual Studio**
1. This operation can be achieved through the cmd script that you can find at the root level named `run_tests.cmd`
	*  First way - Double click on it in order to run it (a console should pop out and some output code shoudl be shown)
	* Second way - Open a command line inside the root folder and execute `run_tests.cmd`


Hope you enjoy my soultion. Thank you for your attention!

Carlo Menapace





