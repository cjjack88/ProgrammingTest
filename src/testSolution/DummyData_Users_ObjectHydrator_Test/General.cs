using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DummyData_Users_ObjectHydrator;

namespace DummyData_Users_ObjectHydrator_Test
{
    [TestClass]
    public class General
    {
        [TestMethod]
        public void TestGetSingle()
        {
            UserModel theUser = new Users().GetSingle();
            Assert.IsNotNull(theUser);
        }

        [TestMethod]
        public void TestMultiple()
        {
            IList<UserModel> theUser = new Users().GetMultiple(50);
            Assert.IsNotNull(theUser);
            Assert.IsTrue(theUser.Count() == 50);
        }
    }
}
