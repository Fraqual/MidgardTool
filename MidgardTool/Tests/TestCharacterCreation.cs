using System;
using MidgardEntities.Character;
using MidgardEntities.Enums;
using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MidgardToolHelper;
using XmlHelper;
using ConfigManager;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class TestCharacterCreation
    {
        private SimpleLogger m_Logger;

        public TestCharacterCreation()
        {
            m_Logger = SimpleLogger.Instance;
        }

        [TestMethod]
        public void TestAttributeDependency()
        {
            CharacterAttribute Intelligence = new CharacterAttribute(ECharacterAttribute.Intelligence);
            CharacterAttribute PA = new CharacterAttribute(ECharacterAttribute.PA);

            PA.AddDependency(Intelligence);

            PA.SetValue(1);
            Assert.IsTrue(PA.IsSet == false);

            Intelligence.SetValue(1);
            Assert.IsTrue(Intelligence.IsSet == true);

            PA.SetValue(1);
            Assert.IsTrue(PA.IsSet == true);
        }

        [TestMethod]
        public void TestAttributeDependencyFormula()
        {
            CharacterAttribute Intelligence = new CharacterAttribute(ECharacterAttribute.Intelligence);
            CharacterAttribute PA = new CharacterAttribute(ECharacterAttribute.PA, (value, dependencies) => 
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
                    throw new ArgumentException($"Dependency {ECharacterAttribute.Intelligence} could not be found!");
                }

                return value + 4 * intelligence.Value / 10 -20;
            });

            PA.AddDependency(Intelligence);

            Intelligence.SetValue(100);

            PA.SetValue(Dice.Roll(100));
        }

        [TestMethod]
        public void LoadCharacterClasses()
        {
            XmlCharacterCreationReader reader = new XmlCharacterCreationReader(MTConfiguration.Instance.XmlPath);

            List<CharacterClass> classes;
            List<CharacterRace> races;

            reader.Read(out classes, out races);
        }

        [TestMethod]
        public void GetAttributeBoarders()
        {
            XmlCharacterCreationReader reader = new XmlCharacterCreationReader(MTConfiguration.Instance.XmlPath);

            reader.ReadAttributeBorders("Zwerg", "Stärke");
        }

    }
}
