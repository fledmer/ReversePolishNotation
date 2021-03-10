﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Equality : Operator
    {
        public Equality(string name, int priority)
        {
            this.name = name;
            this.priority = priority;
        }
        public override double Calculate(ref My_Stack<double> stack)
        {
            return Convert.ToDouble(stack.pop() == stack.pop());
        }

    }
}
