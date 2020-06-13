namespace Pluralsight_LINQ_Fundamentals
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Comparer object compares filelength of two files.
    /// </summary>
    public sealed class FileComparer : IComparer<FileInfo>
    {
        /// <summary>
        /// Compares the length of two files.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        int IComparer<FileInfo>.Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}