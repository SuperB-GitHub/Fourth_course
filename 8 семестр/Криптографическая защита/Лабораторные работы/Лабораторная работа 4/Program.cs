using System;
using System.Text;
using static MyLibrary.StringUtils;
using static MyLibrary.MathUtils;

class ElGamalLab
{
    static Random random = new Random();
    static long P_fir, G_fir, Y_fir;
    static Dictionary<int, char> alph = new Dictionary<int, char>
        {
            {1, 'А'}, {2, 'Б'}, {3, 'В'}, {4, 'Г'}, {5, 'Д'},
            {6, 'Е'}, {7, 'Ё'}, {8, 'Ж'}, {9, 'З'}, {10, 'И'},
            {11, 'Й'}, {12, 'К'}, {13, 'Л'}, {14, 'М'}, {15, 'Н'},
            {16, 'О'}, {17, 'П'}, {18, 'Р'}, {19, 'С'}, {20, 'Т'},
            {21, 'У'}, {22, 'Ф'}, {23, 'Х'}, {24, 'Ц'}, {25, 'Ч'},
            {26, 'Ш'}, {27, 'Щ'}, {28, 'Ъ'}, {29, 'Ы'}, {30, 'Ь'},
            {31, 'Э'}, {32, 'Ю'}, {33, 'Я'}
        };

    static bool IsPrimitiveRoot(long g, long p)
    {
        long phi = EulerPhi(p);
        long current = 1;

        for (long i = 1; i < phi; i++)
        {
            current = Mod(current * g, p);
            if (current == 1)
                return false;
        }
        return true;
    }
    static int FindIndexByLetter(char letter)
    {
        letter = char.ToUpper(letter);
        foreach (var pair in alph)
        {
            if (pair.Value == letter)
                return pair.Key;
        }
        return -1;
    }
    static bool IsRussianText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        foreach (char c in text)
        {
            if (char.IsWhiteSpace(c) || char.IsPunctuation(c) || char.IsDigit(c))
                continue;

            bool isRussian = (c >= 'а' && c <= 'я') || c == 'ё';

            if (!isRussian)
                return false;
        }
        return true;
    }

    static void Input_mess(out string n)
    {
        int cursorTop = Console.CursorTop;

        Console.Write($"Введите сообщение: ");
        n = Console.ReadLine()!.Trim().ToLower();
        while (string.IsNullOrWhiteSpace(n) || !IsRussianText(n))
        {
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);
            Console.Write("Некорректный ввод. Введите русский текст: ");
            n = Console.ReadLine()!.Trim();
        }
        Console.SetCursorPosition(0, cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, cursorTop);

    }
    static void Input_err(out bool err)
    {
        int cursorTop = Console.CursorTop;

        Console.Write($"Передано с ошибкой? (д/н): ");
        string n = Console.ReadLine()!.Trim().ToLower();
        while (string.IsNullOrWhiteSpace(n) || (n != "д" && n != "н"))
        {
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);
            Console.Write("Некорректный ввод. Введите <д> или <н>: ");
            n = Console.ReadLine()!.Trim();
        }
        Console.SetCursorPosition(0, cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, cursorTop);

        err = n == "д";

    }
    static void Input_PGY(out List<long> pgy)
    {
        int cursorTop = Console.CursorTop;

        Console.Write($"Введите открытый ключ p, g, y через пробел: ");
        string input = Console.ReadLine()!.Trim();
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.Write("Некорректный ввод. Введите целые числа: ");
            input = Console.ReadLine()!.Trim();
        }

        pgy = input.Split(' ')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(long.Parse)
            .ToList();

        Console.SetCursorPosition(0, cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, cursorTop);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Лабораторная работа: Криптосистема Эль-Гамаля\n");

        Console.WriteLine("\t\t\t Абонент Б (Получатель) создает ключи\n");

        long P = random.NextInt64(33,100);
        while (!TestMillerRabin(P, 5))
        {
            P = random.NextInt64(33,100);
        }
        Console.WriteLine($"1. Выбрано простое число P = {P}");

        long G = 0;
        for (long i = 2; i <= 9; i++)
        {
            if (IsPrimitiveRoot(i, P))
            {
                G = i;
                break;
            }
        }
        Console.WriteLine($"2. Выбран примитивный элемент G = {G}");
        long X = random.NextInt64(1, P-1);
        Console.WriteLine($"3. Выбран секретный ключ X = {X} (закрытый ключ)");
        long Y = FastPowMod(G, X, P);
        Console.WriteLine($"4. Вычислен открытый ключ Y = g^x (mod p) = {Y} (mod {P})");

        Console.WriteLine($"\nОткрытый ключ (P, G, Y) = ({P_fir = P}, {G_fir = G}, {Y_fir = Y})");
        Console.WriteLine($"Закрытый ключ X = {X}\n");

        Console.WriteLine("\t\t\t Абонент А (Отправитель) шифрует сообщение\n");
        Input_mess(out string message);
        Console.WriteLine($"Исходное сообщение: {message}\n");
        Input_PGY(out List<long> PGY);
        Console.WriteLine($"Получен открытый ключ: P = {P = PGY[0]}, G = {G = PGY[1]}, Y = {Y = PGY[2]}\n");

        long[] aValues = new long[message.Length];
        long[] bValues = new long[message.Length];

        for (int i = 0; i < message.Length; i++)
        {
            char symbol = message[i];

            long M = FindIndexByLetter(symbol);

            Console.WriteLine($"Символ '{symbol}' -> {M}");

            long k;
            do
            {
                k = random.Next(2, 10);
            } while (k >= P - 1);
            Console.WriteLine($"Случайно выбранное k = {k}");

            long a = FastPowMod(G, k, P);
            Console.WriteLine($"a = g^k (mod p) = {G}^{k} (mod {P}) = {a}");

            long yk = FastPowMod(Y, k, P);
            long b = (yk * M) % P;
            Console.WriteLine($"b = y^k * M (mod p) = {Y}^{k} * {M} (mod {P}) = {b}");
            aValues[i] = a;
            bValues[i] = b;

            Console.WriteLine($"  -> k = {k}, a = {a}, b = {b}");
            Console.WriteLine();
        }

        Console.WriteLine("\n\t\t\t Передача шифротекста абоненту Б \n");
        Input_err(out bool err);
        for (long i = 0; i < message.Length; i++)
        {
            if (err)
            {
                Console.WriteLine("Абонент А отправляет пары (a, b) (С ошибками):");
                Console.WriteLine($"  Символ {i + 1}: (a={aValues[i]+1}, b={bValues[i]})");
            }
            else
            {
                Console.WriteLine("Абонент А отправляет пары (a, b):");
                Console.WriteLine($"  Символ {i + 1}: (a={aValues[i]}, b={bValues[i]})");
            }
        }

        Console.WriteLine("\n\t\t\t Абонент Б расшифровывает сообщение\n");
        Console.WriteLine($"Используется закрытый ключ X = {X}\n");

        string decryptedMessage = "";

        for (long i = 0; i < message.Length; i++)
        {

            long a = err ? aValues[i] + 1 : aValues[i];
            long b = bValues[i];

            long axInverse = FastPowMod(a, P - 1 - X, P);

            long M = Mod(b * axInverse, P);

            char decryptedChar = alph[(int)M];
            decryptedMessage += decryptedChar;

            Console.WriteLine($"Символ {i + 1}: a = {a}, b = {b}, x = {X} -> ");
            Console.WriteLine($"M = b * a^(p - 1 - x)(mod p) = {b} * {a}^{P - 1 - X}(mod {P}) = {b} * {axInverse}(mod {P}) = {M} -> '{decryptedChar}'\n");
        }
        decryptedMessage = decryptedMessage.ToLower();

        Console.WriteLine("\n\t\t\t Сравнение исходного и расшифрованного сообщений\n");
        Console.WriteLine($"Исходное сообщение:       {message}");
        Console.WriteLine($"Расшифрованное сообщение: {decryptedMessage}");

        if (message == decryptedMessage)
        {
            Console.WriteLine("\nСообщения совпадают. Расшифрование выполнено корректно.");
        }
        else
        {
            if (P_fir != P || G_fir != G || Y_fir != Y)
            {
                Console.WriteLine("\nСообщения не совпадают. Открытые ключи не совпали.");
            }
            else if (err)
            {
                Console.WriteLine("\nСообщения не совпадают. Была допущена ошибка при передаче зашифрованного сообщения.");
            }
            else
            {
                Console.WriteLine("\nСообщения не совпадают. Надо анализировать...");
            }
        }
        Console.WriteLine("\nНажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}