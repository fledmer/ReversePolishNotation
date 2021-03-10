using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Pow:Operator
    {
        public Pow(string name, int priority)
        {
            this.name = name;
            this.priority = priority;
        }
        public override double Calculate(ref My_Stack<double> stack)
        {
            double a = stack.pop();
            return Math.Pow(stack.pop(),a);
        }
    }
}
