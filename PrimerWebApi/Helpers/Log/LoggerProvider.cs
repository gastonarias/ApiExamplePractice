using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PrimerWebApi.Helpers.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerWebApi.Helpers
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly IConfiguration configuration;
        private ILogger logger;
        private bool disposed = false;

        public LoggerProvider()
        {

        }

        public LoggerProvider(IConfiguration config )
        {
            configuration = config;
        }
        public ILogger CreateLogger(string categoryName)
        {
            if (logger == null)
                return new Logger();

            return logger;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    logger = null;
                }

                disposed = true;
            }
        }
    }
}
