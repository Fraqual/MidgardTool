using MidgardEntities.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlHelper
{
    public class XmlCharacterCreationReader
    {

        #region Constants

        private static readonly string XML_CLASS_FILE_NAME = "classes.xml";
        private static readonly string XML_RACE_FILE_NAME = "races.xml";

        private static readonly string CLASSES = "Classes";
        private static readonly string CLASS = "Class";
        private static readonly string CLASS_NAME = "ClassName";
        private static readonly string CLASS_AVB_RACES = "AvailableRaces";

        private static readonly string RACES = "Races";
        private static readonly string RACE = "Race";
        private static readonly string RACE_NAME = "RaceName";
        private static readonly string RACE_AVB_CLASSES = "AvailableClasses";
        private static readonly string RACE_ATR_BORDERS = "AttributeBorders";

        private static readonly string ATR_MIN = "min";
        private static readonly string ATR_MAX = "max";

        #endregion

        private string m_Path;

        private XElement xClasses;
        private XElement xRaces;

        #region Construction

        public XmlCharacterCreationReader(string path)
        {
            m_Path = path;

            xClasses = XDocument.Load(m_Path + "\\" + XML_CLASS_FILE_NAME).Element(CLASSES);
            xRaces = XDocument.Load(m_Path + "\\" + XML_RACE_FILE_NAME).Element(RACES);
        }

        #endregion

        public void Read(out List<CharacterClass> classes, out List<CharacterRace> races)
        {
            classes = new List<CharacterClass>();
            races = new List<CharacterRace>();

            foreach(var cclass in xClasses.Elements(CLASS))
            {
                classes.Add(new CharacterClass(cclass.Element(CLASS_NAME).Value));
            }

            foreach(var race in xRaces.Elements(RACE))
            {
                races.Add(new CharacterRace(race.Element(RACE_NAME).Value));
            }

            foreach(var cclass in classes)
            {
                XElement avbRaces = xClasses.Elements(CLASS).First(c => c.Element(CLASS_NAME).Value == cclass.Name).Element(CLASS_AVB_RACES);
                if(avbRaces != null)
                {
                    foreach(var race in avbRaces.Elements(RACE))
                    {
                        cclass.AddRace(races.Find(r => r.Name == race.Value));
                    }
                }                
            }

            foreach(var race in races)
            {
                XElement avbClasses = xRaces.Elements(RACE).First(r => r.Element(RACE_NAME).Value == race.Name).Element(RACE_AVB_CLASSES);
                if(avbClasses != null)
                {
                    foreach(var cclass in avbClasses.Elements(CLASS))
                    {
                        race.AddClass(classes.Find(c => c.Name == cclass.Value));
                    }
                }
            }

        }

        /// <summary>
        /// Read min max borders of an character attribute
        /// </summary>
        /// <param name="raceName">Characters race</param>
        /// <param name="attributeName">Attribute name</param>
        /// <returns>Array containing min max values of the specified attribute or default values if the attribute can not be found</returns>
        public int[] ReadAttributeBorders(string raceName, string attributeName)
        {
            XElement xRace = getXRace(raceName);
            if(xRace != null)
            {
                XElement atrBorders = xRace.Element(RACE_ATR_BORDERS);
                if(atrBorders != null)
                {
                    XElement xAttribute = atrBorders.Element(attributeName);
                    if(xAttribute != null)
                    {
                        int[] minmax = new int[2];

                        minmax[0] = int.Parse(xAttribute.Attribute(ATR_MIN).Value);
                        minmax[1] = int.Parse(xAttribute.Attribute(ATR_MAX).Value);

                        return minmax;
                    }
                }
            }
            return new int[] { 1, 100};
        }

        private XElement getXRace(string raceName)
        {
            foreach(var race in xRaces.Elements(RACE))
            {
                if(race.Element(RACE_NAME).Value == raceName)
                {
                    return race;
                }
            }
            return null;
        }

    }
}
