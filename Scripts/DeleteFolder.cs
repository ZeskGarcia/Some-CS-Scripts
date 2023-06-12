using System;
using System.IO;

class FolderDeleter {
    private void pathFolder() {
        string tempPath = Path.GetTempPath();
        string[] tempFiles = Directory.GetFiles(tempPath);

        int totalFiles = tempFiles.Length;
        int processedFiles = 0;
        MessageBox.Show("Deleting " + totalFiles + " temp files", "github.com/ZeskGarcia");
        
        foreach (string file in tempFiles) {
            try {
                // Delete file
                File.Delete(file);

                // Add Processed files count
                processedFiles++;
                // Custom code + Optional Loader

                // double progress = (double)processedFiles / totalFiles * 100;

            } catch (Exception ex) {
                // Add Custom code for error.
            }
        }
    }

    private void customFolder() {
        string folderPath = @"C:\CUSTOMPATH";
        try {
            Directory.Delete(folderPath, true);
        } catch (Exception ex) {
            // Directory could not be deleted
        }
    }
}
