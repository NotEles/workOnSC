using System;

namespace arrdeal
{
    class arrdeal
    {
        public int[] arr;
        public int len;
        int min()
        {
            int M=arr[0];
            foreach(int i in arr)
            {
                if (M > i)
                    M = i;
            }
            return M;
        }
        int max()
        {
            int m = arr[0];
            foreach (int i in arr)
            {
                if (m < i)
                    m = i;
            }
            return m;
        }
        int sum()
        {
            int summ = 0;
            foreach (int i in arr)
                summ += i;
            return summ;
        }
        double ave()
        {
            double summ = 0.0;
            foreach (int i in arr)
                summ += i;
            return summ / len;
        }//转double 解决
        static void Main()
        {
            arrdeal myarr = new arrdeal();
            Console.WriteLine("How many numbers?");
            while(!int.TryParse(Console.ReadLine(),out myarr.len))
            {
                Console.WriteLine("illegal input!");
                Console.WriteLine("How many numbers?");
            }
            myarr.arr = new int[myarr.len];
            for (int i=0;i<myarr.len;i++)
            {
                while (!int.TryParse(Console.ReadLine(), out myarr.arr[i] ))
                {
                    Console.WriteLine("illegal input!");
                }
            }

            Console.WriteLine($"max:{myarr.max()} ,min:{myarr.min()} ,sum:{myarr.sum()}, ave:{myarr.ave()}");

        }   
    }

}