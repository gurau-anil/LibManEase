using LibManEase.Application.Contracts.Logging;
using Serilog;


namespace LibManEase.Infrastructure.Logger
{
    public class SerilogConfiguration
    {
        public string LogFilePath { get; set; } = String.Empty;
        public RollingInterval RollingInterval { get; set; } = RollingInterval.Day;
        public int RetainedFileCountLimit { get; set; } = 7;
    }
    internal class SerilogLogger : IAppLogger
    {
        private readonly ILogger _logger;

        public SerilogLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message) => _logger.Information(message);
        public void LogWarning(string message) => _logger.Warning(message);
        public void LogError(string message, Exception ex = null)
        {
            if (ex != null)
            {
                _logger.Error(ex, message);
            }
            else
            {
                _logger.Error(message);
            }
        }
    }


}
