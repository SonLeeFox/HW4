namespace GeoInterface;

class Mountain : IGeographicObject
{
    public double X { get; }
    public double Y { get; }
    public string Name { get; }
    public string Description { get; }
    public double HighestPoint { get; }

    public Mountain(double x, double y, string name, string description, double highestPoint)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(highestPoint);

        X = x;
        Y = y;
        Name = name;
        Description = description;
        HighestPoint = highestPoint;
    }

    public string GetInfo() =>
        $"{Name} (X = {X}, Y = {Y}): {Description}; найвища точка: {HighestPoint} м";
}
