using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPattern_Decorator;

namespace DesignPattern_Test
{
    [TestClass]
    public class Decorator
    {
        [TestMethod]
        public void TestDecorator()
        {
            // Basic vehicle
            HondaCity car = new HondaCity();

            Console.WriteLine("Honda City base price are : {0}", car.Price);

            // Special offer
            SpecialOffer offer = new SpecialOffer(car);
            offer.DiscountPercentage = 25;
            offer.Offer = "25 % discount";

            Assert.IsNotNull(string.Format("{1} @ Diwali Special Offer and price are : {0} ", offer.Price, offer.Offer));
        }
    }
}
