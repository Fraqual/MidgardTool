using Logger.Enums;
using System;
using System.IO;

namespace Logger
{
    public class SimpleLogger
    {

        private readonly string m_Path;

        public LogLevel LogLevel { get; set; } = LogLevel.Debug;

        #region Construction

        public SimpleLogger(string path)
        {
            m_Path = path;
        }

        #endregion

        /// <summary>
        /// Log a message to log file if its log level is greater or equal than the loggers log level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="logLevel">Log level of the message</param>
        public void Log(string message, LogLevel logLevel)
        {
            if(logLevel >= this.LogLevel)
            {
                writeLine("[" + logLevel + "] " + DateTime.UtcNow + ": " + message);
            }
        }

        private void writeLine(string message)
        {
            using(StreamWriter sw = File.AppendText(m_Path))
            {
                sw.WriteLine(message);
            }
        }

    }
}
