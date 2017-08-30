using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutilateThread
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t1 = new Thread((obj) =>
                {
                    Console.WriteLine(obj);
                });
                Thread.Sleep(1000);
                //设置线程为后台线程
                t1.IsBackground = true;
                t1.Start(i);
            }
            Console.ReadKey();
        }
    }
}
