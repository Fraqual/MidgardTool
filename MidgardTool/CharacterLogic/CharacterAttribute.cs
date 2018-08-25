using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterLogic
{
    public class CharacterAttribute<T> : ICharacterAttribute
    {
        private static Random m_Random;

        public delegate object DependencyFormula(ICharacterAttribute characterAttribute, List<ICharacterAttribute> dependencies);

        public bool IsSet { get; set; } = false;

        public string Name { get; }

        private T m_Value;

        public T Value
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

        private List<ICharacterAttribute> m_Dependencies;

        private DependencyFormula m_DependencyFormula;

        public CharacterAttribute(string name)
        {
            Name = name;
            m_Random = new Random();
            m_Dependencies = new List<ICharacterAttribute>();
        }

        public CharacterAttribute(string name, DependencyFormula dependencyFormula)
        {
            Name = name;
            m_Random = new Random();
            m_Dependencies = new List<ICharacterAttribute>();
            m_DependencyFormula = dependencyFormula;
        }

        public void AddDependency(ICharacterAttribute attribute)
        {
            m_Dependencies.Add(attribute);
        }

        public void RemoveDependency(ICharacterAttribute attribute)
        {
            m_Dependencies.Remove(attribute);
        }

        public void SetRandomValue()
        {
            if(typeof(T) == typeof(int))
            {
                SetDependencyValue();
            }
        }

        public void SetDependencyValue()
        {
            m_DependencyFormula?.Invoke(this, m_Dependencies);
        }

    }
}
