using System;
using System.Threading;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 同步方案信号量 semaphore
            //Semaphore available = new Semaphore(10, 1000);
            //available.WaitOne();
            //var p = available.Release(2);
            //int v = 0;
            //for (int i = 1; i < 10; i++)
            //{
            //    v = available.Release(i);
            //    available.Release();
            //}

            #endregion


            #region 测试json

            #endregion
            Console.WriteLine("Hello World from docker!");
            Console.ReadLine();
        }
    }
}
