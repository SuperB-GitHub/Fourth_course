using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {

        while (true)
        {
            Console.WriteLine($"Выберите задание:\n 1 - Система Вижинера\n 2 - Двойной квадрат Уитстона");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Console.WriteLine($"Выберите действие:\n 1 - Шифрование\n 2 - Расшифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    InputOne(out string text, out string keyword);

                    string encrypted = Vigenere(text.ToUpper(), keyword.ToUpper(), true);
                    Console.WriteLine($"\nЗашифрованный текст: {encrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    InputOne(out string text, out string keyword);

                    string decrypted = Vigenere(text.ToUpper(), keyword.ToUpper(), false);
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

                Console.WriteLine($"Выберите действие:\n 1 - Шифрование\n 2 - Расшифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();

                    Console.WriteLine($"Выберите действие:\n 1 - Создание вручную\n 2 - Создание рандомно");
                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.D1)
                    {
                        Console.Clear();

                        InputSquare(out string strSquare1);
                        PrintTable(strSquare1);
                        InputSquare(out string strSquare2);
                        PrintTable(strSquare2);
                        CreateSquare(out char[,] square1, strSquare1);
                        CreateSquare(out char[,] square2, strSquare2);

                        InputTwo(out string text);
                        List<string> bigrams = ToBigrams(text.ToUpper().Replace("Й", "И"));
                        Console.WriteLine($"\nБиграммы исходного текста:\n{string.Join("||", bigrams)}\n");

                        string encrypt = Uitston(bigrams, square1, square2, true);
                        Console.WriteLine($"\nЗашифрованный текст: {encrypt}\n");

                    }
                    else if (key.Key == ConsoleKey.D2)
                    {
                        Console.Clear();

                        string firstSquare = GenerateSquare(out char[,] square1);
                        Console.WriteLine($"Первая таблица в строчку: {firstSquare}");
                        PrintTable(firstSquare);

                        string secondSquare = GenerateSquare(out char[,] square2);
                        Console.WriteLine($"\nВторая таблица в строчку: {secondSquare}");
                        PrintTable(secondSquare);

                        InputTwo(out string text);
                        List<string> bigrams = ToBigrams(text.ToUpper().Replace("Й", "И"));
                        Console.WriteLine($"\nБиграммы исходного текста:\n{string.Join("||", bigrams)}\n");

                        string encrypt = Uitston(bigrams, square1, square2, true);
                        Console.WriteLine($"\nЗашифрованный текст: {encrypt}\n");

                    }
                    else
                    {
                        break;
                    }
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();

                    Console.Clear();

                    InputSquare(out string strSquare1);
                    PrintTable(strSquare1);
                    InputSquare(out string strSquare2);
                    PrintTable(strSquare2);
                    CreateSquare(out char[,] square1, strSquare1);
                    CreateSquare(out char[,] square2, strSquare2);

                    InputTwo(out string text);
                    List<string> bigrams = ToBigrams(text.ToUpper().Replace("Й", "И"));
                    Console.WriteLine($"\nБиграммы шифртекста:\n{string.Join("||", bigrams)}\n");

                    string decrypt = Uitston(bigrams, square1, square2, false);
                    Console.WriteLine($"\nРасшифрованный текст: {decrypt}\n");
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
    // Ввод данных
    static void InputOne(out string text, out string keyword)
    {
        Console.Clear();

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
    static void InputSquare(out string text)
    {
        Console.WriteLine($"Введите весь квадрат в строку построчно:");
        text = Console.ReadLine()!;
        while (string.IsNullOrEmpty(text) || text.Length != 35)
        {
            if (text.Length != 35)
            {
                Console.WriteLine("Ошибка: количество символов меньше 35.");
            }
            else 
            {
                Console.WriteLine("Ошибка: текст не может быть пустым.");
            }
            Console.WriteLine($"Введите заново:");
            text = Console.ReadLine()!;
        }
        Console.WriteLine();
    }
    static void InputTwo(out string text)
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
    }

    //Вывод данных
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
    static void PrintTable(string alph)
    {
        CreateHorizontal(5, 1);

        for (int i = 0; i < 7; i++)
        {
            Console.Write("|");
            for (int j = 1; j <= 5; j++)
            {
                Console.Write($"{alph[i * 5 + j - 1]}|");
            }
            Console.WriteLine();
            CreateHorizontal(5, 1);
        }
    }

    // Алгоритмы
    static string Vigenere(string text, string keyword, bool isEncrypt)
    {
        string alph = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        int n = alph.Length;

        string result = "";
        int indexKey = 0;

        for (int i = 0; i < text.Length; i++)
        {
            char charText = text[i];

            if (char.IsLetter(charText))
            {
                char charKey = keyword[Mod(indexKey, keyword.Length)];
                char answer = isEncrypt ? alph[Mod(alph.IndexOf(charText) + alph.IndexOf(charKey), n)] : alph[Mod(alph.IndexOf(charText) - alph.IndexOf(charKey), n)];
                Console.WriteLine($"i = {i}, ОТ: {charText} = {alph.IndexOf(charText)}, {charKey} = {alph.IndexOf(charKey)}, ШТ: {answer}");
                result += answer;
                indexKey++;
            }
            else
            {
                Console.WriteLine($"i = {i}, {charText}");
                result += charText;
            }
        }

        return result;
    }
    static string Uitston(List<string> bigrams, char[,] square1, char[,] square2, bool isEncrypt)
    {
        string alph = "АБВГДЕЖЗИКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ ,:.";
        string bigResult = $"Зашифрованные биграммы:\n";
        string result = "";

        foreach (string bigram in bigrams)
        {
            char char1 = bigram[0];
            char char2 = bigram[1];
            string answer = "";

            if (!alph.Contains(char1) || !alph.Contains(char2))
            {
                answer = char1.ToString() + char2.ToString();
                bigResult += answer + " ";
                result += answer;
            }


            if (isEncrypt)
            {
                var (row1, col1) = FindPosition(square1, char1);
                var (row2, col2) = FindPosition(square2, char2);

                if (row1 == row2)
                {
                    char encrypt1 = square2[row2, col1];
                    char encrypt2 = square1[row1, col2];
                    answer = encrypt1.ToString() + encrypt2.ToString();
                }
                else
                {
                    char encrypt1 = square2[row1, col2];
                    char encrypt2 = square1[row2, col1];
                    answer = encrypt1.ToString() + encrypt2.ToString();
                }
            }
            else
            {
                var (row1, col1) = FindPosition(square2, char1);
                var (row2, col2) = FindPosition(square1, char2);

                if (row1 == row2)
                {
                    char encrypt1 = square1[row2, col1];
                    char encrypt2 = square2[row1, col2];
                    answer = encrypt1.ToString() + encrypt2.ToString();
                }
                else
                {
                    char encrypt1 = square1[row1, col2];
                    char encrypt2 = square2[row2, col1];
                    answer = encrypt1.ToString() + encrypt2.ToString();
                }
            }


            bigResult += answer + "||";
            result += answer;
        }
        Console.WriteLine(bigResult);

        return result;
    }

    // Вспомогательные функции
    static int Mod(int a, int m)
    {
        return (a % m + m) % m;
    }
    static string GenerateSquare(out char[,] square)
    {
        string alph = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ ,:";
        Random random = new Random();

        char[] shufAlph = alph.ToCharArray().OrderBy(x => random.Next()).ToArray();
        int index = 0;
        square = new char[7, 5];

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                square[i, j] = shufAlph[index++];
            }
        }

        string result = "";
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                result += square[i, j];
            }
        }

        return result;
    }
    static void CreateSquare(out char[,] square, string strSquare)
    {
        int index = 0;
        square = new char[7, 5];

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                square[i, j] = strSquare[index++];
            }
        }
    }
    static List<string> ToBigrams(string text)
    {
        string alph = "АБВГДЕЖЗИКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ ,:.";
        List<string> bigramms = new List<string>();
        string bigramm = "";

        foreach (char c in text.ToUpper())
        {
            if (alph.Contains(c))
            {
                bigramm += c;
            }

            if (bigramm.Length == 2)
            {
                bigramms.Add(bigramm);
                bigramm = "";
            }
        }

        if (bigramm.Length == 1)
        {
            bigramm += ".";
            bigramms.Add(bigramm);
            bigramm = "";
        }

        return bigramms;
    }
    static (int row, int col) FindPosition(char[,] square, char character)
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (square[i, j] == character)
                {
                    return (i, j);
                }
            }
        }
        return (-1, -1); // Символ не найден
    }

}
