using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_1_Lab.Model;

namespace Test
{
    class Program
    {
        class MyClass
        {
            int _n;

            public int N
            {
                get
                {
                    return _n;
                }

                set
                {
                    if(value >= _n)
                        _n = value;
                }
            }
        }
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            mc.N = 10;
            mc.N -= 1;

            Console.WriteLine(mc.N);

            Console.ReadKey();
        }
    }
}
