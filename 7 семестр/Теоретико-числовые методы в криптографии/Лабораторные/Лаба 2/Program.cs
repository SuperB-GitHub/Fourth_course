class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.Clear();
            long a, deg, m;
            Console.Write($"Введите число a: ");
            while (!long.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("Некорректный ввод. Введите целое число: ");
            }

            Console.Write($"Введите его степень: ");
            while (!long.TryParse(Console.ReadLine(), out deg))
            {
                Console.Write("Некорректный ввод. Введите целое число: ");
            }

            Console.Write($"Введите значение модуля: ");
            while (!long.TryParse(Console.ReadLine(), out m) || NOD(a, m) != 1)
            {
                if (NOD(a, m) != 1)
                {
                    Console.Write($"Некорректный ввод. Введите взаимнопростое с а = {a} число: ");
                }
                else
                {
                    Console.Write("Некорректный ввод. Введите целое число: ");
                }
            }

            if (deg % 2 == 0 && a<0)
            {
                a = Math.Abs(a);
                Console.WriteLine($"\nТ.к. {deg} - чётное, то (-{a})^{deg} = {a}^{deg}");
            }

            long answer = Calculate(a, deg, m);
            Console.WriteLine($"\nОтвет: {answer}, {a}^{deg} ≡ {answer} (mod {m})");

            Console.Write($"\nЖелаете продолжить? (Enter) ");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key != ConsoleKey.Enter) { break; }

        }
    }
    static long Calculate(long a, long deg, long m)
    {
        long result = 0;
        string output = "";
        long equivDeg = CheckRule(a, m);

        output = $"{a}^{deg} (mod {m}) ≡ [{a}^{equivDeg} ≡ 1 (mod {m})] ≡ {a}^({deg / equivDeg}*{equivDeg})";

        deg = deg - (deg / equivDeg) * equivDeg;

        output += $" * {a}^{deg} (mod {m})";

        output += $" ≡ 1 * {a}^{deg} (mod {m})";

        if (a>m)
        { 
            output += $" ≡ [{a} ≡";
            a = Mod(a, m);
            output += $" {a} (mod {m})]";
        }

        output += $" ≡ {a}^{deg} (mod {m})";

        long aPow = (long)(Math.Pow(a, deg));

        output += $" = {aPow} (mod {m})";

        result = Mod(aPow, m);

        output += $" = {result} (mod {m})";

        Console.WriteLine(output);
        return result;

    }
    static long CheckRule(long a, long m)
    {
        if (IsPrime(m))
        {
            Console.WriteLine($"\nТ.к. {m} - простое и НОД({a},{m}) = 1, то исп М.Т.Ф.:");
            Console.WriteLine($"a^p-1 ≡ 1 (mod p)");
            Console.WriteLine($"{a}^{m - 1} ≡ 1 (mod {m})\n");
            return m - 1;
        }
        else
        {
            long newDeg = EulerPhi(m);
            Console.WriteLine($"\nТ.к. {m} - составное и НОД({a},{m}) = 1, то исп т.Эйлера:");
            Console.WriteLine($"a^φ(m) ≡ 1 (mod m)");
            Console.WriteLine($"{a}^φ({m}) ≡ 1 (mod {m})");
            Console.WriteLine($"{a}^{newDeg} ≡ 1 (mod {m})\n");
            return newDeg;
        }
    }
    static long NOD(long a, long b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    static bool IsPrime(long number)
    {
        if (number <= 1) return false;

        if (number <= 3) return true;

        if (number % 2 == 0 || number % 3 == 0) return false;

        for (long i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
                return false;
        }

        return true;
    }
    static long EulerPhi(long n)
    {
        if (n <= 0) return 0;
        if (n == 1) return 1;

        long result = 0;
        for (long i = 1; i <= n; i++)
        {
            if (NOD(i, n) == 1)
                result++;
        }
        return result;
    }
    static long Mod(long a, long m)
    {
        return (a % m + m) % m;
    }
}