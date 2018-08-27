using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger;
using CharacterLogic;

namespace Tests
{
    /// <summary>
    /// Test CharacterLogic Dll on it's own
    /// </summary>
    [TestClass]
    public class TestLogicDll
    {
        SimpleLogger _logger;
        public TestLogicDll()
        {
            _logger = SimpleLogger.Instance;
        }

        /// <summary>
        /// Test GetCharacterClasses
        /// </summary>
        [TestMethod]
        public void TestGetCharacterClasses()
        {

            _logger.Log("TestGetCharacterClasses", LogLevel.Tests);
            //List<string> comparisonList = new List<string>(){"Assasine", "Barbar", "Barde", "Glücksritter", "Händler", "Krieger", "Ordenskrieger", "Spitzbube", "Waldläufer", "Druide", "Hexer", "Magier", "Priester", "Schamane", "Heiler", "Runenmeister", "Thaumaturge", "Weise", "Ermittler", "Magister", "Schattengänger", "Tiermeister"};
            //Current available classes
            List<string> comparisonList = new List<string>() { "Waldläufer" };

            CharacterLogic.CreationLogic logic = new CharacterLogic.CreationLogic();
            List<string> classList = logic.GetCharacterClasses();

            CollectionAssert.AreEquivalent(comparisonList, classList);
        }

        [TestMethod]
        public void TestRaceClassExclution()
        {
            _logger.Log("TestRaceClassExclution", LogLevel.Tests);
            //List<string> comparisonList = new List<string>(){Händler, Krieger , Magier , Priester , Heiler , Runenmeister , Thaumaturge , Feldscher , Zauberkrämer};
            //Current available classes
            List<string> comparisonList = new List<string>();

            CharacterLogic.CreationLogic logic = new CharacterLogic.CreationLogic();
            logic.SetRace("Zwerg");
            List<string> classList = logic.GetCharacterClasses();

            CollectionAssert.AreEquivalent(comparisonList, classList);
        }
    }
}
