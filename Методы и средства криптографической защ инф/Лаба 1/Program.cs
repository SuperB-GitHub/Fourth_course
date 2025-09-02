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

        string encrypted = Encrypt(text, keyword, rows, cols);
        Console.WriteLine("Зашифрованный текст: " + encrypted);
    }

    static string Encrypt(string text, string keyword, int rows, int cols)
    {
        string cleanText = new string(text.ToUpper().Select(c => c != ' ' ? c : '_').ToArray());

        char[,] table = new char[rows, cols];

        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (index < cleanText.Length)
                {
                    table[j, i] = cleanText[index++];
                }
                else
                {
                    table[j, i] = '_';
                }
            }
        }

        // Ключевые значения (из примера): "МЫСЛЕННО" → [3,8,7,2,1,4,5,6]
        int[] keyValues = { 3, 8, 7, 2, 1, 4, 5, 6 };

        //// Сортируем столбцы по возрастанию значений в ключе
        //var sortedColumns = Enumerable.Range(0, cols)
        //    .Select(i => new { Value = keyValues[i], Index = i })
        //    .OrderBy(x => x.Value)
        //    .Select(x => x.Index)
        //    .ToArray();

        // Считываем таблицу по столбцам в новом порядке
        List<char> result = new List<char>();

        for (int row = 0; row < rows; row++)
        {
            int realCol = 1;

            while (realCol<=cols)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (keyValues[col] == realCol)
                    {
                        result.Add(table[row, col]);
                        realCol++;
                    }
                }
            }
        }
        //foreach (int col in sortedColumns)
        //{
        //    for (int row = 0; row < rows; row++)
        //    {
        //        result.Add(table[row, col]);
        //    }
        //}

        string encryptedStr = new string(result.ToArray());

        return encryptedStr;
    }

}