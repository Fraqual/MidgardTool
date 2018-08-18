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
    public class CreationLogic : ICreationLogic
    {
        private SimpleLogger _logger;
        
        private CharacterClass _class = 0;
        private Race _race = 0;

        public CharacterClass Class { get => _class; }
        public Race Race { get => _race; }

        public CreationLogic()
        {
            _logger = SimpleLogger.Instance;                       
        }

        /// <summary>
        /// Get all available character classes
        /// </summary>
        /// <returns>String List of alle available character classes</returns>
        public List<string> GetCharacterClasses()
        {
            _logger.Log("->GetCharacterClasses()", LogLevel.Debug);
            List<string> classList = new List<string>();

            string configPath = Path.Combine(Environment.CurrentDirectory, "Config.xml");

            _logger.Log("ConfigPath: "+configPath, LogLevel.Debug);

            if(!File.Exists(configPath))
            {
                _logger.Log("getCharacterClasses(): ConfigFile not found", LogLevel.Error);
                Console.WriteLine("Config File not found");
            }

            string xmlFolderPath = Environment.CurrentDirectory + Read.ReadFirstContentOfTag(configPath, "xmlPath");

            _logger.Log("XmlFolderPath: " + xmlFolderPath, LogLevel.Debug);

            string classesXml = Path.Combine(xmlFolderPath, "classes.xml");
            string raceXml = Path.Combine(xmlFolderPath, "races.xml");

            classList = Read.ReadAllContentsOfTag(classesXml, "ClassName");

            if (Race != 0)
            {
                List<string> comparisonList = Read.GetContentOfTagInTagWithValue(raceXml, "RaceName", Race.ToString(), "AvailableClasses");
                classList.RemoveAll(item => !comparisonList.Contains(item));
            }            

            return classList;
        }

        /// <summary>
        /// Set the character class
        /// </summary>
        /// <param name="className">Expecting a class name that is in the CharacterClass enum</param>
        public void SetCharacterClass(string className)
        {
            _logger.Log("->SetCharacterClass(" + className+")", LogLevel.Debug);
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

        /// <summary>
        /// Get all available character races
        /// </summary>
        /// <returns>String List of alle available character races</returns>
        public List<string> GetRaces()
        {
            _logger.Log("->GetRaces()", LogLevel.Debug);
            List<string> raceList = new List<string>();

            string configPath = Path.Combine(Environment.CurrentDirectory, "Config.xml");

            _logger.Log("ConfigPath: " + configPath, LogLevel.Debug);

            if (!File.Exists(configPath))
            {
                _logger.Log("GetRaces(): ConfigFile not found", LogLevel.Error);
                Console.WriteLine("Config File not found");
            }

            string xmlFolderPath = Read.ReadFirstContentOfTag(configPath, "xmlPath");

            _logger.Log("XmlFolderPath: " + xmlFolderPath, LogLevel.Debug);

            raceList = Read.ReadAllContentsOfTag(Path.Combine(xmlFolderPath, "races.xml"), "raceName");

            return raceList;
        }

        /// <summary>
        /// Set the character race
        /// </summary>
        /// <param name="className">Expecting a race name that is in the Race enum</param>
        public void SetRace(string raceName)
        {
            _logger.Log("->SetRace(" + raceName + ")", LogLevel.Debug);
            try
            {
                _race = (Race)Enum.Parse(typeof(Race), raceName);
            }
            catch (ArgumentException e)
            {
                _logger.Log("SetRace(): Race name nor recognized", LogLevel.Error);
                Console.WriteLine("Race name nor recognized!");
            }
        }
    }
}
