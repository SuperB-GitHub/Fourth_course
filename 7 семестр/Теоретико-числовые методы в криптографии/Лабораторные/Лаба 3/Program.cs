class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool contin = true;

        while (contin)
        {
            Console.Clear();
            int a, b, m;
            Console.Write($"Введите число a: ");
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("Некорректный ввод. Введите целое число: ");
            }

            Console.Write($"Введите число b: ");
            while (!int.TryParse(Console.ReadLine(), out b))
            {
                Console.Write("Некорректный ввод. Введите целое число: ");
            }

            Console.Write($"Введите значение модуля: ");
            while (!int.TryParse(Console.ReadLine(), out m))
            {
                Console.Write("Некорректный ввод. Введите целое число: ");
                
            }

            Console.WriteLine($"\nПолучившийся пример: {a}x ≡ {b} (mod {m})");
            Console.WriteLine($"Использую т.Эйлера");
            int sol = NOD(a, m);
            if (sol != 1)
            {
                sol = Solutions(ref a, ref b, ref m);
            }

            if (sol == -1)
            {
                contin = OutputEnd();
            }
            else
            {
                int x_0 = Calculate(a, b, m);
                Check(x_0, sol, a * sol, b * sol, m * sol);

                contin = OutputEnd();
            }
        }
    }
    static bool OutputEnd()
    {
        Console.Write($"\nЖелаете продолжить? (Enter) ");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key != ConsoleKey.Enter) { return false; }
        return true;
    }
    static int Solutions(ref int a, ref int b, ref int m)
    {
        string output = "\nТ.к.";
        int sol = NOD(a, m);

        output += $" НОД({a},{m}) = {sol}";

        if (b % sol != 0)
        {
            output += $" и {b} не делится на {sol}, то уравнение не имеет решения.";
            Console.WriteLine(output);
            return -1;
        }
        else
        {
            output += $" и {b} делится на {sol}, то сравнение разрешено и имеет {sol} решений:";
            output += $"\n{a}x ≡ {b} (mod {m}) | :{sol}";
            a = a / sol; b = b / sol; m = m / sol;
            output += $"\n{a}x ≡ {b} (mod {m})";
            Console.WriteLine(output);
            return sol;
        }
    }
    static int Calculate(int a, int b, int m)
    {
        int result = 0;

        string output = $"\nТ.к. НОД({a},{m}) = 1, то исп формулу:";
        output += "\nx_0 = a^(φ(m)-1) * b (mod m)";
        output += $"\nx_0 = {a}^(φ({m})-1) * {b} (mod {m})";

        int deg = EulerPhi(m) - 1;
        output += $" = [φ({m}) - 1 = {deg + 1} - 1 = {deg}] = {a}^{deg} * {b} (mod {m})";

        if (a > m)
        {
            output += $" ≡ [{a} ≡";
            a = Mod(a, m);
            output += $" {a} (mod {m})]";
            output += $" ≡ {a}^{deg} * {b} (mod {m})";
        }

        output += $" ≡ [{a}^{deg} =";

        a = (int)(Math.Pow(a, deg));

        output += $" {a} ≡";

        a = Mod(a, m);

        output += $" {a} (mod {m})] ≡ {a} * {b} (mod {m})";

        result = Mod(a * b, m);

        output += $" = {a * b} (mod {m}) = {result} (mod {m})";

        Console.WriteLine(output);
        return result;

    }
    static void Check(int x_0, int sol, int a, int b, int m)
    {
        Console.WriteLine("\nПроверка:");
        
        for (int i = 0; i < sol; i++)
        {
            int x = x_0 + i * (m / sol);
            Console.WriteLine($"x_{i} = x_0 + {i} * m/d = {x_0} + {i} * {m}/{sol} = {x}");
            bool ch = Mod(a * x, m) == b;
            Console.WriteLine($"{a} * {x} = {a * x} ≡ {b} (mod {m}) - ({ch})\n");
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