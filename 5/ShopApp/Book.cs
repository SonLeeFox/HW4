namespace ShopApp;

class Book : Product
{
    public int Pages { get; }
    public string Publisher { get; }
    public List<string> Authors { get; }

    public override string Kind => "Книга";
    public override string Details => $"{Pages} стор.; {Publisher}; {string.Join(", ", Authors)}";

    public Book(string name, decimal price, string country, DateTime packingDate, string description,
        int pages, string publisher, List<string> authors)
        : base(name, price, country, packingDate, description)
    {
        Pages = pages;
        Publisher = publisher;
        Authors = authors;
    }
}
