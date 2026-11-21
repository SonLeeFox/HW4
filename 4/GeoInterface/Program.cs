namespace GeoInterface;

static class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            List<IGeographicObject> objects = new()
            {
                new River(30.52, 50.45, "Дніпро", "Найбільша річка України", 45, 2201),
                new Mountain(24.50, 48.16, "Говерла", "Найвища вершина України", 2061)
            };

            foreach (IGeographicObject geographicObject in objects)
            {
                Console.WriteLine(geographicObject.GetInfo());
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка в даних об'єкта: {ex.Message}");
        }

        Console.WriteLine("Натисніть Enter для виходу...");
        Console.ReadLine();
    }
}
