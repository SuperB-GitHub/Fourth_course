class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool contin = true;

        while (contin)
        {
            Console.Clear();

            Input(out int a, out int m);
            if (IsPrime(m))
            {
                Console.WriteLine($"Т.к. {m} - простое, то вычисляю символ Лежандра:");
                int answer = Legendre(a, m);
                switch (answer)
                {
                    case 0:
                        Console.WriteLine($"\n\nТ.к. ({a}/{m}) = {answer}, то a ≡ 0(mod p)");
                        break;
                    case 1:
                        Console.WriteLine($"\n\nТ.к. ({a}/{m}) = {answer}, следовательно {a} - квадратичный не вычет по mod {m}, т.е. сравнение 2ой степени разрешимо");
                        break;
                    case -1:
                        Console.WriteLine($"\n\nТ.к. ({a}/{m}) = {answer}, следовательно {a} - квадратичный вычет по mod {m}, т.е. сравнение 2ой степени не разрешимо");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Т.к. {m} - составное, то вычисляю символ Якоби:");
                Jacobi(a, m);
            }
            contin = OutputEnd();
        }
    }

    static int Legendre(int a, int p)
    {
        if (Mod(a,p) == 0)
        {
            return 0;
        }

        Console.Write($"\n({a}/{p}) = ");
        int b = 0;
        int p_b = 0;
        string negSign = "";
        int answer = 1;

        while (a != 0)
        {
            //Свойство 1
            if (a > p && a / p > 0 && IsPrime(p))
            {
                Console.Write($"(1) [{a - p * (a / p)} + {a / p} * {p}] = ");
                a = a - p * (a / p);
                Console.Write($"\n{negSign}({a}/{p}) = ");
            }
            //Свойство 2
            if (SecondPropert(a) != -1 && IsPrime(p))
            {
                b = SecondPropert(a);
                Console.Write($"(2) [{a / (b * b)} * {b}^2] = ");
                a = a / (b * b);
                Console.Write($"\n{negSign}({a}/{p}) = ");
                b = 0;
            }
            //Свойство 3
            if (!IsPrime(a) && ThirdPropert(a) != -1)
            {
                int temp = ThirdPropert(a);
                b = a / temp;
                a = temp;
                p_b = p;
                Console.Write($"(3) [{a} * {b}] = ({a}/{p}) * ({b}/{p}) = \n\n({a}/{p}) = ");
            }
            //Свойство 4 - концовое
            if (a == 1 || a == -1 && IsPrime(p))
            {
                Console.Write($"(4) [{p} ≡ ");
                int temp = Mod(p, 4);
                answer *= 1;
                a = 0;
                if (temp == 3)
                {
                    AddNegSign(ref negSign, "-");
                }
                Console.Write($"{temp}(mod 4)] = {negSign}{answer}");
            }
            //Свойство 6 - концовое
            if (a == 2 && IsPrime(p))
            {
                Console.Write($"(6) [{p} ≡ ");
                int temp = Mod(p, 8);
                answer *= 1;
                a = 0;
                if (temp == 3)
                {
                    AddNegSign(ref negSign, "-");
                }
                Console.Write($"{temp}(mod 8)] = {negSign}{answer}");
            }
            //Свойство 7
            if (IsPrime(a))
            {
                Console.Write($"(7) (-1)^[{p}-1/2 * {a}-1/2] * ({p}/{a}) = ");
                int deg = ((a - 1) / 2) * ((p - 1) / 2);
                Console.Write($"(-1)^{deg} * ({p}/{a}) = ");
                AddNegSign(ref negSign, deg % 2 == 0 ? "" : "-");
                int temp = a; a = p; p = temp;
                Console.Write($"\n{negSign}({a}/{p}) = ");
            }
            if (a == 0 && b>0)
            {
                a = b;
                b = 0;
                p = p_b;
                Console.Write($"\n\n({a}/{p}) = ");
            }
        }
        return negSign.Contains("-") ? -1 : 1;
    }
    static int Jacobi(int a, int m)
    {
        HashSet<int> ms = new HashSet<int>();
        Console.Write($"\n({a}/{m}) = [{m} = "); 
        int _ = 2;
        while (!IsPrime(m))
        {
            
            if (m % _ == 0 && IsPrime(_))
            {
                ms.Add(_);
                m /= _;
                Console.Write($"{_} * ");
            }
            _++;
        }
        ms.Add(m);
        Console.Write($"{m}] =");
        return ms.Count;
    }

    //Функции ввода/вывода
    static void Input(out int a, out int m)
    {
        Console.Write($"Введите значение для а: ");
        while (!int.TryParse(Console.ReadLine(), out a))
        {
            Console.Write("Некорректный ввод. Введите целое число: ");
        }

        Console.Write($"Введите значение для m: ");
        while (!int.TryParse(Console.ReadLine(), out m))
        {
            Console.Write("Некорректный ввод. Введите целое число: ");

        }
        Console.WriteLine($"\nПолученное выражение: ({a}/{m})");
    }
    static bool OutputEnd()
    {
        Console.Write($"\nЖелаете продолжить? (Enter) ");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key != ConsoleKey.Enter) { return false; }
        return true;
    }

    //Функции вспомогательные
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
    static int LightPow(int num, int deg, int m)
    {
        int result = num;
        for (int i = 0; i < deg - 1; i++)
        {
            result = Mod(result * num, m);
        }
        return result;
    }
    static bool IsPrime(int number)
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
    static int SecondPropert(int a)
    {
        for (int i = 2; i <= (int)Math.Sqrt(a); i++)
        {
            int powed = (int)Math.Pow(i, 2);
            if (a % powed == 0 && a >= powed)
            {
                return i;
            }
        }
        return -1;
    }
    static void AddNegSign(ref string negSign, string newSign)
    {
        negSign = negSign.Contains(newSign) ? "" : "-";
    }
    static int ThirdPropert(int a)
    {
        for (int i = 2; i <= (int)Math.Sqrt(a); i++)
        {
            if (a % i == 0)
            {
                return i;
            }
        }
        return -1;
    }
}