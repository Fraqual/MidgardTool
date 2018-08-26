using System;
using System.Collections.Generic;
using CharacterLogic.Enums;
using CharacterLogic.Interfaces;

namespace CharacterLogic
{
    public class Character : ICharacterLogic
    {
        public string Figure { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string PlayerName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public ECharacterClass Class { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Rank { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int LPMaximum { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int APMaximum { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Experience { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int ExperienceTotal { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public List<ISpecialAbility> Special { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public ERace Race { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
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

        }

        private void initialize()
        {
            Strength = new CharacterAttribute(ECharacterAttribute.Strength);
            GW = new CharacterAttribute(ECharacterAttribute.GW);
            Dexterity = new CharacterAttribute(ECharacterAttribute.Dexterity);
            Constitution = new CharacterAttribute(ECharacterAttribute.Constitution);
            Intelligence = new CharacterAttribute(ECharacterAttribute.Intelligence);
            MagicTalent = new CharacterAttribute(ECharacterAttribute.MagicTalent);
            Appereance = new CharacterAttribute(ECharacterAttribute.Appereance);

            PA = new CharacterAttribute(ECharacterAttribute.PA, (value, dependencies) =>
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

            Willpower = new CharacterAttribute(ECharacterAttribute.Willpower, (value, dependencies) => 
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

            Movement = new CharacterAttribute(ECharacterAttribute.Movement, (value, dependencies) => 
            {
                return value + 16;
            });
        }

    }
}
