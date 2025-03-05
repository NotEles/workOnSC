using System;
using System.Runtime.InteropServices;
namespace MAtrix
{
    class MAtrix
    {
        class matirx
        {
            public int[,] ma;
            int col, row;
            public matirx(int c=1,int r=1)
            {
                col = c;
                row = r;
                ma = new int[r,c];//多维数组表示好像有问题 handled
            }
        }
        static void Main()
        {
            Console.WriteLine("dimension(blocked by enter,enter in row):");
            int c, r;
            r = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            matirx m=new matirx(c, r);
            for(int i = 0; i < c; i++)
            {
                for (int j =0;j<r;j++)
                {
                    int tem;
                    tem = int.Parse(Console.ReadLine());
                }
            }

            bool rec = true;
            for(int temc=0;temc<c;temc++)
            {
                int val = m.ma[0,temc];
                int temr = 0;
                int temcc = temc;
                while(temr<r &&temcc<c)//这里用一个返回bool的函数说不定比较好，可以提前return而不是多break返回
                {
                    
                    if (m.ma[temr,temcc] != val)
                    {
                        rec = false;
                        break;
                    }
                    temcc++;
                    temr++;
                }
                if (!rec)
                    break;
            }
            Console.WriteLine($"{rec}");
        }
    }
}