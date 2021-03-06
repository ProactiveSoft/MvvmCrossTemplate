﻿using System.Reflection;
using Foundation;
using MvvmCrossTest.Test.Core;
using UIKit;
using Xunit.Runner;
using Xunit.Sdk;

namespace MvvmCrossTest.Test.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : RunnerAppDelegate
    {
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // We need this to ensure the execution assembly is part of the app bundle
            AddExecutionAssembly(typeof(ExtensibilityPointFactory).Assembly);


            // tests can be inside the main assembly
            AddTestAssembly(Assembly.GetExecutingAssembly());
            // otherwise you need to ensure that the test assemblies will 
            // become part of the app bundle
            AddTestAssembly(typeof(MainViewModelShould).Assembly);

#if false
			// you can use the default or set your own custom writer (e.g. save to web site and tweet it ;-)
			Writer = new TcpTextWriter ("10.0.1.2", 16384);
			// start running the test suites as soon as the application is loaded
			AutoStart = true;
			// crash the application (to ensure it's ended) and return to springboard
			TerminateAfterExecution = true;
#endif
            return base.FinishedLaunching(app, options);
        }
    }


    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    //[Register("AppDelegate")]
    //public class AppDelegate : UIApplicationDelegate
    //{
    //    // class-level declarations

    //    public override UIWindow Window
    //    {
    //        get;
    //        set;
    //    }

    //    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    //    {
    //        // create a new window instance based on the screen size
    //        Window = new UIWindow(UIScreen.MainScreen.Bounds);
    //        Window.RootViewController = new UIViewController();

    //        // make the window visible
    //        Window.MakeKeyAndVisible();

    //        return true;
    //    }

    //    public override void OnResignActivation(UIApplication application)
    //    {
    //        // Invoked when the application is about to move from active to inactive state.
    //        // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
    //        // or when the user quits the application and it begins the transition to the background state.
    //        // Games should use this method to pause the game.
    //    }

    //    public override void DidEnterBackground(UIApplication application)
    //    {
    //        // Use this method to release shared resources, save user data, invalidate timers and store the application state.
    //        // If your application supports background execution this method is called instead of WillTerminate when the user quits.
    //    }

    //    public override void WillEnterForeground(UIApplication application)
    //    {
    //        // Called as part of the transition from background to active state.
    //        // Here you can undo many of the changes made on entering the background.
    //    }

    //    public override void OnActivated(UIApplication application)
    //    {
    //        // Restart any tasks that were paused (or not yet started) while the application was inactive. 
    //        // If the application was previously in the background, optionally refresh the user interface.
    //    }

    //    public override void WillTerminate(UIApplication application)
    //    {
    //        // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
    //    }
    //}
}