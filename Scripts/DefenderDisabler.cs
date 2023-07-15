using Microsoft.Win32;
using System;
using System.Diagnostics;

class DisableDefender {
    static void Main() {
        if (disableDefender()) {
            MessageBox.Show("Windows Defender was disabled");

        } else {
            MessageBox.Show("Failed to disable Windows defender");
        }
    }

    static bool disableDefender() {
        RegistryKey key1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender", true);
        key1.SetValue("DisableAntiSpyware", 1);
        if (key1.GetValue("DisableAntiSpyware").ToString() == "0")
        {
            return false;
        }
        else if (key1.GetValue("DisableAntiSpyware").ToString() == "1")
        {
            return true;
        }
        key1.Dispose();
    }
}
