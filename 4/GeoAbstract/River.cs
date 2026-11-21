namespace GeoAbstract;

class River : GeographicObject
{
    public double FlowSpeed { get; }
    public double Length { get; }

    public River(double x, double y, string name, string description, double flowSpeed, double length)
        : base(x, y, name, description)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(flowSpeed);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(length);

        FlowSpeed = flowSpeed;
        Length = length;
    }

    public override string GetInfo() =>
        $"{base.GetInfo()}; швидкість течії: {FlowSpeed} см/с; довжина: {Length} км";
}
