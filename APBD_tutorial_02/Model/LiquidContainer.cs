using APBD_tutorial_02.Exception;
using APBD_tutorial_02.Notification;

namespace APBD_tutorial_02.Model;

public class LiquidContainer : Container, IHazardNotification
{
    public bool HazardousCargoStorage { get; }

    public LiquidContainer(bool hazardousCargoStorage, double height, double tareWeight, double depth, double maxPayload) 
        : base(depth: depth, height: height, maxPayload: maxPayload, tareWeight: tareWeight)
    {
        Type = ContainerType.Liquid;
        HazardousCargoStorage = hazardousCargoStorage;
    }

    public void LoadCargo(double cargoMass)
    {
        CheckOverfill(cargoMass);

        var storageUsage = Math.Round(cargoMass / MaxPayloadKgs * 100, 2);
        
        if (HazardousCargoStorage && cargoMass > 0.5 * MaxPayloadKgs)
            NotifyHazard($"Loading hazardous cargo ({storageUsage}%)");
        if (cargoMass > 0.9 * MaxPayloadKgs)
            NotifyHazard($"Loading cargo close to its max capacity ({storageUsage}%)");
        
        MassOfCargoKgs = cargoMass;
    }

    public override void EmptyCargo()
    {
        MassOfCargoKgs = 0;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[{SerialNumber}] Hazard: {message}");
    }
    
    protected override string GetTypePrefix()
    {
        return "L";
    }

    public override string ToString()
    {
        return base.ToString() + $", Hazardous cargo - {HazardousCargoStorage}";
    }
}