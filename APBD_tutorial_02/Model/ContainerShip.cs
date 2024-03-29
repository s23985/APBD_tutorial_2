namespace APBD_tutorial_02.Model;

public class ContainerShip
{
    public List<Container> Containers { get; private set; } = [];
    public int MaxSpeedKnots { get; }
    public int MaxContainers { get; }
    public double MaxWeightTons { get; }
    
    public ContainerShip(int maxSpeedKnots, int maxContainers, double maxWeightTons)
    {
        MaxSpeedKnots = maxSpeedKnots;
        MaxContainers = maxContainers;
        MaxWeightTons = maxWeightTons;
    }

    public void LoadContainer(Container container)
    {
        var containersWeight = GetContainersWeight();
        var weightAfterLoad = (containersWeight + container.TareWeightKgs + container.MassOfCargoKgs) / 1000;
        
        if (Containers.Count >= MaxContainers || weightAfterLoad >= MaxWeightTons)
            throw new InvalidOperationException("Cannot load more containers. Maximum capacity reached.");
        
        Containers.Add(container);
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void RemoveContainer(string serialNumber)
    {
        var containerToRemove = Containers.SingleOrDefault(x => x.SerialNumber == serialNumber);
        if (containerToRemove != null)
            Containers.Remove(containerToRemove);
    }

    public Container? UnloadContainer(string serialNumber)
    {
        var container = Containers.SingleOrDefault(x => x.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
            return container;
        }

        return null;
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        RemoveContainer(serialNumber);
        LoadContainer(newContainer);
    }

    public void TransferContainer(string serialNumber, ContainerShip targetShip)
    {
        var container = UnloadContainer(serialNumber);
        
        if (container != null)
            targetShip.LoadContainer(container);
    }
    
    public void PrintShipInfo()
    {
        var containersWeight = Math.Round(GetContainersWeight(), 2);
        
        Console.WriteLine($"Container Ship Info - Max Speed: {MaxSpeedKnots} knots, Max Containers: {MaxContainers}, Max Weight: {MaxWeightTons} tons");
        Console.WriteLine($"Container Ship Status - Used Containers space: {Containers.Count}, Used Weight capacity: {containersWeight} tons");
        Console.WriteLine("Containers:");
        foreach (var container in Containers)
        {
            Console.WriteLine(container.ToString());
        }
    }

    private double GetContainersWeight()
    {
        var weightKgs = Containers.Sum(x => x.TareWeightKgs + x.MassOfCargoKgs);
        return weightKgs / 1000;
    }
}