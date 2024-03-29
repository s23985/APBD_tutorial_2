using APBD_tutorial_02.Model;

public class Program
{
    public static void Main(string[] args)
    {
        var liquidCon = new LiquidContainer(true, height: 5, tareWeight: 3, depth: 4, maxPayload: 234);
        var gasCon = new GasContainer(pressure: 10, height: 5, depth: 3, tareWeight: 5, maxPayload: 2156);
        var refiCon = new RefrigeratedContainer(productType: "Banana", temperature: 13.3, height: 4, depth: 12,
            tareWeight: 5, maxPayload: 1233);
        
        liquidCon.LoadCargo(154);
        
        liquidCon.EmptyCargo();
        
        gasCon.LoadCargo(100);
        Console.WriteLine(gasCon.MassOfCargo);

        gasCon.EmptyCargo();
        Console.WriteLine(gasCon.MassOfCargo);

        var loadInfo = new RefrigeratedCargoLoadInfo()
        {
            Temperature = 13.4,
            CargoMass = 234,
            ProductType = "Banana"
        };
        
        refiCon.LoadCargo(loadInfo);

        Console.WriteLine($"liquidCon: {liquidCon.SerialNumber}, gasCon: {gasCon.SerialNumber}, refiCon: {refiCon.SerialNumber}");
    }
}