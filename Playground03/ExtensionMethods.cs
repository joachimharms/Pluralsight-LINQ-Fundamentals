using _03_ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Playground03
{
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