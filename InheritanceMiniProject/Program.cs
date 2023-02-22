

internal class Program
{
    private static void Main(string[] args)
    {
        List<IRental> rentals = new List<IRental>();
        List<IPurchase> purchases = new List<IPurchase>();


        List<InventoryItemModel> inventory = new List<InventoryItemModel>();

        var vehicle = new VehicleModel { DealerFee = 25, ProductName = "Toyota Camry" };
        var book = new BookModel { ProductName = "Bible", NumberOfPages = 1000 };
        var escavator = new Escavator { ProductName = "CAT Escavotor", QuantityInStock = 2 };

        rentals.Add(vehicle);
        rentals.Add(escavator);

        purchases.Add(book);
        purchases.Add(vehicle);

        Console.Write($"do you want to rent or puchase: ");
        string rentalDecision = Console.ReadLine();

        if (rentalDecision.ToLower() == "rent")
        {

            foreach (var rentable in rentals)
            {
                Console.WriteLine($"Would you like to rent a {rentable.ProductName} (yes/no) : ");
                if (Console.ReadLine().ToLower() == "yes")
                {
                    rentable.Rent();
                }
            }
        }
        else
        {
            foreach (var purchasable in purchases)
            {
                Console.WriteLine($"Item: {purchasable.ProductName}");
                Console.Write("Would you like to purchase this product (yes/no): ");
                string wantToPurchase = Console.ReadLine();

                if (wantToPurchase.ToLower() == "yes")
                {
                    purchasable.Purchase();
                }
            }
        }



        Console.ReadLine();
    }
}
