using System;
using System.Collections.Generic;
using System.IO;
using Logger;
using XmlHelper;
using System.Configuration;
using CharacterCreationLogic.Interfaces;
using CharacterCreationLogic.Enums;
using CharacterCreationLogic.Character;
using MidgardToolHelper;

namespace CharacterCreationLogic
{
    public class CreationLogic : ICreationLogic
    {
        private SimpleLogger _logger;
        
        private ECharacterClass _class = 0;
        private ERace _race = 0;

        private ICharacterLogic m_Character;

        public ECharacterClass Class { get => _class; }
        public ERace Race { get => _race; }

        public CreationLogic() : this(null) { }

        public CreationLogic(ICharacterLogic character)
        {
            _logger = SimpleLogger.Instance;
            m_Character = character;
        }

        /// <summary>
        /// Get all available character classes
        /// </summary>
        /// <returns>String List of alle available character classes</returns>
        public List<string> GetCharacterClasses()
        {
            _logger.Log("->GetCharacterClasses()", LogLevel.Debug);
            List<string> classList = new List<string>();

            var appSettings = ConfigurationManager.AppSettings;

            string xmlFolderPath = Environment.CurrentDirectory + appSettings["xmlPath"];

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
                _class = (ECharacterClass)Enum.Parse(typeof(ECharacterClass), className);
            }
            catch (ArgumentException)
            {
                _logger.Log("setCharacterClass(): Class name not recognized", LogLevel.Error);
                Console.WriteLine("Class name not recognized!");
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

            string xmlFolderPath = Environment.CurrentDirectory + ConfigurationManager.AppSettings["xmlPath"];

            _logger.Log("XmlFolderPath: " + xmlFolderPath, LogLevel.Debug);

            raceList = Read.ReadAllContentsOfTag(Path.Combine(xmlFolderPath, "races.xml"), "RaceName");

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
                _race = (ERace)Enum.Parse(typeof(ERace), raceName);
            }
            catch (ArgumentException)
            {
                _logger.Log("SetRace(): Race name nor recognized", LogLevel.Error);
                Console.WriteLine("Race name nor recognized!");
            }
        }

        public static void RollAttribute(CharacterAttribute attribute)
        {
            int roll = 0;

            switch(attribute.Name)
            {
                case ECharacterAttribute.Strength:
                    roll = Dice.Roll(100);
                    break;
                case ECharacterAttribute.GW:
                    roll = Dice.Roll(100);
                    break;
                case ECharacterAttribute.Dexterity:
                    roll = Dice.Roll(100);
                    break;
                case ECharacterAttribute.Constitution:
                    roll = Dice.Roll(100);
                    break;
                case ECharacterAttribute.Intelligence:
                    roll = Dice.Roll(100);
                    break;
                case ECharacterAttribute.MagicTalent:
                    roll = Dice.Roll(100);
                    break;
                case ECharacterAttribute.Appereance:
                    roll = Dice.Roll(100);
                    break;
                case ECharacterAttribute.PA:
                    roll = Dice.Roll(100);
                    break;
                case ECharacterAttribute.Willpower:
                    roll = Dice.Roll(100);
                    break;
                case ECharacterAttribute.Movement:
                    roll = Dice.Roll(3) + Dice.Roll(3) + Dice.Roll(3) + Dice.Roll(3);
                    break;
                default:
                    throw new ArgumentException("Cannot roll for unknown attribute!");
            }
        }

        public List<string> GetAvailableRaces()
        {
            List<string> races = GetRaces();

            //TODO: Filter races

            return races;
        }

        public List<string> GetAvailableCharacterClasses()
        {
            List<string> classes = GetCharacterClasses();

            //TODO: Filter classes

            return classes;
        }
    }
}
