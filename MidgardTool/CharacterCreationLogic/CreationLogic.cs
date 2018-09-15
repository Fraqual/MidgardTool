using System;
using System.Collections.Generic;
using System.IO;
using Logger;
using XmlHelper;
using System.Configuration;
using CharacterCreationLogic.Interfaces;
using MidgardEntities.Interfaces;
using MidgardEntities.Enums;
using MidgardEntities.Character;
using MidgardToolHelper;
using ConfigManager;

namespace CharacterCreationLogic
{
    public class CreationLogic : ICreationLogic
    {
        private SimpleLogger m_Logger;
        private XmlCharacterCreationReader m_XmlReader;

        private ICharacter m_Character;

        private List<CharacterClass> m_Classes;
        public List<CharacterClass> Classes
        {
            get
            {
                if(m_Classes == null)
                {
                    m_XmlReader.Read(out m_Classes, out m_Races);
                }
                return m_Classes;
            }
        }

        private List<CharacterRace> m_Races;
        public List<CharacterRace> Races
        {
            get
            {
                if(m_Races == null)
                {
                    m_XmlReader.Read(out m_Classes, out m_Races);
                }
                return m_Races;
            }
        }

        public ERollMethod RollMethod { get; set; }

        #region Construction

        public CreationLogic() : this(null) { }

        public CreationLogic(ICharacter character)
        {
            m_Character = character;
            m_XmlReader = new XmlCharacterCreationReader(MTConfiguration.Instance.XmlPath);
        }

        #endregion

        public void RollAttribute(CharacterAttribute attribute)
        {
            if(m_Character.Race != null)
            {
                int[] minmax = m_XmlReader.ReadAttributeBorders(m_Character.Race.Name, attribute.Name.ToString());

                if(RollMethod == ERollMethod.W2)
                {
                    attribute.Value = rollW2(attribute, minmax[0], minmax[1]);
                }
                else if(RollMethod == ERollMethod.W9)
                {
                    // TODO: rollW9
                }
            }
            else
            {
                if(RollMethod == ERollMethod.W2)
                {
                    attribute.Value = rollW2(attribute, 1, 100);
                }
                else if(RollMethod == ERollMethod.W9)
                {
                    // TODO: rollW9
                }
            }
        }

        private int rollW2(CharacterAttribute attribute, int min, int max)
        {
            int value;

            do
            {
                int roll1 = attribute.Roll();
                int roll2 = attribute.Roll();

                value = roll1 > roll2 ? roll1 : roll2;
            }
            while(value < min || value > max);

            return value;
        }

        public List<CharacterClass> AvailableClasses()
        {
            if(m_Character.Race != null)
            {
                return m_Character.Race.AvailableClasses;
            }
            return Classes;
        }

        public List<CharacterRace> AvailableRaces()
        {
            if(m_Character.Class != null)
            {
                return m_Character.Class.AvailableRaces;
            }
            return Races;
        }

    }
}
