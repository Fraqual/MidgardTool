using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterLogic
{
    public interface ICharacterLogic
    {

        string Name { get; set; }


        List<string> GetCharacterClasses();

        List<string> GetRaces();

        void SetRandomName();
    }
}
