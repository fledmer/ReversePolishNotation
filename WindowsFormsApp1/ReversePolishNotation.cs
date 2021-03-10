using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class ReversePolishNotation
    {
        public string polish_text = "";
        public string text = "";
        My_Stack<string> string_stack;
        My_Stack<double> int_stack;
        List<Operator> operators;

        public ReversePolishNotation(string text,List<Operator> operators)
        {
            for(int x = 0; x < text.Length;x++)
            {
                if(text[x]=='-')
                {
                    if (x > 0 && !char.IsNumber(text[x - 1]))
                    {
                        text = text.Substring(0, x) + "$" + text.Substring(x + 1, text.Length - x - 1);
                    }
                }
            }

            this.operators = operators;
            this.operators.Add(new u_Multi("$", int.MaxValue ));
            string s_operator = "";
            this.text = text;
            string_stack = new My_Stack<string>(text.Length);
            text.Replace(" ", "");
            for (int x = 0; x < text.Length;x++)
            {
                if (char.IsDigit(text[x]) || text[x] == ',')
                {
                    if (s_operator != "")
                    {
                        AddOp(s_operator);
                        s_operator = "";
                    }
                    polish_text += text[x];
                }
                else if (text[x] == ')')
                {
                    try
                    {
                        for (string s = string_stack.pop(); s != "("; s = string_stack.pop())   //выгружаем стек
                        {
                            polish_text += " " +s;
                        }
                    }
                    catch
                    {
                        //return;
                        throw new Exception("Целостность скобок нарушена !");
                    }
                }
                else if (text[x] == '(')
                {
                    if (s_operator != "")
                    {
                        AddOp(s_operator);
                        s_operator = "";
                    }
                    string_stack.push("(");
                }
                else
                {
                    if (s_operator == "")
                        polish_text += " ";
                    s_operator += text[x];
                    foreach (var c in operators)
                    {
                        if (c.name == s_operator)
                        {
                            AddOp(c.name);
                            s_operator = "";
                            break;
                        }
                    }
                }
            }
            if (s_operator != "")
                AddOp(s_operator);
            while (!string_stack.is_empty())
                polish_text += " " + string_stack.pop();

            while (polish_text.Contains("  ")) { polish_text = polish_text.Replace("  ", " "); }
        }

        private void AddOp(string op)
        {
            if (string_stack.is_empty())
            {
                string_stack.push(op);
            }
            else
            {
                string chr = string_stack.last();
                while (charPriority(chr) >= charPriority(op))
                {
                    polish_text = (polish_text + " " + chr + " ");
                    string_stack.pop();
                    if (string_stack.is_empty())
                        break;
                    chr = string_stack.last();
                }
                string_stack.push(op);
            }
        }

        public string Calculate()
        {
            try
            {
                int_stack = new My_Stack<double>();
                List<string> calculate_text = new List<string>();
                calculate_text = polish_text.Split(' ').ToList();
                foreach (string x in calculate_text)
                {
                    if (x == " " || x == "")
                        continue;
                    foreach (var v in operators)
                    {
                        if (v.name == x)
                        {
                            int_stack.push(v.Calculate(ref int_stack));
                            goto end2;
                        }
                    }
                    int_stack.push(Convert.ToDouble(x));
                end2:;
                }
                return Convert.ToString(int_stack.last());
            }
            catch
            {
                return text;
            }
            
        }
        private int charPriority(string x)
        {
            foreach(var v in operators)
            {
                if (v.name == x)
                    return v.priority;
            }
            return 0;
        }
    }
}


//Под каждую функцию sin(),cos() отдельный класс. наследование от базового класса.
//Сделать словать под каждый оператор, определяется и приоритет и его запись.
//Добавление новой -> в класс.


//каждая функция будет новым классом, 