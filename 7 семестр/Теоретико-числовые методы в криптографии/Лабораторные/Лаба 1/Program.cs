using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                int a, b;
                Console.Write($"Введите первое число a: ");
                while (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.Write("Некорректный ввод. Введите целое число: ");
                }

                Console.Write($"Введите второе число b: ");
                while (!int.TryParse(Console.ReadLine(), out b))
                {
                    if (b == 0)
                        Console.Write("Ошибка: b не может быть нулём. Введите b ещё раз: ");
                    else
                        Console.Write("Некорректный ввод. Введите целое число: ");
                }

                (List<int> rs, List<int> qs) = a > b ? EuclidAlg(a, b) : EuclidAlg(b, a);
                List<int> xs = FindXorY(qs, true);
                List<int> ys = FindXorY(qs, false);

                CreateTable(rs, qs, xs, ys);

                Console.WriteLine($"НОД({a}, {b}) = {rs.Last()} = {a} * {xs.Last()} + {b} * {ys.Last()}");
                Console.WriteLine();

                Console.Write($"Желаете продолжить? (Enter) ");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key != ConsoleKey.Enter) { break; }

            }
        }

        static (List<int>, List<int>) EuclidAlg(int a, int b)
        {
            List<int> rs = new List<int> { a, b };
            List<int> qs = new List<int>();

            int i = 1;
            Console.WriteLine($"\nОбычный алгоритм Евклида:");
            while (true)
            {
                int dividend = rs[i - 1];
                int divisor = rs[i];

                int q = dividend / divisor;
                int r = dividend % divisor;

                Console.WriteLine($"{dividend} = {q} * {divisor} + {r}");
                qs.Add(q);

                if (r == 0)
                    break;

                rs.Add(r);
                i++;

            }
            return (rs,qs);
        }

        static List<int> FindXorY(List<int> qs, bool isX)
        {
            List<int> fs = isX ? new List<int> { 1, 0 } : new List<int> { 0, 1 };

            int i = 1;
            Console.WriteLine(isX ? $"\nПоиск X:" : $"\nПоиск Y:");
            while (fs.Count != qs.Count+1)
            {
                int f = fs[i - 1] - qs[i - 1] * fs[i];
                Console.Write(isX ? $"x{i + 1}" : $"y{i + 1}");
                Console.WriteLine($" = {fs[i - 1]} - {qs[i - 1]} * {fs[i]} = {f}");
                fs.Add(f);
                i++;
            }


            return fs;
        }

        static void CreateHorizontal(int cols, int cellWidth)
        {
            Console.Write("+");
            for (int i = 0; i < cols; i++)
            {
                Console.Write(new string('-', cellWidth));
                Console.Write("+");
            }
            Console.Write(new string(' ', cellWidth * 3));
            Console.WriteLine();
        }

        static void CreateTable(List<int> rs, List<int> qs, List<int> xs, List<int> ys)
        {
            Console.WriteLine();
            int intrv = rs.First().ToString().Length;
            CreateHorizontal(5, intrv);
            Console.WriteLine($"|{"i".PadRight(intrv)}|{"r".PadRight(intrv)}|{"x".PadRight(intrv)}|{"y".PadRight(intrv)}|{"q".PadRight(intrv)}|");
            CreateHorizontal(5, intrv);
            for(int i = 0;i < rs.Count; i++)
            {
                Console.Write($"|{i.ToString().PadRight(intrv)}|{rs[i].ToString().PadRight(intrv)}|{xs[i].ToString().PadRight(intrv)}|{ys[i].ToString().PadRight(intrv)}|");
                if(i != 0) { Console.Write($"{qs[i - 1].ToString().PadRight(intrv)}|"); }
                else { Console.Write($"{new string(' ',intrv)}|"); }
                Console.WriteLine();
            }
            CreateHorizontal(5, intrv);
            Console.WriteLine();
        }
    }
}
