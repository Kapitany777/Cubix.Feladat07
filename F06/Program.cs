using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace F06
{
    internal class Program
    {
        public static async Task<string> GetChuckNorrisJoke()
        {
            // API: https://api.chucknorris.io/

            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(@"https://api.chucknorris.io/jokes/random");
            }
        }

        public static async void PrintJoke()
        {
            string response = await GetChuckNorrisJoke();

            /*Console.WriteLine(response);
            Console.WriteLine();*/

            if (response != null)
            {
                var jsonData = JsonConvert.DeserializeObject(response) as JObject;
                Console.WriteLine(jsonData?["value"]);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            PrintJoke();

            Console.WriteLine("Waiting for response...");
            Console.ReadLine();
        }
    }
}