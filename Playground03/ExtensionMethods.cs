using System.Collections.Generic;

namespace Playground03
{
    /// <summary>
    /// Class for holding extension methods against IEnumerable types.
    /// </summary>
    public static class ExtensionMethods
    {
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            var counter = 0;
            var enumerator = sequence.GetEnumerator();
            while (enumerator.MoveNext())
            {
                counter++;
            }

            return counter;
        }
    }
}