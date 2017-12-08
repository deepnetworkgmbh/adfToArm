--------------------------------------------------------------------------------
-------------- Azure Data Factory CICD tool NuGet Package Readme ---------------
--------------------------------------------------------------------------------


Version 
-------

0.1.7 08/12/2017


Contact Information
------------------
Company name: Deep Network GmbH.
Email address: info@deepnetwork.com


Description
-----------
This package provides the library and tools that support the CI/CD of Azure Data Factory Visual Studio projects. 

File manifest
-------------
./lib/
./tools/
./readme.txt


Instructions
------------

- Use Command line tool 'AdfToArm.exe'

The tool will check the syntax for your ADF project scripts and generate two files: one ARM template file and one ARM parameter file. 

You can take the ARM parameter file and modify the settings in it then use the ARM template and ARM parameter file for deployment through ARM api.

Example:
./tools/AdfToArm.exe -i "c:\projects\ADF\ADF.dfproj" -o "c:\projects\ADF\ARMs\"

To get a help page run next command:
./tools/AdfToArm.exe --help


- Use C#

Optional.
You can also use C# to create a custom solution based on AdfToArm.Core assembly. It will check the syntax for your scripts and generate two files: one ARM template file and one ARM parameter file. 

You can take the ARM parameter file and modify the settings in it then use the ARM template and ARM parameter file for deployment through ARM api.

C# sample can be found here: https://github.com/deepnetworkgmbh/adfToArm/blob/master/README.md


Documentation
------------
https://azure.microsoft.com/en-us/services/data-factory/
https://azure.microsoft.com/en-us/features/resource-manager/
https://github.com/deepnetworkgmbh/adfToArm/blob/master/README.md


Copyright and licensing
-----------------------