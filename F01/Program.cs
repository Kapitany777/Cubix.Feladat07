using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;

namespace F01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CsvHelper teszt");

            try
            {
                using var reader = new StreamReader("data.csv");
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var records = csv.GetRecords<Szemely>();

                foreach (var item in records)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}