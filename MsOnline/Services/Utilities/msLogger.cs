using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MsOnline.Services.Utilities
{
    public class msLogger : ILogger
    {

        private static msLogger instance;
        private static Logger logger;

        private msLogger()
        {

        }

        public static msLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new msLogger();

            }
            return instance;
        }

        private Logger GetLogger(string theLogger)
        {
            if (msLogger.logger == null)
                msLogger.logger = LogManager.GetLogger(theLogger);
            return msLogger.logger;
        }


        public void Debug(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("loggerRules").Debug(message);
            else
                GetLogger("loggerRules").Debug(message, arg);
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("loggerRules").Error(message);
            else
                GetLogger("loggerRules").Error(message, arg);
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("loggerRules").Info(message);
            else
                GetLogger("loggerRules").Info(message, arg);
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("loggerRules").Warn(message);
            else
                GetLogger("loggerRules").Warn(message, arg);
        }
    }
}