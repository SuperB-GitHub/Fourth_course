class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool contin = true;

        while (contin)
        {
            Console.Clear();

            Input(out int a, out int p);
            Console.WriteLine($"\n1) символ Лежандра:");
            int answer = Legendre(a, p);
            switch (answer)
            {
                case 0:
                    Console.WriteLine($"\n\n({a}/{p}) = {answer}, то a ≡ 0(mod p)");
                    break;
                case 1:
                    Console.WriteLine($"\n\n({a}/{p}) = {answer}, следовательно сравнение 2ой степени разрешимо и имеет 2 решения");
                    Solve(a, p);
                    break;
                case -1:
                    Console.WriteLine($"\n\n({a}/{p}) = {answer}, следовательно сравнение 2ой степени не разрешимо");
                    break;
            }
            contin = OutputEnd();
        }
    }

    //Функции алгоритмов
    static int Legendre(int a, int p)
    {
        if (Mod(a, p) == 0)
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
                if (a == 1 && !negSign.Equals("-"))
                {
                    answer *= 1;
                    a = 0;
                    Console.Write($"(4) = 1");
                }
                else
                {
                    Console.Write($"(4) [{p} ≡ ");
                    int temp = ChooseMod(p, 4);
                    answer *= 1;
                    a = 0;
                    if (temp == 3 || temp == -3)
                    {
                        AddNegSign(ref negSign, "-");
                    }
                    Console.Write($"{temp}(mod 4)] = {negSign}{answer}");
                }
            }
            //Свойство 6 - концовое
            if (a == 2 && IsPrime(p))
            {
                Console.Write($"(6) [{p} ≡ ");
                int temp = ChooseMod(p, 8);
                answer *= 1;
                a = 0;
                if (temp == 3 || temp == -3)
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
            if (a == 0 && b > 0)
            {
                a = b;
                b = 0;
                p = p_b;
                Console.Write($"\n\n{negSign}({a}/{p}) = ");
            }
        }
        return negSign.Contains("-") ? -1 : 1;
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
    static void Solve(int a, int p)
    {
        if (Mod(p, 4) == 3)
        {
            Console.WriteLine($"\n2) {p} ≡ 3 (mod 4), то x ≡ ± a^((p + 1) / 4) (mod p)");
            Console.WriteLine($"x ≡ {a}^(({p} + 1) / 4) (mod {p})");
            int deg = (p + 1) / 4;
            Console.WriteLine($"x ≡ {a}^{deg} (mod {p})");
            int x = LightPow(a, deg, p);
            Console.WriteLine($"x ≡ {x} (mod {p})\n");
            Console.WriteLine($"Т.к. x ≡ ± {x}(mod {p}), то ");
            Console.WriteLine($"x1 ≡ {x} (mod {p})");
            Console.WriteLine($"x2 ≡ {p - x} (mod {p})");
            Check(x, a, p);
        }
        else if (Mod(p, 8) == 5)
        {
            Console.WriteLine($"\n2) {p} ≠ 3 (mod 8); {p} ≡ 5 (mod 8), то вычисляем а^((p - 1) / 4) (mod p)");
            int cond = LightPow(a, (p - 1) / 4, p);
            cond = cond == 1 ? cond : cond - p;

            if (cond == 1)
            {
                Console.WriteLine($"Т.к. {a}^(({p} - 1) / 4) (mod {p}) ≡ {cond}, то x ≡ ± a^((p + 3) / 8) (mod p)");
                int deg = (p + 3) / 8;
                Console.WriteLine($"x ≡ {a}^(({p} + 3) / 8) (mod {p})");
                Console.WriteLine($"x ≡ {a}^{deg} (mod {p})");
                int x = LightPow(a, deg, p);
                Console.WriteLine($"x ≡ {x} (mod {p})\n");
                Console.WriteLine($"Т.к. x ≡ ± {x}(mod {p}), то ");
                Console.WriteLine($"x1 ≡ {x} (mod {p})");
                Console.WriteLine($"x2 ≡ {p - x} (mod {p})");
                Check(x, a, p);
            }
            else if (cond == -1)
            {
                Console.WriteLine($"Т.к. {a}^(({p} - 1) / 4) (mod {p}) ≡ {cond}, то x ≡ ± 2a * (4a)^((p - 5) / 8) (mod p)");
                int deg = (p - 5) / 8;
                Console.WriteLine($"x ≡ 2 * {a} * (4 * {a})^(({p} - 5) / 8) (mod {p})");
                Console.WriteLine($"x ≡ {2 * a} * {4 * a}^{deg} (mod {p})");
                Console.WriteLine($"x ≡ {2 * a} * {LightPow(4 * a, deg, p)} (mod {p})");
                int x = Mod(2 * a * LightPow(4 * a, deg, p), p);
                Console.WriteLine($"x ≡ {x} (mod {p})\n");
                Console.WriteLine($"Т.к. x ≡ ± {x}(mod {p}), то ");
                Console.WriteLine($"x1 ≡ {x} (mod {p})");
                Console.WriteLine($"x2 ≡ {p - x} (mod {p})");
                Check(x, a, p);
            }

        }
        else
        {
            Console.WriteLine($"\n2) {p} ≠ 3 (mod 8); {p} ≡ 5 (mod 8)");
            Console.WriteLine($"\n3) Выберем N такое, что (N/p) = -1:");
            int n = 2;
            for (n = 2; n < p / 8; n++)
            {
                if (IsPrime(n))
                {
                    int cond = LightPow(n, (p - 1) / 2, p) == p - 1 ? -1 : 1;
                    if (cond == -1)
                    {
                        Console.WriteLine($"N = {n} => ({n}/{p}) = {cond} - подходит");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"N = {n} => ({n}/{p}) = {cond} - не подходит");
                    }
                }
            }

            Console.WriteLine($"\n4) Представим: p = 2^k * h + 1");
            double k = 0;
            int h = 1;
            for (h = 1; h < p; h = h+2)
            {
                k = Math.Log2((p - 1) / h);
                if (k % 1 == 0)
                {
                    break;
                }
            }
            Console.WriteLine($"{p} = 2^{k} * {h} + 1, т.е. k = {k}, h = {h}");

            Console.WriteLine($"\n5) Положить:");
            int a1 = LightPow(a, (h + 1) / 2, p);
            Console.WriteLine($"a1 = a^(h + 1)/2 (mod p) = {a}^{(h + 1) / 2} (mod {p}) = {a1} (mod {p})");
            int a2 = LightPow(a, EulerPhi(p) - 1, p);
            Console.WriteLine($"a2 = a^(-1) (mod p) = {a}^(-1) (mod {p}) = [НОД({p},{a}) = {NOD(p, a)} => {a}^(-1) сущ-ет => т.Эйлера: a2 = {a2} (mod {p})");
            int n1 = LightPow(n, h, p);
            Console.WriteLine($"N1 = N^h (mod p) = {n}^{h} (mod {p}) = {n1} (mod {p})");
            int n2 = 1; int j = 0;
            Console.WriteLine($"N2 = 1; j = 0");

            Console.WriteLine($"\n6) Для i = 0,1,...,k-2 выполняю:");
            for (int i = 0; i <= k-2; i++)
            {
                Console.WriteLine($"\nПри i = {i}:");
                int b = Mod(a1 * n2, p);
                Console.WriteLine($"b = a1 * N2 (mod p) = {a1} * {n2} (mod {p}) = {b} (mod {p})");
                int c = Mod(a2 * b * b, p);
                Console.WriteLine($"c = a2 * b^2 (mod p) = {a2} * {b * b} (mod {p}) = {c} (mod {p})");
                int d = LightPow(c, (int)Math.Pow(2, k - 2 - i), p) == p - 1 ? -1 : 1;
                Console.WriteLine($"d = c^2^k-2-i (mod p) = {c}^2^{k-2-i} (mod {p}) = {d} (mod {p})");
                j = d == 1 ? 0 : 1;
                Console.WriteLine($"Т.к. d = {d} (mod {p}), то j = {j}");
                Console.Write($"N2 = N2 * N1^(2^i * j) (mod p) = {n2} * {n1}^(2^{i} * {j}) (mod {p}) = ");
                n2 = Mod(n2 * LightPow(n1, (int)Math.Pow(2, i) * j, p), p);
                Console.WriteLine($"{n2} (mod {p})");
            }

            int x = Mod(a1 * n2, p);
            Console.WriteLine($"\nРезультат: x ≡ ± a1 * N2 (mod p) ≡ ± {a1} * {n2} (mod {p}) ≡ ± {x} (mod {p})");
            Console.WriteLine($"x1 ≡ {x} (mod {p})");
            Console.WriteLine($"x2 ≡ {p - x} (mod {p})");
            Check(x, a, p);
        }
    }
    static void Check(int x, int a, int p)
    {
        Console.WriteLine($"\nПроверка:");
        Console.WriteLine($"{x}^2 = {x * x} ≡ {a} (mod {p}) ({LightPow(x, 2, p) == a})");
        Console.WriteLine($"{p - x}^2 = {(p - x) * (p - x)} ≡ {a} (mod {p}) ({LightPow(p - x, 2, p) == a})");
    }

    //Функции ввода/вывода
    static void Input(out int a, out int p)
    {
        Console.Write($"Введите значение для а: ");
        while (!int.TryParse(Console.ReadLine(), out a))
        {
            Console.Write("Некорректный ввод. Введите целое число: ");
        }

        Console.Write($"Введите значение для p: ");
        while (!int.TryParse(Console.ReadLine(), out p) && IsPrime(p))
        {
            Console.Write("Некорректный ввод. Введите простое целое число: ");

        }
        Console.WriteLine($"\nПолученное выражение: x^2 ≡ {a}(mod {p})");
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
    static int ChooseMod(int a, int m)
    {
        int mod = Mod(a, m);
        return mod == 1 || mod == 3 ? mod : mod - m;
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
    static int LightPow(int num, int deg, int m)
    {
        if(deg == 0)
        {
            return 1;
        }
        else
        {
            int result = num;
            for (int i = 0; i < deg - 1; i++)
            {
                result = Mod(result * num, m);
            }
            return result;
        }
        
    }
    static void AddNegSign(ref string negSign, string newSign)
    {
        negSign = negSign.Equals(newSign) ? "" : "-";
    }
    static int EulerPhi(int n)
    {
        if (n <= 0) return 0;
        if (n == 1) return 1;

        int result = 0;
        for (int i = 1; i <= n; i++)
        {
            if (NOD(i, n) == 1)
                result++;
        }
        return result;
    }
}