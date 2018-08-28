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

        private bool m_CanBeSet;
        public bool CanBeSet
        {
            get
            {
                bool value = true;

                foreach(var dependency in m_Dependencies)
                {
                    if(dependency.IsSet == false)
                    {
                        value = false;
                        break;
                    }
                }

                return value;
            }
            set
            {
                m_CanBeSet = value;
            }
        }

        public ECharacterAttribute Name { get; }

        private static readonly int m_MaxValue = 100;

        private int m_Value;

        public int Value
        {
            get
            {
                return m_Value;
            }
        }

        private List<CharacterAttribute> m_Dependencies;

        private DependencyFormula m_DependencyFormula;

        public CharacterAttribute(ECharacterAttribute name)
        {
            Name = name;
            m_Dependencies = new List<CharacterAttribute>();
            CanBeSet = true;
        }

        public CharacterAttribute(ECharacterAttribute name, DependencyFormula dependencyFormula)
        {
            Name = name;
            m_Dependencies = new List<CharacterAttribute>();
            m_DependencyFormula = dependencyFormula;
            CanBeSet = false;
        }

        public void AddDependency(CharacterAttribute attribute)
        {
            m_Dependencies.Add(attribute);
        }

        public void RemoveDependency(CharacterAttribute attribute)
        {
            m_Dependencies.Remove(attribute);
        }

        public bool SetValue(int value, int minValue = 1, int maxValue = 100)
        {
            if(CanBeSet)
            {
                int nextValue = m_DependencyFormula != null ? m_DependencyFormula(value, m_Dependencies) : value;

                if(nextValue > maxValue || nextValue < minValue)
                {
                    return false;
                }

                if(nextValue > m_MaxValue)
                {
                    nextValue = m_MaxValue;
                }

                m_Value = nextValue;

                IsSet = true;
            }

            return true;
        }

        public static int RollDice(int sides)
        {
            return m_Random.Next(1, sides + 1);
        }

    }
}
