Learn unit test
Update MvvmCross template
    Update Android target
Complete 1 Andriod course in 20 days
Add gig on Fever


___
___


*To Do*: 

* Manually zip template
* Test template
* Doc: Template, Working w/ files & Unit Test
* Programatically zip root
* Copy template to VS's template folder
* Update NuGet
* Test template again
* Make MvvmCross.Template executable
* Merge Dev branch to master


___
___



Steps of editing generated template:

Copy SharedAssemblyInfo.cs & Directory.Build.props to root directory


.Abstraction project
    Edit *.vstemplate* file
        Insert at line 17: <Hidden>true</Hidden>
        Replace at line 20: from "MvvmCrossTest.Abstraction.csproj" to "$safeprojectname$.csproj"


.Core project
    Edit MainViewModel.cs
        Replace at line 1: "MvvmCrossTest.Abstraction.ViewModels"; to "$ext_safeprojectname$.Abstraction.ViewModels";
        Check at line 17: Title using custom template variable
    Edit .csproj
        Replace at line 12: "..\MvvmCrossTest.Abstraction\MvvmCrossTest.Abstraction.csproj" to "..\$ext_safeprojectname$.Abstraction\$ext_safeprojectname$.Abstraction.csproj"
    Edit .vstemplate file
        Insert at line 17: <Hidden>true</Hidden>
        Replace at line 20: "MvvmCrossTest.Core.csproj" to "$safeprojectname$.csproj"


.Forms project
    Edit Helpers/CommonSetup.cs
        Replace at line 3: "MvvmCrossTest.Abstraction.Helpers;" to $ext_safeprojectname$.Abstraction.Helpers;
        Replace at line 4: "MvvmCrossTest.Core.ViewModels;" to "$ext_safeprojectname$.Core.ViewModels;"
    Edit MainPage.xaml
        Replace at line 8: "clr-namespace:MvvmCrossTest.Core.ViewModels;assembly=MvvmCrossTest.Core" to "clr-namespace:$ext_safeprojectname$.Core.ViewModels;assembly=$ext_safeprojectname$.Core"
    Edit .csproj
        Replace at line 14: "..\MvvmCrossTest.Abstraction\MvvmCrossTest.Abstraction.csproj" to "..\$ext_safeprojectname$.Abstraction\$ext_safeprojectname$.Abstraction.csproj"
        Replace at line 15: "..\MvvmCrossTest.Core\MvvmCrossTest.Core.csproj" to "..\$ext_safeprojectname$.Core\$ext_safeprojectname$.Core.csproj"
    Edit .vstemplate
        Insert at line 17: <Hidden>true</Hidden>
        Replace at line 20: "MvvmCrossTest.Forms.csproj" to "$safeprojectname$.csproj"


.UWP project
    Edit AssemblyInfo.cs
        Replace at line 9: "MvvmCrossTest UWP project." to "$ext_safeprojectname$ UWP project."
    Edit .csproj
        Replace at line 20: "MvvmCrossTest.UWP_TemporaryKey.pfx" to "$safeprojectname$_TemporaryKey.pfx"
        Replace at line 163: "..\MvvmCrossTest.Abstraction\MvvmCrossTest.Abstraction.csproj" to "..\$ext_safeprojectname$.Abstraction\$ext_safeprojectname$.Abstraction.csproj"
        Replace at line 165: "MvvmCrossTest.Abstraction" to "$ext_safeprojectname$.Abstraction"
        Replace at line 167: "..\MvvmCrossTest.Core\MvvmCrossTest.Core.csproj" to "..\$ext_safeprojectname$.Core\$ext_safeprojectname$.Core.csproj"
        Replace at line 169: "MvvmCrossTest.Core" to "$ext_safeprojectname$.Core"
        Replace at line 171: "..\MvvmCrossTest.Forms\MvvmCrossTest.Forms.csproj" to "..\$ext_safeprojectname$.Forms\$ext_safeprojectname$.Forms.csproj"
        Replace at line 173: "MvvmCrossTest.Forms" to "$ext_safeprojectname$.Forms"
    Edit .vstemplate
        Insert at line 16: <Hidden>true</Hidden>
        Replace at line 19: "MvvmCrossTest.UWP.csproj" to "$safeprojectname$.csproj"
        Replace at line 54: 'ReplaceParameters="false"' to 'ReplaceParameters="true"'
    Edit .appxmanifest
        Replace at line 17: "MvvmCrossTest.UWP" to "$ext_safeprojectname$"
        Replace at line 33: "MvvmCrossTest.UWP.App" to "$safeprojectname$.App"
        Replace at line 35: "MvvmCrossTest.UWP" to "$ext_safeprojectname$"
        Replace at line 38: "MvvmCrossTest.UWP" to "$ext_safeprojectname$ UWP app."
    Edit Setup.cs
        Replace at line 6: "MvvmCrossTest.Abstraction.Helpers;" to "$ext_safeprojectname$.Abstraction.Helpers;"
        Replace at line 7: "MvvmCrossTest.Forms.Helpers;" to "$ext_safeprojectname$.Forms.Helpers;"
        

.Android project
    Edit AndroidManifest.xml
        Replace at line 2: 'package="com.companyname.MvvmCrossTest"' to 'package="com.proso.$ext_safeprojectname$"'
        Replace at line 4: 'android:label="$safeprojectname$"' to 'android:label="$ext_safeprojectname$"'
    Edit AssemblyInfo.cs:
        Replace at line 10: "MvvmCrossTest Android project." to "$ext_safeprojectname$ Android project."
    Edit MainActivity.cs
        Replace at line 10: 'Label = "MvvmCrossTest",' to '"$ext_safeprojectname$"'
    Edit .csproj
        Replace at line 11: '<AssemblyName>MvvmCrossTest.Android</AssemblyName>' to '<AssemblyName>$safeprojectname$</AssemblyName>'
        Replace at line 110 - 121:
            <ProjectReference Include="..\MvvmCrossTest.Abstraction\MvvmCrossTest.Abstraction.csproj">
                <Project>{2e3244ef-39d5-43cb-ac36-70a8d42c8e85}</Project>
                <Name>MvvmCrossTest.Abstraction</Name>
            </ProjectReference>
            <ProjectReference Include="..\MvvmCrossTest.Core\MvvmCrossTest.Core.csproj">
                <Project>{aee678e2-f59f-4b5c-96cc-6c7c8eb73bdf}</Project>
                <Name>MvvmCrossTest.Core</Name>
            </ProjectReference>
            <ProjectReference Include="..\MvvmCrossTest.Forms\MvvmCrossTest.Forms.csproj">
                <Project>{4a6045c2-2ed5-4c7d-95ad-8b82d3e11fb9}</Project>
                <Name>MvvmCrossTest.Forms</Name>
            </ProjectReference>
            with
            <ProjectReference Include="..\$ext_safeprojectname$.Abstraction\$ext_safeprojectname$.Abstraction.csproj">
                <Project>{2e3244ef-39d5-43cb-ac36-70a8d42c8e85}</Project>
                <Name>$ext_safeprojectname$.Abstraction</Name>
            </ProjectReference>
            <ProjectReference Include="..\$ext_safeprojectname$.Core\$ext_safeprojectname$.Core.csproj">
                <Project>{aee678e2-f59f-4b5c-96cc-6c7c8eb73bdf}</Project>
                <Name>$ext_safeprojectname$.Core</Name>
            </ProjectReference>
            <ProjectReference Include="..\$ext_safeprojectname$.Forms\$ext_safeprojectname$.Forms.csproj">
                <Project>{4a6045c2-2ed5-4c7d-95ad-8b82d3e11fb9}</Project>
                <Name>$ext_safeprojectname$.Forms</Name>
            </ProjectReference>
    Edit .vstemplate:
        Insert at line 16: <Hidden>true</Hidden>
        Replace at line 19: 'TargetFileName="MvvmCrossTest.Android.csproj"' to 'TargetFileName="$safeprojectname$.csproj"'
    Edit Setup.cs:
        Replace at line 6 & 7:
            using MvvmCrossTest.Abstraction.Helpers;
            using MvvmCrossTest.Forms.Helpers;

            w/

            using $ext_safeprojectname$.Abstraction.Helpers;
            using $ext_safeprojectname$.Forms.Helpers;
    Edit SplashScreen.cs:
        Replace at line 10: 'Label = "MvvmCrossTest",' to 'Label = "$ext_safeprojectname$",'


.iOS project
    Edit AssemblyInfo.cs:
        Replace at line 9: "MvvmCrossTest iOS project." to "$ext_safeprojectname$ iOS project."
    Edit info.plist:
        Replace at line 26: '<string>MvvmCrossTest</string>' to '<string>$ext_safeprojectname$</string>'
        Replace at line 28: '<string>com.companyname.MvvmCrossTest</string>' to '<string>com.proso.$ext_safeprojectname$</string>'
        Replace at line 34: 'MvvmCrossTest' to '$ext_safeprojectname$'
    Edit .csproj:
        Replace at line 171 - 182:
            <ProjectReference Include="..\$ext_safeprojectname$.Abstraction\$ext_safeprojectname$.Abstraction.csproj">
                <Project>{2e3244ef-39d5-43cb-ac36-70a8d42c8e85}</Project>
                <Name>$ext_safeprojectname$.Abstraction</Name>
            </ProjectReference>
            <ProjectReference Include="..\$ext_safeprojectname$.Core\$ext_safeprojectname$.Core.csproj">
                <Project>{aee678e2-f59f-4b5c-96cc-6c7c8eb73bdf}</Project>
                <Name>$ext_safeprojectname$.Core</Name>
            </ProjectReference>
            <ProjectReference Include="..\$ext_safeprojectname$.Forms\$ext_safeprojectname$.Forms.csproj">
                <Project>{4a6045c2-2ed5-4c7d-95ad-8b82d3e11fb9}</Project>
                <Name>$ext_safeprojectname$.Forms</Name>
            </ProjectReference>
    Edit .vstemplate:
        Insert at line 16: <Hidden>true</Hidden>
        Replace at line 19: 'TargetFileName="MvvmCrossTest.iOS.csproj"' to 'TargetFileName="$safeprojectname$.csproj"'
        Replace at line 21 & 22: 'ReplaceParameters="false"' to 'ReplaceParameters="true"'
        Copy folder Assets.xcassets
        Insert at line 25:                        
            <Folder Name="Assets.xcassets\AppIcon.appiconset" TargetFolderName="Assets.xcassets\AppIcon.appiconset">
                <ProjectItem TargetFileName="Contents.json" ReplaceParameters="true">Contents.json</ProjectItem>
                <ProjectItem TargetFileName="Icon20.png" ReplaceParameters="false">Icon20.png</ProjectItem>
                <ProjectItem TargetFileName="Icon29.png" ReplaceParameters="false">Icon29.png</ProjectItem>
                <ProjectItem TargetFileName="Icon40.png" ReplaceParameters="false">Icon40.png</ProjectItem>
                <ProjectItem TargetFileName="Icon58.png" ReplaceParameters="false">Icon58.png</ProjectItem>
                <ProjectItem TargetFileName="Icon60.png" ReplaceParameters="false">Icon60.png</ProjectItem>
                <ProjectItem TargetFileName="Icon76.png" ReplaceParameters="false">Icon76.png</ProjectItem>
                <ProjectItem TargetFileName="Icon80.png" ReplaceParameters="false">Icon80.png</ProjectItem>
                <ProjectItem TargetFileName="Icon87.png" ReplaceParameters="false">Icon87.png</ProjectItem>
                <ProjectItem TargetFileName="Icon120.png" ReplaceParameters="false">Icon120.png</ProjectItem>
                <ProjectItem TargetFileName="Icon152.png" ReplaceParameters="false">Icon152.png</ProjectItem>
                <ProjectItem TargetFileName="Icon167.png" ReplaceParameters="false">Icon167.png</ProjectItem>
                <ProjectItem TargetFileName="Icon180.png" ReplaceParameters="false">Icon180.png</ProjectItem>
                <ProjectItem TargetFileName="Icon1024.png" ReplaceParameters="false">Icon1024.png</ProjectItem>
            </Folder>

    Edit Setup.cs:
        Replace at line 5 & 6:
            using MvvmCrossTest.Abstraction.Helpers;
            using MvvmCrossTest.Forms.Helpers;

            w/

            using $ext_safeprojectname$.Abstraction.Helpers;
            using $ext_safeprojectname$.Forms.Helpers;


Test.Core
    Edit MainViewModelShould.cs
        Line 1: Replace `MvvmCrossTest.Core.ViewModels;` w/ `$ext_safeprojectname$.Core.ViewModels;`
    Edit csproj
        Line 8: `"..\..\SharedAssemblyInfo.cs"` remove extra `..\`
        Line 16: Replace `MvvmCrossTest` w/ `$ext_safeprojectname$`
    Edit vstemplate
        Line 3: Description = Tests for core logic.
        Line 17: insert <Hidden>true</Hidden>
        Line 19: Replace `TargetFileName="MvvmCrossTest.Test.Core` to `TargetFileName="$safeprojectname$.csproj"`

Test.Droid
    Edit AndroidManifest.xml
        Replace at line 2: `package="com.companyname.MvvmCrossTest"` to `package="com.proso.$ext_safeprojectname$.test"`
    Edit strings.xml
        Line 2: Replace `name="app_name">$safeprojectname$` w/ `name="app_name">$ext_safeprojectname$.Test`
    Edit MainActivity.cs
        Line 7: Replace `MvvmCrossTest.Test.Core;` to `$ext_safeprojectname$.Test.Core;`
    Edit csproj
        Line 65: `"..\..\SharedAssemblyInfo.cs"` remove extra `..\`
        Line 145: Replace `"..\MvvmCrossTest.Test.Core\MvvmCrossTest.Test.Core.csproj"` to `"..\$ext_safeprojectname$.Test.Core\$ext_safeprojectname$.Test.Core.csproj"`
        Line 147: Replace `<Name>MvvmCrossTest.Test.Core` to `<Name>$ext_safeprojectname$.Test.Core`
    Edit vstemplate
        Line 4: Add description: Android host for tests.
        Line 16: insert <Hidden>true</Hidden>
        Line 18: Replace `TargetFileName="MvvmCrossTest.Test.Droid.csproj"` to `TargetFileName="$safeprojectname$.csproj"`


Test.UWP
    Edit App.xaml.cs
        Line 18: Replace `MvvmCrossTest.Test.Core;` to `$ext_safeprojectname$.Test.Core;`
    Edit csproj
        Line 120: `"..\..\SharedAssemblyInfo.cs"` remove extra `..\`
        Line 171: Replace `Include="..\MvvmCrossTest.Test.Core\MvvmCrossTest.Test.Core.csproj"` with `Include="..\$ext_safeprojectname$.Test.Core\$ext_safeprojectname$.Test.Core.csproj"`
        Line 173: Replace `<Name>MvvmCrossTest.Test.Core` with `<Name>$ext_safeprojectname$.Test.Core`
    Edit vstemplate
        Line 4: Add description: UWP host for tests.
        Line 16: insert <Hidden>true</Hidden>
        Line 18: Replace `TargetFileName="MvvmCrossTest.Test.UWP.csproj"` with `TargetFileName="$safeprojectname$.csproj"`
        Line 30: `"Package.appxmanifest"` values should be replaceable `ReplaceParameters="true"`
    Edit appxmanifest
        Line 17: Replace `<DisplayName>MvvmCrossTest.Test.UWP` w/ `<DisplayName>$ext_safeprojectname$.Test`
        Line 33: Replace `EntryPoint="MvvmCrossTest.Test.UWP.App"` w/ `EntryPoint="$safeprojectname$.App"`
        Line 35: Replace `DisplayName="MvvmCrossTest.Test.UWP"` w/ `DisplayName="$ext_safeprojectname$.Test"`
        Line 38: Replace `Description="MvvmCrossTest.Test.UWP"` w/ `Description="$ext_safeprojectname$ host for tests"`


Test.iOS
    Edit AppDelegate.cs
        Line 3: Replace `using MvvmCrossTest.Test.Core;` w/ `using $ext_safeprojectname$.Test.Core;`
    Edit Info.plist
        Line 6: Replace `<string>MvvmCrossTest.Test.iOS` w/ `<string>$ext_safeprojectname$.Test`
        Line 8: Replace `<string>com.companyname.MvvmCrossTest.Test.iOS</string>` w/ `<string>com.proso.$ext_safeprojectname$.Test</string>`
    Edit csproj
        Line 63: `"..\..\SharedAssemblyInfo.cs"` remove extra `..\`
        Line 96: Replace `<Visible>false</Visible>` w/ `<Visible>true</Visible>`
        Line 142: Replace `Include="..\MvvmCrossTest.Test.Core\MvvmCrossTest.Test.Core.csproj"` w/ `Include="..\$ext_safeprojectname$.Test.Core\$ext_safeprojectname$.Test.Core.csproj"`
        Line 144: Replace `<Name>MvvmCrossTest.Test.Core</Name>` w/ `<Name>$ext_safeprojectname$.Test.Core</Name>`
    Copy `Assets.xcassets` folder
    Edit vstemplate
        Line 4: Add description: iOS host for tests.
        Line 16: insert <Hidden>true</Hidden>
        Line 18: Replace `TargetFileName="MvvmCrossTest.Test.iOS.csproj"` w/ `TargetFileName="$safeprojectname$.csproj"`
        Line 20 & 21: Replace `ReplaceParameters="false"` w/ `ReplaceParameters="true"`
        Line 23: Insert assets folder
              <Folder Name="Assets.xcassets" TargetFolderName="Assets.xcassets">
        <Folder Name="AppIcon.appiconset" TargetFolderName="AppIcon.appiconset">
          <ProjectItem ReplaceParameters="true" TargetFileName="Contents.json">Contents.json</ProjectItem>
          <ProjectItem ReplaceParameters="false" TargetFileName="Icon20.png">Icon20.png</ProjectItem>
          <ProjectItem ReplaceParameters="false" TargetFileName="Icon29.png">Icon29.png</ProjectItem>
          <ProjectItem ReplaceParameters="false" TargetFileName="Icon40.png">Icon40.png</ProjectItem>
          <ProjectItem ReplaceParameters="false" TargetFileName="Icon58.png">Icon58.png</ProjectItem>
          <ProjectItem ReplaceParameters="false" TargetFileName="Icon60.png">Icon60.png</ProjectItem>
          <ProjectItem ReplaceParameters="false" TargetFileName="Icon76.png">Icon76.png</ProjectItem>
          <ProjectItem ReplaceParameters="false" TargetFileName="Icon80.png">Icon80.png</ProjectItem>
          <ProjectItem ReplaceParameters="false" TargetFileName="Icon87.png">Icon87.png</ProjectItem>
          <ProjectItem ReplaceParameters="false" TargetFileName="Icon120.png">Icon120.png</ProjectItem>
          <ProjectItem ReplaceParameters="false" TargetFileName="Icon152.png">Icon152.png</ProjectItem>
          <ProjectItem ReplaceParameters="false" TargetFileName="Icon167.png">Icon167.png</ProjectItem>
          <ProjectItem ReplaceParameters="false" TargetFileName="Icon180.png">Icon180.png</ProjectItem>
          <ProjectItem ReplaceParameters="false" TargetFileName="Icon1024.png">Icon1024.png</ProjectItem>
        </Folder>
      </Folder>


Modify root vstemplate





Create solution template:

    Copy solution level .vstemplate, __TemplateIcon.ico, __PreviewImage.jpg, SharedAssemblyInfo.cs & Directory.Build.props to root.
    Replace at line 5: <Description>MvvmCross template 6.4.2.</Description>  // W/ current MvvmCross version