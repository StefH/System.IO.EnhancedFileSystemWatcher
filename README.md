# System.IO.EnhancedFileSystemWatcher
An EnhancedFileSystemWatcher, which can be used to suppress duplicate events that fire on a single change to the file.

This project is based on [Enhanced-FileSystemWatcher](https://www.codeproject.com/Articles/102493/Enhanced-FileSystemWatcher) which was written by [Vipul Prashar](https://www.codeproject.com/script/Membership/View.aspx?mid=1561441).

## NuGet
[![NuGet Badge](https://buildstats.info/nuget/System.IO.EnhancedFileSystemWatcher)](https://www.nuget.org/packages/System.IO.EnhancedFileSystemWatcher) 

## Frameworks
The following frameworks are supported:
- net 2.0
- net 4.5 and up
- netstandard 1.3
- netstandard 2.0

# Information

## Introduction
This article discusses an enhanced FileSystemWatcher class which can be used to suppress duplicate events that fire on a single change to the file.

## Background
System.IO.FileSystemWatcher class helps the user to monitor a directory and multiple or single file within a directory. Whenever a change (Creation, Modification, Deletion or Renaming) is detected, an appropriate event is raised. However, duplicate events fire depending on the software that is being used to modify the file.


## Observation
Using Notepad, modifying the contents of a file results in 2 Changed events being fired. Doing the same using Textpad results in 4 Changed events being fired.

Using Textpad, creating a file in a directory that was being watched resulted in 1 Created and 3 Changed events being fired. In case of Notepad, Created followed by Deleted!!, followed by Created and 3 Changed Events were observed.

## Proposed Solution
We need to keep track of the event as they get fired and suppress subsequent events that occur within pre-determined interval.

## Example
``` charp
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
```
