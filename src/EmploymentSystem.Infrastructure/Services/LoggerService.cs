using EmploymentSystem.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Settings.Configuration;


namespace EmploymentSystem.Infrastructure.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger _logger;
        private IConfiguration _appConfiguration;

        public LoggerService(ILogger logger, IConfiguration appConfiguration)
        {
            _logger = logger;
            _appConfiguration = appConfiguration;

            _logger = new LoggerConfiguration().
                ReadFrom.Configuration(_appConfiguration, new ConfigurationReaderOptions { SectionName = "Serilog" })
                        .CreateLogger();

            _logger.Information("startlogging");
            _logger.Debug("startlogging");
            _logger.Error("startlogging");
            _logger.Warning("startlogging");
        }


        public void LogError(string content)
        {
            _logger.Error(content);
        }

        public void LogError(Exception ex)
        {
            _logger.Error(ex.Message);
        }

        public void LogInfo(string content)
        {
            _logger.Information(content);
        }

        public void LogWarning(string content)
        {
            _logger.Warning(content);
        }
    }
}
