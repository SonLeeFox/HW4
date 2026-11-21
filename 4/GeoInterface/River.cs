namespace GeoInterface;

class River : IGeographicObject
{
    public double X { get; }
    public double Y { get; }
    public string Name { get; }
    public string Description { get; }
    public double FlowSpeed { get; }
    public double Length { get; }

    public River(double x, double y, string name, string description, double flowSpeed, double length)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegative(flowSpeed);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(length);

        X = x;
        Y = y;
        Name = name;
        Description = description;
        FlowSpeed = flowSpeed;
        Length = length;
    }

    public string GetInfo() =>
        $"{Name} (X = {X}, Y = {Y}): {Description}; швидкість течії: {FlowSpeed} см/с; довжина: {Length} км";
}
