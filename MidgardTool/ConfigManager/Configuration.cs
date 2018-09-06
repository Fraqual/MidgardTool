using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConfigManager
{
    public class MTConfiguration
    {
        private string m_ConfigPath = Environment.CurrentDirectory + @"\..\settings.cfg";

        public string XmlPath { get; set; } = "";
        public string LogPath { get; set; } = "log.txt";
        public string LogLevel { get; set; } = "Debug";

        public static MTConfiguration Instance
        {
            get
            {
                if(m_Config == null)
                {
                    m_Config = new MTConfiguration();
                }
                return m_Config;
            }
        }


        private static MTConfiguration m_Config;
        private MTConfiguration()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(m_ConfigPath));

            if(!File.Exists(m_ConfigPath))
            {
                createConfig();
                return;
            }

            using(StreamReader streamReader = new StreamReader(m_ConfigPath))
            {
                PropertyInfo[] properties = this.GetType().GetProperties();

                while(!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] keyValue = line.Split('=');

                    PropertyInfo property = properties.First(prop => prop.Name == keyValue[0]);
                    if(property != null)
                    {
                        property.SetValue(this, keyValue[1]);
                    }
                }
            }
        }

        private void createConfig()
        {
            using(StreamWriter streamWriter = new StreamWriter(File.OpenWrite(m_ConfigPath)))
            {
                PropertyInfo[] properties = this.GetType().GetProperties();

                foreach(var prop in properties)
                {
                    if(prop.PropertyType != typeof(MTConfiguration))
                    {
                        streamWriter.WriteLine(prop.Name + "=" + prop.GetValue(this));
                    }
                }
            }
        }
    }
}
