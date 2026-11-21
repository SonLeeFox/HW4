namespace ShopApp;

class FoodProduct : Product
{
    public int ShelfLifeDays { get; }
    public decimal Quantity { get; }
    public string Unit { get; }

    public override string Kind => "Продукт";
    public override string Details => $"Термін придатності: {ShelfLifeDays} дн.; кількість: {Quantity} {Unit}";

    public FoodProduct(string name, decimal price, string country, DateTime packingDate, string description,
        int shelfLifeDays, decimal quantity, string unit)
        : base(name, price, country, packingDate, description)
    {
        ShelfLifeDays = shelfLifeDays;
        Quantity = quantity;
        Unit = unit;
    }
}
