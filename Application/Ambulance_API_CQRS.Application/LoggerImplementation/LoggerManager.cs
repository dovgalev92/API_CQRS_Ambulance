﻿using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;
using Ambulance_API_CQRS.Domain.Entities;
using NLog;


namespace Ambulance_API_CQRS.Application.LoggerImplementation
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager() { }

        public void LogDebug(string message) => logger.Debug(message);

        public void LogError(string message) => logger.Error(message);

        public void LogInfo(string message) => logger.Info(message);

        public void LogWarning(string message) => logger.Warn(message);

    }
}