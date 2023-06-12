using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Title = "Not working well (FiveM Unban) got from other github in .bat";
        Console.Clear();

        DeleteFile("%LocalAppData%\\FiveM\\FiveM.app\\discord.dll");
        DeleteDirectory("%userprofile%\\AppData\\Roaming\\discord\\0.0.309");
        RenameFile("%userprofile%\\AppData\\Roaming\\discord\\0.0.309\\modules\\VAULT", "discord_rpc");
        KillProcess("steam.exe");
        DeleteDirectory("%programfiles(x86)%\\Steam\\config");
        DeleteDirectory("%userprofile%\\AppData\\Roaming\\CitizenFX");
        DeleteDirectory("%LocalAppData%\\DigitalEntitlements");

        Environment.Exit(0);
    }

    static void DeleteFile(string path)
    {
        string expandedPath = Environment.ExpandEnvironmentVariables(path);
        File.Delete(expandedPath);
    }

    static void DeleteDirectory(string path)
    {
        string expandedPath = Environment.ExpandEnvironmentVariables(path);
        Directory.Delete(expandedPath, true);
    }

    static void RenameFile(string path, string newName)
    {
        string expandedPath = Environment.ExpandEnvironmentVariables(path);
        string expandedNewName = Environment.ExpandEnvironmentVariables(newName);
        File.Move(expandedPath, expandedNewName);
    }

    static void KillProcess(string processName)
    {
        Process[] processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processName));
        foreach (Process process in processes)
        {
            process.Kill();
        }
    }
}
