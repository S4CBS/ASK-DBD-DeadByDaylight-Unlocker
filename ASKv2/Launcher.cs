using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASKv2
{
    internal class Launcher
    {
        internal static Dictionary<string, string> ProccessNames = new Dictionary<string, string>()
        {
            ["Steam"] = "DeadByDaylight-Win64-Shipping",
            ["EGS"] = "DeadByDaylight-EGS-Shipping",
            ["MS"] = "DeadByDaylight-WinGDK-Shipping"
        };

        private static Dictionary<string, string> LaunchStrings = new Dictionary<string, string>()
        {
            ["Steam"] = "steam://run/381210",
            ["EGS"] = "com.epicgames.launcher://apps/611482b8586142cda48a0786eb8a127c%3A467a7bed47ec44d9b1c9da0c2dae58f7%3ABrill?action=launch&silent=true",
            ["MS"] = "shell:appsfolder\\BehaviourInteractive.DeadbyDaylightWindows_b1gz2xhdanwfm!AppDeadByDaylightShipping"
        };

        internal static void Web(string url)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        internal static void LaunchDBD(string type)
        {
            Process[] process = Process.GetProcessesByName(ProccessNames[type]);
            if (process.Length == 0)
            {
                Web(LaunchStrings[type]);
            }
            else
            {
                foreach (Process Kproc in process)
                {
                    Kproc.Kill();
                    Web(LaunchStrings[type]);
                }
            }
        }

        internal static void KillDBD(string type)
        {
            Process[] process = Process.GetProcessesByName(ProccessNames[type]);
            if (process.Length > 0)
            {
                foreach (Process Kproc in process)
                {
                    Kproc.Kill();
                }
            }
        }
    }
}
