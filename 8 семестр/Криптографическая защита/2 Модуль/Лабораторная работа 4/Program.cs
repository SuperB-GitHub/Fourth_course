using System;
using System.Text;
using static MyLibrary.StringUtils;
using static MyLibrary.MathUtils;

class ElGamalLab
{
    static Random random = new Random();

    // Проверка, является ли g примитивным корнем по модулю p
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

    static void Input_p(out long n)
    {
        int cursorTop = Console.CursorTop;

        Console.Write($"Введите простое число p: ");
        while (!long.TryParse(Console.ReadLine(), out n) || !TestMillerRabin(n))
        {
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);
            Console.Write("Некорректный ввод. Введите простое целое число: ");
        }
        Console.SetCursorPosition(0, cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, cursorTop);
    }
    static void Input_x(out long n, long p)
    {
        int cursorTop = Console.CursorTop;

        Console.Write($"Введите число x, такое что 1 < x < {p-1}: ");
        while (!long.TryParse(Console.ReadLine(), out n) || !(n > 1 && n < (p - 1)))
        {
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);
            Console.Write($"Некорректный ввод. Введите целое число, такое что 1 < x < {p-1}: ");
        }
        Console.SetCursorPosition(0, cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, cursorTop);
    }
    static void Input_mess(out string n)
    {
        int cursorTop = Console.CursorTop;

        Console.Write($"Введите сообщение: ");
        n = Console.ReadLine()!.Trim();
        while (string.IsNullOrWhiteSpace(n))
        {
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);
            Console.Write("Некорректный ввод. Введите текст: ");
            n = Console.ReadLine()!.Trim();
        }
        Console.SetCursorPosition(0, cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, cursorTop);

    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Console.WriteLine("Лабораторная работа: Криптосистема Эль-Гамаля\n");

        Console.WriteLine("\t\t\t Абонент Б (Получатель) создает ключи\n");
        Input_p(out long P);
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
        Input_x(out long X, P);
        Console.WriteLine($"3. Выбран секретный ключ X = {X} (закрытый ключ)");
        long Y = FastPowMod(G, X, P);
        Console.WriteLine($"4. Вычислен открытый ключ Y = g^x (mod p) = {Y} (mod {P})");

        Console.WriteLine($"\nОткрытый ключ (P, G, Y) = ({P}, {G}, {Y})");
        Console.WriteLine($"Закрытый ключ X = {X}\n");

        Console.WriteLine("\t\t\t Абонент А (Отправитель) шифрует сообщение\n");
        Input_mess(out string message);
        Console.WriteLine($"Исходное сообщение: {message}\n");
        Console.WriteLine($"Получен открытый ключ: P = {P}, G = {G}, Y = {Y}\n");

        long[] aValues = new long[message.Length];
        long[] bValues = new long[message.Length];

        Encoding win1251 = Encoding.GetEncoding(1251);

        for (int i = 0; i < message.Length; i++)
        {
            char symbol = message[i];

            byte[] win1251Bytes = win1251.GetBytes(new char[] { symbol });
            long M = win1251Bytes[0];

            Console.Write($"Символ '{symbol}' -> код Win1251: {M}");

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
        Console.WriteLine("Абонент А отправляет пары (a, b):");
        for (long i = 0; i < message.Length; i++)
        {
            Console.WriteLine($"  Символ {i + 1}: (a={aValues[i]}, b={bValues[i]})");
        }

        Console.WriteLine("\n\t\t\t Абонент Б расшифровывает сообщение\n");
        Console.WriteLine($"Используется закрытый ключ X = {X}\n");

        string decryptedMessage = "";

        for (long i = 0; i < message.Length; i++)
        {
            long a = aValues[i];
            long b = bValues[i];

            long ax = FastPowMod(a, X, P);

            long axInverse = FastPowMod(a, P - 1 - X, P);

            long M = (b * axInverse) % P;

            byte[] win1251Bytes = new byte[] { (byte)M };
            char decryptedChar = win1251.GetChars(win1251Bytes)[0];
            decryptedMessage += decryptedChar;

            Console.WriteLine($"Символ {i + 1}: a={a}, b={b} -> M={M} -> '{decryptedChar}'");
        }

        Console.WriteLine("\n\t\t\t Сравнение исходного и расшифрованного сообщений\n");
        Console.WriteLine($"Исходное сообщение:       {message}");
        Console.WriteLine($"Расшифрованное сообщение: {decryptedMessage}");

        if (message == decryptedMessage)
        {
            Console.WriteLine("\nСообщения совпадают. Расшифрование выполнено корректно.");
        }
        else
        {
            Console.WriteLine("\nСообщения не совпадают. Скорее всего мало p.");
        }

        Console.WriteLine("\nНажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}