using APBD_tutorial_02.Exception;
using APBD_tutorial_02.Notification;

namespace APBD_tutorial_02.Model;

public class GasContainer : Container, IHazardNotification
{
    public double PressureAtms { get; }
    
    public GasContainer(double pressure, double height, double tareWeight, double depth, double maxPayload) 
        : base(depth: depth, height: height, maxPayload: maxPayload, tareWeight: tareWeight)
    {
        Type = ContainerType.Gas;
        PressureAtms = pressure;
    }
    
    public void LoadCargo(double cargoMass)
    {
        CheckOverfill(cargoMass);

        MassOfCargoKgs = cargoMass;
    }

    public override void EmptyCargo()
    {
        if (MassOfCargoKgs >= 0.05 * MaxPayloadKgs)
            MassOfCargoKgs = 0.05 * MaxPayloadKgs;
    }
    
    protected override string GetTypePrefix()
    {
        return "G";
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[{SerialNumber}] Hazard: {message}");
    }

    public override string ToString()
    {
        return base.ToString() + $", Pressure - {PressureAtms} atmospheres";
    }
}