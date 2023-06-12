using System;
using System.IO;

class FindFolder {
    string app = "AppName";
    private void Main() {
          string Apppath = getPath(app);
          if (!string.IsNullOrEmpty(Apppath)) {
              MessageBox.Show(Apppath);
          } else {
              MessageBox.Show("Error, app folder of "+app+" not found");
          }
    }
    
    static string getPath(string appName) {
        string executableName = appName;
        string[] drives = Environment.GetLogicalDrives();

        foreach (string drive in drives) {
            string folderPath = FindRecursivePath(drive, executableName);
            if (!string.IsNullOrEmpty(folderPath)) {
                return folderPath;
            }
        }
        return null;
    }

    static string FindRecursivePath(string folderPath, string executableName) {
        try {
            string[] skippedFolders = { "$Recycle.Bin", "System Volume Information", "BUDA" };

            string folderName = Path.GetFileName(folderPath);
            if (Array.IndexOf(skippedFolders, folderName) >= 0) {
                return null;
            }

            string[] files = Directory.GetFiles(folderPath, executableName);
            if (files.Length > 0) {
                return folderPath;
            }

            string[] subdirectories = Directory.GetDirectories(folderPath);
            
            foreach (string subdirectory in subdirectories) {
                string foundPath = FindRecursivePath(subdirectory, executableName);
                if (!string.IsNullOrEmpty(foundPath)) {
                    return foundPath;
                }
            }
        } catch (UnauthorizedAccessException) {
            // Unathorized Folder
        } catch (Exception ex) {
            // Error in folder
        }

        return null;
    }
}
