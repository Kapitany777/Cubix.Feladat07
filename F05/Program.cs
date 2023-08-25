using System.IO.Compression;

namespace F05
{
    internal class Program
    {
        static void ZipCurrentDirectory()
        {
            Console.WriteLine("Zipping current directory...");

            string currentDirectory = Directory.GetCurrentDirectory();
            string zipFileName = $"{currentDirectory}.zip";

            Console.WriteLine($"{currentDirectory} -> {zipFileName}");

            ZipFile.CreateFromDirectory(currentDirectory, zipFileName);

            Console.WriteLine("Ready");
        }

        static void ZipAFile(string fileName)
        {
            // TODO: egy adott file tömörítése
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Zipper application");

            try
            {
                if (args.Length == 0)
                {
                    ZipCurrentDirectory();
                }
                else
                {
                    ZipAFile(args[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }
    }
}