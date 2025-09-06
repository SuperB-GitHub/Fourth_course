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

                //string text = "МЫ ДОЛЖНЫ ПРИЗНАТЬ ОЧЕВИДНОЕ: ПОНИМАЮТ ЛИШЬ ТЕ, КТО ХОЧЕТ ПОНЯТЬ";
                //УВ КХТНФВ ЦЧПОФЖЩГ ХЮЛИПКФХЛ: ЦХФПУЖЕЩ ТПЯГ ЩЛ, СЩХ ЬХЮЛЩ ЦХФЁЩГ
                //int shift = 7;

                Console.WriteLine($"Выберите действие:\n 1 - Шифрование\n 2 - Дешифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();

                    Console.WriteLine($"Введите текст:");
                    string? text = Console.ReadLine();
                    while (string.IsNullOrEmpty(text))
                    {
                        Console.Clear();
                        Console.WriteLine("Ошибка: текст не может быть пустым.");
                        Console.WriteLine($"Введите текст:");
                        text = Console.ReadLine()!;
                    }

                    Console.WriteLine($"Введите число сдвигов: ");
                    int shift;
                    while (!int.TryParse(Console.ReadLine(), out shift))
                    {
                        Console.Write("Некорректный ввод. Введите целое число: ");
                    }

                    string encrypted = CaesarOne(text, shift);
                    Console.WriteLine($"\nЗашифрованный текст: {encrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();

                    Console.WriteLine($"Введите текст:");
                    string? text = Console.ReadLine();
                    while (string.IsNullOrEmpty(text))
                    {
                        Console.Clear();
                        Console.WriteLine("Ошибка: текст не может быть пустым.");
                        Console.WriteLine($"Введите текст:");
                        text = Console.ReadLine()!;
                    }

                    Console.WriteLine($"Введите число сдвигов: ");
                    int shift;
                    while (!int.TryParse(Console.ReadLine(), out shift))
                    {
                        Console.Write("Некорректный ввод. Введите целое число: ");
                    }

                    string decrypted = CaesarOne(text, -shift);
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
                //string text = "АЕРУТНСВЧ";
                //int[,] square = {
                //    {2, 7, 6},
                //    {9, 5, 1},
                //    {4, 3, 8}
                //};
                Console.WriteLine($"Выберите действие:\n 1 - Шифрование\n 2 - Дешифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    ////string decrypted = DecryptTwo(text, square);
                    //Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    //string decrypted = DecryptTwo(text, square);
                    //string encrypted = EncryptTwo(decrypted, square);
                    //Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                    //Console.WriteLine($"Зашифрованный текст: {encrypted}\n");
                }
                else
                {
                    break;
                }

            }
            else if (key.Key == ConsoleKey.D3)
            {
                Console.Clear();
                //string text = "АЕРУТНСВЧ";
                //int[,] square = {
                //    {2, 7, 6},
                //    {9, 5, 1},
                //    {4, 3, 8}
                //};
                Console.WriteLine($"Выберите действие:\n 1 - Шифрование\n 2 - Дешифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    ////string decrypted = DecryptTwo(text, square);
                    //Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    //string decrypted = DecryptTwo(text, square);
                    //string encrypted = EncryptTwo(decrypted, square);
                    //Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                    //Console.WriteLine($"Зашифрованный текст: {encrypted}\n");
                }
                else
                {
                    break;
                }

            }
            else if (key.Key == ConsoleKey.D4)
            {
                Console.Clear();
                //string text = "АЕРУТНСВЧ";
                //int[,] square = {
                //    {2, 7, 6},
                //    {9, 5, 1},
                //    {4, 3, 8}
                //};
                Console.WriteLine($"Выберите действие:\n 1 - Шифрование\n 2 - Дешифрование");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    ////string decrypted = DecryptTwo(text, square);
                    //Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    //string decrypted = DecryptTwo(text, square);
                    //string encrypted = EncryptTwo(decrypted, square);
                    //Console.WriteLine($"Расшифрованный текст: {decrypted}\n");
                    //Console.WriteLine($"Зашифрованный текст: {encrypted}\n");
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

    public static string CaesarOne(string text, int shift)
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


}