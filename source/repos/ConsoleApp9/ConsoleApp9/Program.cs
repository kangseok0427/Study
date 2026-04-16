using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i, j, count = 0;

            for(i = 2; i <= 100; i++)
            {
                for(j = 2; j < i; ++j)
                {
                    if (i % j == 0) break;
                }

                if(j == i)
                {
                    count++;
                    printf("%d%s", i, count % 5 ? " " : "\n");
                }
            }
            return 0;
        }
    }
}
