using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehcicleRentalSystem
{
    public class Car : Vehicle, IReservable
    {
        public string BodyType { get; }

        public Car(int id, string brand, string model, int year, string bodyType)
            : base(id, brand, model, year)
        {
            BodyType = bodyType;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Car: {Brand} {Model}, {Year}, Body: {BodyType}, Available: {IsAvailable}");
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
