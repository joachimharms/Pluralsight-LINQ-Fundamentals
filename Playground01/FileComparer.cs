using System.Collections.Generic;
using System.IO;

namespace Playground01
{
    public class FileComparer : IComparer<FileInfo>
    {
        /// <summary>
        /// Compares two files on their lengths.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}