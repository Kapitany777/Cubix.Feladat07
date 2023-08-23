using F03.Library;
using F03.MyFirstFramework;
using static System.Console;

namespace F03
{
    internal class Program
    {
        static void RandomDemo()
        {
            WriteLine("Random extension demo");

            new Random()
                .If(r => r.Next(2) == 0)
                .Then(ifTrue: () => WriteLine("Bal"), ifFalse: () => WriteLine("Jobb"));

            WriteLine();
        }
        
        static void VectorDemo()
        {
            WriteLine("Vector demo");

            var v1 = new Vector2D(0.0, 0.0);
            WriteLine($"v1 = {v1}, v1.Length = {v1.Length}");

            var v2 = new Vector2D(3.0, 4.0);
            WriteLine($"v2 = {v2}, v2.Length = {v2.Length}");

            WriteLine();
        }

        static void Main(string[] args)
        {
            RandomDemo();

            VectorDemo();
        }
    }
}