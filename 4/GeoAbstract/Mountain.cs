namespace GeoAbstract;

class Mountain : GeographicObject
{
    public double HighestPoint { get; }

    public Mountain(double x, double y, string name, string description, double highestPoint)
        : base(x, y, name, description)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(highestPoint);

        HighestPoint = highestPoint;
    }

    public override string GetInfo() => $"{base.GetInfo()}; найвища точка: {HighestPoint} м";
}
