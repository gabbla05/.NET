using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehcicleRentalSystem
{
    public class Motorcycle : Vehicle, IReservable
    {
        public int EngineCapacity { get; }

        public Motorcycle(int id, string brand, string model, int year, int engineCapacity)
            : base(id, brand, model, year)
        {
            EngineCapacity = engineCapacity;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Motorcycle: {Brand} {Model}, {Year}, Engine: {EngineCapacity}cc, Available: {IsAvailable}");
        }

        public void Reserve(string customer)
        {
            IsAvailable = false;
        }

        public void CancelReservation()
        {
            IsAvailable = true;
        }
    }

}
