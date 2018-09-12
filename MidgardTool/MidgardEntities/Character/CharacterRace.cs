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

        private List<CharacterClass> m_AvailableClasses;
        public List<CharacterClass> AvailableClasses
        {
            get
            {
                if(m_AvailableClasses == null)
                {
                    m_AvailableClasses = new List<CharacterClass>();
                }
                return m_AvailableClasses;
            }
        }


        #region Construction

        public CharacterRace(string name)
        {
            Name = name;
        }

        #endregion

        public void AddClass(CharacterClass characterClass){
            if(characterClass != null && !AvailableClasses.Contains(characterClass))
            {
                AvailableClasses.Add(characterClass);
            }        
        }

        public bool IsAvailableClass(CharacterClass characterClass)
        {
            return AvailableClasses.Contains(characterClass);
        }
    }
}
