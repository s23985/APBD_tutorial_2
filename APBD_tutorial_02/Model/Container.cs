using APBD_tutorial_02.Exception;

namespace APBD_tutorial_02.Model;

public abstract class Container
{
    private static int _containerCounter = 1;
    
    public ContainerType Type { get; protected set; }
    public string SerialNumber { get; protected set; }
    
    public double MassOfCargoKgs { get; protected set; }
    public double HeightCms { get; protected set; }
    public double TareWeightKgs { get; protected set; }
    public double DepthCms { get; protected set; }
    public double MaxPayloadKgs { get; protected set; }

    public Container(double height, double tareWeight, double depth, double maxPayload)
    {
        SerialNumber = GenerateSerialNumber();
        HeightCms = height;
        TareWeightKgs = tareWeight;
        DepthCms = depth;
        MaxPayloadKgs = maxPayload;
    }

    private string GenerateSerialNumber()
    {
        var typePrefix = GetTypePrefix();
        return $"KON-{typePrefix}-{_containerCounter++}";
    }

    protected abstract string GetTypePrefix();
    public abstract void EmptyCargo();
    
    protected void CheckOverfill(double cargoMass)
    {
        if (cargoMass > MaxPayloadKgs)
        {
            throw new OverfillException("Cargo mass exceeds container's capacity.");
        }
    }

    public override string ToString()
    {
        return
            $"Container {SerialNumber}: Mass of Cargo - {MassOfCargoKgs}kg, Height - {HeightCms}cm, Tare Weight - {TareWeightKgs}kg, Depth - {DepthCms}cm";
    }

    public enum ContainerType
    {
        Liquid,
        Gas,
        Refrigerated
    }
}