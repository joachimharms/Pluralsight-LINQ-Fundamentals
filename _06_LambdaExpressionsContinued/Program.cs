using System;
using System.Collections.Generic;
using System.Linq;
using _02_LINQ_Features;

namespace _06_LambdaExpressionsContinued
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Scott" },
                new Employee { Id = 2, Name = "Chris" }
            };

            IEnumerable<Employee> sales = new List<Employee>
             {
                new Employee { Id = 3, Name = "Alex" }
             };

            // foreach (var person in sales)
            // {
            //     Console.WriteLine(person.Name);
            // }

            // Filtering Examples mit LINQ Extensionmethode Where().
            // Named Method Technik:
            foreach (var person in developers.Where(StartsWithS))
            {
                Console.WriteLine(person.Name);
            }

            // Anonyme Methodenansatz. In einer Dataheavy Umgebung wirst du mit verschiedenste Named Methoden
            // schreiben. Um dieses Wirrwarr zu vermeiden, kannst du besser anonyme Methoden verwenden.
            // Anonyme Methoden Technik:
            foreach (var employee in developers.Where(
                delegate (Employee employee)
                {
                    return employee.Name.StartsWith("S");
                }))
            {
                Console.WriteLine(employee.Name);
            }

            //// Da die anonyme Methodentechnik wirklich eine unübersichtliche Syntax hat, siehe Code über mir, haben die MS Entwickler
            //// schwer überlegt wie sie diese anonyme Methodensyntax für das Filtern mit Where vereinfachen können.
            //// Lambda Expression Syntax Technik.
            //// 1. Entwicklungsstufe Lambda: Der C# Compiler weiß dass es sich in obiger anonymen Methode um ein delegate-Typen handeln muss.
            //// Darum war der erste Schritt zur Vereinfachung der anonymen Methoden Syntax das Keyword delegat loszuwerden, da der C# Compiler
            /// weiß, dass die Where Methode ein Delegate Objekt erwartet, kann genauso gut auf das keyword delegate verzichtet werden:

            // foreach (var employee in developers.Where(
            //    (Employee employee)
            //    {
            //        return employee.Name.StartsWith("S");
            //    }
            //    ))
            // {
            //    Console.WriteLine(employee.Name);
            // }

            // 2. Entwicklungschritt: Der C# Compiler ist ebenfalls schlau genug zu wissen, dass da die Where Methode auf eine Sequenz von
            // Employee aufgerufen wird, als Parameter ein Objekt vom Typ Employee erwartet wird.

            // foreach (var employee in developers.Where(
            //    employee
            //    {
            //        return employee.Name.StartsWith("S");
            //    }
            //    ))
            // {
            //    Console.WriteLine(employee.Name);
            // }

            // 3. Entwicklungsschritt Lambda Expression Syntax: Der C# Compiler weiß außerdem, dass als Rückgabewert an die Where Methode ein
            // boolscher Wert erwartet wird. Das heißt wir können sogar auf das return keyword verzichten. Und im Verlauf dieses Überarbeitens
            // sehen wir, dass wir auch noch auf das Semikolon und einige geschwungene Klammern verzichten können zur Vereinfachung der Sprache.
            // Schlußendlich fehlt nur noch der Lambda GoesTo Operator => um aus unserer ursprüuglich sperrigen anonymen Methodensyntax einen
            // vollwertigen kurzen Lambdaausdruck zu machen.
            foreach (var employee in developers.Where(
               employee => employee.Name.StartsWith("S")))
            {
                Console.WriteLine(employee.Name);
            }

            // 4. Entwicklungschritt um die Lamdaschreibweise noch knackiger und präziser zu machen hat sich durchgesetzt den Bezeichner
            // nur noch mit einem Buchstaben zu kennzeichnen, da jeder weiß, dass es sich um ein employee handelt, kann man den auch
            // verkürzt schreiben. Nun haben wir die vollständige Lambdasyntax. Die Methode funktioniert dabei weiterhin genauso, wie die
            // alernativ Schreibweise mit Anonymer Methodentechnik. Es ist praktisch dieselbe Methode nur mit kürzerer und prägnanter Syntax.
            foreach (var employee in developers.Where(
               e => e.Name.StartsWith("S")))
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static bool StartsWithS(Employee employee)
        {
            return employee.Name.StartsWith("S");
        }
    }
}