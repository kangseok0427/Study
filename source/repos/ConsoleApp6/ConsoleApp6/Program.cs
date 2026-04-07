using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int num = rand.Next(0, 10);
            double n2 = rand.NextDouble();

            Console.WriteLine(rand.NextDouble() * 10);
            Console.WriteLine(rand.NextDouble() * 10);
            Console.WriteLine(rand.NextDouble() * 10);
            Console.WriteLine(rand.NextDouble() * 10);
            Console.WriteLine(rand.NextDouble() * 10);

            Console.WriteLine(num + n2);
            Console.WriteLine(num + n2);
            Console.WriteLine(num + n2);
            Console.WriteLine(num + n2);
            Console.WriteLine(num + n2);

            List<int> list = new List<int>();

            list.Add(52);
            list.Add(13);
            list.Add(340);
            list.Add(64);


            for(int i = 0; i < 100; i++)
            {
                list.Add(rand.Next(500));
                list.RemoveAt(0);
                Console.WriteLine("Count : " + list.Count + "\t i : " + list[0]);
            }
        }
    }
}
