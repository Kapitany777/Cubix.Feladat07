namespace F07
{
    internal class Program
    {
        static void PrintKeys(Dictionary<char, int> key)
        {
            foreach (var k in key)
            {
                Console.Write($"{k.Key} {k.Value} \t");
            }

            Console.WriteLine();
        }

        static void PrintLookup(string lookup, Dictionary<char, int> key)
        {
            Console.WriteLine(lookup);
            Console.WriteLine();

            for (char c = 'a'; c <= 'z'; c++)
            {
                try
                {
                    Console.Write($"{c} -> {lookup[key[c]]} | ");
                    Console.Write($"{char.ToUpper(c)} -> {lookup[key[char.ToUpper(c)]]} | ");
                }
                catch { }
            }

            Console.WriteLine();
        }

        private static void Decipher(string result, string[] args, Dictionary<char, int> key, string lookup)
        {
            foreach (var rc in result)
            {
                foreach (var c in args[0])
                {
                    if (lookup[key[c]] == rc)
                    {
                        Console.Write(c);
                        break;
                    }
                }
            }

            Console.WriteLine();
        }

        static void Main(string[] args1)
        {
            var args = new[]
            {
                "shayepib,u_fldntCowvmTrg!c",
                "This_is_a_substitution_cypher,_even_Ceasar_would_be_proud",
                "Congrats,_hope_you_had_a_fine_time_deciphering!"
            };

            var key = args[0]
                .Select((c, i) => (c, i))
                .ToDictionary(e => e.c, e => e.i);

            // PrintKeys(key);

            var lookup = new string(args[0].Reverse().ToArray());

            // PrintLookup(lookup, key);

            Console.WriteLine(
                string.Join('\n',
                args
                .Skip(1)
                .Select(code => new string(code.Select(c => lookup[key[c]]).ToArray()))));

            Console.WriteLine();

            string result1 = "e!vctvctgtcCwc_v_C_v,ftsrm!TyotTiTftuTgcgytb,CdltwTtmy,Cl";
            Decipher(result1, args, key, lookup);

            string result2 = "u,fayg_cot!,mTtr,Ct!gltgtnvfTt_vpTtlTsvm!Tyvfah";
            Decipher(result2, args, key, lookup);
        }
    }
}
