using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterLogic.Interfaces
{
    public interface ICreationLogic
    {        
        List<string> GetCharacterClasses();

        void SetCharacterClass(string className);

        List<string> GetRaces();

        void SetRace(string raceName);

        int GetRandomAttributeValue();
    }
}
