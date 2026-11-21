namespace ShopApp;

abstract class Product
{
    public string Name { get; }
    public decimal Price { get; }
    public string Country { get; }
    public DateTime PackingDate { get; }
    public string Description { get; }

    public abstract string Kind { get; }
    public abstract string Details { get; }

    protected Product(string name, decimal price, string country, DateTime packingDate, string description)
    {
        Name = name;
        Price = price;
        Country = country;
        PackingDate = packingDate;
        Description = description;
    }
}
