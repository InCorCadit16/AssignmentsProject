using System;
using System.IO;
using System.Security.Cryptography;

namespace Assignment13
{
    class Runtime
    {

        static DirectoryInfo Dir1, Dir2;
        static FileSystemWatcher Watcher1;

        static void Main(string[] args)
        {
            //Console.Write("Write first dir: ");
            //string Path1 = Console.ReadLine();
            string Path1 = @"C:\Users\alexandru.rosca\source\repos\AssignmentsProject\Assignment13\Assignment13\obj\Debug\netcoreapp3.1\dir1";
            Dir1 = new DirectoryInfo(Path1);

            Watcher1 = new FileSystemWatcher();
            Watcher1.Path = Path1;

            Watcher1.EnableRaisingEvents = true;

            Watcher1.Changed += new FileSystemEventHandler(OnChanged);
            Watcher1.Created += new FileSystemEventHandler(OnCreated);
            Watcher1.Renamed += new RenamedEventHandler(OnRenamed);
            Watcher1.Deleted += new FileSystemEventHandler(OnDeleted);


            //Console.Write("Write second dir: ");
            //string Path2 = Console.ReadLine();
            string Path2 = @"C:\Users\alexandru.rosca\source\repos\AssignmentsProject\Assignment13\Assignment13\obj\Debug\netcoreapp3.1\dir2";
            Dir2 = new DirectoryInfo(Path2);

            int i = 1;
            while (i != 0)
            {
                Console.WriteLine("0 - exit");
                Console.WriteLine("other - repeat this message");
                i = int.Parse(Console.ReadLine());
            }
        }

        
        

        static void OnChanged(object source, FileSystemEventArgs args)
        {
            FileInfo ChangedFile = new FileInfo(args.FullPath);
            FileStream ReadStream = null;
            
            try {
                ReadStream = ChangedFile.OpenRead();
                using FileStream WriteStream = File.OpenWrite($"{Dir2.FullName}\\{args.Name}");
                {
                    int offset = 0;
                    int count = 1024;
                    byte[] buffer = new byte[count];
                    while ((count = ReadStream.Read(buffer, offset, count)) > 0)
                        WriteStream.Write(buffer, offset, count);
                }
            } catch(IOException ioe)
            {
                Console.WriteLine(ioe.Message);
                ReadStream?.Close();
            }
            
        }

        static void OnCreated(object source, FileSystemEventArgs args)
        {
            FileInfo CreatedFile = new FileInfo(args.FullPath);
            File.Copy($"{Dir1.FullName}\\{args.Name}", $"{Dir2.FullName}\\{args.Name}", true);
            Console.WriteLine($"{args.Name} copied");
        }

        static void OnRenamed(object source, RenamedEventArgs args)
        {
            FileInfo CreatedFile = new FileInfo(args.FullPath);
            File.Move($"{Dir2.FullName}\\{args.OldName}", $"{Dir2.FullName}\\{args.Name}");
            Console.WriteLine($"{args.OldName} renamed to {args.Name}");
        }

        static void OnDeleted(object source, FileSystemEventArgs args)
        {
            new FileInfo($"{Dir2.FullName}\\{args.Name}").Delete();
            Console.WriteLine($"{args.Name} deleted");
        }


        static string CheckMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return md5.ComputeHash(stream).ToString();
                }
            }
        }
    }
}
