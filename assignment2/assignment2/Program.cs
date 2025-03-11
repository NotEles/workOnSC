using System;

namespace SeekPrime
{
    class SeekPrime
    {
        static void Main()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(),out num))
            {
                Console.WriteLine("illegal input");
            }
            //校验>1
            //独立分块
            int[] result = new int[num];
            int index = 0;
            for(int i=2;i<=num;i++)
                {
                    if(num%i==0)
                    {
                        result[index] = i;
                        index++;
                        num = num / i;
                        i = 1;
                    }
                }
            for(int i=0;i<index;i++)
            {
                Console.WriteLine(result[i] + "  ");
            }
        }
    }
}