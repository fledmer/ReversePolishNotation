using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class My_Stack<T>
    {
        private T[] array;
        private int max_size = 100;
        private int ptr = 0;
        public My_Stack()
        {
            array = new T[100];
        }
        public My_Stack(int size)
        {
            if(size < 0)
                throw new Exception("Отрицательный размер стека");
            max_size = size;
            array = new T[size];
        }

        public void push (T x)
        {
            if(is_full())
                throw new Exception("Переполнение стека");
            array[ptr++] = x;
        }

        public T pop()
        {
            if(is_empty())
                throw new Exception("Стек пуст");
            --ptr;
            return array[ptr];

        }

        public T last()
        {
            if (is_empty())
                throw new Exception("Стек пуст");
            return array[ptr-1];
        }

        public bool is_empty()
        {
            return ptr <= 0;
        }

        public bool is_full()
        {
            return ptr - 1 >= max_size;
        }
    }
}
