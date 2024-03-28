namespace APBD_tutorial_02.Model;

public class RefrigeratedContainer : Container
{
    public override void LoadCargo(double cargoMass)
    {
        throw new NotImplementedException();
    }

    public override void EmptyCargo()
    {
        throw new NotImplementedException();
    }
    
    protected override string GetTypePrefix()
    {
        return "C";
    }
}