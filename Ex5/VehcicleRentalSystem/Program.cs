using VehcicleRentalSystem;

class Program
{
    static void Main()
    {
        var rentalCompany = new RentalCompany();

        rentalCompany.AddVehicle(new Car(1, "Toyota", "Corolla", 2020, "Sedan"));
        rentalCompany.AddVehicle(new Motorcycle(2, "Yamaha", "MT-07", 2021, 689));

        rentalCompany.OnNewReservation += message => Console.WriteLine(message);

        rentalCompany.ReserveVehicle(1, "John Doe");
        rentalCompany.ListAvailableVehicles();
    }
}
