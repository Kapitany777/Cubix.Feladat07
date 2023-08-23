using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F03.MyFirstFramework
{
    public class ConditionResult
    {
        public bool Result { get; set; }

        public ConditionResult(bool result)
        {
            this.Result = result;
        }

        public void Then(Action ifTrue, Action ifFalse)
        {
            if (this.Result)
            {
                ifTrue();
            }
            else
            {
                ifFalse();
            }
        }
    }
}
