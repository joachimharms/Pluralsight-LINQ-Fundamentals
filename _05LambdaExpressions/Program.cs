namespace _05_LambdaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Authentication;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// Main program of the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Main method of the application.
        /// </summary>
        /// <param name="args">Default implementation.</param>
        private static void Main(string[] args)
        {
            var cities = new List<string>
            {
                "London",
                "Paris",
                "New York",
                "Berlin",
                "Lissabon",
                "Los Angeles",
                "Tokio",
                "Hong Kong",
                "Madrid",
                "Helsinki",
            };

            Console.WriteLine("1.Filtering mit Where mittels benannter Methode:");
            IEnumerable<string> filteredList =
                cities.Where(StartsWithL);

            foreach (var city in filteredList)
            {
                Console.WriteLine(city);
            }

            Console.WriteLine("\n2. Filtering über Where mit anonymer Methode:");
            IEnumerable<string> filteredCities =
            cities.Where(delegate (string s) { return StartsWithL(s); });

            foreach (var city in filteredCities)
            {
                Console.WriteLine(city);
            }

            Console.WriteLine("\n3. Filtering mit Lambda Expression Syntax:");
            IEnumerable<string> filteredListOfCities =
                cities.Where(s => s.StartsWithL());

            foreach (var city in filteredListOfCities)
            {
                Console.WriteLine(city);
            }
        }

        private static bool StartsWithL(this string name)
        {
            // if (name.StartsWith('L'))
            // {
            //      return true;
            // }
            // return false;
            return name.StartsWith('L');
        }
    }
}