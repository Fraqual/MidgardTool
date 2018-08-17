using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CharacterLogic
{
    public class CreationLogic
    {
        private CharacterClass _class;

        public CharacterClass Class { get => _class; set => _class = value; }

        public List<string> getCharacterClasses()
        {
            List<string> classList = new List<string>();

            string configPath = Path.Combine(Environment.CurrentDirectory, "Config.xml");

            if(!File.Exists(configPath))
            {
                Console.WriteLine("Config File not found");
            }

            string xmlFolderPath = XmlHelper.Read.ReadContentOfTag(configPath, "xmlPath");



                //Read class names from classes xml

                return classList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className">Expecting a class name that is in the CharacterClass enum</param>
        public void setCharacterClass(string className)
        {
            try
            {
                _class = (CharacterClass)Enum.Parse(typeof(CharacterClass), className);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Class name nor recognized!");
            }
        }
    }
}
