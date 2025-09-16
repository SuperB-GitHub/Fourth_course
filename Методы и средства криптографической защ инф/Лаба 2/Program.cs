using System;
using System.Text;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine($"Выберите задание:\n 1 - Шифр Цезаря со сдвигом\n 2 - Афинный шифр Цезаря\n 3 - Шифр Цезаря со словом\n 4 - Шифр Трисемуса\n");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                Console.Clear();

                //МЫ ДОЛЖНЫ ПРИЗНАТЬ ОЧЕВИДНОЕ: ПОНИМАЮТ ЛИШЬ ТЕ, КТО ХОЧЕТ ПОНЯТЬ
                //УВ КХТНФВ ЦЧПОФЖЩГ ХЮЛИПКФХЛ: ЦХФПУЖЕЩ ТПЯГ ЩЛ, СЩХ ЬХЮЛЩ ЦХФЁЩГ
                //int shift = 7;

                Console.WriteLine($"Выберите действие:\n 1 - Шифрование\n 2 - Дешифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();

                    InputOne(out string text, out int shift);

                    PrintCaesarOneTable(shift);
                    string encrypted = CaesarEnDecrypt(text, shift);
                    Console.WriteLine($"\nЗашифрованный текст: {encrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();

                    InputOne(out string text, out int shift);

                    PrintCaesarOneTable(-shift);
                    string decrypted = CaesarEnDecrypt(text, -shift);
                    Console.WriteLine($"\nРасшифрованный текст: {decrypted}\n");
                }
                else
                {
                    break;
                }
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();

                //СМЫСЛ ЖИЗНИ НАШЕЙ – НЕПРЕРЫВНОЕ ДВИЖЕНИЕ
                //ЖЭЪЖЫ СХУЯХ ЯДФНЧ - ЯНГЕНЕЪЗЯБН ЛЗХСНЯХН
                //a = 2; b = 4;

                Console.WriteLine($"Выберите действие:\n 1 - Шифрование\n 2 - Дешифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();

                    InputTwo(out string text, out int a, out int b);

                    PrintCaesarTwoTable(a, b);
                    string encrypted = AffineCaesarEncrypt(text, a, b);
                    Console.WriteLine($"\nЗашифрованный текст: {encrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();

                    InputTwo(out string text, out int a, out int b);

                    PrintCaesarTwoTable(a, b);
                    string decrypted = AffineCaesarDecrypt(text, a, b);
                    Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                }
                else
                {
                    break;
                }

            }
            else if (key.Key == ConsoleKey.D3)
            {
                Console.Clear();

                //РАЗУМА ЛИШАЕТ НЕ СОМНЕНИЕ, А УВЕРЕННОСТЬ
                //ЁШСИБШ АЕПШЮЗ ВЮ ЖГБВЮВЕЮ, Ш ИЪЮЁЮВВГЖЗФ
                //k = 7, ключевое слово ОСЕНЬ

                Console.WriteLine($"Выберите действие:\n 1 - Шифрование\n 2 - Дешифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();

                    InputThree(out string text, out int k, out string keyword);

                    PrintCaesarThreeTable(k, keyword);
                    string encrypted = CaesarWithWordEnDecrypt(text, k, keyword, true);
                    Console.WriteLine($"\nЗашифрованный текст: {encrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();

                    InputThree(out string text, out int k, out string keyword);

                    PrintCaesarThreeTable(k, keyword);
                    string decrypted = CaesarWithWordEnDecrypt(text, k, keyword, false);
                    Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                }
                else
                {
                    break;
                }

            }
            else if (key.Key == ConsoleKey.D4)
            {
                Console.Clear();

                //УСПЕХ – ЭТО КОГДА ТЫ ДЕВЯТЬ РАЗ УПАЛ, НО ДЕСЯТЬ РАЗ ПОДНЯЛСЯ
                //ЫДШЖЮ - АЪГ ХГМПЙ ЪЬ ПЖЛВЪИ ЩЙТ ЫШЙЦ, ЗГ ПЖДВЪИ ЩЙТ ШГПЗВЦДВ
                //ключевое слово ОСЕНЬ

                Console.WriteLine($"Выберите действие:\n 1 - Шифрование\n 2 - Дешифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();

                    InputFour(out string text, out string keyword);

                    PrintCaesarFourTable(keyword);
                    string encrypted = TrisemusEnDecrypt(text, keyword, true);
                    Console.WriteLine($"\nЗашифрованный текст: {encrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();

                    InputFour(out string text, out string keyword);

                    PrintCaesarFourTable(keyword);
                    string decrypted = TrisemusEnDecrypt(text, keyword, false);
                    Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                }
                else
                {
                    break;
                }

            }
            else
            {
                break;
            }
        }
    }
    //Ввод данных
    static void InputOne(out string text, out int shift)
    {
        Console.WriteLine($"Введите текст:");
        text = Console.ReadLine()!;
        while (string.IsNullOrEmpty(text))
        {
            Console.Clear();
            Console.WriteLine("Ошибка: текст не может быть пустым.");
            Console.WriteLine($"Введите текст:");
            text = Console.ReadLine()!;
        }

        Console.WriteLine($"Введите число сдвигов: ");
        while (!int.TryParse(Console.ReadLine(), out shift))
        {
            Console.Write("Некорректный ввод. Введите целое число: ");
        }
    }
    static void InputTwo(out string text, out int a, out int b)
    {
        Console.WriteLine($"Введите текст:");
        text = Console.ReadLine()!;
        while (string.IsNullOrEmpty(text))
        {
            Console.Clear();
            Console.WriteLine("Ошибка: текст не может быть пустым.");
            Console.WriteLine($"Введите текст:");
            text = Console.ReadLine()!;
        }

        Console.WriteLine($"Введите число a: ");
        while (!int.TryParse(Console.ReadLine(), out a) || NOD(a, 33) != 1)
        {
            Console.Write("Некорректный ввод. Введите целое и взаимно простое к 33 число: ");
        }

        Console.WriteLine($"Введите число b: ");
        while (!int.TryParse(Console.ReadLine(), out b))
        {
            Console.Write("Некорректный ввод. Введите целое число: ");
        }
    }
    static void InputThree(out string text, out int k, out string keyword)
    {
        Console.WriteLine($"Введите текст:");
        text = Console.ReadLine()!;
        while (string.IsNullOrEmpty(text))
        {
            Console.Clear();
            Console.WriteLine("Ошибка: текст не может быть пустым.");
            Console.WriteLine($"Введите текст:");
            text = Console.ReadLine()!;
        }

        Console.WriteLine($"Введите число сдвигов k: ");
        while (!int.TryParse(Console.ReadLine(), out k) || k < 0 || k > 33)
        {
            Console.Write("Некорректный ввод. Введите целое положительное и до 33 число: ");
        }

        Console.WriteLine($"Введите ключевое слово:");
        keyword = Console.ReadLine()!;
        while (string.IsNullOrEmpty(keyword))
        {
            Console.WriteLine("Ошибка: ключ не может быть пустым.");
            Console.WriteLine($"Введите ключ:");
            keyword = Console.ReadLine()!;
        }

    }
    static void InputFour(out string text, out string keyword)
    {
        Console.WriteLine($"Введите текст:");
        text = Console.ReadLine()!;
        while (string.IsNullOrEmpty(text))
        {
            Console.Clear();
            Console.WriteLine("Ошибка: текст не может быть пустым.");
            Console.WriteLine($"Введите текст:");
            text = Console.ReadLine()!;
        }

        Console.WriteLine($"Введите ключевое слово:");
        keyword = Console.ReadLine()!;
        while (string.IsNullOrEmpty(keyword))
        {
            Console.WriteLine("Ошибка: ключ не может быть пустым.");
            Console.WriteLine($"Введите ключ:");
            keyword = Console.ReadLine()!;
        }

    }

    //Шифрование/Расшифрование
    static string CaesarEnDecrypt(string text, int shift)
    {
        string Alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        StringBuilder result = new StringBuilder();

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                int index = Alphabet.IndexOf(c);

                if (index != -1)
                {
                    int newIndex = (index + shift + Alphabet.Length) % Alphabet.Length;
                    char encrypted = Alphabet[newIndex];

                    result.Append(encrypted);
                }
                else
                {
                    result.Append(c);
                }
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }
    static string AffineCaesarEncrypt(string text, int a, int b)
    {
        string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        int n = alphabet.Length;

        string result = "";

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char upperChar = char.ToUpper(c);
                int index = alphabet.IndexOf(upperChar);

                if (index != -1)
                {
                    int encryptedIndex = (a * index + b) % n;
                    if (encryptedIndex < 0) encryptedIndex += n;

                    char encryptedChar = alphabet[encryptedIndex];

                    result += encryptedChar;
                }
                else
                {
                    result += c;
                }
            }
            else
            {
                result += c;
            }
        }

        return result;
    }
    static string AffineCaesarDecrypt(string text, int a, int b)
    {
        string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        int n = alphabet.Length;

        int aInverse = ModInverse(a, n);

        string result = "";

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char upperChar = char.ToUpper(c);
                int index = alphabet.IndexOf(upperChar);

                if (index != -1)
                {
                    int decryptedIndex = (aInverse * (index - b)) % n;
                    if (decryptedIndex < 0) decryptedIndex += n;

                    char decryptedChar = alphabet[decryptedIndex];
                    result += decryptedChar;
                }
                else
                {
                    result += c;
                }
            }
            else
            {
                result += c;
            }
        }

        return result;
    }
    static string CaesarWithWordEnDecrypt(string text, int k, string keyword, bool isEncrypt)
    {
        string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        int n = alphabet.Length;
        string newAlph = BuildAlphabetWithShiftAndKeyword(k, keyword);

        string result = "";

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char upperChar = char.ToUpper(c);
                result += isEncrypt ? newAlph[alphabet.IndexOf(c)] : alphabet[newAlph.IndexOf(c)];

            }
            else
            {
                result += c;
            }
        }
        return result;
    }
    static string TrisemusEnDecrypt(string text, string keyword, bool isEncrypt)
    {
        string newAlph = BuildAlphabetWithShiftAndKeyword(0, keyword);
        newAlph = newAlph.Remove(newAlph.IndexOf('Ё'), 1);

        string result = "";
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char upperChar = char.ToUpper(c);
                result += isEncrypt ? newAlph[(newAlph.IndexOf(c)+8)%32] : newAlph[(newAlph.IndexOf(c)+24)%32];

            }
            else
            {
                result += c;
            }
        }
        return result;
    }

    //Таблицы для вывода
    static void CreateHorizontal(int cols, int cellWidth)
    {
        Console.Write("+");
        for (int i = 0; i < cols; i++)
        {
            Console.Write(new string('-', cellWidth));
            Console.Write("+");
        }
        Console.WriteLine();
    }
    static void PrintCaesarOneTable(int shift)
    {
        string Alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        Console.WriteLine("Таблица замены (шифр Цезаря):");
        CreateHorizontal(Alphabet.Length, 1);

        Console.Write("|");
        foreach (char c in Alphabet)
        {
            Console.Write($"{c}|");
        }
        Console.WriteLine();

        CreateHorizontal(Alphabet.Length, 1);

        Console.Write("|");
        for (int i = 0; i < Alphabet.Length; i++)
        {
            int newIndex = (i + shift + Alphabet.Length) % Alphabet.Length;
            Console.Write($"{Alphabet[newIndex]}|");
        }
        Console.WriteLine();

        CreateHorizontal(Alphabet.Length, 1);
    }
    static void PrintCaesarTwoTable(int a, int b)
    {
        string Alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        Console.WriteLine("Таблица замены (Афинный шифр Цезаря):");
        CreateHorizontal(Alphabet.Length, 2);

        Console.Write("|");
        for (int _ = 0; _ < Alphabet.Length; _++)
        {
            if(_ < 10)
            {
                Console.Write($"{_} |");
            }
            else
            {
                Console.Write($"{_}|");
            }
                
        }
        Console.WriteLine();
        CreateHorizontal(Alphabet.Length, 2);

        Console.Write("|");
        foreach (char c in Alphabet)
        {
            Console.Write($"{c} |");
        }
        Console.WriteLine();

        CreateHorizontal(Alphabet.Length, 2);

        List<int> newInds = [];
        Console.Write("|");
        for (int i = 0; i < Alphabet.Length; i++)
        {
            int newIndex = (a * i + b) % Alphabet.Length;
            newInds.Add(newIndex);
            Console.Write($"{Alphabet[newIndex]} |");
        }
        Console.WriteLine();

        CreateHorizontal(Alphabet.Length, 2);

        Console.Write("|");
        foreach (int i in newInds)
        {
            if (i < 10)
            {
                Console.Write($"{i} |");
            }
            else
            {
                Console.Write($"{i}|");
            }
        }
        Console.WriteLine();
        CreateHorizontal(Alphabet.Length, 2);
    }
    static void PrintCaesarThreeTable(int k, string keyword)
    {
        string Alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        string newAlph = BuildAlphabetWithShiftAndKeyword(k, keyword);

        Console.WriteLine("Таблица замены (Шифр Цезаря с кодовым словом):");

        CreateHorizontal(Alphabet.Length, 1);
        Console.Write("|");
        foreach (char c in Alphabet)
        {
            Console.Write($"{c}|");
        }
        Console.WriteLine();

        CreateHorizontal(Alphabet.Length, 1);
        Console.Write("|");
        foreach (char c in newAlph)
        {
            Console.Write($"{c}|");
        }
        Console.WriteLine();

        CreateHorizontal(Alphabet.Length, 1);
    }
    static void PrintCaesarFourTable(string keyword)
    {
        string newAlph = BuildAlphabetWithShiftAndKeyword(0, keyword);
        newAlph = newAlph.Remove(newAlph.IndexOf('Ё'),1);

        Console.WriteLine("Таблица замены (Шифр Трисемуса):");

        CreateHorizontal(8, 1);

        for (int i = 0; i < 4; i++)
        {
            Console.Write("|");
            for (int j = 1; j <= 8; j++)
            {
                Console.Write($"{newAlph[i*8+j-1]}|");
            }
            Console.WriteLine();
            CreateHorizontal(8, 1);
        }
    }

    //Вспомогательные функции
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
    static int ModInverse(int a, int m)
    {
        a = ((a % m) + m) % m;
        for (int x = 1; x < m; x++)
        {
            if ((a * x) % m == 1)
                return x;
        }
        return -1;
    }
    static string BuildAlphabetWithShiftAndKeyword(int shift, string keyword)
    {
        string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        int n = alphabet.Length;

        HashSet<char> keyChars = new HashSet<char>();
        string uniqueKeyword = "";

        foreach (char c in keyword.ToUpper())
        {
            if (alphabet.Contains(c) && keyChars.Add(c))
            {
                uniqueKeyword += c;
            }
        }

        string remaining = "";
        foreach (char c in alphabet)
        {
            if (!keyChars.Contains(c))
            {
                remaining += c;
            }
        }

        string shiftedStart = remaining.Substring(remaining.Length - shift);
        string shiftedEnd = remaining.Substring(0, remaining.Length - shift);

        string result = shiftedStart + uniqueKeyword + shiftedEnd;

        return result;
    }
}

