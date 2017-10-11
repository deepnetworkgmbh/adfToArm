Azure Data Factory Visual Studio project compiler
=======

[![Build Status](https://deepnetwork.visualstudio.com/_apis/public/build/definitions/36d57bcb-8fdc-4a2a-b735-876ab649d0cf/23/badge)](https://deepnetwork.visualstudio.com/_apis/public/build/definitions/36d57bcb-8fdc-4a2a-b735-876ab649d0cf/23/badge) 
[![NuGet](https://img.shields.io/nuget/dt/AzureDataFactory.CICD.svg)](https://www.nuget.org/packages/AzureDataFactory.CICD) 
[![NuGet](https://img.shields.io/nuget/vpre/AzureDataFactory.CICD.svg)](https://www.nuget.org/packages/AzureDataFactory.CICD)

- [Azure Data Factory Visual Studio project compiler](#azure-data-factory-visual-studio-project-compiler)
  - [About](#about)
  - [Installing AzureDataFactory.CICD](#installing-azuredatafactorycicd)
  - [Getting Started](#getting-started)
    - [Command line](#command-line)
    - [.NET application](#net-application)
  - [Continuous Integration / Continuous Deployment](#continuous-integration-continuous-deployment)
  - [Supported ADF Types](#supported-adf-types)
  - [License](#license)

## About

AdfToArm tool gives you an ability to compile Azure Data Factory Visual Studio project into ARM template, which can be deployed to Azure.

> [Azure Data Factory (ADF)](https://azure.microsoft.com/en-us/services/data-factory/) is a hybrid data integration service that allows you to create, schedule and orchestrate your ETL/ELT workflows at scale wherever your data lives, in cloud or self-hosted network 

The most comfortable way to store ADF [as a Code](https://en.wikipedia.org/wiki/Infrastructure_as_Code) is a Visual Studio (VS) project. The project stores ADF description as set of JSON files with different types: Pipeline, Linked Service, Data Set. The problem with this project is that it allows pipelines publication only within the VS itself. There is no standard way to prepare artifact from the project and reuse it somewhere in CI to release on multiple environments.

From the other hand, there is a de facto standard of Azure resource deployment - Azure Resource Manager.

> [Azure Resource Manager (ARM)](https://azure.microsoft.com/en-us/features/resource-manager/) enables you to repeatedly deploy your app and have confidence your resources are deployed in a consistent state. You define the infrastructure and dependencies for your app in a single declarative template. This template is flexible enough to use for all of your environments such as test, staging or production.

This project aims to convert Visual Studio project into ARM template with a set of parameters allowing to reuse it all across development or production environments.


## Installing AzureDataFactory.CICD

You should install [AzureDataFactory.CICD with NuGet](https://www.nuget.org/packages/AzureDataFactory.CICD):

    Install-Package AzureDataFactory.CICD
    
Or via the .NET Core command line interface:

    dotnet add package AzureDataFactory.CICD

Either command, from Package Manager Console or .NET Core CLI, will download and install AzureDataFactory.CICD and all required dependencies.

Once the download is completed, you will get similar package folder:

![Nuget package folder](/docs/images/readme/00_downloaded_nuget.PNG)

Package consists of dotnet library itself (lib folder) and compiled console application (tools).


## Getting Started

The tool can be used from command line or from .NET applications.

### Command line

Navigate to `/packages/tools/` folder and run `AdfToArm.exe --help`: 

![Console app help](/docs/images/readme/01_cli_help.PNG)

There are 5 options:

1. Path to an input file. **Required** parameter. For example: `c:\projects\ADF\ADF.dfproj`
2. Path to an output folder. **Required** parameter. For example: `c:\projects\ADF\ARMs\`
3. Verbose flag, which indicates if INFO level logs should be written to console
4. Help flag.
5. Application version flag.

Here is full example:

    AdfToArm.exe -i "c:\projects\ADF\ADF.dfproj" -o "c:\projects\ADF\ARMs\"

If tool faces any exceptions (missed json property, incorrect values, etc.), information about it will be written to the output and execution will be interrupted:

![Console app exception](/docs/images/readme/02_cli_exception.PNG)

If no error occurs, resulting ARM template you could find at the path set with `--output` or `-o` applciation parameter

### .NET application

Optional. 

You can implement your own version of the tool using the similar code:


```csharp
using AdfToArm.Core;

namespace AdfToArm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AdfCompiler
                .New(@"c:\projects\sample.adf\adf.dfproj") // path to ADF project
                .ParseAdfTemplates()
                .CreateArmTemplate()
                .SaveArmTo(@"c:\projects\sample.adf\arm.json")); // output ARM template
        }
    }
}
```

**NOTE**: AdfCompiler class belongs to `AdfToArm.Core` namespace, which should be referenced


## Continuous Integration / Continuous Deployment

There is a [separate document](/docs/vsts_cicd.md) with all details how to implement simple CI/CD pipeline in [Visual Studio Team Service (VSTS)](https://www.visualstudio.com/team-services/).


## Supported ADF Types

Full list of supported ADF types can be found [here](/docs/adf_types.md).

## License

AzureDataFactory.CICD is licensed under [MIT Licence](http://www.opensource.org/licenses/MIT).