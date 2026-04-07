using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*if (DateTime.Now.Hour < 11) Console.WriteLine("It's time for Breakfast");
            else if (DateTime.Now.Hour < 15) Console.WriteLine("It's time for Lunch");
            else Console.WriteLine("It's time for Dinner");

            Console.Write("Enter Int : ");

            string s = Console.ReadLine();
            int i = int.Parse(s);
            int r = i % 2;

            switch (r)
            {
                case 0: Console.WriteLine("짝수입니다."); break;
                case 1: Console.WriteLine("홀수입니다."); break;
            }

            if(r == 0) Console.WriteLine("짝수입니다.");
            else Console.WriteLine("홀수입니다.");

            Console.Write("이번 달은 몇 월 인가요 : ");
            int i = int.Parse(Console.ReadLine());

            switch (i)
            {
                case 12:
                case 1:
                case 2: Console.WriteLine("겨울입니다."); break;

                case 3:
                case 4:
                case 5: Console.WriteLine("봄 입니다."); break;

                case 6:
                case 7:
                case 8: Console.WriteLine("여름 입니다."); break;

                case 9:
                case 10:
                case 11: Console.WriteLine("가을 입니다."); break;
            }

            if (i > 0 && i < 13)
            {
                if (i == 12) Console.WriteLine("겨울입니다.");
                else if (i < 3) Console.WriteLine("겨울입니다.");
                else if (i < 6) Console.WriteLine("봄 입니다.");
                else if (i < 9) Console.WriteLine("여름 입니다.");
                else Console.WriteLine("가을 입니다.");
            }
            else Console.WriteLine("정확한 값이 아닙니다.");

            Console.Write("입력");
            string l = Console.ReadLine();

            if (l.Contains("안녕")) Console.WriteLine("안녕하세요");
            else Console.WriteLine("^^");

            for (int i = 0; i < 100; i++) Console.WriteLine("출력");

            int[] ia = { 52, 345, 34, 24, 456 };
            for (int i = 0; i < ia.Length; i++) { Console.WriteLine(ia[i]); }

            int[] arr = new int[100];
            for (int i = 0; i < arr.Length; i++) { arr[i] = i + 1; }

            for(int i = 0; i < arr.Length; i++) { Console.WriteLine(arr[i]); }

            int[] ia = { 52, 345, 34, 24, 456 };
            int c = 0;

            while (c < ia.Length) { Console.WriteLine(c + "번째 출력 : " + ia[c]); c++; }

            while (!Console.ReadLine().Contains("X")) {  Console.WriteLine(".........................."); }
            Console.WriteLine("정지");

            string[] array = { "사과", "배", "포도", "딸기", "바나나" };
            foreach (var item in array) {Console.WriteLine(item); }*/

            while (true) {
                Console.WriteLine("짝수 입력시 종료");
                int i = int.Parse(Console.ReadLine());
                if (i % 2 == 0) break;
            }

        }
    }
}
