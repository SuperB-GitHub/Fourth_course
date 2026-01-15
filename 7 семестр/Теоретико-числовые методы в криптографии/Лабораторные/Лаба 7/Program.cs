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
                InputThird(out int a, out int b, out int m);
                int nod = Solutions(ref a, ref b, ref m);

                Console.WriteLine($"\nПерепишем сравнение в виде диофантова уравнения: {a}x - {m}y = {b}\n");
                Console.WriteLine($"Разложим в непрерывную дробь:");
                List<int> qi = EuclidAlg(a, m);
                int first = qi.First();
                qi.Remove(first);

                Console.WriteLine($"\n\nВычислим все подходящие дроби:");
                (int k, int p, int q) = LawSuitableFractions(first, qi);

                Console.WriteLine($"\nТак как k = {k}, Qk-1 = {q}, НОД = {nod}, то");
                m = m * nod;
                List<int> x = new List<int> { Mod((int)Math.Pow(-1, k - 1) * b * q, m) };
                Console.WriteLine($"x = (-1)^k-1 * b/НОД * Qk-1 (mod m) = (-1)^{k - 1} * {b} * {q} (mod {m}) ≡ {x.First()} (mod {m})");

                if (nod > 1)
                {
                    Console.WriteLine($"\nТак как НОД = {nod}, то сравнение имеет 3 решения:");
                    Console.WriteLine($"x0 ≡ {x.First()}");
                    for (int i = 1; i < nod; i++)
                    {
                        x.Add(Mod(x.First() + i * (m / nod), m));
                        Console.WriteLine($"x{i} = x0 + {i} * m/НОД (mod m) = {x.First()} + {i} * ({m}/{nod}) (mod {m}) ≡ {x[i]} (mod {m})");
                    }
                }

                Check(x, a, b, m);

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
    static void InputThird(out int a, out int b, out int m)
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

        Console.Write($"Введите значение для m: ");
        while (!int.TryParse(Console.ReadLine(), out m))
        {
            Console.Write("Некорректный ввод. Введите целое число: ");

        }
        Console.WriteLine($"\nПолученное выражение: {a}x ≡ {b}(mod {m})");
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
    static List<int> EuclidAlg(int a, int b)
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
                Console.Write($"{qi[_]}]");
            }
            else
            {
                Console.Write($"{qi[_]}, ");
            }
        }
        return qi;
    }
    static (int, int, int) LawSuitableFractions(int a, List<int> qi)
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
        int kn = qi.Count;
        return (kn, pk[kn], qk[kn]);
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
    static void Check(List<int> x, int a, int b, int m)
    {
        a = a * x.Count(); b = b * x.Count();
        Console.WriteLine($"\nПроверка:");
        for (int i = 0; i < x.Count; i++)
        {
            int temp = Mod(a * x[i], m);
            Console.WriteLine($"При x{i} ≡ {x[i]}(mod {m}) = {a} * {x[i]} = {a * x[i]}(mod {m}) ≡ {temp}(mod {m}) - {temp == b} ");
        }
    }
}