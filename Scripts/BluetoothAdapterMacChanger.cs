using System;
using System.Management;
using System.Windows.Forms;

class BtMacChanger {
    static void Main() {

        string oldMacAddress = GetBluetoothMacAddress();
        MessageBox.Show("Old Bluetooth MAC address: " + oldMacAddress);
        string newMacAddress = GenerateRandomMacAddress();
        ChangeBluetoothMacAddress(newMacAddress);
        MessageBox.Show("New Bluetooth MAC address: " + newMacAddress);
    }

    private string GetBluetoothMacAddress()
        {
            ManagementClass btClass = new ManagementClass("Win32_NetworkAdapter");
            ManagementObjectCollection btDevices = btClass.GetInstances();

            foreach (ManagementObject btDevice in btDevices)
            {
                if (btDevice["Name"].ToString().Contains("Bluetooth"))
                {
                    return btDevice["MACAddress"].ToString();
                }
            }

            return string.Empty;
        }

        private void ChangeBluetoothMacAddress(string newMacAddress)
        {
            ManagementClass btClass = new ManagementClass("Win32_NetworkAdapter");
            ManagementObjectCollection btDevices = btClass.GetInstances();

            foreach (ManagementObject btDevice in btDevices)
            {
                if (btDevice["Name"].ToString().Contains("Bluetooth"))
                {
                    btDevice.InvokeMethod("SetMACAddress", new object[] { newMacAddress });
                }
            }
        }

        private string GenerateRandomMacAddress()
        {
            byte[] macBytes = new byte[6];
            Random random = new Random();
            random.NextBytes(macBytes);

            macBytes[0] = (byte)(macBytes[0] & 0xFE);
            macBytes[0] = (byte)(macBytes[0] | 0x02);

            string macAddress = string.Join(":", macBytes);

            return macAddress;
        }
}
