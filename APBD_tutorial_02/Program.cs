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
        Console.WriteLine(gasCon.MassOfCargoKgs);

        gasCon.EmptyCargo();
        Console.WriteLine(gasCon.MassOfCargoKgs);

        var loadInfo = new RefrigeratedCargoLoadInfo()
        {
            Temperature = 13.3,
            CargoMass = 234,
            ProductType = "Banana"
        };
        
        refiCon.LoadCargo(loadInfo);

        var containerShip = new ContainerShip(125, 3, 2);

        var containers = new List<Container>
        {
            refiCon, liquidCon, gasCon
        };

        containerShip.LoadContainers(containers);
        containerShip.PrintShipInfo();
    }
}