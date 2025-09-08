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

                    PrintCaesarOneTable(shift);
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

                    PrintCaesarOneTable(-shift);
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

                //СМЫСЛ ЖИЗНИ НАШЕЙ – НЕПРЕРЫВНОЕ ДВИЖЕНИЕ
                //ЖЭЪЖЫ СХУЯХ ЯГФНЧ - ЯНГЕНЕЪЖЯБН ЛЖХСНЯХН

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

                    Console.WriteLine($"Введите число a: ");
                    int a;
                    while (!int.TryParse(Console.ReadLine() , out a) || NOD(a, 33) != 1)
                    {
                        Console.Write("Некорректный ввод. Введите целое и взаимно простое к 33 число: ");
                    }

                    Console.WriteLine($"Введите число b: ");
                    int b;
                    while (!int.TryParse(Console.ReadLine(), out b))
                    {
                        Console.Write("Некорректный ввод. Введите целое число: ");
                    }

                    //PrintCaesarTwoTable(a);
                    string encrypted = AffineCaesarEncrypt(text, a, b);
                    Console.WriteLine($"\nЗашифрованный текст: {encrypted}\n");
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

    static string CaesarOne(string text, int shift)
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

    public static string AffineCaesarEncrypt(string text, int a, int b)
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

                    result += encryptedChar);
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

    private static int NOD(int a, int b)
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
}