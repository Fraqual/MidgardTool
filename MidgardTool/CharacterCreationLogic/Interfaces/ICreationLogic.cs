using MidgardEntities.Character;
using MidgardEntities.Enums;
using System.Collections.Generic;

namespace CharacterCreationLogic.Interfaces
{
    public interface ICreationLogic
    {
        ERollMethod RollMethod { get; set; }

        List<CharacterClass> AvailableClasses();
        List<CharacterRace> AvailableRaces();

        void RollAttribute(CharacterAttribute attribute);
    }
}
