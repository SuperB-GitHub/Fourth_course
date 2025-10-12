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
                ai[_] = a; bi[_] = b; mi[_] = m;
                M_mul *= m;
            }

            for (int i = 0; i < ai.Length; i++)
            {
                if (ai[i] != 1)
                {
                    //Объединеная функция из лабы 3 с возвратом bi[i] = b
                }
            }

            //Функция вывода всей системы

            Solution(ai, bi, mi, M_mul, count);

            contin = OutputEnd();
        }
    }

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

        Console.WriteLine($"\nПолучившиеся сравнение: {a}x ≡ {b} (mod {m})");
    }
    static bool OutputEnd()
    {
        Console.Write($"\nЖелаете продолжить? (Enter) ");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key != ConsoleKey.Enter) { return false; }
        return true;
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
    //Функция обрат
    static void Solution(int[] ai, int[] bi, int[] mi, int M, int count)
    {
        Console.WriteLine("\nРешение:");
        if (CrossSimple(mi))
        {
            Console.WriteLine($"Т.к. {PrintMs(mi)} - попарно взаимно просты, то решение существует.\n");

        }
        else
        {
            Console.WriteLine($"Т.к. {PrintMs(mi)} - попарно взаимно не просты, то решение не существует.");
        }

        
    }
    static string PrintMs(int[] mi)
    {
        string op = $"{mi[0]}";
        for (int i = 1; i < mi.Length; i++)
        {
            op = string.Concat(op, ", " ,mi[i].ToString());
        }
        return op;
    }
}