using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);

            Console.Write("\n----------\n\n");

            Console.WriteLine(long.MaxValue);
            Console.WriteLine(long.MinValue);

            Console.Write("\n----------\n\n");

            Console.WriteLine(123456 + 65432L);

            Console.Write("\n----------\n\n");

            Console.WriteLine("int : " + sizeof(int));
            Console.WriteLine("long : " + sizeof(long));
            Console.WriteLine("float : " + sizeof(float));
            Console.WriteLine("double : " + sizeof(double));
            Console.WriteLine("char : " + sizeof(char));

            Console.Write("\n----------\n\n");
            char a = 'a';
            char b = 'b';

            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);
            Console.WriteLine(a % b);

            Console.Write("\n----------\n\n");

            Console.Write("입력1 : ");
            string input1 = Console.ReadLine();

            Console.Write("입력2 : ");
            string input2 = Console.ReadLine();
            Console.WriteLine(">> " + (int.Parse(input1) + int.Parse(input2)));

            Console.Write("\n----------\n\n");

            Console.WriteLine(52 + "" + 52);

            Console.Write("\n----------\n\n");

            double num = 52.273103;
            Console.WriteLine(num.ToString("F1"));
            Console.WriteLine(num.ToString("F2"));
            Console.WriteLine(num.ToString("F3"));
            Console.WriteLine(num.ToString("F4"));

            Console.Write("\n----------\n\n");

            Console.Write("Calc1 : ");
            string calc1 = Console.ReadLine();

            Console.Write("Calc1 : ");
            string calc2 = Console.ReadLine();

            Console.WriteLine("Calc1 (" + calc1 + ") + Calc2 (" + calc2 + ") = " + (int.Parse(calc1) + int.Parse(calc2)));
            Console.WriteLine("Calc1 (" + calc1 + ") - Calc2 (" + calc2 + ") = " + (int.Parse(calc1) - int.Parse(calc2)));
            Console.WriteLine("Calc1 (" + calc1 + ") * Calc2 (" + calc2 + ") = " + (int.Parse(calc1) * int.Parse(calc2)));
            Console.WriteLine("Calc1 (" + calc1 + ") / Calc2 (" + calc2 + ") = " + (int.Parse(calc1) / int.Parse(calc2)));
            Console.WriteLine("Calc1 (" + calc1 + ") % Calc2 (" + calc2 + ") = " + (int.Parse(calc1) % int.Parse(calc2)));

        }
    }
}
