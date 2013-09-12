using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern_Test
{
    [TestClass]
    public class Singleton
    {
        [TestMethod]
        public void TestSingleton()
        {
            Assert.IsNotNull(DesignPattern_Singleton.Singleton.Instance.Show());
        }
    }
}
