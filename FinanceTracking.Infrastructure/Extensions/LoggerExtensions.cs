using System.ComponentModel;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.Infrastructure.Extensions
{
    public static class LoggerExtensions
    {
        private static readonly string Env = (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development").Substring(0, 1);

        public static void Debug(this ILogger logger, [Localizable(false)] string message, params object?[] args)
        {
            logger.LogDebug("[" + Env + "][D] " + message, args);
        }

        public static void Info(this ILogger logger, [Localizable(false)] string message, params object?[] args)
        {
            logger.LogInformation("[" + Env + "][I] " + message, args);
        }

        public static void Error(this ILogger logger, [Localizable(false)] string message, params object?[] args)
        {
            logger.LogError("[" + Env + "][E] " + message, args);
        }

        public static void Error(this ILogger logger, Exception ex, [Localizable(false)] string message, params object?[] args)
        {
            logger.LogError(ex, "[" + Env + "][E] " + message, args);
        }
    }
}
