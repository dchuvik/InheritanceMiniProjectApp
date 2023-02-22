

public class BookModel : InventoryItemModel, IPurchase
{
    public int NumberOfPages { get; set; }

    public void Purchase()
    {
        QuantityInStock -= 1;
        Console.WriteLine("This item has been purchased.");
    }
}
