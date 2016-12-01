# Welcome to my solution for the Sales Tax Problem

## Overview

This project is witten in **C#** and it has been created in a **Windows** operating system using **Visual Studio 2017**.
The solution provided is composed by three projects:

1. **SalestaxProblem**: This is the core dll which contains all the logic
2. **SalesTaxProblem.Console**: This is a simple console app that can be run in order to see in Console the output provided by the core dll
3. **SalesTaxProblem.Tests**: This is the test dll in which there are the tests used to verify the validity of the solution

The input I choose to implement for this solution is a list of Product that the SalesTaxProblem dll needs to receive in input.
Here it is an exemple of what this dll expect as input for the elaboration:

>  inputList.Add(new Product(1, "Book", 12.49, ProductType.Books, Origin.Local));


Output of the elaboration is a string that contains, divided into different lines, the whole receipt in the form of

* PRODUCTS
* TAXES AMOUNT
* TOTAL AMOUNT

## How To

This project has been written in **Visual Studio 2017**. 
A version of it has to be installed in order to check and modify the code.
If you want to clean and rebuild (or change it) VS2017 is needed. An alternative is to use [msbuild.exe](https://msdn.microsoft.com/it-it/library/dd393574.aspx)

### Clean and compile 

#### With Visual Studio

1. Click on the Solution I(Source tree right click on Solution'SalesTaxProblem')
2. Click on `Clean Solution`
3. Click on `Rebuild Solution`

#### Without Visual Studio

1. You have to install **Microsoft .NET Framework 4.5.2** [Download here](https://www.microsoft.com/en-US/download/details.aspx?id=42643)
2. You have to install **Microsoft Build Tools 2015** [Download here](https://www.microsoft.com/en-US/download/confirmation.aspx?id=48159)
3. Locate the folder in wich the .NET Framework is present and check for `MSBuild.exe` (I can find it in C:\Program Files (x86)\MSBuild\14.0\Bin). If you have problem locating this program have a look [here](https://social.msdn.microsoft.com/Forums/windowsapps/en-US/23a7dc5d-c337-4eed-8af4-c016def5516e/location-of-msbuildexe?forum=msbuild)
4. Clean the project

	* From the folder where you found MsBuild.exe open a cmd and run the following command: `MSBuild.exe "{FOLDER}\SalesTaxProblem.sln" /t:Clean`
	* From the same command line run the following command `MSBuild.exe "{FOLDER}\SalesTaxProblem.sln" /t:rebuild`

You now have cleaned and rebuilded the solution

### Run the console app 

The console app shows just the output for each input requested by the exercise.

If you want to change the input and test the result you can:

1. Update the source code using Visual Studio for the console App
2. Update with an editor a test that is present in `SalestaxProblemTests` with your new entry 
	* clean and rebuild the solution
	* use the script described in section **Run test** for check purposes

#### With Visual Studio

1. Open the file named `Program.cs` in project `SalesTaxProblem.ConsoleApp`
2. Click F5. 

#### Without Visual Studio

1. From File System go to `{FOLDERNAME}\SalesTaxProblem.Console\bin\Debug`
2. We have to way to start console app:

	* double click on `SalesTaxProblem.Console.exe`
	* open a cmd from this folder and execute `SalesTaxProblem.Console.exe`

A command line is opened and the output is show for the three kind of input provided

### Run tests

Every test inside the project named SalestaxProblem.Text contains some comments which describes what is going on.
In every test method you can find the following comment:

* `// Arrange` which tells us that the code below is just for set up the environment
* `// Act` which tells us that the code below execute the operation we want to test
* `// Assert` wich defines everything we have to checkl after the execution.

If you want to add tests of modify the existing one, keep in mind this divions (and copy from the samples!).

#### With Visual Studio

1. Go to the project named `SalesTaxProblem.Tests`
2. Point the test project and right click on it.
3. Select on the contextual menu `Run Unit Tests`. A VS windows should appear and the result for each test will be presented.

####Without Visual Studio

1. This operation can be achieved through the cmd script that you can find at the root level named `run_tests.cmd`
	* First way - Double click on it in order to run it (a console should pop out and some output code shoudl be shown). Note that in this way the cmd will be opened and closed as soon as the operation is completed
	* Second way - Open a command line inside the root folder and execute `run_tests.cmd`


Hope you enjoy my soultion. Thank you for your attention!

Carlo Menapace





