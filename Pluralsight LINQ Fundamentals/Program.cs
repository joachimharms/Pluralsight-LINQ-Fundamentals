using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pluralsight_LINQ_Fundamentals
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string path = @"C:\Windows";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("***");
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            //// 1. Technik Query Syntax:
            //var query = from file in new DirectoryInfo(path).GetFiles()
            //            orderby file.Length descending
            //            select file;

            // 2. Technik:
            var query = new DirectoryInfo(path).GetFiles()
                .OrderByDescending(f => f.Length)
                .Take(5);

            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name,20} : {file.Length,10:N0}");
            }
        }

        private static void ShowLargeFilesWithLinqEigenerVersuch(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles();

            var result = from file in files
                         where file.Length > 1
                         select file;

            //Console.WriteLine(result[1].Name);
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles();

            Array.Sort(files, new FileComparer());

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{files[i].Name,20} : {files[i].Length,10:N0}");
            }
        }
    }

    public class FileComparer : IComparer<FileInfo>
    {
        int IComparer<FileInfo>.Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}