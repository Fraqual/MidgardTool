using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterLogic
{
    public interface ICharacterAttribute
    {
        bool IsSet { get; set; }

        string Name { get; }

        void AddDependency(ICharacterAttribute attribute);

        void RemoveDependency(ICharacterAttribute attribute);


    }
}
