using ConsoleTables;
namespace A1VaniKhanna
{
    internal class Program
    {
        static void Main(string[] args)

        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
               new Car(1, "Toyota Camry", 50.00, "Sedan", "Standard", "yes"),
               new Car(2, "Honda Civic", 60.00, "Sedan", "Exotic", "yes"),
               new Car(3, "Ford Explorer", 69.99, "SUV", "Exotic", "yes"),
               new Car(4, "Nisan Versa", 50.00, "Hatchback", "Standard", "yes"),
               new Car(5, "Hundayi Tucsan", 89.90, "SUV", "Standard", "yes"),
               new Car(6, "Ferrari 488TB", 179.90, "Sports", "Standard", "yes"),
               new Car(7, "Toyoto Corolla", 69.90, "Sedan", "Standard", "yes"),
               new Car(8, "McLaern P1", 199.90, "Sports", "Exotic", "yes"),
             new Motorcycle(9, "Suzuki Boulevard M109R", 49.90, "Cruiser", "Bike", "yes"),
              new Motorcycle(10, "Harley Davidson", 79.90, "Cruiser", "Bike", "yes"),
              new Motorcycle(11, "Honda CRF125", 39.90, "Dirt", "Bike", "yes"),
              new Motorcycle(12, "Durati Monster", 69.90, "Sports", "Bike", "yes"),
              new Motorcycle(13, "Can-Am spyder", 59.90, "Cruiser", "Trike", "yes"),
              new Motorcycle(14, "Polaris Slingshot", 69.90, "Cruiser", "Trike", "yes"),


            };


            Console.WriteLine("\n\tAssignment 1 - Vani khanna\n");
            Console.WriteLine("\t- - - - - - - - - - - - - - - - - - - - -");
            while (true)
            {
            
            Console.WriteLine("\n\tMenu:");
            Console.WriteLine("\n\t1 - View all vehicles");
            Console.WriteLine("\n\t2 - View available vehicles");
            Console.WriteLine("\n\t3 - View reserved vehicles");
            Console.WriteLine("\n\t4 - Reserve a vehicle");
            Console.WriteLine("\n\t5 - Cancel reservation");
            Console.WriteLine("\n\t6 - Exit");

             Console.Write("\n\n\tEnter your choice -\t");
             string userChoice = Console.ReadLine();
                try
                {
                    switch (userChoice)
                    {

                        case "1":

                            var av = from vehicle in vehicles
                                     select vehicle;

                            ConsoleTable table = new ConsoleTable("ID", "Name", "Rental price", "Category", "Type", "Available");

                            foreach (var i in av)
                            {
                                table.AddRow(i.ID, i.Name, i.RentalPrice.ToString("C"), i.Category, i.Type, i.IsReserved);

                            }
                            table.Write(Format.Minimal);

                            break;

                        case "2":
                            var available = from vehicle in vehicles
                                            where vehicle.IsReserved == "yes"
                                            select vehicle;

                            ConsoleTable table1 = new ConsoleTable("ID", "Name", "Rental price", "Category", "Type", "Available");

                            foreach (var i in available)
                            {
                                table1.AddRow(i.ID, i.Name, i.RentalPrice.ToString("C"), i.Category, i.Type, i.IsReserved);

                            }
                            table1.Write(Format.Minimal);
                            break;


                        case "3":
                            var rv = from vehicle in vehicles
                                     where vehicle.IsReserved == "no"
                                     select vehicle;

                            ConsoleTable table2 = new ConsoleTable("ID", "Name", "Rental price", "Category", "Type", "Available");

                            foreach (var i in rv)
                            {
                                table2.AddRow(i.ID, i.Name, i.RentalPrice.ToString("C"), i.Category, i.Type, i.IsReserved);

                            }
                            if (table2.Rows.Count == 0)
                            {
                                Console.WriteLine("\n\t No Records Found !");
                            }
                            else
                            {
                                table2.Write(Format.Minimal);
                            }

                            break;

                        case "4":
                            Console.WriteLine("\t\nAvailable Vehicles:\n");
                            var avail = from vehicle in vehicles
                                        where vehicle.IsReserved == "yes"
                                        select vehicle;

                            ConsoleTable table3 = new ConsoleTable("ID", "Name", "Rental price", "Category", "Type", "Available");

                            foreach (var i in avail)
                            {
                                table3.AddRow(i.ID, i.Name, i.RentalPrice.ToString("C"), i.Category, i.Type, i.IsReserved);

                            }
                            table3.Write(Format.Minimal);

                            Console.Write("\n\tEnter Vehicle ID to Reserve:  ");
                            int reserveVehicleID = int.Parse(Console.ReadLine());

                            Vehicle reservedVehicle = null;

                            foreach (var vehicle in vehicles)
                            {
                                if (vehicle.ID == reserveVehicleID)
                                {
                                    reservedVehicle = vehicle;
                                    break;
                                }
                            }

                            if (reservedVehicle != null && reservedVehicle.IsReserved == "yes")
                            {

                                reservedVehicle.IsReserved = "no";

                                var res = from vehicle in vehicles
                                          where vehicle.IsReserved == "no"
                                          select vehicle;

                                ConsoleTable table4 = new ConsoleTable("ID", "Name", "Rental price", "Category", "Type");

                                foreach (var i in res)
                                {
                                    table4.AddRow(i.ID, i.Name, i.RentalPrice.ToString("C"), i.Category, i.Type);

                                }
                                Console.WriteLine("\n\tVehicle reserved successfully! :)\n");
                                table4.Write(Format.Minimal);
                            }

                            else
                            {

                                Console.WriteLine("\n\tInvalid ID or the vehicle is not available for reservation.");

                            }
                            break;



                        case "5":
                            Console.Write("\n\tEnter vehicle ID to cancel the Reservation: ");

                            int cancelVehicleID = int.Parse(Console.ReadLine());

                            Vehicle cancelVehicle = null;

                            foreach (var vehicle in vehicles)
                            {
                                if (vehicle.ID == cancelVehicleID)
                                {
                                    cancelVehicle = vehicle;
                                    break;
                                }
                            }

                            if (cancelVehicle != null && cancelVehicle.IsReserved == "no")
                            {

                                cancelVehicle.IsReserved = "yes";

                                Console.WriteLine("\n\tVehicle reservation Cancelled successfully :)\n");

                            }

                            else
                            {

                                Console.WriteLine("\n\tInvalid ID or the vehicle is not available for cancellation.");

                            }

                            break;

                        case "6":
                            return;

                        default:
                            Console.WriteLine("\n\tInvalid choice!:( Please try again.");
                            break;

                    }
                }
                catch(FormatException) {
                    Console.WriteLine("\tInvalid Input Enter a valid input");
                }

            }
                

        }

        
    }
}