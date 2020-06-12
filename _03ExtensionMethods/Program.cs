﻿using System;
using System.Collections.Generic;

namespace _03_ExtensionMethods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee{Id = 1, Name = "Scott"},
                new Employee{Id = 2, Name = "Chris"}
            };

            IEnumerable<Employee> sales = new List<Employee>
            {
                new Employee{Id=3,Name="Alex"}
            };

            // Stell dir vor LINQ würde keinen eigenen Count Operator haben und du müsstest deinen eigenen Count Operator
            // für IEnumerable<T> schreiben:
            //Console.WriteLine(MyLinq.Count(developers));
            Console.WriteLine(sales.Count()); // Würde der LINQ Namespace oben wieder einkommentiert, würde der Operator für die IEnumerable Schnittstelle wieder funktionieren.

            IEnumerator<Employee> enumerator = developers.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }
        }
    }
}