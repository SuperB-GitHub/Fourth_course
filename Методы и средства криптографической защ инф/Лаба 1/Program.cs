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
                //string text = "ИЛЛЮЗИИ, ЧЕМ БОЛЬШЕ О НИХ ДУМАЕШЬ, ИМЕЮТ СВОЙСТВО МНОЖИТЬСЯ, ПРИОБРЕТАТЬ БОЛЕЕ ВЫРАЖЕННУЮ ФОРМУ.";
                //string text = "ОМИ__ЕХ__ЕЛПБН_БМЮЛРОНДОНТЮИЛУУЛО_ЗОЕЮМЬЖСИБЕ_АШИВИР_ФЕЕТО,ЕВОШ_ЬЙ_ТЫРЬОССЧАРМ,_ЯТЕТАУ_Н,ВМЬЖ.ИИ";
                //string keyword = "МЫСЛЕННО";
                int rows = 12;
                int cols = 8;
                Console.WriteLine($"Выберите действие:\n 1 - Шифрование\n 2 - Расшифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine($"Введите текст:");
                    string? text = Console.ReadLine();
                    Console.WriteLine($"Введите ключ:");
                    string? keyword = Console.ReadLine();

                    string encrypted = EncryptOne(text, keyword, rows, cols);
                    Console.WriteLine($"Зашифрованный текст: {encrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine($"Введите текст:");
                    string? text = Console.ReadLine();
                    Console.WriteLine($"Введите ключ:");
                    string? keyword = Console.ReadLine();

                    string decrypted = DecryptOne(text, keyword, rows, cols);
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
                //string text = "АЕРУТНСВЧ";
                //int[,] square = {
                //    {2, 7, 6},
                //    {9, 5, 1},
                //    {4, 3, 8}
                //};
                
                Console.WriteLine($"Выберите действие:\n 1 - Расшифрование\n 2 - Шифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    int[,] square = CreateMagicSquare();

                    Console.WriteLine($"Введите текст:");
                    string? text = Console.ReadLine();

                    string decrypted = DecryptTwo(text, square);
                    Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();

                    int[,] square = CreateMagicSquare();

                    Console.WriteLine($"Введите текст:");
                    string? text = Console.ReadLine();

                    string encrypted = EncryptTwo(text, square);
                    Console.WriteLine($"Зашифрованный текст: {encrypted}\n");
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

    static string EncryptOne(string? text, string? keyword, int rows, int cols)
    {
        var indexed = keyword.Select((c, i) => new { Char = c, Index = i }).ToList();
        var sorted = indexed.OrderBy(x => x.Char).ThenBy(x => x.Index).ToList();
        int[] keyValues = indexed.Select(x => sorted.FindIndex(s => s.Char == x.Char && s.Index == x.Index) + 1).ToArray();

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

        PrintTable(text, table, keyword, keyValues, result, true);
        return new string([.. result]);
    }

    static string DecryptOne(string? text, string? keyword, int rows, int cols)
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
                        table[col, row] = text[index++];
                        realCol++;
                    }
                }
            }
        }

        List<char> result = new List<char>();
        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                result.Add(table[col, row]);
            }
        }
        PrintTable(text, table, keyword, keyValues, result, false);
        return new string([.. result]).Replace('_',' ');
    }

    static string DecryptTwo(string? encryptedText, int[,] square)
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

    static string EncryptTwo(string? text, int[,] square)
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

    static bool IsMagicSquare(int[,] matrix)
    {
        int magicSum = matrix[0, 0] + matrix[0, 1] + matrix[0, 2];

        for (int i = 1; i < 3; i++)
        {
            int rowSum = matrix[i, 0] + matrix[i, 1] + matrix[i, 2];
            if (rowSum != magicSum)
                return false;
        }

        for (int j = 0; j < 3; j++)
        {
            int colSum = matrix[0, j] + matrix[1, j] + matrix[2, j];
            if (colSum != magicSum)
                return false;
        }

        int diag1 = matrix[0, 0] + matrix[1, 1] + matrix[2, 2];
        if (diag1 != magicSum)
            return false;

        int diag2 = matrix[0, 2] + matrix[1, 1] + matrix[2, 0];
        if (diag2 != magicSum)
            return false;

        return true;
    }

    static int[,] CreateMagicSquare()
    {
        bool magic = false;
        int[,] square = new int[3, 3];
        while (magic == false)
        {
            Console.WriteLine("Введите 9 целых чисел для заполнения матрицы 3x3 (по строкам):");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                    while (!int.TryParse(Console.ReadLine(), out square[i, j]))
                    {
                        Console.Write("Некорректный ввод. Введите целое число: ");
                    }
                }

            }
            magic = IsMagicSquare(square);
            if (magic == false)
            {
                Console.Clear();
                Console.WriteLine("Не магический квадрат!");
            }
        }

        return square;
    }

    static void PrintTable(string? text ,char[,] table, string keyword, int[] keyValues, List<char> result, bool isEncode)
    {
        int cols = table.GetLength(0);
        int rows = table.GetLength(1);
        int cellWidth = 3;

        CreateHorizontal(cols, rows, cellWidth);

        if (isEncode)
        {
            Console.Write("|");
            for (int i = 0; i < cols; i++)
            {
                Console.Write($" {keyword[i]} ");
                Console.Write("|");
            }

            Console.Write(new string(' ', cellWidth * 3));

            Console.Write("|");
            for (int i = 1; i < cols + 1; i++)
            {
                int key = 0;
                while (keyValues[key] != i)
                {
                    key++;
                }
                Console.Write($" {keyword[key]} ");
                Console.Write("|");
            }
            Console.WriteLine();

            Console.Write("|");
            for (int i = 0; i < cols; i++)
            {
                Console.Write($" {keyValues[i]} ");
                Console.Write("|");
            }

            Console.Write(new string(' ', cellWidth * 3));

            Console.Write("|");
            for (int i = 0; i < cols; i++)
            {
                Console.Write($" {i + 1} ");
                Console.Write("|");
            }
            Console.WriteLine();
        }
        else
        {
            Console.Write("|");
            for (int i = 1; i < cols + 1; i++)
            {
                int key = 0;
                while (keyValues[key] != i)
                {
                    key++;
                }
                Console.Write($" {keyword[key]} ");
                Console.Write("|");
            }
            

            Console.Write(new string(' ', cellWidth * 3));

            Console.Write("|");
            for (int i = 0; i < cols; i++)
            {
                Console.Write($" {keyword[i]} ");
                Console.Write("|");
            }
            Console.WriteLine();

            Console.Write("|");
            for (int i = 0; i < cols; i++)
            {
                Console.Write($" {i + 1} ");
                Console.Write("|");
            }

            Console.Write(new string(' ', cellWidth * 3));

            Console.Write("|");
            for (int i = 0; i < cols; i++)
            {
                Console.Write($" {keyValues[i]} ");
                Console.Write("|");
            }
            Console.WriteLine();
        }

        CreateHorizontal(cols, rows, cellWidth);

        if (isEncode)
        {
            int index = 0;
            for (int r = 0; r < rows; r++)
            {
                Console.Write("|");
                for (int c = 0; c < cols; c++)
                {
                    Console.Write($" {table[c, r]} ");
                    Console.Write("|");
                }

                Console.Write(new string(' ', cellWidth * 3));

                Console.Write("|");

                for (int c = 1; c <= cols; c++)
                {
                    Console.Write($" {result[index]} ");
                    index++;
                    Console.Write("|");
                }

                Console.WriteLine();
            }
        }
        else
        {
            int index = 0;
            for (int r = 0; r < rows; r++)
            {
                Console.Write("|");
                for (int c = 1; c <= cols; c++)
                {
                    Console.Write($" {text[index]} ");
                    index++;
                    Console.Write("|");
                }

                Console.Write(new string(' ', cellWidth * 3));

                Console.Write("|");
                for (int c = 0; c < cols; c++)
                {
                    Console.Write($" {table[c, r]} ");
                    Console.Write("|");
                }

                Console.WriteLine();
            }
        }


            CreateHorizontal(cols, rows, cellWidth);
    }

    static void CreateHorizontal(int cols, int rows, int cellWidth)
    {
        for (int j = 0; j < 2; j++)
        {
            Console.Write("+");
            for (int i = 0; i < cols; i++)
            {
                Console.Write(new string('-', cellWidth));
                Console.Write("+");
            }
            Console.Write(new string(' ', cellWidth * 3));
        }
        Console.WriteLine();
    }
}
