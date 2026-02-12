class Programm
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool contin = true;

        while (contin)
        {
            Console.Clear();
            Input_n(out int n);

            Console.WriteLine($"\n"+TestMillerRabin(n));

            contin = OutputEnd();
        }
    }

    //Функции ввода/вывода
    static void Input_n(out int n)
    {
        int cursorTop = Console.CursorTop;

        Console.Write($"Введите значение n ≥ 5 и нечётное: ");
        while (!int.TryParse(Console.ReadLine(), out n) || n < 5 || n % 2 == 0)
        {
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);
            Console.Write("Некорректный ввод. Введите целое нечётное от 5 число: ");
        }
        Console.Clear();
        Console.WriteLine($"Введено значение n: {n}");
    }
    static void Input_a(out int a, int n)
    {
        int cursorTop = Console.CursorTop;

        Console.Write($"Введите значение для а, которое 2 ≤ a ≤ n-2: ");
        while (!int.TryParse(Console.ReadLine(), out a) || a < 2 || a > n - 2)
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

    static string TestMillerRabin(int n)
    {
        int n_1 = n - 1;

        //Шаг 1
        int t = n_1;
        int s = 0;
        while (t % 2 == 0)
        {
            t = t / 2;
            s++;
        }
        Console.WriteLine($"\nШаг 1.\nВычисляю {n_1} = 2^{s} * {t} => s = {s}; t = {t}");

        //Шаг 2
        Console.WriteLine($"\nШаг 2.");
        Input_a(out int a, n);
        int k = 0;

        //Шаг 3
        Console.WriteLine($"\nШаг 3.");
        int nod = EuclidAlg(n, a);
        if (nod != 1)
        {
            Console.WriteLine($"\nТ.к. НОД({n}, {a}) = {nod}, то к п. 8");
            return $"Число n = {n} - составное";
        }
        Console.WriteLine($"\nТ.к. НОД({n}, {a}) = 1, то к п. 4");

        //Шаг 4
        Console.WriteLine($"\nШаг 4.");
        int b = LightPow(a, t, n);
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
            b = LightPow(b, 2, n);
            Console.WriteLine($"{b} (mod {n}); k = {k}");
            if (b == n_1)
            {
                Console.WriteLine($"b = {b} = n-1 = {n_1}");
                found = true;
            }
        }
        return found ? $"Число n = {n} - вероятно простое" : $"Число n = {n} - составное";
    }

    //Функции вспомогательные
    static int NOD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    static int Mod(int a, int m)
    {
        return (a % m + m) % m;
    }
    static bool IsPrime(int number)
    {
        if (number <= 1) return false;

        if (number <= 3) return true;

        if (number % 2 == 0 || number % 3 == 0) return false;

        for (int i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
                return false;
        }

        return true;
    }
    static int EuclidAlg(int a, int b)
    {
        List<int> rs = new List<int> { a, b };
        List<int> qs = new List<int>();

        int i = 1;
        Console.WriteLine($"Обычный алгоритм Евклида:");
        while (true)
        {
            int dividend = rs[i - 1];
            int divisor = rs[i];

            int q = dividend / divisor;
            int r = dividend % divisor;

            Console.WriteLine($"{dividend} = {q} * {divisor} + {r}");
            qs.Add(q);

            if (r == 0)
                break;

            rs.Add(r);
            i++;

        }
        return rs.Last();
    }
    static int LightPow(int num, int deg, int m)
    {
        if (deg == 0)
        {
            return 1;
        }
        else
        {
            int result = num;
            for (int i = 0; i < deg - 1; i++)
            {
                result = Mod(result * num, m);
            }
            return result;
        }

    }
}