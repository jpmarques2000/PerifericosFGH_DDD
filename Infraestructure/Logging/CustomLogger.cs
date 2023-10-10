using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly CustomLoggerProviderConfiguration _configuration;

        public CustomLogger(string loggerName, 
            CustomLoggerProviderConfiguration configuration)
        {
            _loggerName = loggerName;
            _configuration = configuration;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(
            LogLevel logLevel
            , EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            var mensagem = string.Format($"{logLevel}: {eventId}" +
                $" - {formatter(state, exception)}");
            WriteTextOnFile(mensagem);
        }

        private void WriteTextOnFile(string mensagem)
        {
            var filePath = @$"C:\Users\JoaoPaulo\source\repos\Loja_PerifericosFGH\API_DDD_Loja_PerifericosFGH\Infraestructure\bin\LOG-{DateTime.Now:yyyy-MM-dd}.txt";
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.Create(filePath).Dispose();
            }

            using StreamWriter streamWriter = new StreamWriter(filePath, true);
            streamWriter.WriteLine(mensagem);
            streamWriter.Close();
        }
    }
}
