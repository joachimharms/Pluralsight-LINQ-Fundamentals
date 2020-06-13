using System.Collections.Generic;

namespace Playground02
{
    /// <summary>
    /// Hauptprogramm der Anwendung.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Hauptmethode der Anwendung.
        /// </summary>
        /// <param name="args">Default implementation</param>
        private static void Main(string[] args)
        {
            // Employee[] developers = new Employee[]
            // {
            //    new Employee{ Name = "Tarzan", Id="1" },
            //    new Employee { Name = "Tina", Id = "2" }
            // };
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Name = "Tarzan", Id = "1" },
                new Employee { Name = "Tina", Id = "2" },
            };

            IEnumerable<Employee> workers = new List<Employee>
            {
                new Employee { Name = "Dorothea", Id = "3" }
            };

            foreach (var developer in developers)
            {
                System.Console.WriteLine(developer.Name + "," + developer.Id);
            }

            foreach (var worker in workers)
            {
                System.Console.WriteLine(worker.Name + " , " + worker.Id);
            }

            foreach (var worker in workers)
            {
                System.Console.WriteLine(worker.Name);
                System.Console.WriteLine(workers.GetType());
            }

            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                System.Console.WriteLine();
            }
        }
    }
}