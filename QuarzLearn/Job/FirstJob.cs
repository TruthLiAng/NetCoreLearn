using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuartzLearn.Job
{
    public class FirstJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"{DateTime.Now.ToString()}--FirstJob");
            return Task.CompletedTask;
        }
    }

    public class First1Job : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"{DateTime.Now.ToString()}--First1Job");
            return Task.CompletedTask;
        }
    }

    public class SecondJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"{DateTime.Now.ToString()}--SecondJob--{context.MergedJobDataMap["tg2"]}");
            return Task.CompletedTask;
        }
    }

    public class Second1Job : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"{DateTime.Now.ToString()}--Second1Job");
            return Task.CompletedTask;
        }
    }
}