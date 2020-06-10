using System;
using System.Collections.Generic;

namespace _02_LINQ_Features
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //// ----------------------- Teil 1
            //Employee[] developers = new Employee[]
            //{
            //    new Employee{ Id = 1, Name="Scott"},
            //    new Employee{Id = 2, Name="Chris"}
            //};

            //List<Employee> sales = new List<Employee>
            //{
            //    new Employee{Id = 3, Name="Alex"}
            //};

            //foreach (var person in developers)
            //{
            //    Console.WriteLine(person.Name);
            //}

            //foreach (var person in sales)
            //{
            //    Console.WriteLine(person.Name);
            //}

            ////-------------------------- Teil 2
            //// Wir deklarieren ein Instanz vom Typ IEnumerable und können trotzdem darüber iterieren.
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee{Id = 1, Name = "Scott"},
                new Employee{Id = 2, Name = "Chris"}
            };

            IEnumerable<Employee> sales = new List<Employee>
            {
                new Employee{Id=3,Name="Alex"}
            };

            //foreach (var person in developers)
            //{
            //    Console.WriteLine(person.Name);
            //}

            //foreach (var person in sales)
            //{
            //    Console.WriteLine(person.Name);
            //}

            ////----------------------------- TEIL 3
            //// GetEnumerator Methodenaufruf liefert ein Enumerator<T>-Objekt welches über eine Collection iterieren kann.
            ////var enumerator = sales.GetEnumerator();
            //IEnumerator<Employee> enumerator = sales.GetEnumerator();

            //// sozusagen eine Foreach-Schleife auf die hare Tour:
            //while (enumerator.MoveNext())
            //{
            //    // Current ist ein Pointer auf das aktuelle Element über das das Enumertor<T> Objekt gerade iteriert.
            //    Console.WriteLine(enumerator.Current.Name);
            //}

            IEnumerator<Employee> enumerator = developers.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }
        }
    }
}