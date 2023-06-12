using System;
using System.Diagnostics;

class IPAddressRenewalScript
{
    static void Main()
    {
        ReleaseIPAddress();
        RenewIPAddress();

        Console.WriteLine("IP address has been released and renewed.");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void ReleaseIPAddress()
    {
        ExecuteCommand("ipconfig /release");
    }

    static void RenewIPAddress()
    {
        ExecuteCommand("ipconfig /renew");
    }

    static void ExecuteCommand(string command)
    {
        ProcessStartInfo processInfo = new ProcessStartInfo();
        processInfo.FileName = "cmd.exe";
        processInfo.Arguments = "/c " + command;
        processInfo.RedirectStandardOutput = true;
        processInfo.UseShellExecute = false;
        processInfo.CreateNoWindow = true;

        Process process = new Process();
        process.StartInfo = processInfo;
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);

        process.WaitForExit();
    }
}
