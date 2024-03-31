using APBD_tutorial_02.Model;

namespace APBD_tutorial_02;
    
public class Program
{
    public static void Main(string[] args)
    {
        // Create a container
        var liquidCon = new LiquidContainer(true, height: 5, tareWeight: 3, depth: 4, maxPayload: 234);
        var gasCon = new GasContainer(pressure: 10, height: 5, depth: 3, tareWeight: 5, maxPayload: 2156);
        var refiCon = new RefrigeratedContainer(productType: "Banana", temperature: 13.3, height: 4, depth: 12,
            tareWeight: 5, maxPayload: 1233);
        var liquidCon2 = new LiquidContainer(true, height: 2, tareWeight: 8, depth: 6, maxPayload: 400);
        
        // Load a container
        liquidCon.LoadCargo(154);
        gasCon.LoadCargo(125);

        gasCon.EmptyCargo();
        Console.WriteLine($"Mass of cargo in gas container after emptying: {gasCon.MassOfCargoKgs}");

        var loadInfo = new RefrigeratedCargoLoadInfo()
        {
            Temperature = 13.3,
            CargoMass = 234,
            ProductType = "Banana"
        };
        
        refiCon.LoadCargo(loadInfo);

        // Create a container ship
        var shipA = new ContainerShip(125, 4, 2);
        var shipB = new ContainerShip(222, 5, 4);

        var containers = new List<Container>
        {
            refiCon, liquidCon, gasCon, liquidCon2
        };

        // Load containers onto a ship
        shipA.LoadContainers(containers);

        // Remove a container from the ship
        shipA.RemoveContainer(liquidCon2.SerialNumber);
        
        // Unload a container
        shipA.LoadContainer(liquidCon2);
        var unloadedLiquidCon2 = shipA.UnloadContainer(liquidCon2.SerialNumber);
        
        // Replace a container on the ship with a given number with another container
        shipA.ReplaceContainer(liquidCon.SerialNumber, unloadedLiquidCon2);
        
        // The possibility of transferring a container between two ships
        shipA.TransferContainer(unloadedLiquidCon2.SerialNumber, shipB);
        
        shipA.PrintShipInfo();
        Console.WriteLine();
        shipB.PrintShipInfo();
    }
}