Continuous Integration (CI) / Continuous Deployment (CD) with Visual Studio Team Services (VSTS)
=====

The whole process is split on three parts:
  - [Provide a process of getting compiler tool](#compiler-tool)
  - [Create a Build Definition (ADF project transformation to ARM template)](#vsts-build-definition)
  - [Create a Release Definiton (ARM deployment)](#vsts-release-definition)

## Get compiler tool

From the box Visual Studio ADF project does not support compilation to ARM template. Therefore we need to link it somehow with the tool, which can do it.

Default ADF project also does not support NuGet packages, therefore we need to find a way to get compilator into the project without it.
In terms of VSTS it can be done in two ways:
* check in compiled AdfToArm tool into repository with ADF project
* create class library with referenced AzureDataFactory.CICD nuget package and add it into Visual Studio solution with ADF project.

Here is described second possibility, because it allows convinient package updates, clear version history, smaller repository (obviously, compiled sources are much bigger than referenced NuGet package).

1. Create a *class library* in solution with ADF project

![Create a class library](/docs/images/cicd/01_create_proj.jpg)

2. Install NuGet package AzureDataFactory.CICD into created class library
3. Commit and push your changes into the repository. The commit should consist of 4 files:
    * Updated solution file
    * packages.config with three NuGet packages inside: *AzureDataFactory.CICD* and dependant *Newtonsoft.Json*, *System.ValueTuple*
    * AssemblyInfo.cs of created class library
    * *.csproj file of created library

    ![Commit with class library](/docs/images/cicd/02_class_proj_git_commit.PNG)

Your repository is ready to be built with VSTS

## VSTS Build Definition

1. Open *VSTS/Build and Release/Builds*. Press *"+ New"* button.

![New Build Definition](/docs/images/cicd/03_bd_new.PNG)

2. In opened page choose *Empty process*, enter *Process* *Name* and choose *Agent queue*. The *Agent queue* should have capabilities to run cmd commands and restore NuGet packages. You can choose built-in "Hosted" queue.

![Build Definition Name and Agent queue](/docs/images/cicd/04_bd_name_queue.PNG)

3. At *Get sources* tab select your repository with ADF project and created class library
4. Into *Phase 1* add three tasks:
    * **Nuget Restore**. Choose *Command* *restore* and your *Path to solution* (you can select it by clicking on *"..."* button)

    ![Nuget restore params](/docs/images/cicd/05_bd_nuget.PNG)

    * **Batch Script**. Choose *Path* to `AdfToArm.exe`, enter *input* (path to *dfproj file) and *output* (directory for generated ARM tempalte) parameters to *Arguments* field:

    ![Batch script](/docs/images/cicd/06_bd_cmd.PNG)

    * **Publish Build Artifacts**. Enter *Path to Publish* (**NOTE**: it should be the same as in output parameters from Batch task), any *Artifact name* and choose *Artifact Type* *Server*.
    
    ![Publish task](/docs/images/cicd/07_bd_publish_artifacts.PNG)

5. Open *Triggers* tab and enable *Continuous Integration*. Choose your working branches. 

![Triggers](/docs/images/cicd/08_bd_triggers.PNG)

6. Press *Save and queue* button.

**Pay attention**, current solution doesn't require Visual Studio solution to be built at all. Nuget restores artifact without MSBuild task invocation and script is executed using existing files (executable AdfToArm tool and json files).

This Build Definition artifact as a result will contain two files produced by AdfToArm.exe application: ARM template and parameters file for it. 

Now, you're ready to deploy your artifacts to any environment.

## VSTS Release Definition

A wide range of ARM parameters allows you to customize your deployment to any environment: the only one thing you need to change is parameters itself. It can be done in two ways:
* Create separate `arm.parameters.env_name.json` files based on default one with corresponding properties. You can download sample file from any succeed Build:

![Artifacts](/docs/images/cicd/09_rd_artifacts.PNG)

* *Override template parameters* in ARM deployment release task (will be shown in this tutorial)

Create a Release Definition.

1. Open *VSTS/Build and Release/Builds*. Press *"+"* button and choose *Create Release Definition*.
2. Select *Empty template* and enter *Environment name*
3. Press *Add artifact* button

![New Release Definition](/docs/images/cicd/10_rd_new.PNG)

4. Choose previously created Build Artifact

![New Artifact](/docs/images/cicd/11_rd_add_artifact.PNG)

5. Enable **Continuous Deployment**:
    * Press button with lightning symbol on added *Artifact*, enable the trigger and choose the branch.
    
    ![CD of artifact](/docs/images/cicd/11_1_rd_enable_cd.PNG)

    * Press button with lightning symbol on created *Environment* and select *After release* trigger.
    
    ![Start deployment automatically](/docs/images/cicd/11_2_rd_enable_cd.PNG)

6. Open *Tasks* tab and add *Azure Resource Group Deployment* task into *Run on agent* phase 

![New Task](/docs/images/cicd/12_rd_add_arm_task.PNG)

7. Specify *Task* parameters:
    * Select Azure subscription, Resource group name and location
    * Select *Template* and *Template parameters* by clicking on *...* button
    * You can override template parameters in corresponding field. In the sample, `-Location` was overrided with *northeurope* value, because ADF is not available in all locations and Resource Group was created in location without ADF support. 

![Task params](/docs/images/cicd/13_rd_arm_task_params.PNG)

**NOTE**: you can use *variables* with syntax like `$(Variable_Name)`. Each variable should be added to *Variables* tab.

8. Save the Release Definition and create a new release from it.

Your CI/CD pipeline is ready and any commit to the repository will trigger build/release to your Azure Resource Group