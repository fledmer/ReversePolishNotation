using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
            List<Operator> operators = new List<Operator> {
            new Plus("+",2),
            new Minus("-",2),
            new Multiply("*",3),
            new Division("/",3),
            new Sin("sin",5),
            new Cos("cos",5),
            new Pow("^",4),
            new Equality("==",1),
            new Constants("pi",Math.PI)};
            ReversePolishNotation p1 = new ReversePolishNotation(textBox1.Text,operators);
            textBox2.Text = p1.polish_text;
            textBox3.Text = p1.Calculate();



        }

    }
}
