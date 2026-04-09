using System;
using System.Numerics;
using System.Text;
using static MyLibrary.MathUtils;
using static MyLibrary.StringUtils;

class RSALab
{
    static Random random = new Random();

    // Русский алфавит (1..33) - ТОЧНО КАК В ПРИМЕРЕ
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

    // ТОЧНО ТАКИЕ ЖЕ ФУНКЦИИ КАК В ПРИМЕРЕ
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

    // Функции для BigInteger, которых нет в твоей библиотеке
    static bool IsPrimeBig(BigInteger n, int k = 5)
    {
        if (n <= 1) return false;
        if (n == 2 || n == 3) return true;
        if (n % 2 == 0) return false;

        BigInteger d = n - 1;
        int s = 0;
        while (d % 2 == 0)
        {
            d /= 2;
            s++;
        }

        byte[] bytes = new byte[n.GetByteCount()];
        Random.Shared.NextBytes(bytes);

        for (int i = 0; i < k; i++)
        {
            BigInteger a;
            do
            {
                Random.Shared.NextBytes(bytes);
                a = BigInteger.Abs(new BigInteger(bytes)) % (n - 2) + 2;
            } while (a < 2 || a >= n - 1);

            BigInteger x = BigInteger.ModPow(a, d, n);
            if (x == 1 || x == n - 1) continue;

            bool composite = true;
            for (int r = 1; r < s; r++)
            {
                x = BigInteger.ModPow(x, 2, n);
                if (x == n - 1)
                {
                    composite = false;
                    break;
                }
            }
            if (composite) return false;
        }
        return true;
    }

    static BigInteger GeneratePrime(int bits)
    {
        BigInteger candidate;
        do
        {
            byte[] bytes = new byte[bits / 8 + 1];
            Random.Shared.NextBytes(bytes);
            bytes[bytes.Length - 1] |= 0x80; // Старший бит = 1
            bytes[0] |= 0x01; // Нечетное
            candidate = new BigInteger(bytes);
            if (candidate < 0) candidate = -candidate;
        } while (!IsPrimeBig(candidate, 5));
        return candidate;
    }

    static BigInteger ModInverse(BigInteger e, BigInteger phi)
    {
        BigInteger t = 0, newT = 1;
        BigInteger r = phi, newR = e;

        while (newR != 0)
        {
            BigInteger quotient = r / newR;
            (t, newT) = (newT, t - quotient * newT);
            (r, newR) = (newR, r - quotient * newR);
        }

        if (t < 0) t += phi;
        return t;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Лабораторная работа: Криптосистема RSA (BigInteger)\n");

        Console.WriteLine("\t\t\t Абонент Б (Получатель) создает ключи\n");

        // Генерация 512-битных простых чисел (в сумме дадут 1024-битный ключ)
        Console.WriteLine("Генерация 512-битных простых чисел p и q...");
        BigInteger p = GeneratePrime(512);
        BigInteger q = GeneratePrime(512);
        while (p == q) q = GeneratePrime(512);

        Console.WriteLine($"1. Выбрано простое число p = {p.ToString().Substring(0, Math.Min(50, p.ToString().Length))}...");
        Console.WriteLine($"2. Выбрано простое число q = {q.ToString().Substring(0, Math.Min(50, q.ToString().Length))}...");

        BigInteger n = p * q;
        Console.WriteLine($"3. Вычислен модуль n = p * q (битность: {n.GetBitLength()} бит)");

        BigInteger phi = (p - 1) * (q - 1);
        Console.WriteLine($"4. Вычислена функция Эйлера φ(n) = {phi.ToString().Substring(0, Math.Min(50, phi.ToString().Length))}...");

        BigInteger e = 65537; // Стандартная открытая экспонента
        Console.WriteLine($"5. Выбрана открытая экспонента e = {e}");

        BigInteger d = ModInverse(e, phi);
        Console.WriteLine($"6. Вычислена закрытая экспонента d = {d.ToString().Substring(0, Math.Min(50, d.ToString().Length))}...");

        Console.WriteLine($"\nОткрытый ключ (e, n) = ({e}, n...{n.ToString().Substring(Math.Max(0, n.ToString().Length - 20))})");
        Console.WriteLine($"Закрытый ключ (d, n) = (d...{d.ToString().Substring(Math.Max(0, d.ToString().Length - 20))}, n...{n.ToString().Substring(Math.Max(0, n.ToString().Length - 20))})\n");

        Console.WriteLine("\t\t\t Абонент А (Отправитель) шифрует сообщение\n");
        Input_mess(out string message);
        Console.WriteLine($"Исходное сообщение: {message}\n");

        // Преобразуем сообщение в числа
        BigInteger[] messageNumbers = new BigInteger[message.Length];
        for (int i = 0; i < message.Length; i++)
        {
            messageNumbers[i] = FindIndexByLetter(message[i]);
            Console.WriteLine($"Символ '{message[i]}' -> {messageNumbers[i]}");
        }

        // Шифрование
        BigInteger[] encrypted = new BigInteger[message.Length];
        Console.WriteLine("\nШифрование (используем открытый ключ e, n):");
        for (int i = 0; i < message.Length; i++)
        {
            encrypted[i] = BigInteger.ModPow(messageNumbers[i], e, n);
            Console.WriteLine($"  C{i + 1} = {messageNumbers[i]}^{e} mod n = {encrypted[i]}");
        }

        Console.WriteLine("\n\t\t\t Передача шифротекста абоненту Б\n");
        Console.WriteLine("Абонент А отправляет зашифрованные блоки:");
        for (int i = 0; i < encrypted.Length; i++)
        {
            Console.WriteLine($"  Символ {i + 1}: {encrypted[i]}");
        }

        Console.WriteLine("\n\t\t\t Абонент Б расшифровывает сообщение\n");
        Console.WriteLine($"Используется закрытый ключ d\n");

        string decryptedMessage = "";
        for (int i = 0; i < encrypted.Length; i++)
        {
            BigInteger decryptedNum = BigInteger.ModPow(encrypted[i], d, n);
            char decryptedChar = alph[(int)decryptedNum];
            decryptedMessage += decryptedChar;

            Console.WriteLine($"Символ {i + 1}: C = {encrypted[i]}, d = ...");
            Console.WriteLine($"  M = C^d mod n = {decryptedNum} -> '{decryptedChar}'\n");
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
            Console.WriteLine("\nСообщения не совпадают. Ошибка!");
        }

        Console.WriteLine("\nНажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}