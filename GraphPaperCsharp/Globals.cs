using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkInSeine
{
    internal class Globals
    {
        static public Settings.Settings Settings;
        static public bool DesignMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        public static void WriteSettings()
        {
            if (Settings != null && !DesignMode)
            {
                Settings.Write();
            }
        }
        static public bool UsePrintMargins
        {
            get
            {
                if (Settings== null || DesignMode)
                {
                    return true;
                }
                else
                {
                    return Settings.GetValueBoolean("Main", "UsePrintMargins", true);
                }
            }
            set
            {
                if (value != UsePrintMargins)
                {
                    if (Settings != null)
                    {
                        Settings.SetValue("Main", "UsePrintMargins", value);
                        Settings.Write();
                    }
                }
            }
        }
    }
}
