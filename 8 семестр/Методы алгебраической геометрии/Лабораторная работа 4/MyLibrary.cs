using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary
{
    /// <summary>
    /// Мои самописные математические функции для лабораторных работ 
    /// 
    /// Ver. 28032026
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// Находит наибольший общий делитель (НОД) двух чисел
        /// </summary>
        public static int NOD(int a, int b)
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

        /// <summary>
        /// Находит наибольший общий делитель (НОД) двух чисел
        /// </summary>
        public static long NOD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Находит НОД для трех и более чисел
        /// Числа перечислять через запятую
        /// </summary>
        public static int NOD(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("Массив чисел не может быть пустым");

            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = NOD(result, numbers[i]);
                if (result == 1) return 1;
            }
            return result;
        }

        /// <summary>
        /// Находит НОД для трех и более чисел
        /// Числа перечислять через запятую
        /// </summary>
        public static long NOD(params long[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("Массив чисел не может быть пустым");

            long result = numbers[0];
            for (long i = 1; i < numbers.Length; i++)
            {
                result = NOD(result, numbers[i]);
                if (result == 1) return 1;
            }
            return result;
        }

        /// <summary>
        /// Возвращает неотрицательный остаток от деления (mod)
        /// </summary>
        public static int Mod(int a, int m)
        {
            if (m == 0)
                throw new DivideByZeroException("Модуль не может быть равен нулю");

            return (a % m + m) % m;
        }

        /// <summary>
        /// Возвращает неотрицательный остаток от деления (mod)
        /// </summary>
        public static long Mod(long a, long m)
        {
            if (m == 0)
                throw new DivideByZeroException("Модуль не может быть равен нулю");

            return (a % m + m) % m;
        }

        /// <summary>
        /// Проверяет, является ли число простым
        /// </summary>
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number <= 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Проверяет, является ли число простым
        /// </summary>
        public static bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number <= 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;

            for (uint i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Расширенный алгоритм Евклида с выводом шагов
        /// </summary>
        public static int EuclidAlg(int af, int bf)
        {
            int a = Math.Max(Math.Abs(af), Math.Abs(bf));
            int b = Math.Min(Math.Abs(af), Math.Abs(bf));
            List<int> rs = new List<int> { a, b };
            List<int> qs = new List<int>();

            int i = 1;
            Console.WriteLine($"Обычный алгоритм Евклида для {a} и {b}:");

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

            int gcd = rs.Last();
            Console.WriteLine($"НОД = {gcd}\n");
            return gcd;
        }

        /// <summary>
        /// Быстрое возведение в степень по модулю (бинарный метод - более эффективный)
        /// </summary>
        public static int FastPowMod(int num, int deg, int m)
        {
            if (m == 0)
                throw new DivideByZeroException("Модуль не может быть равен нулю");

            if (m == 1) return 0;

            long result = 1;
            long baseNum = num % m;
            long exponent = deg;

            while (exponent > 0)
            {
                if ((exponent & 1) == 1) // если степень нечетная
                    result = (result * baseNum) % m;

                baseNum = (baseNum * baseNum) % m;
                exponent >>= 1; // делим степень на 2
            }

            return (int)result;
        }

        /// <summary>
        /// Быстрое возведение в степень по модулю
        /// </summary>
        public static long FastPowMod(long num, long deg, long m)
        {
            if (m == 0)
                throw new DivideByZeroException("Модуль не может быть равен нулю");

            if (m == 1) return 0;

            long result = 1;
            long baseNum = num % m;
            long exponent = deg;

            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                    result = (result * baseNum) % m;

                baseNum = (baseNum * baseNum) % m;
                exponent >>= 1;
            }

            return result;
        }

        /// <summary>
        /// Находит все простые делители числа
        /// </summary>
        public static List<int> PrimeFactors(int n)
        {
            List<int> factors = new List<int>();
            n = Math.Abs(n);

            // Проверяем делимость на 2
            while (n % 2 == 0)
            {
                factors.Add(2);
                n /= 2;
            }

            // Проверяем нечетные делители
            for (int i = 3; i * i <= n; i += 2)
            {
                while (n % i == 0)
                {
                    factors.Add(i);
                    n /= i;
                }
            }

            // Если осталось простое число больше 2
            if (n > 1)
                factors.Add(n);

            return factors;
        }

        /// <summary>
        /// Находит все простые делители числа
        /// </summary>
        public static List<long> PrimeFactors(long n)
        {
            List<long> factors = new List<long>();
            n = Math.Abs(n);

            // Проверяем делимость на 2
            while (n % 2 == 0)
            {
                factors.Add(2);
                n /= 2;
            }

            // Проверяем нечетные делители
            for (uint i = 3; i * i <= n; i += 2)
            {
                while (n % i == 0)
                {
                    factors.Add(i);
                    n /= i;
                }
            }

            // Если осталось простое число больше 2
            if (n > 1)
                factors.Add(n);

            return factors;
        }

        /// <summary>
        /// Проверяет, являются ли числа взаимно простыми
        /// </summary>
        public static bool CrossSimple(int a, int b)
        {
            return NOD(a, b) == 1;
        }

        /// <summary>
        /// Проверяет, являются ли числа взаимно простыми
        /// </summary>
        public static bool CrossSimple(long a, long b)
        {
            return NOD(a, b) == 1;
        }

        /// <summary>
        /// Вычисляет функцию Эйлера φ(n) - количество чисел от 1 до n, взаимно простых с n
        /// </summary>
        public static int EulerPhi(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;

            int result = n;
            int temp = n;

            for (int p = 2; p * p <= temp; p++)
            {
                if (temp % p == 0)
                {
                    while (temp % p == 0)
                        temp /= p;

                    result -= result / p;
                }
            }

            if (temp > 1)
                result -= result / temp;

            return result;
        }

        /// <summary>
        /// Вычисляет функцию Эйлера φ(n) - количество чисел от 1 до n, взаимно простых с n
        /// </summary>
        public static long EulerPhi(long n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;

            long result = n;
            long temp = n;

            for (uint p = 2; p * p <= temp; p++)
            {
                if (temp % p == 0)
                {
                    while (temp % p == 0)
                        temp /= p;

                    result -= result / p;
                }
            }

            if (temp > 1)
                result -= result / temp;

            return result;
        }

        /// <summary>
        /// Вычисляет обратный элемент при помощи функции Эйлера φ(n)
        /// </summary>
        /// <returns> long = n^(φ(n) - 1) (mod m)</returns>
        public static long InversElem(long n, long m)
        {
            if (!CrossSimple(n,m)) return 0;

            return FastPowMod(n, EulerPhi(m) - 1, m);
        }

    }

    /// <summary>
    /// Мои самописные строковые функции для лабораторных работ 
    /// 
    /// Ver. 28032026
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Запрашивает у пользователя подтверждение на продолжение.
        /// </summary>
        /// <returns>true, если нажат Enter; false в противном случае.</returns>
        public static bool OutputEnd()
        {
            Console.Write($"\nЖелаете продолжить? (Enter) ");
            ConsoleKeyInfo key = Console.ReadKey();
            return key.Key == ConsoleKey.Enter;
        }

        /// <summary>
        /// Универсальный метод для ввода списка чисел с настраиваемыми сообщениями
        /// </summary>
        /// <param name="startMess">Сообщение перед вводом</param>
        /// <param name="errMess">Сообщение об ошибке</param>
        /// <param name="finalMess">Формат итогового сообщения (можно использовать {0}, {1} и т.д. для подстановки значений)</param>
        /// <param name="expectedCount">Ожидаемое количество чисел (0 - любое количество)</param>
        /// <returns>Список введённых чисел</returns>
        public static List<long> InputList(string startMess = "", string errMess = "Некорректный ввод. Введите целые числа: ", string finalMess = "", int expectedCount = 0)
        {
            int cursorTop = Console.CursorTop;
            List<long> result = new List<long>();

            while (true)
            {
                Console.Write(startMess);
                string? input = Console.ReadLine()?.Trim();

                while (string.IsNullOrWhiteSpace(input))
                {
                    Console.Write(errMess);
                    input = Console.ReadLine()?.Trim();
                }

                var numbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => long.TryParse(x, out long val) ? val : (long?)null)
                    .ToList();

                if (numbers.Any(x => x == null))
                {
                    Console.SetCursorPosition(0, cursorTop);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, cursorTop);
                    Console.Write(errMess);
                    continue;
                }

                result = numbers.Select(x => x.GetValueOrDefault()).ToList();

                if (expectedCount > 0 && result.Count != expectedCount)
                {
                    Console.SetCursorPosition(0, cursorTop);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, cursorTop);
                    Console.Write($"Ошибка: нужно ввести ровно {expectedCount} чисел. {errMess}");
                    continue;
                }

                break;
            }

            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);

            if (!string.IsNullOrEmpty(finalMess))
            {
                if (finalMess.Contains("{0}"))
                    Console.WriteLine(string.Format(finalMess, result.ToArray()));
                else
                    Console.WriteLine(finalMess);
            }

            return result;
        }

        /// <summary>
        /// Ввод одного числа
        /// </summary>
        public static long InputNumber(string startMess, string errMess = "Некорректный ввод. Введите целое число: ", string finalMess = "")
        {
            return InputList(startMess, errMess, finalMess, 1).First();
        }
    }
}
