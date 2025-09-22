using System;
using System.Text;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Шифр Плейфера");
            Console.WriteLine($"Выберите действие:\n 1 - Шифрование\n 2 - Расшифрование");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                Console.Clear();

                Input(out string text, out string keyword);
                PrintTable(keyword);

                Console.WriteLine($"\nЗашифрованный текст:\n{EncryptPlayfair(text, keyword, true)}");
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();

                Input(out string text, out string keyword);
                PrintTable(keyword);

                Console.WriteLine($"\nРасшифрованный текст:\n{EncryptPlayfair(text, keyword, false)}");
            }
            else
            {
                break;
            }
            Console.WriteLine("");
        }


    }
    static void Input(out string text, out string keyword)
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
    static void PrintTable(string keyword)
    {
        string newAlph = BuildNewAlphWithKeyword(keyword);

        Console.WriteLine("Таблица замены (Шифр Трисемуса):");

        CreateHorizontal(8, 1);

        for (int i = 0; i < 4; i++)
        {
            Console.Write("|");
            for (int j = 1; j <= 8; j++)
            {
                Console.Write($"{newAlph[i * 8 + j - 1]}|");
            }
            Console.WriteLine();
            CreateHorizontal(8, 1);
        }
    }
    static string BuildNewAlphWithKeyword(string keyword)
    {
        string alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
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

        string result = uniqueKeyword + remaining;

        return result;
    }
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
    static List<string> ToBigrams(string text)
    {
        string alph = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        List<string> bigramms = new List<string>();
        string bigramm = "";

        foreach (char c in text.ToUpper())
        {
            if (alph.Contains(c))
            {
                if (bigramm.Contains(c))
                {
                    bigramm += "Ъ";
                    bigramms.Add(bigramm);

                    bigramm = "";
                    bigramm += c;
                }
                else
                {
                    bigramm += c;
                }
            }
            else if (c != ' ')
            {
                if (bigramm.Length == 1)
                {
                    bigramm += "Ъ";
                    bigramms.Add(bigramm);

                    bigramm = "";
                }

                bigramms.Add(c.ToString());
            }

            if (bigramm.Length == 2)
            {
                bigramms.Add(bigramm);
                bigramm = "";
            }
        }

        if (bigramm.Length == 1)
        {
            bigramm += "Ъ";
            bigramms.Add(bigramm);
            bigramm = "";
        }

        return bigramms;
    }
    static string EncryptPlayfair(string text, string keyword, bool isEncrypt)
    {
        string newAlph = BuildNewAlphWithKeyword(keyword);
        char[,] array = new char[4, 8];

        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 8; j++)
                array[i, j] = newAlph[i * 8 + j];


        List<string> bigrams = ToBigrams(text);
        Console.WriteLine($"\nБиграммы исходного текста:\n{string.Join(" ", bigrams)}");
        string bigramsCrypted = $"\nБиграммы после шифра:\n";
        string result = "";

        foreach (string bigram in bigrams)
        {
            if (bigram.Length == 2)
            {
                string newBigram = isEncrypt ? RulesForPlayfair(bigram, array, true): RulesForPlayfair(bigram, array, false);
                bigramsCrypted += newBigram + " ";
                result += newBigram;
            }
            else
            {
                bigramsCrypted += bigram + " ";
                result += bigram + " ";
            }
        }
        Console.WriteLine(bigramsCrypted);
        return result;
    }
    static string RulesForPlayfair(string bigram, char[,] array, bool isEncrypt)
    {
        char a = bigram[0];
        char b = bigram[1];

        var (rowA, colA) = FindPosition(a, array);
        var (rowB, colB) = FindPosition(b, array);

        if (rowA == rowB)
        {
            int shift = isEncrypt ? 1 : -1;
            colA = Mod(colA + shift, 8);
            colB = Mod(colB + shift, 8);
        }
        else if (colA == colB)
        {
            int shift = isEncrypt ? 1 : -1;
            rowA = Mod(rowA + shift, 4);
            rowB = Mod(rowB + shift, 4);
        }
        else
        {
            (colA, colB) = (colB, colA);
        }

        char encryptedA = array[rowA, colA];
        char encryptedB = array[rowB, colB];

        return $"{encryptedA}{encryptedB}";
    }
    static (int row, int col) FindPosition(char c, char[,] table)
    {
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 8; j++)
                if (table[i, j] == c)
                    return (i, j);
        throw new ArgumentException($"Символ {c} не найден в таблице");
    }
    static int Mod(int a, int m)
    {
        return (a % m + m) % m;
    }
}