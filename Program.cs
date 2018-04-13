﻿using Newtonsoft.Json;
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
            JsonMovie m = new JsonMovie
            {
                Name = "非诚勿扰1",
                Director = "冯小刚",
                ReleaseYear = 2008,
                ChiefActor = "葛优",
                ChiefActress = "舒淇"
            };

            string json = JsonConvert.SerializeObject(m, Formatting.Indented);
            Console.WriteLine(json);

            JsonMovie v = JsonConvert.DeserializeObject<JsonMovie>(json);
            #endregion
            Console.WriteLine("Hello World from docker!");
            Console.ReadLine();
        }
    }
}
