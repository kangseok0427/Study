using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int[] a = new int[6];
            int[] b = new int[6];
            bool[] c = new bool[6];
            int d = 0;

            for (int i = 0; i < 6; i++)
            {
                Console.Write(i + 1 + "번 결과 입력 : ");
                a[i] = int.Parse(Console.ReadLine());
            }

            for(int j  = 0; j < 6; j++)
            {
                int k = rand.Next(1, 46);
                b[j] = k;
                Console.WriteLine(j + 1 + "번 번호 : " + k );
            }

            for(int l =  0; l < 6; l++)
            {
                if(a[l] == b[l])
                {
                    Console.WriteLine(l + 1 + "번 결과 일치");
                    c[l] = true;
                }
                else 
                { 
                    Console.WriteLine(l + 1 + "번 결과 불일치");
                    c[l] = false;
                }
            }

            for (int m = 0; m < 6; m++) 
            {
                if (c[m] == true) d++;
            }

            switch (d)
            {
                case 0: Console.WriteLine("7등입니다."); break;
                case 1: Console.WriteLine("6등입니다."); break;
                case 2: Console.WriteLine("5등입니다."); break;
                case 3: Console.WriteLine("4등입니다."); break;
                case 4: Console.WriteLine("3등입니다."); break;
                case 5: Console.WriteLine("2등입니다."); break;
                case 6: Console.WriteLine("1등입니다."); break;
            }
        }
    }
}
