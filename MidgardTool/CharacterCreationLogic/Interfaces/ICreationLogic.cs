using MidgardEntities.Character;
using MidgardEntities.Enums;
using System.Collections.Generic;

namespace CharacterCreationLogic.Interfaces
{
    public interface ICreationLogic
    {
        List<CharacterClass> AvailableClasses();
        List<CharacterRace> AvailableRaces();
    }
}
