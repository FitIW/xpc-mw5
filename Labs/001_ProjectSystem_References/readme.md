# Basic project structure

* [Basic project structure](#basic-project-structure)
  * [Shortcuts](#shortcuts)
  * [File structure](#file-structure)
  * [Solution file *.sln](#solution-file-sln)
  * [Project file *.csproj](#project-file-csproj)

<!-- Links -->

[VS]: https://visualstudio.microsoft.com
[vscode]: https://code.visualstudio.com/docs/editor/editingevolved
[TFM]: https://docs.microsoft.com/en-us/dotnet/standard/frameworks
[VCS]: https://en.wikipedia.org/wiki/Version_control
[IDE]: https://en.wikipedia.org/wiki/Integrated_development_environment
[nuget]: https://docs.microsoft.com/en-us/nuget/what-is-nuget

<!-- local links -->
[csproj]: #project-file-csproj

<!-- blog posts -->
[blog-vsfolders1]: http://www.blackwasp.co.uk/VSSolutionFolders.aspx
[blog-vsfolders2]: https://www.cathrinewilhelmsen.net/organizing-visual-studio-projects-solution-folders/

## Shortcuts

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
├───CsprojConsoleApplicationNew # project with new csproj (still targeting .NET Framework 4.7.2)
│       CsprojConsoleApplicationNew.csproj # new "sdk" like csproj
│       Program.cs
│
├───CsprojConsoleApplicationOld # project with old csproj (NET Framework 4.7.2)
│   │   App.config 
│   │   CsprojConsoleApplicationOld.csproj # old cpsroj
│   │   packages.config # definition of used nuget packages
│   │   Program.cs
│   │
│   └───Properties
│           AssemblyInfo.cs
│
└───MyPerfectProject
    │   MyPerfectProject.csproj
    │   Program.cs
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
  * [Visual Studio Solution Folders by Richard Carr][blog-vsfolders1]
  * [Organizing Visual Studio Projects in Solution Folders by Cathrine Wilhelmsen][blog-vsfolders2]

## Project file *.csproj

> ClassLibrary1.csproj  
> MyPerfectProject.csproj
> CsprojConsoleApplicationNew.csproj
> CsprojConsoleApplicationOld.csproj

* this are specific for `C#`
* Exist also for other languages - `fsproj` - F#, `sqlproj` - SQL, `vbproj` - VB .NET
* Syntax is valid XML
* Old and New "sdk like syntax"
  * **Old**
    * [see old csproj](./CsprojConsoleApplicationOld/CsprojConsoleApplicationOld.csproj)
    * Nuget is separated - for restoration is responsible nuget tool or VS
      * all transitive dependencies from nuget must me **included** like Dlls
      * If you reference package A that is depend on package B, you need to have references to both packages
      * from csproj you have relative path to `*.dll` and other files from nuget file (nupkg) that is exposed in `../packages/**` folder
    * `*.targets` and `*.props` have relative path to `$(VSToolsPath)/......` - you need to have installed task locally
  * **New**
    * [see new csproj](./CsprojConsoleApplicationNew/CsprojConsoleApplicationNew.csproj)
    * should be used also with old .NET Framework
    * Nuget is first class citizen in csproj
      * If you reference package A that is depend on package B, you have reference just to package A
      * nuget have cache in `%USERPROFILE%/.nuget/packages/` folder
    * `*.targets` and `*.props` are distributed via nuget packages (basic `*.targets` and `*.props` are installed with dotnet CLI)
