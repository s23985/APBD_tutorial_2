using APBD_tutorial_02.Exception;

namespace APBD_tutorial_02.Model;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; }
    public double Temperature { get; }
 
    public RefrigeratedContainer(string productType, double temperature, double height, double tareWeight, double depth, double maxPayload)
        : base(depth: depth, height: height, maxPayload: maxPayload, tareWeight: tareWeight)
    {
        Type = ContainerType.Refrigerated;
        ProductType = productType;
        Temperature = temperature;
    }
    
    public void LoadCargo(RefrigeratedCargoLoadInfo cargoLoadInfo)
    {
        if (cargoLoadInfo.ProductType != ProductType || Temperature < cargoLoadInfo.Temperature)
            throw new InvalidContainerException("Container is not suitable.");
        
        if (cargoLoadInfo.CargoMass > MaxPayload)
            throw new OverfillException("Cargo mass exceeds container capacity.");

        MassOfCargo = cargoLoadInfo.CargoMass;
    }

    public override void EmptyCargo()
    {
        MassOfCargo = 0;
    }
    
    protected override string GetTypePrefix()
    {
        return "C";
    }
}

public class RefrigeratedCargoLoadInfo
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }
    public double CargoMass { get; set; }
}