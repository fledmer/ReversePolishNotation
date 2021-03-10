using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class u_Multi:Operator
    {
        public u_Multi(string name, int priority)
        {
            this.name = name;
            this.priority = priority;
        }
        public override double Calculate(ref My_Stack<double> stack)
        {
            return -1 * stack.pop();
        }
    }
}
