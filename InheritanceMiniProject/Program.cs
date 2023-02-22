

internal class Program
{
    private static void Main(string[] args)
    {
        Car toyota = new Car { NumberOfWheels = 4, ProductTitle = "Toyota Tacoma" };
        Car honda = new Car { NumberOfWheels = 4, ProductTitle = "Honda Civic" };
        Motorcycle harley = new Motorcycle { NumberOfWheels = 2, ProductTitle = "Harley, Davidson" };
        Boat ship = new Boat { NumberOfWheels = 0, ProductTitle = "The Black Pearl" };


        List<IRidable> ridable = new List<IRidable>();
        List<IDrivable> drivable = new List<IDrivable>();

        ridable.Add(harley);
        ridable.Add(ship);
        drivable.Add(honda);
        drivable.Add(toyota);

        Console.Write($"Hello, would you like to ride or drive? (enter ride/drive): ");
        string userResponse = Console.ReadLine().ToLower();

        bool isDone = false;
        do
        {
            if (userResponse == "ride")
            {
                var count = 1;
                foreach (var vehicle in ridable)
                {
                    Console.Write($"Would you like to ride a {vehicle.ProductTitle}? (yes/no)");
                    string rideResponse = Console.ReadLine().ToLower();

                    if (rideResponse == "yes")
                    {
                        vehicle.Ride();
                        isDone = true;
                    }

                    if (count == ridable.Count)
                    {
                        Console.WriteLine("There are no other drivable vehicles, Try again");
                        Console.Write("Press Enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        count -= ridable.Count; 
                    }
                    count++;
                }


            }
            else if (userResponse == "drive")
            {
                var count = 1;
                foreach (var vehicle in drivable)
                {
                    Console.Write($"Would you like to drive a {vehicle.ProductTitle}? (yes/no): ");
                    string rideResponse = Console.ReadLine().ToLower();

                    if (rideResponse == "yes")
                    {
                        vehicle.Drive();
                        isDone = true;
                    }
                    if (count == ridable.Count)
                    {
                        Console.WriteLine("There are no other drivable vehicles, Try again");
                        Console.Write("Press Enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                        count -= ridable.Count;
                    }
                    count++;

                }
            }
            else
            {
                Console.WriteLine("We have no more vehicles.");
                Console.Write("Press enter to try again... ");
                Console.ReadLine();
                Console.Clear();
            }
        } while (!isDone);

        Console.ReadLine();

    }
}

public interface IProduct
{
    public string ProductTitle { get; set; }
    public int NumberOfWheels { get; set; }
}

public interface IDrivable : IProduct
{
    public void Drive();
}

public interface IRidable : IProduct
{
    public void Ride();
}

public class Vehicle : IProduct
{
    public string ProductTitle { get; set; }
    public int NumberOfWheels { get; set; }

    public void TurnOn()
    {
        Console.WriteLine("Vehicle turns on");
    }

    public void TurnOff()
    {
        Console.WriteLine("Vehicle turns off");
    }
}

public class Car : Vehicle, IDrivable
{
    public string ProductTitle { get; set; }
    public int NumberOfWheels { get; set; }

    public void Drive()
    {
        Console.WriteLine("Car goes vrooom");
    }
}

public class Motorcycle : Vehicle, IRidable
{
    public string ProductTitle { get; set; }
    public int NumberOfWheels { get; set; }

    public void Ride()
    {
        Console.WriteLine("Motorcycle ride");
    }
}

public class Boat : Vehicle, IProduct, IRidable
{
    public string ProductTitle { get; set; }
    public int NumberOfWheels { get; set; }

    public void Ride()
    {
        Console.WriteLine("Boat goes float");
    }
}

