using NUnit.Framework;
using VehicleRentalSystem;
using System.Collections.Generic;
using VehcicleRentalSystem;

namespace VehicleRentalSystem.Tests
{
    public class RentalTests
    {
        [Test]
        public void Car_Creation_Should_Set_Properties()
        {
            var car = new Car(1, "Audi", "A4", 2019, "Sedan");

            Assert.AreEqual("Audi", car.Brand);
            Assert.AreEqual("A4", car.Model);
            Assert.AreEqual(2019, car.Year);
            Assert.AreEqual("Sedan", car.BodyType);
            Assert.IsTrue(car.IsAvailable);
        }

        [Test]
        public void Motorcycle_Can_Be_Reserved_And_Canceled()
        {
            var moto = new Motorcycle(2, "Honda", "CB500", 2020, 500);

            moto.Reserve("Tester");
            Assert.IsFalse(moto.IsAvailable);

            moto.CancelReservation();
            Assert.IsTrue(moto.IsAvailable);
        }

        [Test]
        public void GetAvailableVehicles_Should_Return_Only_Available()
        {
            var car = new Car(1, "Audi", "A4", 2019, "Sedan");
            var moto = new Motorcycle(2, "Yamaha", "R3", 2021, 321);
            moto.Reserve("X");

            var list = new List<Vehicle> { car, moto };
            var available = list.GetAvailableVehicles();

            Assert.AreEqual(1, available.Count);
            Assert.AreEqual(car, available[0]);
        }

        [Test]
        public void OnNewReservation_Event_Should_Trigger()
        {
            var rental = new RentalCompany();
            var triggered = false;

            rental.OnNewReservation += (msg) => triggered = true;

            rental.AddVehicle(new Car(1, "Ford", "Focus", 2018, "Hatchback"));
            rental.ReserveVehicle(1, "Tester");

            Assert.IsTrue(triggered);
        }
    }
}
