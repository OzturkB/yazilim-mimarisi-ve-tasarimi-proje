using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazilimMimarisiVeTasarimiProje
{
    public enum VehicleType
    {
        Car = 1,
        Truck = 2,
        Motorcycle = 3
    }

    public interface IVehicleFactory
    {
        IVehicle ProduceVehicle(VehicleType type);
    }

    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle ProduceVehicle(VehicleType type)
        {
            IVehicle vehicle = null;
            switch (type)
            {
                case VehicleType.Car:
                    vehicle = new Car();
                    break;
                case VehicleType.Truck:
                    vehicle = new Truck();
                    break;
                case VehicleType.Motorcycle:
                    vehicle = new Motorcycle();
                    break;
            }
            return vehicle;
        }
    }
}
