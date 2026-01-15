public class Lab2
{
    static void Main()
    {
        Console.WriteLine("Число | Квадрат");
        for (int i = 1; i < 11; i++)
        {
            Console.WriteLine($"  {i}   |  {Math.Pow(i, 2)}");
        }
    }
}