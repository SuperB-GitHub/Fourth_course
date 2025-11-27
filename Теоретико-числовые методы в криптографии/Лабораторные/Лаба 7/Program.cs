using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
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
                EuclidAlg(ref a, ref b);

                contin = OutputEnd();
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine($"Найти рациональное число, которое обращается в непрерывную дробь\n");

            }
            else if (key.Key == ConsoleKey.D3)
            {
                Console.Clear();

            }
            else
            {
                Console.Clear();
                contin = OutputEnd();
            }
        }
    }

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
        string input = Console.ReadLine();
        qi = input.Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(int.Parse)
            .ToList();

        while (!int.TryParse(Console.ReadLine(), out b))
        {
            Console.Write("Некорректный ввод. Введите целое число: ");

        }
        Console.WriteLine($"\nПолученная дробь: {a}/{b}");
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
        string pm = " + ";
        int lenpm = pm.Length;

        string first = $"{new string(' ', qi[0].ToString().Length)}{new string(' ', lenpm)}1";
        Console.WriteLine("\n" + first);

        for (int i = 1; i < qi.Count; i++)
        {
            if (i == qi.Count - 1)
            {
                Console.WriteLine($"{new string(' ', (i - 1) * (first.Length - 1))}{qi[i - 1]}{pm}{new string('-', qi[i].ToString().Length)}");
                Console.WriteLine($"{new string(' ', (i) * (first.Length - 1))}{qi[i]}");
            }
            else
            {
                Console.WriteLine($"{new string(' ', (i - 1) * (first.Length - 1))}{qi[i - 1]}{pm}{new string('-', qi[i].ToString().Length)}{new string(' ', lenpm)}1");
            }

        }




    }

    static void EuclidAlg(ref int a, ref int b)
    {
        List<int> ai = new List<int> { a };
        List<int> bi = new List<int> { b };
        List<int> qi = new List<int> { };
        List<int> ri = new List<int> { };

        int r = ai[0] - (ai[0] / bi[0]) * bi[0];
        int i = 0;
        while (r != 0)
        {
            int q = ai[i] / bi[i];
            qi.Add(q);
            r = ai[i] - q * bi[i];
            ri.Add(r);
            ai.Add(bi[i]);
            bi.Add(r);
            Console.WriteLine($"{ai[i]} = {qi[i]} * {bi[i]} + {ri[i]} |:{bi[i]}     {ai[i]}/{bi[i]} = {qi[i]} + {ri[i]}/{bi[i]}");
            i++;
        }

        Console.Write($"\n{ai[0]}/{bi[0]} = ");
        PrintFraction(qi);
        //for (int _ = 0; _ < qi.Count-1; _++)
        //{
        //    Console.Write($"{qi[_]} + 1 / ");
        //}
        //Console.Write(qi[qi.Count - 1]);

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

}