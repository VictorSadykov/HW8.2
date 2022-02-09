using System;
using System.IO;

namespace HW8._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\test";
            var dirSize = GetDirectorySize(path);
            Console.WriteLine($"Размер папки по пути:{path}\n{dirSize} байт.");
        }

        static long GetDirectorySize(string path, long output = 0)
        {
            var directory = new DirectoryInfo(path);


            if (directory.Exists)
            {
                var dirs = directory.GetDirectories();
                var files = directory.GetFiles();

                foreach (var file in files)
                {
                    try
                    {
                        output += file.Length;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                foreach (var dir in dirs)
                {
                    try
                    {
                        output += GetDirectorySize(dir.FullName, output);

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }

                
            }

            return output;
        }
    }
}
