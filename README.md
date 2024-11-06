# C# Selenium Automation Project

This is a C# project that uses [Selenium WebDriver](https://www.selenium.dev/documentation/en/webdriver/) to automate web browser interactions for testing and scraping purposes. The project includes various examples of browser automation such as logging in, filling out forms, and performing basic validations.

## Table of Contents

- [Project Overview](#project-overview)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Running the Tests](#running-the-tests)
- [Project Structure](#project-structure)
- [Common Issues](#common-issues)
- [License](#license)

## Project Overview

This project outlines the basic framework to verify the ENSEK sample website as well as all the documentation on the Test Strategy and the Bug Report found for the test that was done from the Report outlined in the Report folder. Please check the `documents` folder to see the Test Strategy and Bug Report and the `Reports` and `Screenshots` folders to see the test that was run, the results of that and the screenshots taken.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8 or later)
- [Selenium WebDriver](https://www.selenium.dev/documentation/en/webdriver/) for C# (installed via NuGet)
- A browser driver (e.g., ChromeDriver, GeckoDriver) corresponding to the browser you wish to automate

## Installing Dependencies

You can install the required NuGet packages using the .NET CLI:

```bash
dotnet add package Microsoft.Extensions.Configuration 8.0.0
dotnet add package Microsoft.Extensions.Configuration.Json 8.0.0
dotnet add package Microsoft.NET.Test.Sdk 17.11.1
dotnet add package ExtentReports 5.0.4
dotnet add package Selenium.WebDriver 4.26.1
dotnet add package Selenium.Support 4.26.1
dotnet add package Selenium.WebDriver.ChromeDriver 130.0.6723.9300 # For Chrome, or install other drivers as needed
dotnet add package NUnit 4.2.2 # Optional, for testing framework
dotnet add package NUnit3TestAdapter 4.6.0 # Optional, for testing framework
```

Alternatively, you can use the Visual Studio NuGet Package Manager to install these dependencies.

## Getting Started

Follow these steps to set up the project locally:

Clone this repository:

```bash
git clone https://github.com/Sam-Levene/ensek_coding_challenge.git
cd ensek_coding_challenge
```

Restore the .NET project dependencies:

```bash
dotnet restore
```
Open the project in your IDE (Visual Studio, VS Code, etc.).

Ensure that the appropriate browser driver (e.g., ChromeDriver or GeckoDriver) is installed and available in your system’s PATH or specify the driver location in your code.

## Running the Tests

To run the tests, you can use the .NET CLI:

Build the project:

```bash
dotnet build
```

Run the tests using NUnit (if you're using NUnit for testing):

```bash
dotnet test
```

Or if you're not using a testing framework, you can execute the main automation script directly by running:

```bash
dotnet run
```

You should see the browser launch in headless mode and perform the automated actions specified in the test scripts.

## Project Structure

Here's a basic overview of the project directory structure:

```bash
/ensek_coding_challenge
│
├── /AppConfig              # Configuration for the app site.
│   └── Config.cs
│
├── /Base                   # Default Base Class for the tests to inherit from
│   └── BaseTests.cs
│
├── /Pages                  # Page Object Models for Selenium (optional)
│   └── RegisterPage.cs
│
├── /Tests                  # Test scripts (if using NUnit or other testing frameworks)
│   └── RegistrationTests.cs
│
├── /Utilities              # Helper classes and methods, including the instructions for the Browser and the WebDriver.
│   ├── DriverHelper.cs
│   ├── HelperFunctions.cs
│   └── ExtentReportManager.cs
│
├── .gitignore
├── ensek_coding_challenge.csproj
├── ensek_coding_challenge.sln
├── appsettings.json
└── README.md
```
AppConfig: Contains configurations for the app site to be used
Base: Contains defualt and base class items for the other pages to inherit from
Pages: Contains the Page Object Model classes for abstracting and organizing web elements.
Tests: Contains NUnit test classes (or other testing frameworks).
Utilities: Helper classes for managing the WebDriver or other utility functions.

## Common Issues

Driver Version Mismatch: Ensure that the browser driver version matches the browser version you're automating. You can download the correct driver from ChromeDriver for Chrome, GeckoDriver for Firefox, or other drivers for different browsers.

Driver Not Found: Ensure the browser driver (e.g., chromedriver.exe) is available in your system PATH, or specify the path to the driver explicitly in your code.

## License

This project is licensed under the MIT License - see the LICENSE file for details.