using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern_Decorator
{
    public class HondaCity : IVehicle
    {
        public string Make
        {
            get { return "HondaCity"; }
        }

        public string Model
        {
            get { return "CNG"; }
        }

        public double Price
        {
            get { return 1000000; }
        }
    }
}
