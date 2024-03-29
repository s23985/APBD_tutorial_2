namespace APBD_tutorial_02.Model;

public abstract class Container
{
    private static int _containerCounter = 1;
    
    public ContainerType Type { get; protected set; }
    public string SerialNumber { get; protected set; }
    
    public double MassOfCargo { get; protected set; }
    public double Height { get; protected set; }
    public double TareWeight { get; protected set; }
    public double Depth { get; protected set; }
    public double MaxPayload { get; protected set; }

    public Container(double height, double tareWeight, double depth, double maxPayload)
    {
        SerialNumber = GenerateSerialNumber();
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxPayload = maxPayload;
    }

    private string GenerateSerialNumber()
    {
        var typePrefix = GetTypePrefix();
        return $"KON-{typePrefix}-{_containerCounter++}";
    }

    protected abstract string GetTypePrefix();
    public abstract void EmptyCargo();
    
    public enum ContainerType
    {
        Liquid,
        Gas,
        Refrigerated
    }
}