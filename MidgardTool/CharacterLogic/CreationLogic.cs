using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Logger;
using XmlHelper;

namespace CharacterLogic
{
    public class CreationLogic
    {
        private CharacterClass _class;
        private SimpleLogger _logger;

        public CharacterClass Class { get => _class; set => _class = value; }

        public CreationLogic()
        {
            _logger = SimpleLogger.Instance;                       
        }

        public List<string> getCharacterClasses()
        {
            _logger.Log(" ->getCharacterClasses()", LogLevel.Debug);
            List<string> classList = new List<string>();

            string configPath = Path.Combine(Environment.CurrentDirectory, "Config.xml");

            _logger.Log("ConfigPath: "+configPath, LogLevel.Debug);

            if(!File.Exists(configPath))
            {
                _logger.Log("getCharacterClasses(): ConfigFile not found", LogLevel.Error);
                Console.WriteLine("Config File not found");
            }

            string xmlFolderPath = Read.ReadFirstContentOfTag(configPath, "xmlPath");

            _logger.Log("XmlFolderPath: " + xmlFolderPath, LogLevel.Debug);

            classList = Read.ReadAllContentsOfTag(Path.Combine(xmlFolderPath, "classes.xml"), "ClassName");

            return classList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className">Expecting a class name that is in the CharacterClass enum</param>
        public void setCharacterClass(string className)
        {
            _logger.Log(" ->setCharacterClass("+className+")", LogLevel.Debug);
            try
            {
                _class = (CharacterClass)Enum.Parse(typeof(CharacterClass), className);
            }
            catch (ArgumentException e)
            {
                _logger.Log("setCharacterClass(): Class name nor recognized", LogLevel.Error);
                Console.WriteLine("Class name nor recognized!");
            }
        }
    }
}
