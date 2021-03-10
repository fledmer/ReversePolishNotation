using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Cos : Operator
    {
        public Cos(string name, int priority)
        {
            this.name = name;
            this.priority = priority;
        }
        public override double Calculate(ref My_Stack<double> stack)
        {
            return Math.Cos(stack.pop());
        }

    }
}
