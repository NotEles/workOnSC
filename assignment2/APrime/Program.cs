using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace APrime
{
    class APrime 
    {
        static void Main()
        {
            int[] num = new int[101];
            num[1] = num[0] = 1;
            for(int i=2;i<50;i++)
            {
                for(int j=2;i*j<=100;j++)
                {
                    num[i * j] = 1;
                }
            }
            for(int t=2;t<101;t++)
            {
                if (num[t] == 0)
                    Console.Write($"{t} ");
            }
        }
        
    }
}