using APBD_tutorial_02.Model;

public class Program
{
    public static void Main(string[] args)
    {
        var liquidCon = new LiquidContainer();
        var gasCon = new GasContainer();
        var refiCon = new RefrigeratedContainer();

        Console.WriteLine($"liquidCon: {liquidCon.SerialNumber}, gasCon: {gasCon.SerialNumber}, refiCon: {refiCon.SerialNumber}");
    }
}