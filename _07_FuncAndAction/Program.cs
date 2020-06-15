using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_FuncAndAction
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
                new Employee { Id = 3, Name = "Alex" },
            };

            //// ***Func***
            // Beispiel 1: Func zeigt auf benannte Methode.
            Func<int, int> f = Square;
            Console.WriteLine(f(3));

            // Beispiel 2: Bevorzugte Technik für Func Types besonders
            // bei Verwendung mit Linq sind Lamda Ausdrücke anstatt benannter Methoden.
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(3));

            // Leicht andere Syntax bei zwei Eingabeparametern. Die übergebenen Parameter müssen nun geklammert
            // werden. Nur bei einem Übergabeparameter darf die Klammer weggelassen werden. Zeigt der Func auf
            // eine Methode mit keinen Übergabeparametern oder mit mehr als einem Übergabeparameter kann auf die
            // Klammerung der Übergabeparameter nicht verzichtet werden.
            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine(add(3, 6));

            // Quadriere die Summe der Addition und gebe an der Konsole aus:
            Console.WriteLine(square(add(3, 5)));

            // Es ist ebenfalls zulässig die Methode mit expliziten Datentypen zu implementieren:
            Func<int, int, int> addNew = (int x, int y) => x + y;
            Console.WriteLine(addNew(3, 6));

            // Es ist ebenfalls zulässig statt einzeilige Lambdasyntax zu verwenden, geschwungene Klammern
            // einzufügen, wenn es der Anwendungsfall für komplizierteren Code bedarf:
            Func<int, int, int> addWithBraces = (x, y) =>
            {
                // Do something:
                int temp = x + y;

                // Sobald du geschwungene Klammer Syntax einführst musst du auch das keyword return verwenden:
                return temp;
            };

            //// ***Action***
            // Eine Action gibt nur void zurück:
            Action<int> write = x => Console.WriteLine(x);
            write(9);

            // Kombination aus ein Action und zwei Func Delegaten:
            write(square(add(3, 5)));

            //// ***Teil 3***
            Console.WriteLine("\n***Filtering and sorting***");
            foreach (var developer in developers)
            {
                Console.WriteLine(developer.Name);
            }

            // Für einen Report brauchen wir die Namen aller Developer deren Namen aus fünf Buchstaben besteht in alphabetischer Reihenfolge.
            foreach (var developer in developers.Where(e => e.Name.Length == 5)
                                                 .OrderBy(e => e.Name))
            {
                Console.WriteLine(developer.Name);
            }

            //// Teil 4 var keyword.
            Console.WriteLine("\n***var keyword***");

            // In Linq wird das keyword häufig verwendet.
            var name = "Scott";
            var x = 3.0;
            var y = 2;
            var z = x * y;

            // Das keyword var bedeutet nicht etwa dass wir dadurch dynamische Typisierung
            // oder eine ähnliche Technik verwenden. Die Variable ist trotzdem stark typisiert.
            // Die starke Typisierung in C# bleibt weiterhin eingehalten. Der Compiler kann
            // sich den Typ einer Variablen automatisch ableiten. So können wir auf den Typen
            // testen:
            // All lines print "TRUE".
            Console.WriteLine(name is string);
            Console.WriteLine(x is double);
            Console.WriteLine(y is int);
            Console.WriteLine(z is double);

            // 5. Teil Query Syntax Einführung. Die obige foreach Schleif kann so etwas
            // lesbarer gemacht werden:
            var query = developers.Where(e => e.Name.Length == 5)
                                   .OrderBy(e => e.Name);

            foreach (var employee in query)
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static int Square(int arg)
        {
            return arg * arg;
        }
    }
}