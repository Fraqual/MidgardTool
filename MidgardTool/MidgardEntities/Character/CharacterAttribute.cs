using MidgardEntities.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidgardEntities.Character
{
    public class CharacterAttribute
    {
        public static Random m_Random = new Random();

        public delegate int RollFormula();
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

        private int m_Value;
        public int Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                if(CanBeSet)
                {
                    m_Value = m_DependencyFormula != null ? m_DependencyFormula(value, m_Dependencies) : value;
                    IsSet = true;
                }
            }
        }

        public ReadOnlyCollection<CharacterAttribute> Dependencies
        {
            get
            {
                return m_Dependencies.AsReadOnly();
            }
        }

        private List<CharacterAttribute> m_Dependencies;

        private RollFormula m_RollFormula;
        private DependencyFormula m_DependencyFormula;

        public CharacterAttribute(ECharacterAttribute name, RollFormula rollFormula) : this(name, rollFormula, null) { }

        public CharacterAttribute(ECharacterAttribute name, RollFormula rollFormula, DependencyFormula dependencyFormula)
        {
            Name = name;
            m_RollFormula = rollFormula;
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

        public int Roll()
        {
            return m_RollFormula();
        }

    }
}
