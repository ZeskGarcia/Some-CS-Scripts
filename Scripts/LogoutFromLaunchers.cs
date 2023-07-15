using System;
using System.Diagnostics;
using System.IO;

class LogoutFromSteamAndRockstar {

    
    static void Main() {
        // MessageBox.Show("Logging out from steam", "Noxius Unban");
        CloseProcess("FiveM");
        Process.Start("steam://logout");

        string rockstarLauncherPath = getAppDir("RockstarGamesLauncher");
        if (!string.IsNullOrEmpty(rockstarLauncherPath)) {
            Process.Start(rockstarLauncherPath, "--command=logout");
            // Process finished
        } else {
            // Could not find rockstar games launcher
        }
    }
    
    static void deleteFiveMData() {
        // DigitalEntitlements
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string dEPath = Path.Combine(appDataPath, "DigitalEntitlements");
        if (Directory.Exists(dEPath)) { Directory.Delete(dEPath, true); }

        // Soon More
    }

    static string getAppDir(string appName) {
        if (appName == "RockstarGamesLauncher") {
            string programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            string rockstarLauncherPath = Path.Combine(programFilesPath, "Rockstar Games", "Launcher", "Launcher.exe");

            if (File.Exists(rockstarLauncherPath)) {
                return rockstarLauncherPath;
            }
            
            return null;
        }

        return null;
    }

    static void CloseProcess(string appName) {
        Process[] appProcess = Process.GetProcessesByName(appName);
        foreach (Process process in appProcess) {
            process.CloseMainWindow();
            process.WaitForExit();
        }
    }
}
