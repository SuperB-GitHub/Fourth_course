using System;
using System.Numerics;
using System.Text;
using static MyLibrary.MathUtils;
using static MyLibrary.StringUtils;

class RSALab
{
    static Random random = new Random();

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
    static BigInteger ModInverse(BigInteger e, BigInteger m)
    {
        BigInteger t = 0, newT = 1;
        BigInteger r = m, newR = e;

        while (newR != 0)
        {
            BigInteger quotient = r / newR;
            (t, newT) = (newT, t - quotient * newT);
            (r, newR) = (newR, r - quotient * newR);
        }

        if (t < 0) t += m;
        return t;
    }

    static void InputBI(string message, out BigInteger num)
    {
        int cursorTop = Console.CursorTop;

        Console.Write(message);
        string input = Console.ReadLine()!.Trim();

        while (string.IsNullOrWhiteSpace(input) || !BigInteger.TryParse(input, out num))
        {
            Console.SetCursorPosition(0, cursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursorTop);
            Console.Write("Некорректный ввод. Введите целое число: ");
            input = Console.ReadLine()!.Trim();
        }

        Console.SetCursorPosition(0, cursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, cursorTop);
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Лабораторная работа: Криптосистема RSA\n");

        Console.WriteLine("\t\t\t Абонент Б (Получатель) создает ключи\n");

        int bits = 1024;
        Console.WriteLine($"Генерация {bits}-битных простых чисел p и q...");
        BigInteger p = GeneratePrime(bits);
        BigInteger q = GeneratePrime(bits);
        while (p == q) q = GeneratePrime(bits);

        Console.WriteLine($"1. Выбрано простое число p = \n{p}\n");
        Console.WriteLine($"2. Выбрано простое число q = \n{q}\n");

        BigInteger n = p * q;
        Console.WriteLine($"3. Вычислен модуль n = p * q (битность: {n.GetBitLength()} бит): \n{n}\n");

        BigInteger m = (p - 1) * (q - 1);
        Console.WriteLine($"4. Вычислено число m = (p - 1) * (q - 1) = \n{m}\n");

        Console.WriteLine("5. Выбор числа d, взаимно простого с m:");
        BigInteger d;
        do
        {
            byte[] bytes = new byte[m.GetByteCount()];
            random.NextBytes(bytes);
            d = BigInteger.Abs(new BigInteger(bytes)) % (m - 2) + 2;
        } while (BigInteger.GreatestCommonDivisor(d, m) != 1);

        Console.WriteLine($"d = \n{d}\n");
        Console.WriteLine($"Проверка: НОД(d, m) = {BigInteger.GreatestCommonDivisor(d, m)}");

        Console.WriteLine("\n6. Вычисление e из условия e * d ≡ 1 (mod m) => e = ");
        BigInteger e = ModInverse(d, m);
        Console.WriteLine($"\n{e}\n");
        Console.WriteLine($"Проверка: (e * d) mod m = {(e * d) % m}\n");


        Console.WriteLine($"\nОткрытый ключ (e, n) = \ne :{e.ToString().Substring(0, Math.Min(30, e.ToString().Length))}...\nn :{n.ToString().Substring(0, Math.Min(30, e.ToString().Length))}...\n");
        Console.WriteLine($"Закрытый ключ (d, n) = \nd :{d.ToString().Substring(0, Math.Min(30, e.ToString().Length))}...\nn :{n.ToString().Substring(0, Math.Min(30, e.ToString().Length))}...\n");

        Console.WriteLine("\t\t\t Абонент А (Отправитель) шифрует сообщение\n");
        Input_mess(out string message);

        InputBI("Введите ключ e:", out BigInteger enc_key);
        Console.WriteLine();
        InputBI("Введите n ключ:", out BigInteger enc_n);
        Console.WriteLine();

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
            encrypted[i] = BigInteger.ModPow(messageNumbers[i], enc_key, enc_n);
            Console.WriteLine($"  C{i + 1} = {messageNumbers[i]}^{enc_key.ToString().Substring(0, Math.Min(30, e.ToString().Length))}... mod n = \n{encrypted[i]}\n");
        }

        Console.WriteLine("\n\t\t\t Передача шифротекста абоненту Б\n");
        Console.WriteLine("Абонент А отправляет зашифрованные блоки:");
        Input_err(out bool err);
        for (int i = 0; i < encrypted.Length; i++)
        {
            Console.WriteLine($"  Символ {i + 1}: {(err ? encrypted[i] + 1 : encrypted[i])}");
        }

        Console.WriteLine("\n\t\t\t Абонент Б расшифровывает сообщение\n");
        InputBI("Введите ключ d:", out BigInteger dec_key);
        Console.WriteLine();
        InputBI("Введите n ключ:", out BigInteger dec_n);
        Console.WriteLine();

        string decryptedMessage = "";
        for (int i = 0; i < encrypted.Length; i++)
        {
            BigInteger decryptedNum = BigInteger.ModPow((err ? encrypted[i] + 1 : encrypted[i]), dec_key, dec_n);

            try
            {
                char decryptedChar = alph[(int)decryptedNum];
                decryptedMessage += decryptedChar;
                Console.WriteLine($"Символ {i + 1}: M = {(err ? encrypted[i] + 1 : encrypted[i])}^{enc_key.ToString().Substring(0, Math.Min(30, e.ToString().Length))}... mod n = {decryptedNum} -> '{decryptedChar}'\n");
            }
            catch
            {
                Console.WriteLine("\nВозникла ошибка при расшифровки, скорее всего ключи не те.\n");
            }
        }
        decryptedMessage = decryptedMessage.ToLower();

        Console.WriteLine("\n\t\t\t Сравнение исходного и расшифрованного сообщений\n");
        Console.WriteLine($"Исходное сообщение:       {message}");
        Console.WriteLine($"Расшифрованное сообщение: {decryptedMessage}");

        if (message == decryptedMessage)
        {
            Console.WriteLine("\nСообщения совпадают. Расшифрование выполнено корректно.");
        }
        else if (enc_key == dec_key)
        {
            Console.WriteLine("\nСообщения не совпадают. Было введено два <e> или <d>.");
        }
        else if (err)
        {
            Console.WriteLine("\nСообщения не совпадают. При передаче сообщения была допущена ошибка.");
        }
        else if ((enc_key != e && enc_key != d) || (dec_key == e || dec_key == d))
        {
            Console.WriteLine("\nСообщения не совпадают. При шифровании использовался не тот ключ.");
        }
        else if ((dec_key != e && dec_key != d) || (enc_key == e || enc_key == d))
        {
            Console.WriteLine("\nСообщения не совпадают. При расшифровании использовался не тот ключ.");
        }
        else if ((enc_key != e && enc_key != d) && (dec_key != e && dec_key != d))
        {
            Console.WriteLine("\nСообщения не совпадают. При шифровании и расшифровании использовались не те ключи.");
        }
        else
        {
            Console.WriteLine("\nСообщения не совпадают. Не предвиденная ошибка.");
        }

        Console.WriteLine("\nНажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}