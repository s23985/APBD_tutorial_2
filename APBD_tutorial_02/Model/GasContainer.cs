using APBD_tutorial_02.Exception;
using APBD_tutorial_02.Notification;

namespace APBD_tutorial_02.Model;

public class GasContainer : Container, IHazardNotification
{
    public double Pressure { get; }
    
    public GasContainer(double pressure, double height, double tareWeight, double depth, double maxPayload) 
        : base(depth: depth, height: height, maxPayload: maxPayload, tareWeight: tareWeight)
    {
        Type = ContainerType.Gas;
        Pressure = pressure;
    }
    
    public void LoadCargo(double cargoMass)
    {
        if (cargoMass > MaxPayload)
            throw new OverfillException("Cargo mass exceeds container capacity.");

        MassOfCargo = cargoMass;
    }

    public override void EmptyCargo()
    {
        if (MassOfCargo >= 0.05 * MaxPayload)
            MassOfCargo = 0.05 * MaxPayload;
    }
    
    protected override string GetTypePrefix()
    {
        return "G";
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[{SerialNumber}] Hazard: {message}");
    }
}