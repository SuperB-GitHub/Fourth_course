using System.Linq.Expressions;
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
            Console.WriteLine($"1 - Регистровый сдвиг с обратной связью\n");
            Console.WriteLine($"2 - Скремблирование\n");

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine($"Регистровый сдвиг с обратной связью\n");
                InputFirst(out List<int> xi, out string reg);
                LSFR(xi, reg);

                contin = OutputEnd();
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine($"Скремблирование");
                InputSecond(out List<int> bi, out string reg);
                Scramble(bi, reg);

                contin = OutputEnd();
            }
            else
            {
                Console.Clear();
                contin = OutputEnd();
            }
        }
    }
    
    static void InputFirst(out List<int> xi, out string reg)
    {
        Console.Write($"Введите значения степени полинома через пробел: ");
        string inputxi = Console.ReadLine()!.Trim();
        while (string.IsNullOrWhiteSpace(inputxi))
        {
            Console.Write("Некорректный ввод. Введите целые числа: ");
            inputxi = Console.ReadLine()!.Trim();
        }

        xi = inputxi.Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(int.Parse)
            .ToList();

        Console.WriteLine($"\nПолученный полином: x^{string.Join(" + x^", xi)}");

        Console.Write($"Введите инициализируемое значение: ");
        reg = Console.ReadLine()!.Trim();
        while (string.IsNullOrWhiteSpace(reg) || reg.Length != xi.First())
        {
            Console.Write($"Некорректный ввод. Введите {xi.First()}-битную последовательность: ");
            reg = Console.ReadLine()!.Trim();
        }
    }
    static void InputSecond(out List<int> bi, out string reg)
    {
        Console.Write($"\nВведите инициализируемое значение: ");
        reg = Console.ReadLine()!.Trim();
        while (string.IsNullOrWhiteSpace(reg))
        {
            Console.Write($"Некорректный ввод. Введите последовательность: ");
            reg = Console.ReadLine()!.Trim();
        }

        Console.Write($"Введите значения степени примера через пробел: ");
        string input_bi = Console.ReadLine()!.Trim();
        while (string.IsNullOrWhiteSpace(input_bi))
        {
            Console.Write("Некорректный ввод. Введите целые числа: ");
            input_bi = Console.ReadLine()!.Trim();
        }

        bi = input_bi.Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(int.Parse)
            .ToList();

        Console.WriteLine($"Полученный полином: bi = ai ^ b(i-{string.Join(") ^ b(i-", bi)})");
    }
    static bool OutputEnd()
    {
        Console.Write($"\nЖелаете продолжить? (Enter) ");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key != ConsoleKey.Enter) { return false; }
        return true;
    }


    static void LSFR(List<int> xi, string reg)
    {
        string perRepeat = reg[reg.Length - 1].ToString();

        int xor = XOR(reg, xi);
        string newReg = xor.ToString() + reg.Substring(0, reg.Length - 1);
        perRepeat += newReg[reg.Length - 1].ToString();
        Console.WriteLine($"Шаг 1: {reg} | {reg[reg.Length - 1]}");
        Console.WriteLine($"Шаг 2: {newReg} | {newReg[reg.Length - 1]}");

        int _ = 3;
        while (newReg != reg)
        {
            xor = XOR(newReg, xi);
            newReg = xor.ToString() + newReg.Substring(0, reg.Length - 1);
            perRepeat += newReg[reg.Length - 1].ToString();
            Console.WriteLine($"Шаг {_}: {newReg} | {newReg[reg.Length - 1]}");
            _++;
        }

        Console.WriteLine($"Период повтора: {perRepeat}");
    }
    static int XOR(string reg, List<int> xi)
    {
        int xor = Convert.ToInt32(reg[xi.First() - xi[1] - 1].ToString());

        for (int i = 2; i < xi.Count; i++)
        {
            int n = xi.First() - xi[i] - 1;
            xor ^= Convert.ToInt32(reg[n].ToString());
        }
        return xor;
    }
    static void Scramble(List<int> bi, string reg)
    {
        string b = reg[0].ToString();
        string c = b[0].ToString();

        Console.WriteLine("\nВычисление bi:");
        Console.WriteLine("┌─────┬───────┬─────────────┬─────┐");
        Console.WriteLine("│ i   │ ai    │ Вычисление  │ bi  │");
        Console.WriteLine("├─────┼───────┼─────────────┼─────┤");
        Console.WriteLine($"│ 0   │ {b[0],-5} │ {reg[0],-11} │ {b[0],-3} │");


        for (int i = 1; i < reg.Length; i++)
        {
            int newb = Convert.ToInt32(reg[i].ToString());
            string expression = $"{reg[i]}";

            foreach (int num in bi)
            {
                try
                {
                    int xorValue = Convert.ToInt32(b[i - num].ToString());
                    newb ^= xorValue;
                    expression += $"^b{i - num}";
                }
                catch { continue; }
            }

            b += newb.ToString();
            Console.WriteLine($"│ {i,-3} │ {reg[i],-5} │ {expression,-11} │ {newb,-3} │");
        }

        Console.WriteLine("└─────┴───────┴─────────────┴─────┘");

        Console.WriteLine("\nВычисление ci:");
        Console.WriteLine("┌─────┬───────┬─────────────┬─────┐");
        Console.WriteLine("│ i   │ bi    │ Вычисление  │ ci  │");
        Console.WriteLine("├─────┼───────┼─────────────┼─────┤");
        Console.WriteLine($"│ 0   │ {c[0],-5} │ {b[0],-11} │ {c[0],-3} │");

        for (int i = 1; i < reg.Length; i++)
        {
            int newc = Convert.ToInt32(b[i].ToString());
            string expression = $"{b[i]}";

            foreach (int num in bi)
            {
                try
                {
                    int xorValue = Convert.ToInt32(b[i - num].ToString());
                    newc ^= xorValue;
                    expression += $"^b{i - num}";
                }
                catch { continue; }
            }

            c += newc.ToString();
            Console.WriteLine($"│ {i,-3} │ {b[i],-5} │ {expression,-11} │ {newc,-3} │");
        }
        Console.WriteLine("└─────┴───────┴─────────────┴─────┘");

        Console.WriteLine($"┌─────────────────────────────────┐");
        Console.WriteLine($"│           Результат             │");
        Console.WriteLine($"├────┬────────────────────────────┤");
        Console.WriteLine($"│ ai │ {reg,-26} │");
        Console.WriteLine($"├────┼────────────────────────────┤");
        Console.WriteLine($"│ bi │ {b,-26} │");
        Console.WriteLine($"├────┼────────────────────────────┤");
        Console.WriteLine($"│ сi │ {c,-26} │");
        Console.WriteLine($"└────┴────────────────────────────┘");
    }

}