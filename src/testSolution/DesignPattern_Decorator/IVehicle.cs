using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern_Decorator
{
    public interface IVehicle
    {
        string Make { get; }
        string Model { get; }
        double Price { get; }
    }
}
