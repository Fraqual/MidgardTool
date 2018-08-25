using System;
using CharacterLogic;
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
            CharacterAttribute<int> Intelligence = new CharacterAttribute<int>("Intelligence");
            CharacterAttribute<int> PA = new CharacterAttribute<int>("PA");

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
            CharacterAttribute<int> Intelligence = new CharacterAttribute<int>("Intelligence");
            CharacterAttribute<int> PA = new CharacterAttribute<int>("PA", (attribute, dependencies) => 
            {
                ICharacterAttribute intelligence = null;
                string intelligenceName = "Intelligence";

                foreach(var dependency in dependencies)
                {
                    if(dependency.Name == intelligenceName)
                    {
                        intelligence = dependency;
                    }
                }

                if(intelligence == null)
                {
                    throw new ArgumentException($"Dependency {intelligenceName} could not be found!");
                }

                return null;
            });

            PA.AddDependency(Intelligence);
        }

    }
}
