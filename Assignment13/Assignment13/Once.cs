using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
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
            string Path1 = @"dir1";
            Dir1 = new DirectoryInfo(Path1);

            //Console.Write("Write first dir: ");
            //string Path1 = Console.ReadLine();
            string Path2 = @"dir2";
            Dir2 = new DirectoryInfo(Path2);

            var options = new EnumerationOptions();
            options.RecurseSubdirectories = true;
            foreach (var file in Dir1.GetFiles("*", options))
            {
                FileInfo file2 = new FileInfo(file.FullName.Replace("dir1", "dir2"));
;                
                if (!file2.Exists)
                {
                    string newPaths = file.FullName.Replace($"{Dir1.FullName}", "").Replace($"\\{file.Name}", "");
                    DirectoryInfo directory = new DirectoryInfo(Dir2.FullName);
                    if (newPaths != "")
                    {
                        string[] subdirs = newPaths.Split('\\');
                        for (int i = 0; i < subdirs.Length; i++)
                            if (subdirs[i] != "")
                                directory = directory.CreateSubdirectory(subdirs[i]);
                    }
                        file.CopyTo($"{directory.FullName}\\{file.Name}");
                        Console.WriteLine($"{newPaths}\\{file.Name} copied");
                    
                }
                else
                {
                    Rewrite(file, file2);
                }
            }

            foreach (var file in Dir2.GetFiles("*", options))
            {
                FileInfo file2 = new FileInfo(file.FullName.Replace("dir2", "dir1"));
                if (!file2.Exists)
                {
                    file.Delete();
                    Console.WriteLine($"{file.Name} deleted");
                }
            }

            foreach (var directory in Dir2.GetDirectories("*", options))
            {
                DirectoryInfo directory2 = new DirectoryInfo(directory.FullName.Replace("dir2", "dir1"));

                if (!directory2.Exists)
                {
                    DirectoryInfo realDirectory = new DirectoryInfo(directory.FullName);
                    if (realDirectory.Exists)
                    {
                        realDirectory.Delete(true);
                    }
                    Console.WriteLine($"{directory.Name} path deleted");
                }
            }

        }

        static void Rewrite(FileInfo file1, FileInfo file2)
        {
            if (NeedToRewrite(GetMD5(file1), GetMD5(file2)))
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

        static byte[] GetMD5(FileInfo file)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = file.OpenRead())
                {
                    return md5.ComputeHash(stream);
                }
            }
        }

        static bool NeedToRewrite(byte[] first, byte[] second)
        {
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i]) return true;
            }
            return false;
        }

       
    }
}
