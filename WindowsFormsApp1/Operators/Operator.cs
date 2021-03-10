using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    abstract class Operator
    {
        public string name;
        public int priority;

        public Operator()
        {

        }

        virtual public double Calculate(ref My_Stack<double > stack)
        {
            return 0;
        }

    }
}
