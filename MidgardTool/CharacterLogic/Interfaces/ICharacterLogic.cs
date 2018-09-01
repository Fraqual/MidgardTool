using CharacterLogic.Enums;
using System.Collections.Generic;

namespace CharacterLogic.Interfaces
{
    public interface ICharacterLogic
    {
        string Name { get; set; }
        string PlayerName { get; set; }
        ECharacterClass Class { get; set; }
        int Rank { get; set; }


        int LPMaximum { get; set; }
        int APMaximum { get; set; }
        int Experience { get; set; }
        int ExperienceTotal { get; set; }


        List<ISpecialAbility> Special { get; set; }
        ERace Race { get; set; }
        string Origin { get; set; }
        string Faith { get; set; }
        ESocialStatus SocialStatus { get; set; }
        int Age { get; set; }
        ESex Sex { get; set; }
        EHandedness Handedness { get; set; }
        int Size { get; set; }
        int Weight { get; set; }


        CharacterAttribute Strength { get; set; }
        CharacterAttribute GW { get; set; }
        CharacterAttribute Dexterity { get; set; }
        CharacterAttribute Constitution { get; set; }
        CharacterAttribute Intelligence { get; set; }
        CharacterAttribute MagicTalent { get; set; }
        CharacterAttribute Appereance { get; set; }
        CharacterAttribute PA { get; set; }
        CharacterAttribute Willpower { get; set; }
        CharacterAttribute Movement { get; set; }

    }
}
