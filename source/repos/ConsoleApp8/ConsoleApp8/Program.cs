using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        class Pdc
        {
            public string name;
            public int price;

            public void Print()
            {
                Console.WriteLine(name + " : " + price + "원");
            }
        }
        static void Main(string[] args)
        {
            List<Pdc> li = new List<Pdc>();

            li.Add(new Pdc() { name = "감자", price = 2000});
            li.Add(new Pdc() { name = "토마토", price = 3000 });

            foreach(var item in li) item.Print();
        }
    }
}
