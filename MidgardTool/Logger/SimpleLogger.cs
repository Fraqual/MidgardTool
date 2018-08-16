using Logger.Enums;
using System;
using System.IO;

namespace Logger
{
    /// <summary>
    /// Simple singleton logger
    /// </summary>
    public class SimpleLogger
    {

        private readonly string m_Path;

        private static SimpleLogger m_Logger;

        public LogLevel LogLevel { get; set; } = LogLevel.Debug;

        public static SimpleLogger Instance
        {
            get => m_Logger;
        }

        #region Construction

        public static SimpleLogger Construct(string path)
        {
            if(m_Logger == null)
            {
                m_Logger = new SimpleLogger(path);
            }

            return m_Logger;
        }

        private SimpleLogger(string path)
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
            if(Path.GetDirectoryName(m_Path) != string.Empty && !Directory.Exists(Path.GetDirectoryName(m_Path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(m_Path));
            }

            using(StreamWriter sw = File.AppendText(m_Path))
            {
                sw.WriteLine(message);
            }
        }

    }
}
