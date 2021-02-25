# Basic project structure

* [Basic project structure](#basic-project-structure)
  * [Dictionary and used shortcuts](#dictionary-and-used-shortcuts)
  * [File structure](#file-structure)
  * [Solution file *.sln](#solution-file-sln)
  * [Project file *.csproj](#project-file-csproj)

<!-- Links -->

[VS]: https://visualstudio.microsoft.com
[blog-vsfolders]: http://www.blackwasp.co.uk/VSSolutionFolders.aspx
[vscode]: https://code.visualstudio.com/docs/editor/editingevolved
[TFM]: https://docs.microsoft.com/en-us/dotnet/standard/frameworks
[VCS]: https://en.wikipedia.org/wiki/Version_control
[IDE]: https://en.wikipedia.org/wiki/Integrated_development_environment
[nuget]: https://docs.microsoft.com/en-us/nuget/what-is-nuget
<!-- local links -->

[csproj]: #project-file-csproj

## Dictionary and used shortcuts

> "shortcut" - "meaning"

* IDE - [Integrated Development Environment][IDE]
* VS - [**Visual Studio**][VS] - Integrated Development Environment
* vscode - **[Visual Studio Code][vscode]** - Text editor
* TFM - **[Target Framework Moniker][TFM]**
* VCS - **[Version Control System][VCS]**
* Nuget - [Standard dependency manager in .NET world][nuget]

## File structure

> this files should be pushed to repository, `bin` and `obj` folders are after restore/build in every project folder. To repository you want push only source code, not binaries (I break this rule with Lectures/**.pdf files, be patient we migrate it to .md files ;))

```bash
C:.
│   .gitignore # generated with `dotnet new gitignore`, here are files that will be ignored by VCS
│   MySolution.sln # solution file
│   readme.md # this file - it is good idea to put this file to every project that you create - it is start of documentation ;) 
│
├───ClassLibrary1 # folder with C# project
│       Class1.cs # C# file that is included to this csproj
│       ClassLibrary1.csproj # C# project file
│
└───MyPerfectProject
    │   MyPerfectProject.csproj
    │   Program.cs
    │
    └───Folder
            Test.cs

```

## Solution file *.sln

> MySolution.sln

* This file is responsible for load your codebase in [VS]
* Syntax of is "yaml" like
* file contains files which are by default visible for **[Visual Studio]**.
  * Contains links to project files - [csproj]
  * Could contain "solution files" - is recommended to add every file on `*sln` level files
* Everything could be structured with "VS Folders"
  * They are just virtual paths that are used **only** in VS
  * This folders could hide content in Visual Studio
  * [blog-vsfolders]

## Project file *.csproj

> ClassLibrary1.csproj  
> MyPerfectProject.csproj

* this are specific for `C#`
* Exist also for other languages - `fsproj` - F#, `sqlproj` - SQL, `vbproj` - VB .NET
* Syntax is valid XML
* Old and New "sdk like syntax"
  * **Old**
    * [see old csproj](./CsprojConsoleApplicationOld/CsprojConsoleApplicationOld.csproj)
    * Nuget is separated - for restoraTion is responsible nuget tool or VS
      * all transitive depdencies from nuget must me **included** like Dlls
      * If you reference package A that is depdend on package B, you need to have references to both pacakges
      * from csproj you have relative path to `*.dll` and other files from nuget file (nupkg) that is exposed in `../packages/**` folder
    * `*.targets` and `*.props` have relative path to `$(VSToolsPath)/......` - you need to have installed task locally
  * **New**
    * [see new csproj](./CsprojConsoleApplicationNew/CsprojConsoleApplicationNew.csproj)
    * should be used also with old .NET Framework
    * Nuget is first class citizen in csproj
      * If you reference package A that is depdend on package B, you have reference just to package A
      * nuget have cache in `%USERPROFILE%/.nuget/packages/` folder
    * `*.targets` and `*.props` are distributed via nuget packages (basic `*.targets` and `*.props` are installed with dotnet CLI)
