## Xamarin Forms Initialization

Xam.Forms initialization is done in each platform\`s base `Setup` class.  
`Xamarin.Forms.Forms.Init()` is called in `Setup`\`s `FormsApplication` property.  

*Use*: 

3rd-party Controls (*in their samples done according to builtin Xam.Forms template*) show 3rd-party Control initialization near the code where `Xamarin.Forms.Forms.Init()` is present.  
You can initialize 3rd-party Controls by overriding `Setup`\`s `FormsApplication` property.  