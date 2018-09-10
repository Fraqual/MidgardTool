using MidgardEntities.Character;
using System.Collections.Generic;
using System.Xml.Linq;

namespace XmlHelper
{
    public class XmlCharacterClassReader
    {
        private string m_Path;

        private static readonly string XML_CLASSES = "Classes";
        private static readonly string XML_CLASS = "Class";
        private static readonly string XML_CLASS_NAME = "ClassName";

        public XmlCharacterClassReader(string path)
        {
            m_Path = path;
        }

        public List<CharacterClass> GetAllClasses()
        {
            List<CharacterClass> classes = new List<CharacterClass>();

            XDocument xDoc = XDocument.Load(m_Path);

            XElement xClasses = xDoc.Element(XML_CLASSES);

            foreach(var cclass in xClasses.Elements(XML_CLASS))
            {
                classes.Add(new CharacterClass(cclass.Element(XML_CLASS_NAME).Value));
            }

            return classes;
        }

    }
}
