using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FF8Utilities.Updater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Args[0] = Utilities folder
            // Args[1] = ZIP file of new update

            if (args.Length < 2) throw new ArgumentNullException("Invalid args");
            string utilitiesFolder = args[0];
            string updatePath = args[1];


            if (!Directory.Exists(utilitiesFolder)) throw new ArgumentException("Utilities not found");
            if (!File.Exists(updatePath)) throw new ArgumentException("Update not found");

            Process[] utilitiesProcesses = Process.GetProcessesByName("FF8Utilities");

            DateTime updatedStartedAt = DateTime.Now;
            while (utilitiesProcesses.Length > 0)
            {
                if (updatedStartedAt < DateTime.Now.AddSeconds(-20))
                {
                    // If it hasnt exited in 20 seconds something is wrong, break out
                    Console.WriteLine("Update failed. Pressing enter will open the download page in your browser to manually install");
                    Console.ReadLine();
                    Process.Start("https://github.com/Kiitoksia/FF8-Utilities/releases/latest");
                    Environment.Exit();
                }

                // Wait for utilities to close
                Thread.Sleep(250);
                utilitiesProcesses = Process.GetProcessesByName("FF8Utilities");
            }
            
            using (FileStream fs = File.OpenRead(updatePath))
            {
                using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Read, true))
                {
                    string rootFolder = zip.Entries[0].FullName.TrimEnd('/');


                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        if (string.IsNullOrEmpty(entry.Name)) continue;
                        string cleanedFilePath = entry.FullName.Substring(rootFolder.Length + 1);
                        if (string.IsNullOrEmpty(cleanedFilePath)) continue; // Root folder
                        string newFilePath = Path.Combine(utilitiesFolder, cleanedFilePath);
                        string newDirectoryName = Path.GetDirectoryName(newFilePath);
                        if (!Directory.Exists(newDirectoryName)) Directory.CreateDirectory(newDirectoryName);

                        entry.ExtractToFile(newFilePath, true);
                    }
                }
            }

            File.Delete(updatePath); // Cleanup
            Process.Start(Path.Combine(utilitiesFolder, "FF8Utilities.exe"));
            Environment.Exit(0);
        }
    }
}
