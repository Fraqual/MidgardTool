using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardEntities.Character
{
    public class CharacterRace
    {
        public string Name { get; set; }

        private List<CharacterClass> m_AvailableClasses = new List<CharacterClass>();

        #region Construction

        public CharacterRace(string name)
        {
            Name = name;
        }

        #endregion

        public void AddClass(CharacterClass characterClass){
            m_AvailableClasses.Add(characterClass);
        }

        public bool IsAvailableClass(CharacterClass characterClass)
        {
            return m_AvailableClasses.Contains(characterClass);
        }
    }
}
