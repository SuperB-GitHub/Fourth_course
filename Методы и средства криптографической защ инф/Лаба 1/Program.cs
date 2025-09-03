using System.Text;

class Program
{
    static void Main()
    {

        while (true)
        {
            Console.WriteLine($"Выберите задание:\n 1 - Шифрующие таблицы\n 2 - Магический квадрат");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                Console.Clear();
                string text = "ИЛЛЮЗИИ, ЧЕМ БОЛЬШЕ О НИХ ДУМАЕШЬ, ИМЕЮТ СВОЙСТВО МНОЖИТЬСЯ, ПРИОБРЕТАТЬ БОЛЕЕ ВЫРАЖЕННУЮ ФОРМУ.";
                string keyword = "МЫСЛЕННО";
                int rows = 12;
                int cols = 8;
                Console.WriteLine($"Выберите действие:\n 1 - Шифрование\n 2 - Дешифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    string encrypted = EncryptOne(text, keyword, rows, cols);
                    Console.WriteLine($"Зашифрованный текст: {encrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    string encrypted = EncryptOne(text, keyword, rows, cols);
                    string decrypted = DecryptOne(encrypted, keyword, rows, cols);
                    Console.WriteLine($"Зашифрованный текст: {encrypted}\n");
                    Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                }
                else
                {
                    break;
                }
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                string text = "АЕРУТНСВЧ";
                int[,] square = {
                    {2, 7, 6},
                    {9, 5, 1},
                    {4, 3, 8}
                };
                Console.WriteLine($"Выберите действие:\n 1 - Дешифрование\n 2 - Шифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    string decrypted = DecryptTwo(text, square);
                    Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    string decrypted = DecryptTwo(text, square);
                    string encrypted = EncryptTwo(decrypted, square);
                    Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                    Console.WriteLine($"Зашифрованный текст: {encrypted}\n");
                    //crypt
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

    static string EncryptOne(string text, string keyword, int rows, int cols)
    {
        string cleanText = new string(text.ToUpper().Select(c => c != ' ' ? c : '_').ToArray());

        char[,] table = new char[cols, rows];

        int index = 0;
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                if (index < cleanText.Length)
                {
                    table[i, j] = cleanText[index++];
                }
                else
                {
                    table[j, i] = '_';
                }
            }
        }

        var indexed = keyword.Select((c, i) => new { Char = c, Index = i }).ToList();
        var sorted = indexed.OrderBy(x => x.Char).ThenBy(x => x.Index).ToList();

        int[] keyValues = indexed.Select(x => sorted.FindIndex(s => s.Char == x.Char && s.Index == x.Index) + 1).ToArray();

        List<char> result = new List<char>();

        for (int row = 0; row < rows; row++)
        {
            int realCol = 1;

            while (realCol <= cols)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (keyValues[col] == realCol)
                    {
                        result.Add(table[col, row]);
                        realCol++;
                    }
                }
            }
        }

        string encryptedStr = new string(result.ToArray());

        return encryptedStr;
    }

    static string DecryptOne(string encryptedText, string keyword, int rows, int cols)
    {
        char[,] table = new char[cols, rows];

        var indexed = keyword.Select((c, i) => new { Char = c, Index = i }).ToList();
        var sorted = indexed.OrderBy(x => x.Char).ThenBy(x => x.Index).ToList();
        int[] keyValues = indexed.Select(x => sorted.FindIndex(s => s.Char == x.Char && s.Index == x.Index) + 1).ToArray();

        int index = 0;
        for (int row = 0; row < rows; row++)
        {
            int realCol = 1;
            while (realCol <= cols)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (keyValues[col] == realCol)
                    {
                        table[col, row] = encryptedText[index++];
                        realCol++;
                    }
                }
            }
        }

        StringBuilder result = new StringBuilder();
        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                result.Append(table[col, row]);
            }
        }

        return result.ToString().Replace('_', ' ');
    }

    static string DecryptTwo(string encryptedText, int[,] square)
    {
        var positions = new (int row, int col)[9];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                int value = square[i, j];
                positions[value - 1] = (i, j);
            }

        char[,] grid = new char[3, 3];
        int index = 0;
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                grid[i, j] = encryptedText[index++];
            }

        string result = "";
        for (int num = 1; num <= 9; num++)
        {
            var pos = positions[num - 1];
            result += grid[pos.row, pos.col];
        }

        return result;
    }

    static string EncryptTwo(string text, int[,] square)
    {
        var positions = new (int row, int col)[9];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int value = square[i, j];
                positions[value - 1] = (i, j);
            }
        }

        char[,] grid = new char[3, 3];

        for (int num = 1; num <= 9; num++)
        {
            var pos = positions[num - 1]; 
            grid[pos.row, pos.col] = text[num - 1];
        }

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result.Append(grid[i, j]);
            }
        }

        return result.ToString();
    }
}
