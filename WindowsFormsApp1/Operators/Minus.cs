using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Minus:Operator
    {
        public Minus(string name, int priority)
        {
            this.name = name;
            this.priority = priority;
        }

        public override double Calculate(ref My_Stack<double> stack)
        {
            double a = stack.pop();
            if (stack.is_empty())
                return -a;
            double b = stack.pop();
            return b-a;
        }
    }
}
