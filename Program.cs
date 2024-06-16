using System;
using System.IO;
using Microsoft.Win32;

namespace RobloxMultipleInstances
{
    class Program
    {
        private static Mutex rbxMultiMutex;
        static void Main(string[] args)
        {
            string CookiesFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Roblox\LocalStorage\RobloxCookies.dat");
            bool Apply773Fix = !(string.IsNullOrEmpty(CookiesFile) || !File.Exists(CookiesFile) || File.Exists(Path.Combine(Environment.CurrentDirectory, "no773fix.txt")));

            if (!Apply773Fix) Console.WriteLine($"Not applying 773 error fix | Cookies File Exists: {File.Exists(CookiesFile)} | User No Fix File Exists: {File.Exists(Path.Combine(Environment.CurrentDirectory, "no773fix.txt"))}");

            if (Apply773Fix) try { using (new FileStream(CookiesFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { } } catch { Apply773Fix = false; } // Check if the file is already locked by another program

            using (Apply773Fix ? new FileStream(CookiesFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None) : null)
                    {
                    
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\Classes\roblox\shell\open\command";
            string valueName = "";
            object testValue = Registry.GetValue(keyPath, valueName, null);
            string path = testValue?.ToString();

            if (path!= null && path.Contains(@"\version-"))
            {
                path = path.Split(new[] { @"\version-" }, StringSplitOptions.None)[0];
            }

            path = path.TrimStart('"');

            foreach (var directory in Directory.GetDirectories(path))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directory);
                if (dirInfo.Name.StartsWith("version-", StringComparison.OrdinalIgnoreCase))
                {
                    bool fileFound = dirInfo.GetFiles("RobloxPlayerInstaller.exe", SearchOption.TopDirectoryOnly).Length > 0;
                    if (fileFound)
                    {
                            File.Delete(Path.Combine(directory, "RobloxPlayerInstaller.exe"));
                    }
                }
            }
            rbxMultiMutex = new Mutex(true, "ROBLOX_singletonMutex");
            Console.WriteLine("You can now use as many roblox clients as your pc can handle!");
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
        }
    }
}
