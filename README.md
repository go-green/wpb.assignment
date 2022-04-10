# wpb.assignment

## Instructions

1. Automation test project has been implemented using .NET Core 3.1, C# version 8.0 and nUnit unit testing framework.
2. Specflow nuget package was used to implement the scenarios in BDD style https://specflow.org/
3. Download and install Visual Studio 2022 (VS 2022) community edition. https://visualstudio.microsoft.com/vs/community/
4. Install visuals studio extension "Specflow for Visual Studio 2022". Open VS 2022 > Extenstion Menu > Manage Extensions > Search for "Specflow for Visual Studio 2022" > Download the extension. (You need to restart VS 2022  for the extension installation to be completed)
5. The chromedriver.exe included in the project is only compatible with Chrome Version 100.0.4896.75. If you have a newer version of the chrome browser, please upgrade the chromedriver.exe accordingly. https://chromedriver.chromium.org/downloads
7. Make sure chromedriver.exe is not being used by any other process during test execution. Use "taskkill -f -im chromedriver.exe" to kill if it's being used.

## Executing tests from Visual Studio 2022

1. Open VS 2022 build the solution
2. Select Tests > Windows > Test Explorer from the Visual studio menu
3. After successful compilation of the test solution, you should see tests in the Test Explorer panel.
4. Right-click and run all or selected tests

## Executing tests from the command line

1. Navigate to the test solution folder where you can find the *.sln file e.g. C:\Users\<USER>\source\repos\WpbCarsRating
2. Open command line and run "dotnet test WpbCarsRating.sln"

## Failing tests

NOTE: There are two tests failing and those failures are due to application bugs
1. When the Last Name field is left empty, the error message goes as "First Name is required"
2. Some car models Author details are not displayed in the comments list

## Improvements that I could have made

1. Web UI tests don't have a Logger implemented.
2. Can implement a HTML report generating capability after a test run to see the pass/fail status and stats
3. Screenshots can be captured before and after every step and embedded in the HTML report.
4. Use of IWebDriver in page objects and page components tightly couple the framework to selenium/webdriver. This can be eliminated by wrapping the IWebDriver to a framework-specific interface so that the framework will be independent of the underlying webdriver technology.
5. Tests can be configured to run in parallel
6. Tests can be configured to run on Docker
