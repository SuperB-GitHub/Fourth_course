class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool contin = true;

        while (contin)
        {
            Console.Clear();
            Console.Write($"Из скольки сравнений система: ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count))
            {
                Console.Write("Некорректный ввод. Введите целое число: ");
            }

            int[] ai = new int[count];
            int[] bi = new int[count];
            int[] mi = new int[count];
            int M_mul = 1;

            for (int _ = 0; _ < count; _++)
            {
                Console.WriteLine($"\nЗапись {_ + 1} сравнения:\n");
                InputCompare(out int a, out int b, out int m);
                if (a != 1)
                {
                    CalcLab3(ref a, ref b, ref m);
                }
                ai[_] = a; bi[_] = b ; mi[_] = m;
                M_mul *= m;
                Console.WriteLine($"\nПолучившиеся сравнение: {a}x ≡ {b} (mod {m})");
            }
            PrintSys(bi, mi);
            CalcLab4(ai, bi, mi, M_mul, count);

            contin = OutputEnd();
        }
    }

    //Функции ввода/вывода
    static void InputCompare(out int a, out int b, out int m)
    {
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
    }
    static bool OutputEnd()
    {
        Console.Write($"\nЖелаете продолжить? (Enter) ");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key != ConsoleKey.Enter) { return false; }
        return true;
    }
    static string PrintMs(int[] mi)
    {
        string op = $"{mi[0]}";
        for (int i = 1; i < mi.Length; i++)
        {
            op = string.Concat(op, ", ", mi[i].ToString());
        }
        return op;
    }
    static void PrintSys(int[] bi, int[] mi)
    {
        Console.WriteLine("\nПолученная система сравнений:");
        for (int i = 0; i < bi.Length; i++)
        {
            Console.WriteLine($"x ≡ {bi[i]}(mod {mi[i]})");
        }
    }
    static void PrintCheck(int x0, int[] bi, int[] mi)
    {
        Console.WriteLine("Проверка решения:");
        for (int i = 0; i < bi.Length; i++)
        {
            Console.WriteLine($"{x0} ≡ {bi[i]} (mod {mi[i]}) ({Mod(x0, mi[i]) == bi[i]})");
        }
    }

    //Функции алгоритмов
    static void CalcLab4(int[] ai, int[] bi, int[] mi, int M, int count)
    {
        Console.WriteLine("\nРешение:");
        if (CrossSimple(mi))
        {
            Console.WriteLine($"Т.к. {PrintMs(mi)} - попарно взаимно просты, то решение существует.\n");
            int x0 = 0;
            string x_0 = "x0 = ";
            for (int i = 0; i < count; i++)
            {
                int m = mi[i];
                int Mi = M / m;
                int Ni = Mi;
                Console.WriteLine($"M{i + 1} = {Ni}");
                Console.Write($"{i + 1})N{i + 1} = M{i}^(-1) (mod {m}) = {Ni}^(-1) (mod {m}) = ");
                Console.Write($"[Т.к. НОД({Ni},{m}) = {NOD(Ni, m)}, то {Ni}^(-1) ∃: a^(-1) (mod m) = a^(φ(m)-1) (mod m)] = ");
                Console.Write($"{Ni}^(φ({m})-1) (mod {m}) = ");
                int deg = EulerPhi(m) - 1;
                Console.Write($"{Ni}^{deg} (mod {m}) = ");
                Ni = Mod(Ni, m);
                Console.Write($"{Ni}^{deg} (mod {m}) = ");
                Ni = LightPow(Ni, deg, m);
                Console.Write($"{Ni} (mod {m})\n");
                Console.WriteLine();
                x0 += bi[i] * Ni * Mi;
                x_0 += $"({bi[i]} * {Ni} * {Mi}) + ";
            }
            x_0 = x_0.Substring(0, x_0.Length - 3);
            Console.Write($"{x_0} (mod {M}) = {x0} (mod {M}) = ");
            x0 = Mod(x0, M);
            Console.WriteLine($"{x0} (mod {M})\n");

            PrintCheck(x0, bi, mi);
        }
        else
        {
            Console.WriteLine($"Т.к. {PrintMs(mi)} - попарно взаимно не просты, то решение не существует.");
        }


    }
    static void CalcLab3(ref int a, ref int b, ref int m)
    {
        int result = 0;

        string output = $"\nТ.к. НОД({a},{m}) = {NOD(a, m)}, то исп формулу:";
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
        a = 1; b = result;
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
    static bool CrossSimple(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (NOD(nums[i], nums[j]) != 1)
                    return false;
            }
        }
        return true;
    }
    static int LightPow(int num, int deg, int m)
    {
        int result = num;
        for (int i = 0; i < deg-1; i++)
        {
            result = Mod(result * num, m);
        }
        return result;
    }
}