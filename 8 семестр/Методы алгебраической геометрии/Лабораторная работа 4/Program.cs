using static MyLibrary.MathUtils;
using static MyLibrary.StringUtils;

namespace Лабораторная_работа_4
{

    class Coords
    {
        public Coords()
        {
        }

        public Coords(long x, long y)
        {
            this.x = x;
            this.y = y;
        }

        public long x { get; set; }
        public long y { get; set; }

        public void insert(List<long> x_y)
        {
            x = x_y[0];
            y = x_y[1];
        }
        public string print()
        {
            return $"({x}, {y})";
        }
        public bool equals(Coords other)
        {
            return x == other.x && y == other.y ? true : false;
        }
        public bool contains(List<Coords> list)
        {
            foreach (Coords item in list)
            {
                if (x == item.x && y == item.y)
                {
                    return true;   
                }
            }
            return false;
        }
        public long indexof(List<Coords> list)
        {
            for (long i = 0; i < list.Count(); i++)
            {
                Coords item = list[(int)i];
                if (x == item.x && y == item.y)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool contin = true;

            while (contin)
            {
                Console.Clear();
                Input_e(out List<long> abm);
                TableXandY(abm, out List<long> xi, out List<long> yi);
                Input_PQ(out Coords p, abm, true);
                Input_PQ(out Coords q, abm, false);
                PplusQ(p, q, abm[2]);
                twoP(p, abm);

                Console.WriteLine("\nСкалярное умножение точек ЭК");
                Input_n(out long n);
                Lab5(p, n, abm);

                Console.WriteLine($"\nНахождение порядка точки в группе ЭК");
                Lab6(p, abm);

                contin = OutputEnd();
            }
        }

        // Функции ввода/вывода
        static void Input_PQ(out Coords t, List<long> abm, bool PorQ)
        {
            int cursorTop = Console.CursorTop;

            Console.Write($"Выберите значения для x и y от {(PorQ ? "P" : "Q")} через пробел: ");
            string input = Console.ReadLine()!.Trim();
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Некорректный ввод. Введите целые числа: ");
                input = Console.ReadLine()!.Trim();
            }

            t = new Coords();
            t.insert(input.Split(' ')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(long.Parse)
                .ToList());

            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);

            if (checkCoords(abm, t))
            {
                Console.WriteLine($"Значения подходят: {(PorQ ? "P" : "Q")}({t.x}; {t.y})");
            }
            else
            {
                Console.WriteLine($"Значения не подходят: {(PorQ ? "P" : "Q")}({t.x}; {t.y})");
                Input_PQ(out t, abm, PorQ);
            }


        }
        static void Input_e(out List<long> abm)
        {
            int cursorTop = Console.CursorTop;

            Console.Write($"Введите значения a, b и m через пробел: ");
            string input = Console.ReadLine()!.Trim();
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Некорректный ввод. Введите целые числа: ");
                input = Console.ReadLine()!.Trim();
            }

            abm = input.Split(' ')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(long.Parse)
                .ToList();

            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);

            Console.WriteLine($"Полученное выражение: E{abm[2]}(a:{abm[0]}, b:{abm[1]}) => y² = x³ + {abm[0]}x + {abm[1]}");
        }
        static void Input_n(out long n)
        {
            int cursorTop = Console.CursorTop;

            Console.Write($"\nВведите значение скаляра: ");
            while (!long.TryParse(Console.ReadLine(), out n))
            {
                Console.SetCursorPosition(0, cursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, cursorTop);
                Console.Write("Некорректный ввод. Введите целое число: ");
            }
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);

            Console.WriteLine($"\n3) Введено значение скаляра: {n}");
        }

        // Функции логики
        static void TableXandY(List<long> abm, out List<long> xi, out List<long> yi)
        {
            xi = new List<long>();
            yi = new List<long>();
            List<long> num = new List<long>();
            for (int x_y = 0; x_y <= abm[2] - 1; x_y++)
            {
                num.Add(x_y);
                xi.Add(Mod(FastPowMod(x_y, 3, abm[2]) + abm[0] * x_y + abm[1], abm[2]));
                yi.Add(FastPowMod(x_y, 2, abm[2]));
            }

            Console.WriteLine();
            Console.WriteLine($"n | {string.Join(" | ", num.Select(n => $"{n}".PadRight(2)))}");
            Console.WriteLine($"x | {string.Join(" | ", xi.Select(n => $"{n}".PadRight(2)))}");
            Console.WriteLine();
            Console.WriteLine($"n | {string.Join(" | ", num.Select(n => $"{n}".PadRight(2)))}");
            Console.WriteLine($"y | {string.Join(" | ", yi.Select(n => $"{n}".PadRight(2)))}\n");

            Console.WriteLine("\nНайденные точки: ");
            HashSet<Coords> fine = new HashSet<Coords>();
            for (int x = 0; x <= xi.Count() - 1; x++)
            {
                for (int y = 0; y <= yi.Count() - 1; y++)
                {
                    Coords tmp = new Coords(x, y);
                    if (checkCoords(abm, tmp))
                    {
                        fine.Add(tmp);
                        Console.Write($"({x}, {y}) ");
                    }
                }
            }
            Console.WriteLine($"и O\nПЭК = {fine.Count() + 1}\n");
        }
        static bool checkCoords(List<long> abm, Coords xy)
        {
            long x = Mod(FastPowMod(xy.x, 3, abm[2]) + abm[0] * xy.x + abm[1], abm[2]);
            long y = FastPowMod(xy.y, 2, abm[2]);
            return x == y;
        }
        static void PplusQ(Coords p, Coords q, long m)
        {
            long lambda1 = q.y - p.y;
            long lambda2 = q.x - p.x;
            if (lambda2 != 0)
            {
                long lambda = lambda1 * InversElem(lambda2, m);
                Console.WriteLine($"\n1) P + Q = λ = (y₂ - y₁)/(x₂ - x₁) = " +
                    $"{lambda1}/{lambda2} = {lambda1} * {lambda2}⁻¹ = " +
                    $"{lambda1} * {InversElem(lambda2, m)} = {lambda}(mod {m}) = {lambda = Mod(lambda, m)}(mod {m})\n");

                Coords t = TheoremViet(p, q, m, lambda);
                Console.WriteLine($"\nR = P + Q => R({t.x}, {t.y})\n");
            }
            else
            {
                Console.WriteLine($"\n1) Т.к. x1 = x2, то точки симметричны, а значит R = O\n");
            }

        }
        static void twoP(Coords p, List<long> abm)
        {
            long m = abm[2];
            long lambda1 = 3 * FastPowMod(p.x, 2, m) + abm[0];
            long lambda2 = 2 * p.y;
            long lambda = lambda1 * InversElem(lambda2, m);
            Console.WriteLine($"2) 2P = λ = (3x²₁ + a)/(2y₁) = " +
                $"{lambda1}/{lambda2} = {lambda1} * {lambda2}⁻¹ = " +
                $"{lambda1} * {InversElem(lambda2, m)} = {lambda}(mod {m}) = {lambda = Mod(lambda, m)}(mod {m})\n");

            Coords t = TheoremViet(p, p, m, lambda);
            Console.WriteLine($"\n2P({t.x}, {t.y})");
        }
        static Coords TheoremViet(Coords p, Coords q, long m, long lambda)
        {
            Console.WriteLine("По приколу (теореме Виета для кубических уравнений):");
            long x = FastPowMod(lambda, 2, m) - p.x - q.x;
            Console.WriteLine($"x₃ = λ² - x₁ - x₂ = {x}(mod {m}) ≡ {x = Mod(x, m)}(mod {m}) ");
            long y = lambda * (p.x - x) - p.y;
            Console.WriteLine($"y₃ = λ(x₁ - x₃) - y₁ = {y}(mod {m}) ≡ {y = Mod(y, m)}(mod {m}) ");

            return new Coords { x = x, y = y };
        }

        // Лабораторная работа 5
        static void Lab5(Coords p, long n, List<long> abm)
        {
            List<long> bin = Convert.ToString(n, 2).Select(c => long.Parse(c.ToString())).ToList();
            Console.WriteLine($"{n}₁₀ = {Convert.ToString(n, 2)}₂\n");

            Coords R = new Coords(0, 0);
            Console.WriteLine($"1) R -> O\n2)");

            foreach (long item in bin)
            {
                Console.Write($"  ({item}): R{R.print()} = 2R");
                R = MulFunc(R, abm);
                Console.Write($"{R.print()}");

                if (item == 1)
                {
                    Console.Write($" => R = R{R.print()} + P{p.print()}");
                    R = AddFunc(p, R, abm[2]);
                    Console.Write($" = R{R.print()}");
                }

                Console.WriteLine();
            }
            Console.WriteLine($"3) {n}R = R{R.print()})");
        }
        static Coords AddFunc(Coords P, Coords R, long m)
        {
            Coords nul = new Coords(0, 0);

            if (R.equals(nul))
            {
                return P;
            }
            else if (P.equals(nul))
            {
                return R;
            }
            else
            {
                long lambda1 = R.y - P.y;
                long lambda2 = R.x - P.x;
                if (lambda2 == 0)
                {
                    return new Coords(0, 0);
                }
                else
                {
                    long lambda = Mod(lambda1 * InversElem(lambda2, m), m);
                    Coords t = JokeFunc(R, P, m, lambda);
                    return t;
                }
            }
        }
        static Coords MulFunc(Coords R, List<long> abm)
        {
            Coords nul = new Coords(0, 0);

            if (R.equals(nul))
            {
                return R;
            }
            else
            {
                long m = abm[2];
                long lambda1 = 3 * FastPowMod(R.x, 2, m) + abm[0];
                long lambda2 = 2 * R.y;
                if (lambda2 == 0)
                {
                    return nul;
                }
                else
                {
                    long lambda = Mod(lambda1 * InversElem(lambda2, m), m);
                    Coords t = JokeFunc(R, R, m, lambda);
                    return t;
                }
            }
        }
        static Coords JokeFunc(Coords p, Coords q, long m, long lambda)
        {
            long x = Mod(FastPowMod(lambda, 2, m) - p.x - q.x, m);
            long y = Mod(lambda * (p.x - x) - p.y, m);
            return new Coords(x, y);
        }

        //Лабораторная работа 6
        static void Lab6(Coords P, List<long> abm)
        {
            long p = abm[2];
            long m = (long)Math.Ceiling(Math.Sqrt(p + 1 + 2 * Math.Sqrt(p)));
            Console.WriteLine($"\nm = √N₁, где N₁ = p + 1 + 2√p = {p} + 1 + {2 * Math.Sqrt(p)} ≈ " +
                $"{p + 1 + 2 * Math.Sqrt(p)} => √N₁ ≈ {Math.Sqrt(p + 1 + 2 * Math.Sqrt(p))} = {m}");

            List<long> ts = new List<long>();
            List<Coords> tps = new List<Coords>();
            for (int t = 1; t <= m; t++)
            {
                ts.Add(t);
                tps.Add(SkalMul(P, t, abm));
            }

            Console.WriteLine();
            Console.WriteLine($"t  | {string.Join(" | ", ts.Select(n => $"{n}".PadRight(7)))}");
            Console.WriteLine($"tp | {string.Join(" | ", tps.Select(n => $"{n.print()}".PadRight(7)))}");
            Console.WriteLine();

            Coords Q = SkalMul(P, m, abm);
            Console.Write($"Q = -mP = -{m}P = -{m}{P.print()} = -{Q.print()} = ");
            Q.y = Mod(Q.y * (-1), p);
            Console.WriteLine($"{Q.print()}(mod {p})\n");

            Coords R = new Coords(0, 0);
            Console.WriteLine($"R -> 0");
            long n = 0;

            for (int i = 0; i < m-1; i++)
            {
                if (R.contains(tps))
                {
                    n = m * i + R.indexof(tps) + 1;
                    Console.WriteLine($"{i + 1}) R{R.print()} содержится в таблице, период n = m:{m} * i:{i} + t:{R.indexof(tps) + 1} = {n}");
                    break;
                }
                else
                {
                    Console.Write($"{i + 1}) R{R.print()} не содержится в таблице, поэтому R = R{R.print()} + Q{Q.print()} = ");
                    R = R.equals(Q) ? MulFunc(R, abm) : AddFunc(R, Q, p);
                    //R = AddFunc(R, Q, p);
                    Console.WriteLine($"R{R.print()}");
                    
                }
            }
            Console.WriteLine($"Ответ: Период n = {n}");

        }
        static Coords SkalMul(Coords p, long n, List<long> abm)
        {
            List<long> bin = Convert.ToString(n, 2).Select(c => long.Parse(c.ToString())).ToList();

            Coords R = new Coords(0, 0);

            foreach (long item in bin)
            {
                R = MulFunc(R, abm);

                if (item == 1)
                {
                    R = AddFunc(p, R, abm[2]);
                }
            }
            return R;
        }
    } 
}