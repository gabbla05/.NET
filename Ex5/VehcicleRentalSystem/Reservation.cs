using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehcicleRentalSystem
{
    public class Reservation
    {
        public int VehicleId { get; }
        public string Customer { get; }

        public Reservation(int vehicleId, string customer)
        {
            VehicleId = vehicleId;
            Customer = customer;
        }
    }


}
