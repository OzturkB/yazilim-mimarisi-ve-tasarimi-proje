using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazilimMimarisiVeTasarimiProje
{
    public interface IVehicle
    {
        void DisplayInfo();
    }

    public class Car : IVehicle
    {
        public void DisplayInfo()
        {
            Console.WriteLine("Car produced");
        }
    }

    public class Truck : IVehicle
    {
        public void DisplayInfo()
        {
            Console.WriteLine("Truck produced");
        }
    }

    public class Motorcycle : IVehicle
    {
        public void DisplayInfo()
        {
            Console.WriteLine("Motorcycle produced");
        }
    }
}
