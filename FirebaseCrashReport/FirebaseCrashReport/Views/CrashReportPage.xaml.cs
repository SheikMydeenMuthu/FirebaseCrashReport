using FirebaseCrashReport.Interface;
using FirebaseCrashReport.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirebaseCrashReport.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrashReportPage : ContentPage
    {
        public CrashReportPage()
        {
            InitializeComponent();            
            BindingContext = new CrashReportViewModel();
        }
    }
}