using System;
using System.Collections.Generic;
using System.Linq;
using FirebaseCrashReport.Interface;
using Foundation;
using UIKit;
using Firebase.Core;
using Firebase.Crashlytics;
using Xamarin.Forms;

namespace FirebaseCrashReport.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());
            Firebase.Core.App.Configure();

            Crashlytics.Configure();
            Fabric.Fabric.SharedSdk.Debug = true;

            try
            {
                string division = "string";
                int value = Convert.ToInt32(division);
            }
            catch (Exception ex)
            {
                var crashInfo = new Dictionary<object, object>
                {
                    [NSError.LocalizedDescriptionKey] = ex.Message,
                    ["StackTrace"] = ex.StackTrace
                };

                var error = new NSError(new NSString(ex.GetType().FullName),
                                        -1,
                                        NSDictionary.FromObjectsAndKeys(crashInfo.Values.ToArray(), crashInfo.Keys.ToArray(), crashInfo.Count));


                Crashlytics.SharedInstance.RecordError(error);
                // var crashReporting = DependencyService.Get<ICrashReporting>();

                //crashReporting.CrashReportingInit();
            }
            return base.FinishedLaunching(app, options);
        }
    }
}
