using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Init();
        }

        public static void Init()
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 1; i++)
            {
                try
                {
                    //Task.Run(async () =>
                    //{
                    //    await ResultCal("test" + i.ToString());
                    //});

                    var task = Task.Run(() => ResultCal1("test" + i.ToString()));
                    tasks.Add(Task.Run(() => ResultCal("test" + 1.ToString())));
                    tasks.Add(Task.Run(() => ResultCal("test" + 11.ToString())));
                    tasks.Add(Task.Run(() => ResultCal("test" + 111.ToString())));
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            foreach (var item in tasks)
            {
                item.Wait();
            }
        }

        public static void ResultCal1(string data)
        {
            try
            {
                do
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(DateTime.Now.ToString() + data);
                } while (true);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static void ResultCal(string data)
        {
            try
            {
                do
                {
                    Task.Run(() =>
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine(DateTime.Now.ToString() + data);
                    }).Wait();
                } while (true);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}