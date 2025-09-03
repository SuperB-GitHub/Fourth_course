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

                    //string encrypted = EncryptOne(text, keyword, rows, cols);
                    string decrypted = DecryptOne(text, keyword, rows, cols);
                    //Console.WriteLine($"Зашифрованный текст: {encrypted}\n");
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
                    Console.WriteLine($"Введите текст:");
                    string? text = Console.ReadLine();

                    int[,] square = new int[3, 3];

                    Console.WriteLine("Введите 9 целых чисел для заполнения матрицы 3x3 (по строкам):");

                    // Вводим элементы матрицы
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

                    string decrypted = DecryptTwo(text, square);
                    Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();

                    Console.WriteLine($"Введите текст:");
                    string? text = Console.ReadLine();

                    int[,] square = new int[3, 3];

                    Console.WriteLine("Введите 9 целых чисел для заполнения матрицы 3x3 (по строкам):");

                    // Вводим элементы матрицы
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

                    //string decrypted = DecryptTwo(text, square);
                    string encrypted = EncryptTwo(text, square);
                    //Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
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

    static string DecryptOne(string? encryptedText, string? keyword, int rows, int cols)
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
        // Считаем сумму первой строки (её будем сравнивать с остальными)
        int magicSum = matrix[0, 0] + matrix[0, 1] + matrix[0, 2];

        // Проверка остальных строк
        for (int i = 1; i < 3; i++)
        {
            int rowSum = matrix[i, 0] + matrix[i, 1] + matrix[i, 2];
            if (rowSum != magicSum)
                return false;
        }

        // Проверка столбцов
        for (int j = 0; j < 3; j++)
        {
            int colSum = matrix[0, j] + matrix[1, j] + matrix[2, j];
            if (colSum != magicSum)
                return false;
        }

        // Проверка главной диагонали (сверху-слева направо-вниз)
        int diag1 = matrix[0, 0] + matrix[1, 1] + matrix[2, 2];
        if (diag1 != magicSum)
            return false;

        // Проверка побочной диагонали (сверху-справа налево-вниз)
        int diag2 = matrix[0, 2] + matrix[1, 1] + matrix[2, 0];
        if (diag2 != magicSum)
            return false;

        // Если всё совпадает — это магический квадрат
        return true;
    }
}
