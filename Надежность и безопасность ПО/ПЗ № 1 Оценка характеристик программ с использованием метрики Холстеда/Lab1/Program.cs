public class Lab1
{
    static void Maxmin(ref int x, ref int y)
    {
        if (x < y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }

    static void Main()
    {
        Console.Write($"Введите значение A: ");
        int A = int.Parse(Console.ReadLine());
        Console.Write($"Введите значение B: ");
        int B = int.Parse(Console.ReadLine());
        Console.Write($"Введите значение C: ");
        int C = int.Parse(Console.ReadLine());

        Maxmin(ref A, ref B);
        Maxmin(ref B, ref C);
        Maxmin(ref A, ref B);

        Console.Write($"\nA<B<C : {A}<{B}<{C}");
    }

}