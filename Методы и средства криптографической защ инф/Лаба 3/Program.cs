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

                ToBigrams(text);

            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();

                Input(out string text, out string keyword);
                PrintTable(keyword);

                ToBigrams(text);
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
        string newAlph = BuildAlphabetWithShiftAndKeyword(0, keyword);
        newAlph = newAlph.Remove(newAlph.IndexOf('Ё'), 1);

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
        string alph = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        List<string> bigramms = new List<string>();
        string bigramm = "";

        foreach (char c in text.ToUpper())
        {
            if (alph.Contains(c) && bigramm.Length <= 1 && !bigramm.Contains(c)) 
            {
                bigramm += c;
            }
            else if (alph.Contains(c) && bigramm.Length <= 1 && ())
            {
                
            }
            else
            {
            }

            if (bigramm.Length == 2)
            {
                
            }
        }

        foreach (char c in text.ToUpper())
            if (c >= 'А' && c <= 'Я')
                sb.Append(c);

        string clean = sb.ToString();
        
        int i = 0;

        while (i < clean.Length)
        {
            if (i + 1 >= clean.Length)
            {
                // Одна буква осталась — добавляем Ъ
                bigrams.Add(clean[i] + "Ъ");
                i++;
            }
            else if (clean[i] == clean[i + 1])
            {
                // Две одинаковые — вставляем Ъ между
                bigrams.Add(clean[i] + "Ъ");
                i++; // Переходим ко второй (она станет началом следующей пары)
            }
            else
            {
                // Нормальная пара
                bigrams.Add(clean[i] + "" + clean[i + 1]);
                i += 2;
            }
        }

        return bigrams;
    }
}