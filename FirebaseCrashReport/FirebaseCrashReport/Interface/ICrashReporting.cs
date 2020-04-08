using System;
using System.Collections.Generic;
using System.Text;

namespace FirebaseCrashReport.Interface
{
    public interface ICrashReporting
    {
        bool CrashReportingInit();
        bool SendCrashReport(string crashMessage);
        bool CrashReportingMisc();
        void ForceCrash();
    }
}
