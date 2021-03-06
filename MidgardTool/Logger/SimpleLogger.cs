﻿using System;
using System.IO;
using System.Configuration;
using ConfigManager;

namespace Logger
{
    /// <summary>
    /// Simple singleton logger
    /// </summary>
    public class SimpleLogger
    {

        private static string m_Path = "log.txt";

        private static SimpleLogger m_Logger;

        private static LogLevel m_LoggingLevel = LogLevel.Debug;

        public static LogLevel LoggingLevel { get => m_LoggingLevel; set => m_LoggingLevel = value; }

        public static SimpleLogger Instance
        {
            get
            {
                if(m_Logger == null)
                {
                    m_Logger = new SimpleLogger();

                    m_Path = MTConfiguration.Instance.LogPath;
                    string logLvl = MTConfiguration.Instance.LogLevel;
                    Enum.TryParse(logLvl, out m_LoggingLevel);

                    if(Path.GetDirectoryName(m_Path) != string.Empty && !Directory.Exists(Path.GetDirectoryName(m_Path)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(m_Path));
                    }
                    if(!File.Exists(m_Path))
                    {
                        File.Create(m_Path).Close();
                    }

                    using (StreamWriter sw = File.AppendText(m_Path))
                    {
                        sw.WriteLine("\n"+DateTime.UtcNow+"\t\tS T A R T E D\n");
                    }

                }

                return m_Logger;
            }
        }

        #region Construction

        private SimpleLogger() { }

        #endregion

        /// <summary>
        /// Log a message to log file if its log level is greater or equal than the loggers log level
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="logLevel">Log level of the message</param>
        public void Log(string message, LogLevel logLevel)
        {
            if(logLevel >= LoggingLevel)
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
