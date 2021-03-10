using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Constants:Operator
    {
        private double value;
        public Constants(string name,double value)
        {
            this.name = name;
            this.value = value;
            priority = int.MaxValue - 1;
        }

        public override double Calculate(ref My_Stack<double> stack)
        {
            return value;
        }
    }
}
