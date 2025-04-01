﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehcicleRentalSystem
{
    public static class VehicleExtensions
    {
        public static List<Vehicle> GetAvailableVehicles(this List<Vehicle> vehicles)
        {
            return vehicles.Where(v => v.IsAvailable).ToList();
        }
    }


}
