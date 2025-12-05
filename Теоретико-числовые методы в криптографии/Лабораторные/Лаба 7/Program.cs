using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        bool contin = true;
        while (contin)
        {
            Console.Clear();
            Console.WriteLine($"Выберите задание:\n");
            Console.WriteLine($"1 - Представить число в виде непрерывной дроби\n");
            Console.WriteLine($"2 - Найти рациональное число, которое обращается в непрерывную дробь\n");
            Console.WriteLine($"3 - Решить сравнение первой степени с помощью непрерывных дробей\n");

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine($"Представить число в виде непрерывной дроби\n");
                InputFirst(out int a, out int b);

                Console.WriteLine($"\nИспользуя алгоритм Евклида:");
                EuclidAlg(a, b);

                contin = OutputEnd();
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine($"Найти рациональное число, которое обращается в непрерывную дробь\n");
                InputSecond(out int a, out List<int> qi);

                Console.WriteLine($"\n1) Просто сложение и умножение дробей");
                MultiplicAndAdd(a, qi);

                Console.WriteLine($"\n2) По закону составления подходящих дробей");
                LawSuitableFractions(a, qi);

                contin = OutputEnd();
            }
            else if (key.Key == ConsoleKey.D3)
            {
                Console.Clear();
                Console.WriteLine($"Решить сравнение первой степени с помощью непрерывных дробей\n");
                InputThird(out int a, out int b, out int p);

                contin = OutputEnd();

            }
            else
            {
                Console.Clear();
                contin = OutputEnd();
            }
        }
    }

    // Ввод/вывод информации
    static void InputFirst(out int a, out int b)
    {
        Console.Write($"Введите значение для а: ");
        while (!int.TryParse(Console.ReadLine(), out a))
        {
            Console.Write("Некорректный ввод. Введите целое число: ");
        }

        Console.Write($"Введите значение для b: ");
        while (!int.TryParse(Console.ReadLine(), out b))
        {
            Console.Write("Некорректный ввод. Введите целое число: ");

        }
        Console.WriteLine($"\nПолученная дробь: {a}/{b}");
    }
    static void InputSecond(out int a, out List<int> qi)
    {
        Console.Write($"Введите значение для а: ");
        while (!int.TryParse(Console.ReadLine(), out a))
        {
            Console.Write("Некорректный ввод. Введите целое число: ");
        }

        Console.Write($"Введите значения коэффициентов через пробел: ");
        string input = Console.ReadLine()!;
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.Write("Некорректный ввод. Введите целые числа: ");
            input = Console.ReadLine()!;
        }

        qi = input.Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(int.Parse)
            .ToList();

        Console.WriteLine($"\nПолученная дробь: [{a}; {string.Join(", ", qi)}]");
    }
    static void InputThird(out int a, out int b, out int p)
    {
        Console.Write($"Введите значение для а: ");
        while (!int.TryParse(Console.ReadLine(), out a))
        {
            Console.Write("Некорректный ввод. Введите целое число: ");
        }

        Console.Write($"Введите значение для b: ");
        while (!int.TryParse(Console.ReadLine(), out b))
        {
            Console.Write("Некорректный ввод. Введите целое число: ");
        }

        Console.Write($"Введите значение для p: ");
        while (!int.TryParse(Console.ReadLine(), out p))
        {
            Console.Write("Некорректный ввод. Введите простое целое число: ");

        }
        Console.WriteLine($"\nПолученное выражение: {a}x ≡ {b}(mod {p})");
    }
    static bool OutputEnd()
    {
        Console.Write($"\nЖелаете продолжить? (Enter) ");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key != ConsoleKey.Enter) { return false; }
        return true;
    }
    public static void PrintFraction(List<int> qi)
    {
        if (qi == null || qi.Count == 0) return;

        string pm = " + ";
        int lenpm = pm.Length;

        List<string> lines = new List<string>();

        lines.Add($"{new string(' ', qi[0].ToString().Length)}{new string(' ', lenpm)}1");

        for (int i = 1; i < qi.Count; i++)
        {
            int currentIndent = 0;

            for (int j = 0; j < i - 1; j++)
            {
                currentIndent += qi[j].ToString().Length + lenpm;
            }

            if (i == qi.Count - 1)
            {
                string numLine = $"{new string(' ', currentIndent)}{qi[i - 1]}{pm}{new string('-', qi[i].ToString().Length)}";
                string denomLine = $"{new string(' ', currentIndent + qi[i - 1].ToString().Length + lenpm)}{qi[i]}";

                lines.Add(numLine);
                lines.Add(denomLine);
            }
            else
            {
                string line = $"{new string(' ', currentIndent)}{qi[i - 1]}{pm}{new string('-', qi[i].ToString().Length)}{new string(' ', lenpm)}1";
                lines.Add(line);
            }
        }
        Console.WriteLine();
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }

    // Работа алгоритмов
    static void EuclidAlg(int a, int b)
    {
        List<int> ai = new List<int> { a };
        List<int> bi = new List<int> { b };
        List<int> qi = new List<int> { };
        List<int> ri = new List<int> { };

        int i = 0;
        int r;

        do
        {
            int q = (int)Math.Floor((double)ai[i] / bi[i]);
            qi.Add(q);
            r = ai[i] - q * bi[i];
            ri.Add(r);

            Console.WriteLine($"{ai[i]} = {q} * {bi[i]} + {r} |:{bi[i]}     {ai[i]}/{bi[i]} = {q} + {r}/{bi[i]}");

            ai.Add(bi[i]);
            bi.Add(r);
            i++;

        } while (r != 0);

        Console.Write($"\n{ai[0]}/{bi[0]} = ");
        PrintFraction(qi);

        Console.Write($"\n{ai[0]}/{bi[0]} = [{qi[0]}; ");
        for (int _ = 1; _ < qi.Count; _++)
        {
            if (_ == qi.Count - 1)
            {
                Console.Write($"1/{qi[_]}]");
            }
            else
            {
                Console.Write($"1/{qi[_]}, ");
            }
        }
    }
    static void LawSuitableFractions(int a, List<int> qi)
    {
        Console.Write($"Так как [{a}; {string.Join(", ", qi)}], то a0 = {a}");
        for (int k = 0; k < qi.Count; k++)
        {
            Console.Write($", b{k + 1} = 1, a{k + 1} = {qi[k]}");
        }

        Console.WriteLine($"\nТакже P-1 = 1, Q-1 = 0, P0 = a0 = {a}, Q0 = 1");
        List<int> pk = new List<int> { 1, a };
        List<int> qk = new List<int> { 0, 1 };

        Console.WriteLine($"Остальные значения K = 1,...,{qi.Count} считаем по формулам: Pk = ak * Pk−1 + bk * Pk−2; Qk = ak * Qk−1 + bk * Qk−2\n");
        for (int k = 0; k < qi.Count; k++)
        {
            pk.Add(qi[k] * pk[k + 1] + pk[k]);
            Console.WriteLine($"P{k + 1} = a{k + 1} * P{k} + b{k + 1} * P{k - 1} = {qi[k]} * {pk[k + 1]} + 1 * {pk[k]} = {pk[k + 2]}");
            qk.Add(qi[k] * qk[k + 1] + qk[k]);
            Console.WriteLine($"Q{k + 1} = a{k + 1} * Q{k} + b{k + 1} * Q{k - 1} = {qi[k]} * {qk[k + 1]} + 1 * {qk[k]} = {qk[k + 2]}\n");
        }

        Console.WriteLine($"\nОтвет:\n \t [{a}; {string.Join(", ", qi)}] = {pk.Last()}/{qk.Last()}");
    }
    static void MultiplicAndAdd(int a, List<int> qi)
    {
        PrintFraction(new List<int> { a }.Concat(qi).ToList());
        Console.Write($"[{a}; {string.Join(", ", qi)}] = ");
        int x = 1; int y = qi.Last();

        for (int i = qi.Count() - 2; i >= 0; i--) 
        {
            x = x + qi[i] * y;
            int temp = x; x = y; y = temp;
            Console.Write($"{x}/{y} = ");
        }
        x = x + a * y;
        Console.Write($"{x}/{y}\n");
    }
}