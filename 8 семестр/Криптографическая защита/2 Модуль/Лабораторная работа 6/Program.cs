using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using static Лабораторная_работа_6.GOST;
using static Лабораторная_работа_6.RSA;
using static MyLibrary.MathUtils;

class RSASignatureLab
{
    static Random random = new Random();

    // Глобальные переменные для ключей
    static BigInteger savedN;
    static BigInteger savedE;
    static BigInteger savedD;

    static string ReadTextFromWord(string filePath)
    {
        try
        {
            StringBuilder text = new StringBuilder();

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                Body body = wordDoc.MainDocumentPart!.Document!.Body!;

                foreach (var paragraph in body.Elements<Paragraph>())
                {
                    foreach (var run in paragraph.Elements<Run>())
                    {
                        foreach (var textElement in run.Elements<Text>())
                        {
                            text.Append(textElement.Text);
                        }
                    }
                    text.AppendLine();
                }
            }

            return text.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            return null!;
        }
    }
    static string ReadTextDataFromWord(string filePath)
    {
        try
        {
            StringBuilder text = new StringBuilder();

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                Body body = wordDoc.MainDocumentPart!.Document!.Body!;

                foreach (var paragraph in body.Elements<Paragraph>())
                {
                    foreach (var run in paragraph.Elements<Run>())
                    {
                        foreach (var textElement in run.Elements<Text>())
                        {
                            text.Append(textElement.Text);
                        }
                    }
                    text.AppendLine();
                }
            }

            // Просто добавляем дату последнего изменения файла в конец
            FileInfo fileInfo = new FileInfo(filePath);
            text.AppendLine();
            text.Append($"[Последнее изменение: {fileInfo.LastWriteTime:yyyy-MM-dd HH:mm:ss}]");

            return text.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            return null!;
        }
    }
    static void PrintKey(string name, BigInteger key)
    {
        string keyStr = key.ToString();
        if (keyStr.Length > 64)
        {
            Console.WriteLine($"{name}:\n{keyStr.Substring(0, 32)}...{keyStr.Substring(keyStr.Length - 32)}");
        }
        else
        {
            Console.WriteLine($"{name}:\n{keyStr}");
        }
    }
    static void SaveSignatureToFile(BigInteger signature, string documentPath)
    {
        string signaturePath = Path.ChangeExtension(documentPath, ".sig");
        File.WriteAllText(signaturePath, signature.ToString());
        Console.WriteLine($"\n✓ Подпись сохранена в файл: {signaturePath}");
    }
    static BigInteger LoadSignatureFromFile(string documentPath)
    {
        string signaturePath = Path.ChangeExtension(documentPath, ".sig");
        if (File.Exists(signaturePath))
        {
            string signatureText = File.ReadAllText(signaturePath);
            return BigInteger.Parse(signatureText);
        }
        return 0;
    }
    static void SaveKeysToFile()
    {
        string keyPath = "rsa_keys.txt";
        using (StreamWriter sw = new StreamWriter(keyPath))
        {
            sw.WriteLine($"N={savedN}");
            sw.WriteLine($"E={savedE}");
            sw.WriteLine($"D={savedD}");
        }
        Console.WriteLine($"✓ Ключи сохранены в файл: {keyPath}");
    }
    static bool LoadKeysFromFile()
    {
        string keyPath = "rsa_keys.txt";
        if (File.Exists(keyPath))
        {
            try
            {
                string[] lines = File.ReadAllLines(keyPath);
                savedN = BigInteger.Parse(lines[0].Substring(2));
                savedE = BigInteger.Parse(lines[1].Substring(2));
                savedD = BigInteger.Parse(lines[2].Substring(2));
                return true;
            }
            catch
            {
                return false;
            }
        }
        return false;
    }
    static void CreateAndSign()
    {
        Console.Clear();
        Console.WriteLine("=".PadRight(80, '='));
        Console.WriteLine("ПУНКТ 1: СОЗДАНИЕ И ПОДПИСАНИЕ ДОКУМЕНТА");
        Console.WriteLine("=".PadRight(80, '='));
        Console.WriteLine();

        // Генерация ключей
        Console.WriteLine("ГЕНЕРАЦИЯ КЛЮЧЕВ RSA");
        Console.WriteLine("-".PadRight(80, '-'));
        Console.WriteLine();

        int bits = 1024;
        Console.WriteLine($"Генерация {bits}-битных простых чисел p и q...");
        Console.WriteLine("Это может занять несколько секунд...");

        BigInteger p = GenPrime(bits);
        BigInteger q = GenPrime(bits);
        while (p == q) q = GenPrime(bits);

        Console.WriteLine($"✓ Простое число p сгенерировано");
        Console.WriteLine($"✓ Простое число q сгенерировано");

        BigInteger n = p * q;
        BigInteger phi = (p - 1) * (q - 1);

        Console.WriteLine($"✓ Модуль n = p * q (битность: {n.GetBitLength()} бит)");

        // Выбор открытой экспоненты e
        BigInteger e = 65537;
        if (BigInteger.GreatestCommonDivisor(e, phi) != 1)
        {
            Console.WriteLine("   e = 65537 не подходит, ищем другое значение...");
            do
            {
                byte[] bytes = new byte[phi.GetByteCount()];
                random.NextBytes(bytes);
                e = BigInteger.Abs(new BigInteger(bytes)) % (phi - 2) + 2;
            } while (BigInteger.GreatestCommonDivisor(e, phi) != 1);
        }

        Console.WriteLine($"✓ Открытая экспонента e = {e}");

        // Вычисление секретной экспоненты d
        BigInteger d = ModInverse(e, phi);
        Console.WriteLine("✓ Секретная экспонента d вычислена");
        Console.WriteLine();

        // Сохраняем ключи в глобальные переменные
        savedN = n;
        savedE = e;
        savedD = d;

        Console.WriteLine("СОЗДАННЫЕ КЛЮЧИ:");
        Console.WriteLine("---------------");
        PrintKey("Открытый ключ (e)", e);
        PrintKey("Открытый ключ (n)", n);
        Console.WriteLine();
        PrintKey("Закрытый ключ (d)", d);
        PrintKey("Закрытый ключ (n)", n);
        Console.WriteLine();

        // Сохраняем ключи в файл
        SaveKeysToFile();
        Console.WriteLine();

        // Выбор документа
        Console.WriteLine("ВЫБОР ДОКУМЕНТА ДЛЯ ПОДПИСАНИЯ");
        Console.WriteLine("-".PadRight(80, '-'));
        Console.WriteLine();

        Console.Write("Введите путь к документу Word (.docx): ");
        string filePath = Console.ReadLine()!.Trim('"');

        if (string.IsNullOrWhiteSpace(filePath))
        {
            Console.WriteLine("Путь не указан. Создайте файл 'document.docx' в папке с программой.");
            Console.Write("Введите путь заново: ");
            filePath = Console.ReadLine()!.Trim('"');
        }

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл не найден: {filePath}");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            return;
        }

        // Чтение документа
        Console.WriteLine("\nЧтение текста из документа...");
        string documentText = ReadTextFromWord(filePath);

        if (documentText == null)
        {
            Console.WriteLine("Не удалось прочитать документ.");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            return;
        }

        if (string.IsNullOrWhiteSpace(documentText))
        {
            Console.WriteLine("Документ пуст или не содержит текста.");
            documentText = "Тестовый документ для подписания.";
        }

        Console.WriteLine($"\nТекст документа (первые 200 символов):");
        Console.WriteLine(new string('-', 60));
        string preview = documentText.Length > 200 ? documentText.Substring(0, 200) + "..." : documentText;
        Console.WriteLine(preview);
        Console.WriteLine(new string('-', 60));
        Console.WriteLine($"Полная длина текста: {documentText.Length} символов");

        // Вычисление хеша
        Console.WriteLine("\nВычисление SHA-256 хеша документа...");
        byte[] hash = SHA256Hash(documentText);
        Console.WriteLine($"Хеш документа (SHA-256): {BitConverter.ToString(hash).Replace("-", "").ToLower()}");

        // Подписание хеша (используем d - закрытый ключ)
        Console.WriteLine("\nПодписание хеша с использованием закрытого ключа (d, n)...");
        BigInteger signature = SignHash(hash, d, n);
        string sigStr = signature.ToString();
        Console.WriteLine($"Цифровая подпись:");
        if (sigStr.Length > 100)
        {
            Console.WriteLine($"{sigStr.Substring(0, 50)}...{sigStr.Substring(sigStr.Length - 50)}");
        }
        else
        {
            Console.WriteLine(sigStr);
        }

        // Сохранение подписи
        SaveSignatureToFile(signature, filePath);

        // Проверка подписи (сразу после создания)
        Console.WriteLine("\nПРОВЕРКА ПОДПИСИ (после создания)");
        Console.WriteLine("-".PadRight(80, '-'));

        bool isValid = VerifySignature(hash, signature, e, n);

        if (isValid)
        {
            Console.WriteLine("\n✓ ПОДПИСЬ ВЕРНА! Документ успешно подписан.");
        }
        else
        {
            Console.WriteLine("\n✗ ОШИБКА! Подпись не прошла проверку.");
        }

        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }
    static void VerifySignatureFromFile()
    {
        Console.Clear();
        Console.WriteLine("=".PadRight(80, '='));
        Console.WriteLine("ПУНКТ 2: ПРОВЕРКА ПОДПИСИ ДОКУМЕНТА");
        Console.WriteLine("=".PadRight(80, '='));
        Console.WriteLine();

        // Загрузка ключей
        Console.WriteLine("ЗАГРУЗКА КЛЮЧЕЙ");
        Console.WriteLine("-".PadRight(80, '-'));

        if (!LoadKeysFromFile())
        {
            Console.WriteLine("Не найдены сохраненные ключи!");
            Console.WriteLine("Сначала выполните пункт 1 (Создание и подписание документа).");
            Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("✓ Ключи успешно загружены:");
        PrintKey("Открытый ключ (e)", savedE);
        PrintKey("Открытый ключ (n)", savedN);
        Console.WriteLine();

        // Выбор документа
        Console.WriteLine("ВЫБОР ДОКУМЕНТА ДЛЯ ПРОВЕРКИ");
        Console.WriteLine("-".PadRight(80, '-'));

        Console.Write("Введите путь к документу Word (.docx): ");
        string filePath = Console.ReadLine()!.Trim('"');

        if (string.IsNullOrWhiteSpace(filePath))
        {
            Console.WriteLine("Путь не указан.");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            return;
        }

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл не найден: {filePath}");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            return;
        }

        // Загрузка подписи
        Console.WriteLine("\nЗАГРУЗКА ПОДПИСИ");
        Console.WriteLine("-".PadRight(80, '-'));

        BigInteger signature = LoadSignatureFromFile(filePath);

        if (signature == 0)
        {
            Console.WriteLine($"Не найден файл подписи для документа {Path.GetFileName(filePath)}");
            Console.WriteLine($"Файл подписи должен называться: {Path.ChangeExtension(filePath, ".sig")}");
            Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("✓ Подпись успешно загружена");
        string sigStr = signature.ToString();
        Console.WriteLine($"Подпись: {(sigStr.Length > 100 ? sigStr.Substring(0, 50) + "..." + sigStr.Substring(sigStr.Length - 50) : sigStr)}");
        Console.WriteLine();

        // Чтение документа
        Console.WriteLine("ЧТЕНИЕ ДОКУМЕНТА");
        Console.WriteLine("-".PadRight(80, '-'));

        string documentText = ReadTextFromWord(filePath);

        if (documentText == null)
        {
            Console.WriteLine("Не удалось прочитать документ.");
            Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"\nТекст документа (первые 200 символов):");
        Console.WriteLine(new string('-', 60));
        string preview = documentText.Length > 200 ? documentText.Substring(0, 200) + "..." : documentText;
        Console.WriteLine(preview);
        Console.WriteLine(new string('-', 60));
        Console.WriteLine($"Полная длина текста: {documentText.Length} символов");

        // Вычисление хеша
        Console.WriteLine("\nВычисление SHA-256 хеша документа...");
        byte[] hash = SHA256Hash(documentText);
        Console.WriteLine($"Хеш документа (SHA-256): {BitConverter.ToString(hash).Replace("-", "").ToLower()}");

        // Проверка подписи
        Console.WriteLine("\nПРОВЕРКА ПОДПИСИ");
        Console.WriteLine("-".PadRight(80, '-'));

        Console.WriteLine("Проверка подписи с использованием открытого ключа (e, n)...");
        bool isValid = VerifySignature(hash, signature, savedE, savedN);

        Console.WriteLine("\n" + "=".PadRight(60, '='));
        if (isValid)
        {
            Console.WriteLine("✓ РЕЗУЛЬТАТ: ПОДПИСЬ ВЕРНА!");
            Console.WriteLine("  Документ аутентичен и не был изменен после подписания.");
        }
        else
        {
            Console.WriteLine("✗ РЕЗУЛЬТАТ: ПОДПИСЬ НЕВЕРНА!");
            Console.WriteLine("  Документ был изменен или подпись подделана.");
        }
        Console.WriteLine("=".PadRight(60, '='));

        // Дополнительно: проверка на изменение
        Console.WriteLine("\nДОПОЛНИТЕЛЬНАЯ ПРОВЕРКА");
        Console.WriteLine("-".PadRight(80, '-'));
        Console.WriteLine("Хотите проверить, как изменится результат при изменении документа? (д/н)");
        Console.Write("> ");
        string answer = Console.ReadLine()!.Trim().ToLower();

        if (answer == "д" || answer == "да" || answer == "l" || answer == "yes")
        {
            Console.WriteLine("\nВносим минимальное изменение (добавляем пробел в конец)...");
            string modifiedText = documentText + " ";
            byte[] modifiedHash = SHA256Hash(modifiedText);

            Console.WriteLine($"Исходный хеш (первые 32 символа): {BitConverter.ToString(hash).Replace("-", "").ToLower().Substring(0, 32)}...");
            Console.WriteLine($"Измененный хеш (первые 32 символа): {BitConverter.ToString(modifiedHash).Replace("-", "").ToLower().Substring(0, 32)}...");

            bool isModifiedValid = VerifySignature(modifiedHash, signature, savedE, savedN);

            if (!isModifiedValid)
            {
                Console.WriteLine("\n✓ Результат: Подпись успешно обнаружила изменение!");
                Console.WriteLine("  Даже минимальное изменение текста делает подпись недействительной.");
            }
            else
            {
                Console.WriteLine("\n✗ Результат: Подпись НЕ обнаружила изменение!");
            }
        }

        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "ЭЦП RSA - Лабораторная работа 6";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА 6");
            Console.WriteLine("РЕАЛИЗАЦИЯ ЭЛЕМЕНТОВ ЭЦП RSA");
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine();
            Console.WriteLine("ГЛАВНОЕ МЕНЮ:");
            Console.WriteLine("-".PadRight(80, '-'));
            Console.WriteLine();
            Console.WriteLine("  1 - Создание и подписание документа");
            Console.WriteLine("      (генерация ключей, загрузка документа, вычисление хеша,");
            Console.WriteLine("       подписание, сохранение подписи)");
            Console.WriteLine();
            Console.WriteLine("  2 - Проверка подписи документа");
            Console.WriteLine("      (загрузка документа, загрузка подписи, вычисление хеша,");
            Console.WriteLine("       сверка с открытым ключом)");
            Console.WriteLine();
            Console.WriteLine("  0 - Выход");
            Console.WriteLine();
            Console.WriteLine("-".PadRight(80, '-'));
            Console.Write("\nВыберите пункт меню: ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    CreateAndSign();
                    break;
                case "2":
                    VerifySignatureFromFile();
                    break;
                case "0":
                    Console.WriteLine("\nДо свидания!");
                    return;
                default:
                    Console.WriteLine("\nНеверный выбор. Нажмите любую клавишу...");
                    Console.ReadKey();
                    byte[] hash94_256 = Gost94Hash("Hello, world!");
                    Console.WriteLine("ГОСТ 34.11-94 (256 бит): " + Convert.ToHexString(hash94_256));
                    break;
            }
        }
    }
}

