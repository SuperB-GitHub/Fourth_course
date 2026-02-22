using static MyMathLibrary.MathUtils;

class Programm
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool contin = true;

        while (contin)
        {
            Console.Clear();
            Input_n(out long n);

            Console.WriteLine($"\n"+TestMillerRabin(n));

            contin = OutputEnd();
        }
    }

    //Функции ввода/вывода
    static void Input_n(out long n)
    {
        int cursorTop = Console.CursorTop;

        Console.Write($"Введите значение n ≥ 5 и нечётное: ");
        while (!long.TryParse(Console.ReadLine(), out n) || n < 5 || n % 2 == 0)
        {
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);
            Console.Write("Некорректный ввод. Введите целое нечётное от 5 число: ");
        }
        Console.Clear();
        Console.WriteLine($"Введено значение n: {n}");
    }
    static void Input_a(out long a, long n)
    {
        int  cursorTop = Console.CursorTop;

        Console.Write($"Введите значение для а, которое 2 ≤ a ≤ n-2: ");
        while (!long.TryParse(Console.ReadLine(), out a) || a < 2 || a > n - 2)
        {
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);
            Console.Write("Некорректный ввод. Введите целое число, которое 2 ≤ a ≤ n-2: ");
        }

        Console.SetCursorPosition(0, cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, cursorTop);

        Console.WriteLine($"Введено значение a: {a}");
    }
    static bool OutputEnd()
    {
        Console.Write($"\nЖелаете продолжить? (Enter) ");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key != ConsoleKey.Enter) { return false; }
        return true;
    }

    static string TestMillerRabin(long n)
    {
        long n_1 = n - 1;

        //Шаг 1
        long t = n_1;
        long s = 0;
        while (t % 2 == 0)
        {
            t = t / 2;
            s++;
        }
        Console.WriteLine($"\nШаг 1.\nВычисляю {n_1} = 2^{s} * {t} => s = {s}; t = {t}");

        //Шаг 2
        Console.WriteLine($"\nШаг 2.");
        Input_a(out long a, n);
        long k = 0;

        //Шаг 3
        Console.WriteLine($"\nШаг 3.");
        long nod = NOD(n, a);
        if (nod != 1)
        {
            Console.WriteLine($"\nТ.к. НОД({n}, {a}) = {nod}, то к п. 8");
            return $"Число n = {n} - составное";
        }
        Console.WriteLine($"\nТ.к. НОД({n}, {a}) = 1, то к п. 4");

        //Шаг 4
        Console.WriteLine($"\nШаг 4.");
        long b = FastPowMod(a, t, n);
        Console.WriteLine($"Вычисляю b ≡ aᵗ(mod n) => b ≡ {a}^{t} (mod {n}) ≡ {b}");

        //Шаг 5
        Console.WriteLine($"\nШаг 5-6.");
        if (b == 1 || b == n_1)
        {
            return $"Число n = {n} - вероятно простое";
        }
        Console.WriteLine($"Так как b ≠ 1 и b ≠ n-1, то вычисляю b ≡ b²(mod n)\n");

        //Шаг 6
        bool found = false;
        while (k<s && !found)
        {
            k++;
            Console.Write($"b = {b}² (mod {n}) = ");
            b = FastPowMod(b, 2, n);
            Console.WriteLine($"{b} (mod {n}); k = {k}");
            if (b == n_1)
            {
                Console.WriteLine($"b = {b} = n-1 = {n_1}");
                found = true;
            }
        }
        return found ? $"Число n = {n} - вероятно простое" : $"Число n = {n} - составное";
    }
}