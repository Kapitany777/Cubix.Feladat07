using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace F03.MyFirstFramework
{
    public static class RandomExtensions
    {
        public static ConditionResult If(this Random random, Func<Random, bool> condition) => new(condition(random));
    }
}
