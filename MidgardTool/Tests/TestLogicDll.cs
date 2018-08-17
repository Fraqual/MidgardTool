using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger;

namespace Tests
{
    [TestClass]
    public class TestLogicDll
    {
        SimpleLogger _logger;
        public TestLogicDll()
        {
            _logger = SimpleLogger.Instance;
        }

        /// <summary>
        /// Test CharacterLogic Dll on it's own
        /// </summary>
        [TestMethod]
        public void TestGetCharacterClasses()
        {

            _logger.Log("TestGetCharacterClasses", LogLevel.Tests);
            //List<string> comparisonList = new List<string>(){"Assasine", "Barbar", "Barde", "Glücksritter", "Händler", "Krieger", "Ordenskrieger", "Spitzbube", "Waldläufer", "Druide", "Hexer", "Magier", "Priester", "Schamane", "Heiler", "Runenmeister", "Thaumaturge", "Weise", "Ermittler", "Magister", "Schattengänger", "Tiermeister"};
            //Current available classes
            List<string> comparisonList = new List<string>() { "Waldläufer" };

            CharacterLogic.CreationLogic logic = new CharacterLogic.CreationLogic();
            List<string> classesStrings = logic.getCharacterClasses();

            Assert.AreEqual(comparisonList, classesStrings);
        }
    }
}
