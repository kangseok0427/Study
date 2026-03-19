using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int time = 10;
            int a = 273;
            int b = 52;

            Console.Write("Hello C# Programming . . !\n");
            Console.WriteLine("Hello C# Programming . . !");
            Console.WriteLine("Hello C# Programming . . !");

            Console.WriteLine(0x53);
            Console.WriteLine(5 + 3 * 2);
            Console.WriteLine(0);
            Console.WriteLine(0.0);

            Console.WriteLine("2601110276\nKang");
            Console.WriteLine("\"안녕\"\t하세요");
            Console.WriteLine("가나다" + "라마" + "바사아" + "자차카타" + "파하");

            Console.WriteLine((int)'가');
            Console.WriteLine((int)'힣');

            Console.WriteLine((int)'A');
            Console.WriteLine((int)'B');
            Console.WriteLine((char)66);

            Console.WriteLine('가' + '힣');
            Console.WriteLine("안녕하세요"[0]);
            Console.WriteLine("안녕하세요"[2]);
            Console.WriteLine("안녕하세요"[4]);

            Console.WriteLine(true);
            Console.WriteLine(false);

            Console.WriteLine((9 < time) && (time < 12));

            Console.WriteLine(DateTime.Now.Hour > 9 || DateTime.Now.Hour < 12);
            Console.WriteLine(DateTime.Now.Hour > 9 && DateTime.Now.Hour < 12);

            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);
            Console.WriteLine(a % b);

        }
    }
}