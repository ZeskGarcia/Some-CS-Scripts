using System;
using System.Diagnostics;
using Microsoft.Win32;

class UninstallFiveMAndClean
{
    static void Main()
    {
        UninstallFiveM();
        DeleteFiveMRegistryEntries();

        Console.WriteLine("FiveM has been uninstalled, and associated Registry entries have been deleted.");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void UninstallFiveM()
    {
        string uninstallerPath = GetFiveMUninstallerPath();
        if (!string.IsNullOrEmpty(uninstallerPath))
        {
            ProcessStartInfo uninstallProcessInfo = new ProcessStartInfo();
            uninstallProcessInfo.FileName = uninstallerPath;
            uninstallProcessInfo.UseShellExecute = true;

            Process uninstallProcess = Process.Start(uninstallProcessInfo);
            uninstallProcess.WaitForExit();
        }
        else
        {
            Console.WriteLine("FiveM uninstaller not found.");
        }
    }

    static string GetFiveMUninstallerPath()
    {
        string uninstallerPath = string.Empty;

        using (RegistryKey uninstallKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
        {
            if (uninstallKey != null)
            {
                foreach (string subKeyName in uninstallKey.GetSubKeyNames())
                {
                    using (RegistryKey subKey = uninstallKey.OpenSubKey(subKeyName))
                    {
                        string displayName = subKey.GetValue("DisplayName") as string;
                        if (!string.IsNullOrEmpty(displayName) && displayName.Equals("FiveM"))
                        {
                            uninstallerPath = subKey.GetValue("UninstallString") as string;
                            break;
                        }
                    }
                }
            }
        }

        return uninstallerPath;
    }

    static void DeleteFiveMRegistryEntries()
    {
        using (RegistryKey uninstallKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", true))
        {
            if (uninstallKey != null)
            {
                uninstallKey.DeleteSubKeyTree("{40F7E88C-70F5-456E-82E5-4B5F80C60542}", false);
            }
        }
    }
}
