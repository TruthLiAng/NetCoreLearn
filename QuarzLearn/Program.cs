using Quartz;
using Quartz.Impl;
using QuartzLearn.Job;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace QuartzLearn
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            InitJobAsync().GetAwaiter().GetResult();
        }

        private static async Task InitJobAsync()
        {
            try
            {
                NameValueCollection props = new NameValueCollection
            {
                { "type","value" }
            };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                IJobDetail jobD1 = JobBuilder.Create<FirstJob>().WithIdentity("firstJob", "g1").Build();
                IJobDetail jobD2 = JobBuilder.Create<First1Job>().WithIdentity("first1Job", "g1").Build();
                IJobDetail jobD3 = JobBuilder.Create<SecondJob>().WithIdentity("SecondJob", "g2").Build();
                IJobDetail jobD4 = JobBuilder.Create<Second1Job>().WithIdentity("Second1Job", "g2").Build();

                ITrigger trigger1 = TriggerBuilder.Create().WithIdentity("trg1", "g1")
                    .StartNow().WithCronSchedule("/5 * * ? * *").Build();
                ITrigger trigger2 = TriggerBuilder.Create().WithIdentity("trg2", "g2")
                    .UsingJobData("tg2", "计时东")
                    .StartNow().WithCronSchedule("/5 * * ? * *").Build();

                await scheduler.ScheduleJob(jobD1, trigger1);
                await scheduler.ScheduleJob(jobD3, trigger2);

                await scheduler.Start();

                // some sleep to show what's happening
                await Task.Delay(TimeSpan.FromSeconds(60));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}