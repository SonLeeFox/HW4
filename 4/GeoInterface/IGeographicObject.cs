namespace GeoInterface;

interface IGeographicObject
{
    double X { get; }
    double Y { get; }
    string Name { get; }
    string Description { get; }

    string GetInfo();
}
