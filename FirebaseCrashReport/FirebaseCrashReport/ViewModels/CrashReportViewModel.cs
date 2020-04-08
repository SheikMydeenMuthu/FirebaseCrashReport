using FirebaseCrashReport.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FirebaseCrashReport.ViewModels
{
    public class CrashReportViewModel: BaseViewModel
    {
        #region Fields
        private string _crashReportText;
       
        #endregion

        #region Constructor
        public CrashReportViewModel()
        {
                        
        }
        #endregion

        #region Properties
        public string CrashReportText
        {
            get { return _crashReportText; }
            set
            {
                _crashReportText = value;
                OnPropertyChanged();
            }
        }

        public Command SendCrashReport
        {
            get {
                return new Command(() =>
                {
                    var crashReporting = DependencyService.Get<ICrashReporting>();

                    //crashReporting.CrashReportingInit();
                    crashReporting.SendCrashReport("Test");
                });
            }
        }
        #endregion

    }
}
