

public class Escavator : InventoryItemModel, IRental
{
    public void Dig()
    {
        Console.WriteLine("digging");
    }

    public void Rent()
    {
        QuantityInStock -= 1;
        Console.WriteLine("has been rented");
    }

    public void ReturnRental()
    {
        QuantityInStock += 1;
        Console.WriteLine("has been returned");
    }
}