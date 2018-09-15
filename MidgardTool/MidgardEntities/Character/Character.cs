using System;
using System.Collections.Generic;
using MidgardEntities.Enums;
using MidgardEntities.Interfaces;
using MidgardToolHelper;

namespace MidgardEntities.Character
{
    public class Character : ICharacter
    {
        public string Name { get; set; }
        public string PlayerName { get; set; }
        public CharacterClass Class { get; set; }
        public int Rank { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int LPMaximum { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int APMaximum { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Experience { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int ExperienceTotal { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public List<ISpecialAbility> Special { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public CharacterRace Race { get; set; }
        public string Origin { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Faith { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public ESocialStatus SocialStatus { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Age { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public ESex Sex { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public EHandedness Handedness { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Size { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Weight { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }


        public CharacterAttribute Strength { get; set; }
        public CharacterAttribute GW { get; set; }
        public CharacterAttribute Dexterity { get; set; }
        public CharacterAttribute Constitution { get; set; }
        public CharacterAttribute Intelligence { get; set; }
        public CharacterAttribute MagicTalent { get; set; }
        public CharacterAttribute Appereance { get; set; }
        public CharacterAttribute PA { get; set; }
        public CharacterAttribute Willpower { get; set; }
        public CharacterAttribute Movement { get; set; }


        public Character()
        {
            initialize();
        }

        private void initialize()
        {
            Strength = new CharacterAttribute(ECharacterAttribute.Strength, () => { return Dice.Roll(100); });
            GW = new CharacterAttribute(ECharacterAttribute.GW, () => { return Dice.Roll(100); });
            Dexterity = new CharacterAttribute(ECharacterAttribute.Dexterity, () => { return Dice.Roll(100); });
            Constitution = new CharacterAttribute(ECharacterAttribute.Constitution, () => { return Dice.Roll(100); });
            Intelligence = new CharacterAttribute(ECharacterAttribute.Intelligence, () => { return Dice.Roll(100); });
            MagicTalent = new CharacterAttribute(ECharacterAttribute.MagicTalent, () => { return Dice.Roll(100); });
            Appereance = new CharacterAttribute(ECharacterAttribute.Appereance, () => { return Dice.Roll(100); });

            PA = new CharacterAttribute(ECharacterAttribute.PA, () => { return Dice.Roll(100); }, (value, dependencies) =>
            {
                CharacterAttribute intelligence = null;

                foreach(var dependency in dependencies)
                {
                    if(dependency.Name == ECharacterAttribute.Intelligence)
                    {
                        intelligence = dependency;
                    }
                }

                if(intelligence == null)
                {
                    throw new ArgumentException($"Could not find dependency attribute {ECharacterAttribute.Intelligence} for attribute {PA.Name}!");
                }

                return value + 4 * intelligence.Value / 10 - 20;
            });
            PA.AddDependency(Intelligence);

            Willpower = new CharacterAttribute(ECharacterAttribute.Willpower, () => { return Dice.Roll(100); }, (value, dependencies) => 
            {
                CharacterAttribute intelligence = null;
                CharacterAttribute constitution = null;

                foreach(var dependency in dependencies)
                {
                    if(intelligence == null && dependency.Name == ECharacterAttribute.Intelligence)
                    {
                        intelligence = dependency;
                    }
                    else if(constitution == null && dependency.Name == ECharacterAttribute.Constitution)
                    {
                        constitution = dependency;
                    }
                }

                if(intelligence == null)
                {
                    throw new ArgumentException($"Could not find dependency attribute {ECharacterAttribute.Intelligence} for attribute {PA.Name}!");
                }
                if(constitution == null)
                {
                    throw new ArgumentException($"Could not find dependency attribute {ECharacterAttribute.Constitution} for attribute {PA.Name}!");
                }

                return value + 2 * (constitution.Value / 10 + intelligence.Value / 10) - 20;
            });
            Willpower.AddDependency(Constitution);
            Willpower.AddDependency(Intelligence);

            Movement = new CharacterAttribute(ECharacterAttribute.Movement, () => { return Dice.Roll(3) + Dice.Roll(3) + Dice.Roll(3) + Dice.Roll(3); }, (value, dependencies) => 
            {
                return value + 16;
            });
        }

    }
}
