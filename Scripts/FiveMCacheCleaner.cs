using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.Title = "FiveM Tools";
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine("Press Any Key to optimize FiveM and Clear the cache");
        Console.ReadKey(true);
        Console.Clear();

        Console.WriteLine("Clearing FiveM Cache...");
        System.Threading.Thread.Sleep(1000);
        DeleteDirectory("%LocalAppData%\\FiveM\\FiveM.app\\cache\\browser");
        DeleteDirectory("%LocalAppData%\\FiveM\\FiveM.app\\cache\\db");
        DeleteDirectory("%LocalAppData%\\FiveM\\FiveM.app\\cache\\priv");
        DeleteDirectory("%LocalAppData%\\FiveM\\FiveM.app\\cache\\servers");
        DeleteDirectory("%LocalAppData%\\FiveM\\FiveM.app\\cache\\subprocess");
        DeleteDirectory("%LocalAppData%\\FiveM\\FiveM.app\\cache\\unconfirmed");
        DeleteFile("%LocalAppData%\\FiveM\\FiveM.app\\crashometry");
        DeleteFile("%LocalAppData%\\FiveM\\FiveM.app\\launcher_skip_mtl2");
        DeleteFile("%LocalAppData%\\FiveM\\FiveM.app\\session");
        DeleteDirectory("%LocalAppData%\\FiveM\\FiveM.app\\plugins");
        DeleteDirectory("%LocalAppData%\\FiveM\\FiveM.app\\mods");
        DeleteDirectory("%LocalAppData%\\FiveM\\FiveM.app\\logs");
        DeleteDirectory("%LocalAppData%\\FiveM\\FiveM.app\\crashes");
        DeleteFile("%LocalAppData%\\FiveM\\FiveM.app\\caches.XML");
        DeleteFile("%LocalAppData%\\FiveM\\FiveM.app\\adhesive.dll");

        Console.WriteLine("Optimizing Your Computer for FiveM...");
        System.Threading.Thread.Sleep(1000);
        RunCommand("powercfg -s 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c");
        KillProcess("GTAVLauncher.exe");
        SetProcessPriority("FiveM.exe", 128);
        SetProcessPriority("FiveM_b2189_GTAProcess.exe", 128);
        KillProcess("wmpnetwk.exe");
        KillProcess("OneDrive.exe");
        KillProcess("speedfan.exe");
        KillProcess("TeamWiever_Service.exe");
        KillProcess("opera.exe");
        KillProcess("java.exe");

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
       
        Console.WriteLine("Cache cleaned");

        System.Threading.Thread.Sleep(10000);
    }

    static void DeleteDirectory(string path)
    {
        string command = $"cmd.exe /c rmdir /s /q \"{path}\"";
        RunCommand(command);
    }

    static void DeleteFile(string path)
    {
        string command = $"cmd.exe /c del /s /q /f \"{path}\"";
        RunCommand(command);
    }

    static void RunCommand(string command)
    {
        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = $"/c {command}";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
        process.WaitForExit();
    }

    static void KillProcess(string processName)
    {
        Process[] processes = Process.GetProcessesByName(processName);
        foreach (Process process in processes)
        {
            process.Kill();
        }
    }

    static void SetProcessPriority(string processName, int priority)
    {
        Process[] processes = Process.GetProcessesByName(processName);
        foreach (Process process in processes)
        {
            process.PriorityClass = (ProcessPriorityClass)priority;
        }
    }
}
