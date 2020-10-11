using ApiExamplePractice.Helpers.Log;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiExamplePractice.Services
{
    public class WriteFileTestIHostedService : IHostedService, IDisposable
    {
        private readonly IHostEnvironment hostEnvironment;
        private Timer timer;

        public WriteFileTestIHostedService(IHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            WriteToFile("StartAsync");

            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            WriteToFile(DateTime.Now.ToString());
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            WriteToFile("StopAsync");
            
            timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void WriteToFile(string v)
        {
            LoggerService.Default.Info(v);
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
