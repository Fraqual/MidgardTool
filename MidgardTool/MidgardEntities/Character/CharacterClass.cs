using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardEntities.Character
{
    public class CharacterClass
    {
        public string Name { get; set; }

        private List<CharacterRace> m_AvailableRaces;
        public List<CharacterRace> AvailableRaces
        {
            get
            {
                if(m_AvailableRaces == null)
                {
                    m_AvailableRaces = new List<CharacterRace>();
                }
                return m_AvailableRaces;
            }
        }

        #region Construction

        public CharacterClass(string name)
        {
            Name = name;
        }

        #endregion

        public void AddRace(CharacterRace race)
        {
            if(race != null && !AvailableRaces.Contains(race))
            {
                AvailableRaces.Add(race);
            }           
        }

        public bool IsAvailableRace(CharacterRace race)
        {
            return AvailableRaces.Contains(race);
        }
    }
}
