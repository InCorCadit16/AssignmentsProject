using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assignment13
{
    

    class Once
    {

        static DirectoryInfo Dir1, Dir2;


        static void Main(string[] args)
        {
            //Console.Write("Write first dir: ");
            //string Path1 = Console.ReadLine();
            string Path1 = @"C:\Users\alexandru.rosca\source\repos\AssignmentsProject\Assignment13\Assignment13\obj\Debug\netcoreapp3.1\dir1";
            Dir1 = new DirectoryInfo(Path1);

            //Console.Write("Write first dir: ");
            //string Path1 = Console.ReadLine();
            string Path2 = @"C:\Users\alexandru.rosca\source\repos\AssignmentsProject\Assignment13\Assignment13\obj\Debug\netcoreapp3.1\dir2";
            Dir2 = new DirectoryInfo(Path2);

            var options = new EnumerationOptions();
            options.RecurseSubdirectories = true;
            foreach (var file in Dir1.GetFiles("*", options))
            {
                FileInfo[] matches = Dir2.GetFiles(file.Name, options);
                if (matches.Length == 0)
                {
                    string[] subdirs = file.FullName.Replace("dir1","dir2").Replace(Dir2.FullName, "").Split('\\');
                    DirectoryInfo directory = new DirectoryInfo(Dir2.FullName);
                    for (int i = 1; i < subdirs.Length - 1; i++)
                        directory = directory.CreateSubdirectory(subdirs[i]);
                    
                    file.CopyTo($"{directory.FullName}\\{file.Name}");
                    Console.WriteLine($"{file.Name} copied");
                }
                else
                {
                    Rewrite(file, matches[0]);
                }
            }

            foreach (var file in Dir2.GetFiles("*", options))
            {
                FileInfo[] matches = Dir1.GetFiles(file.Name, options);
                if (matches.Length == 0)
                {
                    foreach (var matchedFile in matches)
                    {
                        if (matchedFile.FullName.Replace("dir2","dir1") == file.FullName)
                        {
                            file.Delete();
                            Console.WriteLine($"{file.Name} deleted");
                        }
                    }
                }
            }

        }

        static void Rewrite(FileInfo file1, FileInfo file2)
        {
            using FileStream Reader = file1.OpenRead();
            {
                using FileStream Writer = file2.OpenWrite();
                {
                    int offset = 0;
                    int count = 1024;
                    byte[] buffer = new byte[count];
                    while ((count = Reader.Read(buffer, offset, count)) > 0)
                        Writer.Write(buffer, offset, count);
                }
            }
            Console.WriteLine($"{file2.Name} changed");
        }

    }
}
