using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMathLibrary
{
    //Ver. 02032026
    //Ver. 23032026
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

            // Проверяем простые делители
            for (int p = 2; p * p <= temp; p++)
            {
                if (temp % p == 0)
                {
                    while (temp % p == 0)
                        temp /= p;

                    result -= result / p;
                }
            }

            // Если остался простой делитель больше 1
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

            // Проверяем простые делители
            for (uint p = 2; p * p <= temp; p++)
            {
                if (temp % p == 0)
                {
                    while (temp % p == 0)
                        temp /= p;

                    result -= result / p;
                }
            }

            // Если остался простой делитель больше 1
            if (temp > 1)
                result -= result / temp;

            return result;
        }

        public static long InversElem(long n, long m)
        {
            if (!CrossSimple(n,m)) return 0;

            return FastPowMod(n, EulerPhi(m) - 1, m);
        }

        //static void InputList(string startMess, string errMess = "Некорректный ввод. Введите целые числа: ", string finalMess)
        //{
        //    int cursorTop = Console.CursorTop;

        //    Console.Write($"Выберите значения для x и y от P через пробел: ");
        //    string input = Console.ReadLine()!.Trim();
        //    while (string.IsNullOrWhiteSpace(input))
        //    {
        //        Console.Write("Некорректный ввод. Введите целые числа: ");
        //        input = Console.ReadLine()!.Trim();
        //    }

        //    p = new Coords();
        //    p.insert(input.Split(' ')
        //        .Where(x => !string.IsNullOrWhiteSpace(x))
        //        .Select(long.Parse)
        //        .ToList());

        //    List<long> tmp = ;


        //    Console.SetCursorPosition(0, cursorTop);
        //    Console.Write(new string(' ', Console.WindowWidth));
        //    Console.SetCursorPosition(0, cursorTop);

        //    Console.WriteLine($"Полученное выражение: E{pq[2]}(a:{pq[0]}, b:{pq[1]}) => y² = x³ + {pq[0]}x + {pq[1]}");
        //}
    }
}
