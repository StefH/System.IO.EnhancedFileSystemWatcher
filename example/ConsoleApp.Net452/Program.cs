using System;
using System.IO;

namespace ConsoleApp.Net452
{
    class Program
    {
        static void Main(string[] args)
        {
            var fsw = new EnhancedFileSystemWatcher(@"C:\temp", "*.txt");
            fsw.Created += fsw_Created;
            fsw.Changed += fsw_Changed;
            fsw.Deleted += fsw_Deleted;
            fsw.Renamed += fsw_Renamed;
            fsw.EnableRaisingEvents = true;

            Console.WriteLine("Waiting for things to happen in C:\\temp");
            Console.ReadLine();
        }

        static void fsw_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("Renamed: FileName - {0}, ChangeType - {1}, Old FileName - {2}", e.Name, e.ChangeType, e.OldName);
        }

        static void fsw_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Deleted: FileName - {0}, ChangeType - {1}", e.Name, e.ChangeType);
        }

        static void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Changed: FileName - {0}, ChangeType - {1}", e.Name, e.ChangeType);
        }

        static void fsw_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Created: FileName - {0}, ChangeType - {1}", e.Name, e.ChangeType);
        }
    }
}