using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigManager;

namespace Tests
{
    [TestClass]
    public class TestConfigManager
    {
        [TestMethod]
        public void CreateConfig()
        {
            MTConfiguration conf = MTConfiguration.Instance;
        }
    }
}
