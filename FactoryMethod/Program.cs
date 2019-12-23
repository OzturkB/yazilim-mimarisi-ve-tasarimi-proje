using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazilimMimarisiVeTasarimiProje
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicleFactory = new VehicleFactory();

            IVehicle vehicleCar = vehicleFactory.ProduceVehicle(VehicleType.Car);
            vehicleCar.DisplayInfo();

            IVehicle vehicleMotorcycle = vehicleFactory.ProduceVehicle(VehicleType.Motorcycle);
            vehicleMotorcycle.DisplayInfo();
            Console.ReadLine();
        }
    }
}
