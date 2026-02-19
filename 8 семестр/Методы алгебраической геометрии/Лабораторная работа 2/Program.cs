using static MyMathLibrary.MathUtils;

namespace Лабораторная_работа_2
{
    class Program
    {
    static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool contin = true;

            while (contin)
            {
                Console.Clear();
                Input_n(out long n);
                Input_f(out List<long> xi);
                Input_c(out long c);

                long answer = MethodPollard(n, xi, c);
                Console.WriteLine(answer != 0 ? 
                    $"\nЧисло {answer} нетривиальный делитель числа {n}" :
                    "\nДелитель не найден");

                contin = OutputEnd();
            }
        }

        // Функции ввода/вывода
        static void Input_n(out long n)
        {
            int cursorTop = Console.CursorTop;

            Console.Write($"Введите значение n нечётное: ");
            while (!long.TryParse(Console.ReadLine(), out n) || n % 2 == 0)
            {
                Console.SetCursorPosition(0, cursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, cursorTop);
                Console.Write("Некорректный ввод. Введите целое нечётное число: ");
            }
            Console.Clear();
            Console.WriteLine($"Введено значение n: {n}");
        }
        static void Input_f(out List<long> xi)
        {
            int cursorTop = Console.CursorTop;

            Console.Write($"Введите значения степени полинома через пробел: ");
            string inputxi = Console.ReadLine()!.Trim();
            while (string.IsNullOrWhiteSpace(inputxi))
            {
                Console.Write("Некорректный ввод. Введите целые числа: ");
                inputxi = Console.ReadLine()!.Trim();
            }

            xi = inputxi.Split(' ')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(long.Parse)
                .ToList();

            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);

            var terms = xi.Select(exp => exp == 0 ? "1" : $"x^{exp}");

            Console.WriteLine($"Полученный полином: {string.Join(" + ", terms)}");
        }
        static void Input_c(out long c)
        {
            int cursorTop = Console.CursorTop;

            Console.Write($"Введите значение для c: ");
            while (!long.TryParse(Console.ReadLine(), out c))
            {
                Console.SetCursorPosition(0, cursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, cursorTop);
                Console.Write("Некорректный ввод. Введите целое число: ");
            }

            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);

            Console.WriteLine($"Введено значение c: {c}");
        }
        static void PrintPollardTable(List<(int i, long a, long b, long d)> data, long n)
        {
            int widthABD = n.ToString().Length + 2;

            string medianFormat = $"│ {{0,{2}}} │ {{1,{widthABD}}} │ {{2,{widthABD}}} │ {{3,{widthABD}}} │";

            Console.WriteLine();
            Console.WriteLine("┌" + new string('─', 4) + "┬" +
                                   new string('─', widthABD + 2) + "┬" +
                                   new string('─', widthABD + 2) + "┬" +
                                   new string('─', widthABD + 2) + "┐");

            Console.WriteLine(string.Format(medianFormat, "i", "a", "b", "d"));

            Console.WriteLine("├" + new string('─', 4) + "┼" +
                                   new string('─', widthABD + 2) + "┼" +
                                   new string('─', widthABD + 2) + "┼" +
                                   new string('─', widthABD + 2) + "┤");

            foreach (var row in data)
            {
                Console.WriteLine(string.Format(medianFormat, row.i.ToString(), row.a.ToString(), row.b.ToString(), row.d.ToString()));
            }

            Console.WriteLine("└" + new string('─', 4) + "┴" +
                                   new string('─', widthABD + 2) + "┴" +
                                   new string('─', widthABD + 2) + "┴" +
                                   new string('─', widthABD + 2) + "┘");
        }
        static bool OutputEnd()
        {
            Console.Write($"\nЖелаете продолжить? (Enter) ");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key != ConsoleKey.Enter) { return false; }
            return true;
        }

        // Функции логики
        static long MethodPollard(long n, List<long> xi, long c)
        {
            int count = 0;
            long a = c;
            long b = c;

            List<(int i, long a, long b, long d)> tableData = new List<(int, long, long, long)>();

            tableData.Add((count, a, b, 0));
            Console.WriteLine($"\nПри i={count}: a = {a}; b = {b}");

            count++;
            a = f(a, n, xi);
            b = f(f(b, n, xi), n, xi);
            long d = NOD(a - b, n);
            tableData.Add((count, a, b, d));
            Console.WriteLine($"При i={count}: a = {a}; b = {b}; d = {d}");

            while (d == 1)
            {
                a = f(a, n, xi);
                b = f(f(b, n, xi), n, xi);
                d = NOD(a - b, n);
                count++;
                tableData.Add((count, a, b, d));
                Console.WriteLine($"При i={count}: a = {a}; b = {b}; d = {d}");
            }
            
            PrintPollardTable(tableData, n);

            return d != n && d != 1 ? d : 0;
        }
        static long f(long x, long n, List<long> xi)
        {
            long result = 0;
            for (int i = 0; i < xi.Count; i++)
            {
                result += FastPowMod(x, xi[i], n);
            }
            return result;
        }
    }
}