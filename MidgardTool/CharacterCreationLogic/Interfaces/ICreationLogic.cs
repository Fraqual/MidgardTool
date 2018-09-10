using MidgardEntities.Enums;
using System.Collections.Generic;

namespace CharacterCreationLogic.Interfaces
{
    public interface ICreationLogic
    {        
        List<string> GetCharacterClasses();

        void SetCharacterClass(string className);

        List<string> GetRaces();

        void SetRace(string raceName);

        List<string> GetAvailableRaces();
        List<string> GetAvailableCharacterClasses();
    }
}
