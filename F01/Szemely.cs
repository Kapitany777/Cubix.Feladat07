using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F01
{
    public class Szemely
    {
        public int Id { get; set; }

        public string Vezeteknev { get; set; }

        public string Keresztnev { get; set; }
        
        public override string ToString()
        {
            return $"{Id} {Vezeteknev} {Keresztnev}";
        }
    }
}
