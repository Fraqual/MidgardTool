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

        private ICharacter m_Character;

        private List<CharacterClass> m_Classes;
        public List<CharacterClass> Classes
        {
            get
            {
                if(m_Classes == null)
                {
                    XmlCharacterCreationReader reader = new XmlCharacterCreationReader(MTConfiguration.Instance.XmlPath);
                    reader.Read(out m_Classes, out m_Races);
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
                    XmlCharacterCreationReader reader = new XmlCharacterCreationReader(MTConfiguration.Instance.XmlPath);
                    reader.Read(out m_Classes, out m_Races);
                }
                return m_Races;
            }
        }

        #region Construction

        public CreationLogic() : this(null) { }

        public CreationLogic(ICharacter character)
        {
            m_Character = character;
        }

        #endregion

        public List<string> AvailableClasses()
        {
            return Classes.ConvertAll(c => c.Name);
        }

        public List<string> AvailableRaces()
        {
            return Races.ConvertAll(r => r.Name);
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
    }
}
