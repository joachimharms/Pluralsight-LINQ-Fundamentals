using System.Collections.Generic;

namespace Playground02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Employee[] developers = new Employee[]
            //{
            //    new Employee{ Name = "Tarzan", Id="1" },
            //    new Employee { Name = "Tina", Id = "2" }
            //};

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee{ Name = "Tarzan", Id="1" },
                new Employee { Name = "Tina", Id = "2" }
            };

            IEnumerable<Employee> workers = new List<Employee>
            {
                new Employee{Name="Dorothea", Id="3"}
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

    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}