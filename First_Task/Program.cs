namespace autum_2024_task_1;
using NugetPack;

public class Prog
{
    public static void Main()
    {
        var GenAlg = new GenericAlgo();
        GenAlg.Initialize(3, 3, 3, 64);
        var bestSol = GenAlg.GetBestSol(100);

        Console.WriteLine("Лучшая расстановка:");
        foreach (var sq in  bestSol.rectangles)
        {
            Console.WriteLine($"x_l: {sq.x_l} y_b: {sq.y_b} w: {sq.weight} h: {sq.height}");
        }

        Console.WriteLine($"Площадь содержащего прямокгольника: {bestSol.count_metric()}");
        ///Console.WriteLine($"Площадь содержащего прямокгольника: {bestSol.count_metric()}");
        ///Console.WriteLine($"Площадь содержащего прямокгольника: {bestSol.count_metric()}");
        ///Console.WriteLine($"Площадь содержащего прямокгольника: {bestSol.count_metric()}");
        if (bestSol.IsValid())
        {
            ///Console.WriteLine("Бред");

        }

    }
}
