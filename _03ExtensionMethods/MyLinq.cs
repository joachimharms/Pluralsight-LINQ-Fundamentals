using System.Collections.Generic;

namespace _03_ExtensionMethods
{
    public static class MyLinq
    {
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            int counter = 0;
            foreach (var item in sequence)
            {
                counter++;
            }

            return counter;
        }
    }
}