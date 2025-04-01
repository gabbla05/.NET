using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehcicleRentalSystem
{
    public class RentalCompany
    {
        private List<Vehicle> vehicles = new();
        private List<Reservation> reservations = new();

        public event Action<string> OnNewReservation;

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void ReserveVehicle(int vehicleId, string customer)
        {
            var vehicle = vehicles.FirstOrDefault(v => v.Id == vehicleId);
            if (vehicle is IReservable reservable && vehicle.IsAvailable)
            {
                reservable.Reserve(customer);
                reservations.Add(new Reservation(vehicleId, customer));
                OnNewReservation?.Invoke($"New reservation for vehicle ID {vehicleId} by {customer}.");
            }
        }

        public void CancelReservation(int vehicleId)
        {
            var reservation = reservations.FirstOrDefault(r => r.VehicleId == vehicleId);
            if (reservation != null)
            {
                var vehicle = vehicles.FirstOrDefault(v => v.Id == vehicleId);
                if (vehicle is IReservable reservable)
                {
                    reservable.CancelReservation();
                    reservations.Remove(reservation);
                }
            }
        }

        public void ListAvailableVehicles()
        {
            var available = vehicles.GetAvailableVehicles();
            foreach (var v in available)
            {
                v.DisplayInfo();
            }
        }
    }


}
