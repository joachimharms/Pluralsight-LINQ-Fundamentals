using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Playground01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var path = "C:/Windows";

            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("***");
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;

            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name,20} : {file.Length,0:N}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            var directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();

            Array.Sort(files, new FileComparer());
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{files[i].Name} : {files[i].Length}");
            }
        }
    }

    public class FileComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}