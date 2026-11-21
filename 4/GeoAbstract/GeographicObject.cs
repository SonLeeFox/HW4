namespace GeoAbstract;

abstract class GeographicObject
{
    public double X { get; }
    public double Y { get; }
    public string Name { get; }
    public string Description { get; }

    protected GeographicObject(double x, double y, string name, string description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        X = x;
        Y = y;
        Name = name;
        Description = description;
    }

    public virtual string GetInfo() => $"{Name} (X = {X}, Y = {Y}): {Description}";
}
