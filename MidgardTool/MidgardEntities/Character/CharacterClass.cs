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

        private List<CharacterRace> m_AvailableRaces = new List<CharacterRace>();

        #region Construction

        public CharacterClass(string name)
        {
            Name = name;
        }

        #endregion

        public void AddRace(CharacterRace race)
        {
            m_AvailableRaces.Add(race);
        }

        public bool IsAvailableRace(CharacterRace race)
        {
            return m_AvailableRaces.Contains(race);
        }
    }
}
