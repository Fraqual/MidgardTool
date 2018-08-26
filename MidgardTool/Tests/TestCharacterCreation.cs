using System;
using CharacterLogic;
using CharacterLogic.Enums;
using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            PA.Value = 0;
            Assert.IsTrue(PA.IsSet == false);

            Intelligence.Value = 0;
            Assert.IsTrue(Intelligence.IsSet == true);

            PA.Value = 0;
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

            Intelligence.Value = 100;

            PA.SetDependencyValue(CharacterAttribute.RollDice(100));
        }

    }
}
