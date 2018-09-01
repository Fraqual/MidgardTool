using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterLogic
{
    public class CharacterManager
    {
        private List<Character> m_Characters;


        public CharacterManager()
        {
            m_Characters = new List<Character>();
        }


        public void AddCharacter(Character character)
        {
            m_Characters.Add(character);
        }

        public void RemoveCharacter(Character character)
        {
            m_Characters.Remove(character);
        }

        public List<Character> GetCharacter(string charName)
        {
            return m_Characters.FindAll(c => c.Name == charName);
        }

        public List<Character> GetPlayerCharacter(string playerName)
        {
            return m_Characters.FindAll(c => c.PlayerName == playerName);
        }
    }
}
