using ApiExamplePractice.Helpers.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrimerWebApi.Context;
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

        public IServiceProvider Service { get; }

        public WriteFileTestIHostedService(IHostEnvironment hostEnvironment,
             IServiceProvider service)
        {
            this.hostEnvironment = hostEnvironment;

            Service = service;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            WriteToFile("StartAsync");

            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(100));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            WriteToFile(DateTime.Now.ToString());

            using (var scope = Service.CreateScope())
            {
                var cont = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var data = cont.Autores.Include(x => x.Libros).ToList();
                WriteToFile(data.ToString());
            }
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
