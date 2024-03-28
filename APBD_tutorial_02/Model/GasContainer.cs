using APBD_tutorial_02.Notification;

namespace APBD_tutorial_02.Model;

public class GasContainer : Container, IHazardNotification
{
    public override void LoadCargo(double cargoMass)
    {
        throw new NotImplementedException();
    }

    public override void EmptyCargo()
    {
        throw new NotImplementedException();
    }

    public void NotifyHazard(string containerNumber, string message)
    {
        throw new NotImplementedException();
    }
    
    protected override string GetTypePrefix()
    {
        return "G";
    }
}