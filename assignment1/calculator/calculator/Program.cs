// See https://aka.ms/new-console-template for more information
using System;

namespace cal
{
    class Pro
    {
        static void Main(string[] args)
        {
            int sum, ad1, ad2;
            string tem;
            tem = Console.ReadLine();
            ad1 = Int32.Parse(tem);
            tem = Console.ReadLine();
            ad2 = Int32.Parse(tem);
            sum = ad1 + ad2;
            Console.WriteLine("{0}+{1}={2}", ad1, ad2, sum);
        }
    }
}
