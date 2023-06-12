using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;

class runAsAdmin {
    static void Main() {
        if (!RunningAsAdmin()) {
            MessageBox.Show("Please run this app as admin", "github.com/ZeskGarcia");
            return;
        }
    }

    static bool RunningAsAdmin() {
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }
}
