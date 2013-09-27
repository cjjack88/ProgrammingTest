using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDisposeable_Lib;

namespace IDisposable_Lib_Test
{
    [TestClass]
    public class TestIDisposeable
    {
        [TestMethod]
        public void TestIDisposableTwise()
        {
            using (CallStringBuilder myCallStringBuilder = new CallStringBuilder())
            {
                Assert.IsTrue((myCallStringBuilder.GetHelloWorld() == "Hello World"));
                Assert.IsTrue((myCallStringBuilder.GetHelloWorld() == "Hello World"));
            }
        }
    }
}
