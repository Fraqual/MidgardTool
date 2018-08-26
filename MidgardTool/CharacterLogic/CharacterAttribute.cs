using CharacterLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterLogic
{
    public class CharacterAttribute
    {
        public static Random m_Random = new Random();

        public delegate int DependencyFormula(int value, List<CharacterAttribute> dependencies);

        public bool IsSet { get; set; } = false;

        public ECharacterAttribute Name { get; }

        private int m_Value;

        public int Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                bool canBeSet = true;

                foreach(var dependency in m_Dependencies)
                {
                    if(!dependency.IsSet)
                    {
                        canBeSet = false;
                        break;
                    }
                }

                if(canBeSet)
                {
                    m_Value = value;
                    IsSet = true;
                }
            }
        }

        private List<CharacterAttribute> m_Dependencies;

        private DependencyFormula m_DependencyFormula;

        public CharacterAttribute(ECharacterAttribute name)
        {
            Name = name;
            m_Dependencies = new List<CharacterAttribute>();
        }

        public CharacterAttribute(ECharacterAttribute name, DependencyFormula dependencyFormula)
        {
            Name = name;
            m_Dependencies = new List<CharacterAttribute>();
            m_DependencyFormula = dependencyFormula;
        }

        public void AddDependency(CharacterAttribute attribute)
        {
            m_Dependencies.Add(attribute);
        }

        public void RemoveDependency(CharacterAttribute attribute)
        {
            m_Dependencies.Remove(attribute);
        }

        public void SetDependencyValue(int baseValue)
        {
            m_DependencyFormula?.Invoke(baseValue, m_Dependencies);
        }

        public static int RollDice(int sides)
        {
            return m_Random.Next(1, sides + 1);
        }

    }
}
