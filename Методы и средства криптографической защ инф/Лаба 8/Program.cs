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
                //Console.Clear();
                //Console.WriteLine($"Найти рациональное число, которое обращается в непрерывную дробь\n");
                //InputSecond(out int a, out List<int> qi);

                //Console.WriteLine($"\n1) Просто сложение и умножение дробей");
                //MultiplicAndAdd(a, qi);

                //Console.WriteLine($"\n2) По закону составления подходящих дробей");
                //LawSuitableFractions(a, qi);

                //contin = OutputEnd();
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
        string inputxi = Console.ReadLine()!;
        while (string.IsNullOrWhiteSpace(inputxi))
        {
            Console.Write("Некорректный ввод. Введите целые числа: ");
            inputxi = Console.ReadLine()!;
        }

        xi = inputxi.Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(int.Parse)
            .ToList();

        Console.WriteLine($"\nПолученный полином: x^{string.Join(" + x^", xi)}");

        Console.Write($"Введите инициализируемое значение: ");
        reg = Console.ReadLine()!;
        while (string.IsNullOrWhiteSpace(reg) || reg.Length != xi.First())
        {
            Console.Write($"Некорректный ввод. Введите {xi.First()}-битную последовательность: ");
            reg = Console.ReadLine()!;
        }
        Console.WriteLine($"\nПолученное значение: {reg}");
    }
    static void InputSecond(out List<int> xi, out string reg)
    {
        Console.Write($"Введите инициализируемое значение: ");
        reg = Console.ReadLine()!;
        while (string.IsNullOrWhiteSpace(reg))
        {
            Console.Write($"Некорректный ввод. Введите последовательность: ");
            reg = Console.ReadLine()!;
        }
        Console.WriteLine($"\nПолученное значение: {reg}");

        Console.Write($"Введите значения степени полинома через пробел: ");
        string inputxi = Console.ReadLine()!;
        while (string.IsNullOrWhiteSpace(inputxi))
        {
            Console.Write("Некорректный ввод. Введите целые числа: ");
            inputxi = Console.ReadLine()!;
        }

        xi = inputxi.Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(int.Parse)
            .ToList();

        Console.WriteLine($"\nПолученный полином: x^{string.Join(" + x^", xi)}");
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
}