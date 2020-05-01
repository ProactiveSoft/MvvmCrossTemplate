## List of Contents
- [List of Contents](#list-of-contents)
- [To Do](#to-do)
- [Overview](#overview)
- [Template Creation Steps](#template-creation-steps)
- [Gotchas](#gotchas)
- [Template Usage Steps](#template-usage-steps)
- [Resources](#resources)


___
___


## To Do

Use `Directory.Build.props` file to specify latest C# version for all projects in a solution at one place.  
Source - [C# language versioning](https://docs.microsoft.com/en-in/dotnet/csharp/language-reference/configure-language-version "C# language versioning - MS Doc")

Create template using VSIX (Work item 879) 


___
___



## Overview

*Use*: Creating reusable VS Solution.


___



## Template Creation Steps 

![Create VS project template wizard image][6]

![Final wizard page image][7]

![Projects (in the Solution) drop-down menu image][5]


1. Create project
2. Write all the boilerplate code
3. Create project template zips
   1. Menu  -->  Project  -->  Export Template
   2. Select Project template & then next
   3. Fill form   ...*more details in notes*
   4. Uncheck Automatically import  -->  Finish
   5. Repeat steps (3.1), (3.2), (3.3) & (3.4) for all projects
4. Edit files
   1. Create new folder
   2. Unzip all project template zips in respective folders
   3. Edit each folder\`s files   ...*more details in notes*
      1. Things to edit:
         * `xaml` files
         * `using` import statements
         * `namespace`
         * AssemblyInfo.cs file
         * Manifest files
         * `csproj` file
         * Project references in `csproj` file
         * `MyTemplate.vstemplate` file
5. Create soluton `.vstemplate`
   1. Create new xml file
   2. Fill `TemplateData` details
      1. Use some icon for template
      2. Fill Tags
   3. Define solution level folders
   4. Add path for each sub-project `.vstemplate`
6. Zip all: Select all  -->  Context menu  -->  Send to  -->  Compressed (zipped) folder
7. Copy zipped folder to:  
   `C:\Users\<user-name>\OneDrive\Documents\Visual Studio 2019\Templates\ProjectTemplates\Visual C#\Cross-Platform`


___


*Notes*:

* To use project\`s name: use `$safeprojectname$`
* To use solution\`s name: use `$ext_safeprojectname$`

___

* MvvmCross version format: *major.micro.mini*. E.g 7 (major).2 (micro).4 (mini)
* Update MvvmCross VS template after every MvvmCross major & micro release *(7.0.0, 7.1.0)* of MvvmCross.
* Don\`t update template for mini releases *(e.g. 7.2.0, 7.2.1)*.


___
___


## Gotchas

Fill Export Template Wizard:

![Final wizard page image][7]

For the template name, replace "MvvmCrossTest.Android" w/ "Proso.MvvmCross.Android".
Similary replace template name for other projects.


___
___



*iOS*:

* `Info.plist`'s & `Entitlements.plist`'s parameters are not replaced by default. Configure `.vstemplate` to replace.

```xml
<ProjectItem ReplaceParameters="true" TargetFileName="Info.plist">Info.plist</ProjectItem>
```


___


*Android*:

* Suffix android project name w/ *Droid*.
* Suffixing w/ *Android* causes problems in namespace.

```xml
<ProjectTemplateLink ProjectName="$safeprojectname$.Droid" CopyParameters="true">
      Proso.MvvmCross.Android\MyTemplate.vstemplate
</ProjectTemplateLink>
```


___


*UWP*:

`Package.appxmanifest`\`s parameters are not replaced by default. Configure `.vstemplate` to replace.

```xml
<ProjectItem ReplaceParameters="true" TargetFileName="Package.appxmanifest">Package.appxmanifest</ProjectItem>
```

Manually add UWP Test platform SDK to *Test.UWP.csproj*:

```xml
<ItemGroup>
  <SDKReference Include="TestPlatform.Universal, Version=$(VisualStudioVersion)" />
</ItemGroup>
```


___
___
___
___
___
___



## Template Usage Steps

1. Copy `SharedAssemblyInfo.cs` & `Directory.Build.props` to solution folder
2. Add both to solution using: Add  -->  Existing Item
3. Add `SharedAssemblyInfo.cs` as a link to each project
4. Add test assemblies
   1. Uncomment <Test Assemblies> section in `Directory.Build.props`
   2. Fill project names. E.g. `Proso.MyProject.Test.Core`
5. Copy `Assets.xcassets` folder from the builtin Xamarin.Forms template or from your template folder (`D:\Plugins\MvvmCrossTest\Proso.MvvmCross Template\Template\Proso.MvvmCross.iOS\Assets.xcassets`).   ...*[more details][8]*



* When creating a project, to create project folders in the solution folder *(directly inside solution folder)*, check **Place solution & project in the same directory** option.
* Otherwise project folders are added in solution sub-folder\`s directory.


___
___
___
___



## Resources

* [Create Multi-Project VS Template][1]
* [Multi-Project VS Template Sample][2]
* [MvvmCross Playground][10]
* [MvvmCross 6.3.0 Template][9]
* [Create VS Project Template][3]
* [Pack VS Project Template into VSIX][4]
* [Share AssemblyInfo.cs properties][12]
* **Visual Studio Template's Schema**: *`C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Xml\Schemas\1033\vstemplate.xsd`*
* [Create template using VSIX][13]














[1]: https://www.youtube.com/watch?v=jUmRUQs2xrs "How to create a visual studio solution template (multi project) - YouTube"
[2]: https://github.com/JTOne123/XamFormsMvxTemplate "A Visual Studio 2017 template for projects based on Xamarin.Forms 3.3 and MvvmCross 6.2 - GitHub"
[3]: https://docs.microsoft.com/en-us/visualstudio/ide/creating-project-and-item-templates?view=vs-2019 "Create Project & Item Templates - MS Doc"
[4]: https://www.youtube.com/watch?v=Jhi1WFp47Qk "Create Project template & pack it into a VSIX VS extension - MS Doc"
[5]: .\Images\Projects-drop-down-menu.png "Projects (in the Solution) drop-down menu"
[6]: .\Images\Export-Template-Wizard.png "Create VS project template wizard"
[7]: .\Images\Final-wizard.png "Final wizard page"
[8]: https://forums.xamarin.com/discussion/comment/362053/#Comment_362053 "Solution: iOS images in Assets.xcassets is not copied in Custom VS project template - Xam Forum"
[9]: https://github.com/Plac3hold3r/MvxScaffolding/tree/develop/src/Templates/MvxForms/Blank/src "MvvmCross 6.3.0 template - Placeholder"
[10]: https://github.com/MvvmCross/MvvmCross/tree/develop/Projects/Playground "MvvmCross Playground Sample"
[11]: C:\Program%20Files%20(x86)\Microsoft%20Visual%20Studio\2019\Enterprise\Xml\Schemas\1033\vstemplate.xsd "Visual Studio (vstemplate) Schema"
[12]: https://stackoverflow.com/a/49601178 "Sharing AssemblyInfo.cs properties using Directory.Build.props - Stackoverflow"
[13]: https://www.dotnetcurry.com/visual-studio/1521/visual-studio-project-setup-solution-snapshotter "Streamlining Your Visual Studio Project Setup - Dot Net Curry"