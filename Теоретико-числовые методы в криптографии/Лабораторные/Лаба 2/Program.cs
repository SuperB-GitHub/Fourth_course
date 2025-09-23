class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            int a, deg, m;
            Console.Write($"Введите число a: ");
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("Некорректный ввод. Введите целое число: ");
            }

            Console.Write($"Введите его степень: ");
            while (!int.TryParse(Console.ReadLine(), out deg))
            {
                Console.Write("Некорректный ввод. Введите целое число: ");
            }

            Console.Write($"Введите значение модуля: ");
            while (!int.TryParse(Console.ReadLine(), out m))
            {
                Console.Write("Некорректный ввод. Введите целое число: ");
            }

            if (deg % 2 == 0)
            {
                a = Math.Abs(a);
                Console.WriteLine($"\nТ.к. {deg} - чётное, то (-{a})^{deg} = {a}^{deg}");
            }

            int answer = Calculate(a, deg, m);
            Console.WriteLine($"\nОтвет: {answer}, {a}^{deg} ≡ {answer} (mod {m})");

            Console.Write($"\nЖелаете продолжить? (Enter) ");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key != ConsoleKey.Enter) { break; }

        }
    }
    static int Calculate(int a, int deg, int m)
    {
        int result = 0;
        string output = "";
        int equivDeg = CheckRule(a, m);

        output = $"{a}^{deg} (mod {m}) ≡ [{a}^{equivDeg} ≡ 1 (mod {m})] ≡";

        deg = deg - (deg / equivDeg) * equivDeg;

        output += $" 1 * {a}^{deg} (mod {m})";

        if (a>m)
        {
            output += $" ≡ [{a} ≡";
            a = Mod(a, m);
            output += $" {a} (mod {m})] ";
        }

        output += $"≡ {a}^{deg} (mod {m})";

        int aPow = (int)(Math.Pow(a, deg));

        output += $" = {aPow} (mod {m})";

        result = Mod(aPow, m);

        output += $" = {result} (mod {m})";

        Console.WriteLine(output);
        return result;

    }
    static int CheckRule(int a, int m)
    {
        if (IsPrime(m) && NOD(a,m)==1)
        {
            Console.WriteLine($"\nТ.к. {m} - простое и НОД({a},{m}) = 1, то исп М.Т.Ф.:");
            Console.WriteLine($"a^p-1 ≡ 1 (mod p)");
            Console.WriteLine($"{a}^{m-1} ≡ 1 (mod {m})\n");
            return m - 1;
        }
        else
        {
            int newDeg = EulerPhi(m);
            Console.WriteLine($"\nТ.к. {m} - составное и НОД({a},{m}) = 1, то исп т.Эйлера:");
            Console.WriteLine($"a^φ(m) ≡ 1 (mod m)");
            Console.WriteLine($"{a}^φ({m}) ≡ 1 (mod {m})");
            Console.WriteLine($"{a}^{newDeg} ≡ 1 (mod {m})\n");
            return newDeg;
        }
    }
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
    static int EulerPhi(int n)
    {
        if (n <= 0) return 0;
        if (n == 1) return 1;

        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            if (NOD(i, n) == 1)
                result++;
        }
        return result;
    }
    static int Mod(int a, int m)
    {
        return (a % m + m) % m;
    }
}