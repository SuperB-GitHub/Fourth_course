using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string text = "ИЛЛЮЗИИ, ЧЕМ БОЛЬШЕ О НИХ ДУМАЕШЬ, ИМЕЮТ СВОЙСТВО МНОЖИТЬСЯ, ПРИОБРЕТАТЬ БОЛЕЕ ВЫРАЖЕННУЮ ФОРМУ.";
        string keyword = "МЫСЛЕННО";
        int rows = 12;
        int cols = 8;

        string encrypted = EncryptOne(text, keyword, rows, cols);
        Console.WriteLine("Зашифрованный текст: " + encrypted);
        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();

        text = "АЕРУТНСВЧ";

        int[,] square = {
            {2, 7, 6},
            {9, 5, 1},
            {4, 3, 8}
        };
        string decrypted = DecryptTwo(text, square);
        Console.WriteLine("Расшифрованный текст: " + decrypted);
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



    static string DecryptTwo(string text, int[,] square)
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
                grid[i, j] = text[index++];
            }

        string result = "";
        for (int num = 1; num <= 9; num++)
        {
            var pos = positions[num - 1];
            result += grid[pos.row, pos.col];
        }

        return result;
    }
}
