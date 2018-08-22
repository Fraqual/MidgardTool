using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterLogic
{
    public class Character : ICharacterLogic
    {
        private CreationLogic m_CreationLogic;

        private string m_Name;


        public Character()
        {
            m_CreationLogic = new CreationLogic();
        }


        public string Name { get => m_Name; set => m_Name = value; }

        public List<string> GetCharacterClasses() => m_CreationLogic.GetCharacterClasses();

        public List<string> GetRaces() => m_CreationLogic.GetRaces();

        public void SetRandomName()
        {
            Random rng = new Random();

            double n = rng.NextDouble();

            if(n < 0.5)
            {
                Name = "Jonas";
            }
            else
            {
                Name = "Sebastian";
            }
        }
    }
}
