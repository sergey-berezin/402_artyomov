namespace autum_2024_task_1;
using NugetPack;

public class Prog
{
    public static void Main()
    {
        var GenAlg = new GenericAlgo;
        GenAlg.Initialize(3, 3, 3, 64);
        var bestSol = GenAlg.GetBestSol(1000);

        Console.WriteLine("Лучшая расстановка:");
        foreach (sq in  bestSol.rectangles)
        {
            Console.WriteLine($"x_l: {sq.x_l} y_b: {sq.y_b} w: {sq.w} h: {sq.h}");
        }

        Console.WriteLine($"Площадь содержащего прямокгольника: {bestSol.Metric}");

    }
}
