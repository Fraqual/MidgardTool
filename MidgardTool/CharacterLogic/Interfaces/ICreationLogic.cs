using CharacterLogic.Enums;
using System.Collections.Generic;

namespace CharacterLogic.Interfaces
{
    public interface ICreationLogic
    {        
        List<string> GetCharacterClasses();

        void SetCharacterClass(string className);

        List<string> GetRaces();

        void SetRace(string raceName);
    }
}
