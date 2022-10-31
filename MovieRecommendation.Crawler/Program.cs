using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieRecommendation.Business.Repository;
using MovieRecommendation.Entities;
using MovieRecommendation.DAL;
using Quartz.Impl;
using Quartz.Logging;
using Quartz;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MovieRecommendation.Crawler
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
           
                LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

                // Grab the Scheduler instance from the Factory
                StdSchedulerFactory factory = new StdSchedulerFactory();
                IScheduler scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                // define the job and tie it to our HelloJob class
                IJobDetail job = JobBuilder.Create<ProcessJob>()
                    .WithIdentity("job1", "group1")
                    .Build();

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group1")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInHours(2)
                        .RepeatForever())
                    .Build();

                // Tell quartz to schedule the job using our trigger
                await scheduler.ScheduleJob(job, trigger);

                await Task.Delay(TimeSpan.FromSeconds(60));

                // and last shut down the scheduler when you are ready to close your program
                await scheduler.Shutdown();

                Console.WriteLine("Press any key to close the application");
                Console.ReadKey();
        }

        private class ConsoleLogProvider : ILogProvider
        {
            public Logger GetLogger(string name)
            {
                return (level, func, exception, parameters) =>
                {
                    if (level >= LogLevel.Info && func != null)
                    {
                        Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] [" + level + "] " + func(), parameters);
                    }
                    return true;
                };
            }

            public IDisposable OpenNestedContext(string message)
            {
                throw new NotImplementedException();
            }

            public IDisposable OpenMappedContext(string key, object value, bool destructure = false)
            {
                throw new NotImplementedException();
            }
        }
    }

    public class ProcessJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("Movie crawler started.");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"config.json", true, true);

            var config = builder.Build();

            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IRepository<Movies>, Repository<Movies>>()
                .AddDbContext<MovieRecommendationDbContext>(options => options.UseSqlServer(config["ConnectionString"]))
                .BuildServiceProvider();

            var lastMovieIdFromDB = 0;
            IRepository<Movies> connection = serviceProvider.GetService<IRepository<Movies>>();
            var lastMovie = connection.Get().OrderByDescending(x => x.MovieId).FirstOrDefault();
            if (lastMovie != null)
            {
                lastMovieIdFromDB = lastMovie.MovieId;
            }
            CrawlerManager crawlerService = new CrawlerManager(connection, config);
            await crawlerService.Proccess(lastMovieIdFromDB + 1);

            await Console.Out.WriteLineAsync("All movies reveiced.");
        }


    }
}
