// See https://aka.ms/new-console-template for more information
using System;

namespace cal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入第一个数：");
            if (!int.TryParse(Console.ReadLine(), out int ad1))
            {
                Console.WriteLine("illegal input!");
                return;
            }
            Console.Write("请输入第二个数：");
            if (!int.TryParse(Console.ReadLine(), out int ad2))
            {
                Console.WriteLine("illegal input!");
                return;
            }
            int sum = ad1 + ad2;
            Console.WriteLine($"{sum}={ad1}+{ad2}");
            /*
            int sum, ad1, ad2;
            string tem;
            tem = Console.ReadLine();
            ad1 = Int32.Parse(tem);
            tem = Console.ReadLine();
            ad2 = Int32.Parse(tem);
            sum = ad1 + ad2;
            Console.WriteLine("{0}+{1}={2}", ad1, ad2, sum);*/
        }
    }
}
