using F02.Library;
using System;
using System.Data;
using System.Reflection;

namespace F02
{
    internal class Program
    {
        static void LibraryInfo()
        {
            var libTypes = typeof(ILeirhato)
                .Assembly
                .GetTypes()
                .Where(t => t.Namespace == "F02.Library")
                .OrderBy(t => t.Name);

            foreach (var libType in libTypes)
            {
                Console.WriteLine($"{libType.Namespace} / {libType.Name}");

                var libMethods = libType
                    .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Where(m => !m.IsSpecialName)
                    .OrderBy(m => m.Name);

                foreach (var method in libMethods)
                {
                    Console.WriteLine($"\t{method.Name}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static void ListInfo()
        {
            var listType = typeof(List<int>);

            Console.WriteLine($"{listType.Namespace} / {listType.Name}");

            var listProperties = listType
                .GetProperties()
                .OrderBy(p => p.Name);

            foreach (var property in listProperties)
            {
                Console.WriteLine($"\t{property.Name}");
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            LibraryInfo();
            ListInfo();
        }
    }
}