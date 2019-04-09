---
uti: com.xamarin.workbook
id: f9121e87-d59c-484e-ac1a-c2fe4ee504bf
title: VS Project Template
platforms:
- DotNetCore
---

```csharp
using static System.Console;
```
___

> When upgrading MvvmCross template for VS 2019:

Initialize custom controls in UWP in `Setup` class.

```csharp
public class Setup : MvxFormsWindowsSetup<Core.App, Forms.App>
{
      public override IEnumerable<Assembly> GetViewAssemblies() =>
            new HashSet<Assembly>(base.GetViewAssemblies())
            {
                //+ Initialize custom controls
                typeof(SfSegmentedControlRenderer).GetTypeInfo().Assembly,
                typeof(Forms.Views.MainPage).GetTypeInfo().Assembly
            };
}
```

___

Add `LinkedPleaseInclude` for UWP.

Code sample is present in EggTimer app (`D:\LearnApps\Proso.EggTimer\Proso.EggTimer\Proso.EggTimer.UWP`).


___

Don\`t inject `INavigationService` in every VM. Not all VMs need to navigate.

___

Other things to do:

* Upgrade project template for VS 2019
* Upgrade Xam.Forms
* Upgrade MvvmCross
* Upgrade UWP Nuget package `Microsoft.NETCore.UniversalWindowsPlatform`

___


## List of Contents
- [List of Contents](#list-of-contents)
- [Overview](#overview)
- [Steps](#steps)
  - [Gotchas](#gotchas)
- [Resources](#resources)



___
___



## Overview

*Use*: Creating reusable VS Solution.


___



## Steps

![Create VS project template wizard image][6]

![Final wizard page image][7]

![Projects (in the Solution) drop-down menu image][5]


1. Create project
2. Write all the boilerplate code
3. Create project template zips
   1. Menu  -->  Project  -->  Export Template
   2. Select Project template & then next
   3. Uncheck Automatically import  -->  Finish
   4. Repeat steps (3.1), (3.2) & (3.3) for all projects
4. Edit files
   1. Create new folder
   2. Unzip all project template zips in respective folders
   3. Edit each folder\`s files   ...*more details in notes*
      1. Things to edit:
         * `using` import statements
         * `namespace`
         * `csproj` file
         * Project references in `csproj` file
5. Create soluton `.vstemplate`
   1. Create new xml file
   2. Fill `TemplateData` details
   3. Use some icon for template
   4. Define solution level folders
   5. Add path for each sub-project `.vstemplate`
6. Zip all: Select all  -->  Context menu  -->  Send to  -->  Compressed (zipped) folder
7. Copy zipped folder to:  
   `C:\Users\<user-name>\OneDrive\Documents\Visual Studio 2017\Templates\ProjectTemplates\Visual C#\Cross-Platform`


___


*Notes*:

To use project\`s name: use `$safeprojectname$`  
To use solution\`s name: use `$ext_safeprojectname$`


___
___


### Gotchas

* iOS `Info.plist`\`s parameters are not replaced by default. Configure `.vstemplate` to replace.  
  `<ProjectItem ReplaceParameters="true" TargetFileName="Info.plist">Info.plist</ProjectItem>`


* Copy `Assets.xcassets` folder from the builtin Xamarin.Forms template (*not created by custom template*).   ...*[more details][8]*
* Copy images from `Resources` folder


___


* In Android, create namespace alias for `Android` namespace.
* E.g. in `LinkerPleaseInclude`:  

```csharp
using Droid = Android;

[Droid.Runtime.Preserve(AllMembers = true)]
public class LinkerPleaseInclude {}
```


___


* In UWP, configure `MyTemplate.vstemplate` to replace `Package.appxmanifest`\`s parameters.  
  `<ProjectItem ReplaceParameters="true" TargetFileName="Package.appxmanifest">Package.appxmanifest</ProjectItem>`



___
___



## Resources

* [Create Multi-Project VS Template][1]
* [Multi-Project VS Template Sample][2]
* [Create VS Project Template][3]
* [Pack VS Project Template into VSIX][4]














[1]: https://www.youtube.com/watch?v=jUmRUQs2xrs "How to create a visual studio solution template (multi project) - YouTube"
[2]: https://github.com/JTOne123/XamFormsMvxTemplate "A Visual Studio 2017 template for projects based on Xamarin.Forms 3.3 and MvvmCross 6.2 - GitHub"
[3]: https://docs.microsoft.com/en-us/visualstudio/ide/creating-project-and-item-templates?view=vs-2017 "Create Project & Item Templates - MS Doc"
[4]: https://www.youtube.com/watch?v=Jhi1WFp47Qk "Create Project template & pack it into a VSIX VS extension - MS Doc"
[5]: \Images\Projects-drop-down-menu.png "Projects (in the Solution) drop-down menu"
[6]: \Images\Export-Template-Wizard.png "Create VS project template wizard"
[7]: \Images\Final-wizard.png "Final wizard page"
[8]: https://forums.xamarin.com/discussion/comment/362053/#Comment_362053 "Solution: iOS images in Assets.xcassets is not copied in Custom VS project template - Xam Forum"