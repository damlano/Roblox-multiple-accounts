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
            string cookiesFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Roblox\LocalStorage\RobloxCookies.dat");
            bool apply773Fix = !(string.IsNullOrEmpty(cookiesFile) || !File.Exists(cookiesFile) || File.Exists(Path.Combine(Environment.CurrentDirectory, "no773fix.txt")));

            if (!apply773Fix)
            {
                Console.WriteLine($"Not applying 773 error fix | Cookies File Exists: {File.Exists(cookiesFile)} | User No Fix File Exists: {File.Exists(Path.Combine(Environment.CurrentDirectory, "no773fix.txt"))}");
            }

            if (apply773Fix)
            {
                try
                {
                    using (new FileStream(cookiesFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) { }
                }
                catch
                {
                    apply773Fix = false;
                }
            }

            using (apply773Fix ? new FileStream(cookiesFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None) : null)
            {
                try
                {
                    rbxMultiMutex = new Mutex(true, "ROBLOX_singletonMutex");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Environment.Exit(-1);
                }

                Console.WriteLine("You can now use as many roblox clients as your pc can handle!");
                Console.WriteLine("Press any key to close...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
