using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Crashlytics;
using FirebaseCrashReport.Interface;
using FirebaseCrashReport.iOS.Services;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(CrashReportiOS))]
namespace FirebaseCrashReport.iOS.Services
{
    public class CrashReportiOS: ICrashReporting
    {
        /// <summary>
        /// Crashalytics reporting initialize 
        /// </summary>
        /// <returns><c>true</c>, if reporting init failed, <c>false</c> otherwise worked OK.</returns>
        public bool CrashReportingInit()
        {
            try
            {
                Firebase.Core.App.Configure();

                Crashlytics.Configure();
                Fabric.Fabric.SharedSdk.Debug = true;

                Fabric.Fabric.With(typeof(Crashlytics));
                


            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("CrashReportingInit - " +
                                        " failed - " + exception.Message);
                return true;
            }

            return false;
        }

        public bool SendCrashReport(string crashMessage)
        {
            try
            {
                var data = new Dictionary<object, object> {
                { "Class name", "Test Class" },
                { "Method name", "Test Method" }
            };
                var nsData = NSDictionary.FromObjectsAndKeys(data.Values.ToArray(), data.Keys.ToArray(), data.Keys.Count);

                Logging.NSLogCallerInformation($"Hi! Maybe I'm about to crash! Here's some data: {nsData}");
                Crashlytics.SharedInstance.SetValue(nsData, "data");

                Crashlytics.SharedInstance.LogEvent("Test");

                Crashlytics.SharedInstance.Crash();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Not needed on iOS.
        /// </summary>
        /// <returns><c>false</c>.</returns>
        public bool CrashReportingMisc()
        {
            return false;
        }

        /// <summary>
        /// Forces an application crash 
        /// </summary>
        public void ForceCrash()
        {
            throw new ApplicationException("This is a forced crash - iOS");
        }
    }
}