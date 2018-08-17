using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test CharacterLogic Dll on it's own
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            //List<string> comparisonList = new List<string>(){"Assasine", "Barbar", "Barde", "Glücksritter", "Händler", "Krieger", "Ordenskrieger", "Spitzbube", "Waldläufer", "Druide", "Hexer", "Magier", "Priester", "Schamane", "Heiler", "Runenmeister", "Thaumaturge", "Weise", "Ermittler", "Magister", "Schattengänger", "Tiermeister"};
            //Current available classes
            List<string> comparisonList = new List<string>() { "Waldläufer" };

            CharacterLogic.CreationLogic logic = new CharacterLogic.CreationLogic();
            List<string> classesStrings = logic.getCharacterClasses();

            Assert.AreEqual(comparisonList, classesStrings);
        }
    }
}
