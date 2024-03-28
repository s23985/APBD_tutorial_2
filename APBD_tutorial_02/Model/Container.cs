namespace APBD_tutorial_02.Model;

public abstract class Container
{
    private static int _containerCounter = 1;
    
    public string SerialNumber { get; protected set; }
    public double MassOfCargo { get; protected set; }
    public double Height { get; protected set; }
    public double TareWeight { get; protected set; }
    public double Depth { get; protected set; }
    public double MaxPayload { get; protected set; }

    public Container()
    {
        SerialNumber = GenerateSerialNumber();
    }

    private string GenerateSerialNumber()
    {
        var typePrefix = GetTypePrefix();
        return $"KON-{typePrefix}-{_containerCounter++}";
    }

    protected abstract string GetTypePrefix();
    public abstract void LoadCargo(double cargoMass);
    public abstract void EmptyCargo();
    
}