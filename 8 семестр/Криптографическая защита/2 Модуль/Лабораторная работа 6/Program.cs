using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Numerics;
using System.Text;
using static MyLibrary.MathUtils;
using static Лабораторная_работа_6.GOST;
using static Лабораторная_работа_6.RSA;

class Lab6_7
{
    static Random random = new Random();

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

    static void SaveSignRSA(BigInteger sign, string docPath)
    {
        string signaturePath = Path.ChangeExtension(docPath, ".sig");
        int count = 1;
        while (File.Exists(signaturePath))
        {
            signaturePath = Path.Combine(Path.GetDirectoryName(signaturePath)!, $"{Path.GetFileNameWithoutExtension(signaturePath)}_{count}.sig");
            count++;
        }
        File.WriteAllText(signaturePath, sign.ToString());
        Console.WriteLine($"\nПодпись сохранена в файл: {signaturePath}");
    }
    static void SaveSignGOST(BigInteger r, BigInteger s, string docPath)
    {
        string signPath = Path.ChangeExtension(docPath, ".sig");
        int count = 1;
        while (File.Exists(signPath))
        {
            signPath = Path.Combine(Path.GetDirectoryName(signPath)!, $"{Path.GetFileNameWithoutExtension(signPath)}_{count}.sig");
            count++;
        }
        using StreamWriter sw = new(signPath);
        sw.WriteLine($"r={r}");
        sw.WriteLine($"s={s}");
        Console.WriteLine($"\nПодпись сохранена в файл: {signPath}");
    }
    static void SaveKeysRSA(string docPath, BigInteger n, BigInteger e, BigInteger d)
    {
        string keysPath = Path.ChangeExtension(docPath, ".keys");
        int count = 1;
        while (File.Exists(keysPath))
        {
            keysPath = Path.Combine(Path.GetDirectoryName(keysPath)!, $"{Path.GetFileNameWithoutExtension(keysPath)}_{count}.keys");
            count++;
        }
        using StreamWriter sw = new(keysPath);
        sw.WriteLine($"N={n}");
        sw.WriteLine($"E={e}");
        sw.WriteLine($"D={d}");
        Console.WriteLine($"\nКлючи сохранены в файл: {keysPath}");
    }
    static void SaveParamsGOST(string docPath, BigInteger p, BigInteger q, BigInteger a, BigInteger x, BigInteger y)
    {
        string keysPath = Path.ChangeExtension(docPath, ".params");
        int count = 1;
        while (File.Exists(keysPath))
        {
            keysPath = Path.Combine(Path.GetDirectoryName(keysPath)!, $"{Path.GetFileNameWithoutExtension(keysPath)}_{count}.keys");
            count++;
        }
        using StreamWriter sw = new(keysPath);
        sw.WriteLine($"p={p}");
        sw.WriteLine($"q={q}");
        sw.WriteLine($"a={a}");
        sw.WriteLine($"x={x}");
        sw.WriteLine($"y={y}");
        Console.WriteLine($"\nКлючи сохранены в файл: {keysPath}");
    }
    
    static BigInteger LoadSignRSA(string sigPath)
    {
        if (File.Exists(sigPath))
        {
            string signatureText = File.ReadAllText(sigPath);
            return BigInteger.Parse(signatureText);
        }
        return 0;
    }
    static void LoadSignGOST(string sigPath, out BigInteger r, out BigInteger s)
    {
        if (File.Exists(sigPath))
        {
            try
            {
                string[] lines = File.ReadAllLines(sigPath);
                r = BigInteger.Parse(lines[0].Substring(2));
                s = BigInteger.Parse(lines[1].Substring(2));
            }
            catch
            {
                r = s = BigInteger.Zero;
            }
        }
        else r = s = BigInteger.Zero;
    }
    static bool LoadKeysRSA(string keysPath, out BigInteger n, out BigInteger e, out BigInteger d)
    {
        if (File.Exists(keysPath))
        {
            try
            {
                string[] lines = File.ReadAllLines(keysPath);
                n = BigInteger.Parse(lines[0].Substring(2));
                e = BigInteger.Parse(lines[1].Substring(2));
                d = BigInteger.Parse(lines[2].Substring(2));
                return true;
            }
            catch
            {
                n = e = d = BigInteger.Zero;
                return false;
            }
        }
        n = e = d = BigInteger.Zero;
        return false;
    }
    static bool LoadParamsGOST(string keysPath, out BigInteger p, out BigInteger q, out BigInteger a, out BigInteger x, out BigInteger y)
    {
        if (File.Exists(keysPath))
        {
            try
            {
                string[] lines = File.ReadAllLines(keysPath);
                p = BigInteger.Parse(lines[0].Substring(2));
                q = BigInteger.Parse(lines[1].Substring(2));
                a = BigInteger.Parse(lines[2].Substring(2));
                x = BigInteger.Parse(lines[3].Substring(2));
                y = BigInteger.Parse(lines[4].Substring(2));
                return true;
            }
            catch
            {
                p = q = a = x = y = BigInteger.Zero;
                return false;
            }
        }
        p = q = a = x = y = BigInteger.Zero;
        return false;
    }

    static void CreateAndSignRSA()
    {
        Console.Clear();
        Console.WriteLine("\nДействие 1: Создание и подписание документа");
        Console.WriteLine();

        Console.WriteLine("Генерация ключей по алгоритму RSA");
        Console.WriteLine();

        int bits = 1024;
        Console.WriteLine($"Генерация {bits}-битных простых чисел p и q...");
        Console.WriteLine();

        BigInteger p = GenPrime(bits);
        BigInteger q = GenPrime(bits);
        while (p == q) q = GenPrime(bits);

        Console.WriteLine($"Простое число p = {p.ToString().Substring(0, Math.Min(30, p.ToString().Length))}...\n");
        Console.WriteLine($"Простое число q = {q.ToString().Substring(0, Math.Min(30, q.ToString().Length))}...\n");

        BigInteger n = p * q;
        BigInteger m = (p - 1) * (q - 1);

        Console.WriteLine($"Модуль n = p * q (битность: {n.GetBitLength()} бит): \n{n.ToString().Substring(0, Math.Min(30, n.ToString().Length))}...\n");
        Console.WriteLine($"Число m = (p - 1) * (q - 1) = {m.ToString().Substring(0, Math.Min(30, m.ToString().Length))}...\n");

        BigInteger e = 0;
        do
        {
            byte[] bytes = new byte[m.GetByteCount()];
            random.NextBytes(bytes);
            e = BigInteger.Abs(new BigInteger(bytes)) % (m - 2) + 2;
        } while (BigInteger.GreatestCommonDivisor(e, m) != 1);

        Console.WriteLine($"Открытая экспонента e = {e.ToString().Substring(0, Math.Min(30, e.ToString().Length))}...\n");

        BigInteger d = ModInverse(e, m);
        Console.WriteLine($"Секретная экспонента d = {d.ToString().Substring(0, Math.Min(30, d.ToString().Length))}...\n");

        Console.WriteLine("Созданные ключи:\n");
        Console.WriteLine($"Открытый ключ (e): {e.ToString().Substring(0, Math.Min(30, e.ToString().Length))}...");
        Console.WriteLine($"Открытый ключ (n): {n.ToString().Substring(0, Math.Min(30, n.ToString().Length))}...");
        Console.WriteLine();
        Console.WriteLine($"Закрытый ключ (d): {d.ToString().Substring(0, Math.Min(30, d.ToString().Length))}...");
        Console.WriteLine($"Закрытый ключ (n): {n.ToString().Substring(0, Math.Min(30, n.ToString().Length))}...");
        Console.WriteLine();

        Console.Write("Введите путь к документу Word (.docx): ");
        string filePath = Console.ReadLine()!.Trim('"');

        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            Console.Write("Путь не указан или Файл не найден. Введите путь заново: ");
            filePath = Console.ReadLine()!.Trim('"');
        }

        SaveKeysRSA(filePath, n, e, d);

        string documentText = ReadTextFromWord(filePath);
        if (string.IsNullOrWhiteSpace(documentText))
        {
            Console.WriteLine("Документ пуст или не содержит текста.");
            documentText = "Тестовый документ для подписания.";
        }

        Console.WriteLine($"\nТекст документа:");
        string preview = documentText.Length > 200 ? documentText.Substring(0, 200) + "..." : documentText;
        Console.WriteLine(preview);
        Console.WriteLine($"\nПолная длина текста: {documentText.Length} символов");

        Console.WriteLine("\nВычисление SHA-256 хеша документа...");
        byte[] hash = SHA256Hash(documentText);
        Console.WriteLine($"Хеш документа (SHA-256): {Convert.ToHexStringLower(hash)}");

        Console.WriteLine("\nПодписание хеша с использованием закрытого ключа (d, n)...");
        BigInteger signature = SignHash(hash, d, n);
        string sigStr = signature.ToString();
        Console.WriteLine($"Цифровая подпись: {sigStr.Substring(0, 50)}...");

        SaveSignRSA(signature, filePath);

        Console.WriteLine("\nПроверка создания подписи:");

        bool isValid = VerifySignature(hash, signature, e, n);

        if (isValid)
        {
            Console.WriteLine("\nПодпись верна! Документ успешно подписан.");
        }
        else
        {
            Console.WriteLine("\nПодпись не ликвидна! Подпись не прошла проверку.");
        }

        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }
    static void VerifySignatureRSA()
    {
        Console.Clear();
        Console.WriteLine("\nДействие 2: Проверка подписи документа");
        Console.WriteLine();

        Console.Write("Введите путь к документу Word (.docx): ");
        string filePath = Console.ReadLine()!.Trim('"');

        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            Console.Write("Путь не указан или Файл не найден. Введите путь заново: ");
            filePath = Console.ReadLine()!.Trim('"');
        }
        string documentText = ReadTextFromWord(filePath);

        Console.WriteLine($"\nТекст документа:");
        string preview = documentText.Length > 200 ? documentText.Substring(0, 200) + "..." : documentText;
        Console.WriteLine(preview);
        Console.WriteLine($"\nПолная длина текста: {documentText.Length} символов");

        Console.Write("Введите путь к файлу с ключами (.keys): ");
        string keysPath = Console.ReadLine()!.Trim('"');

        if (string.IsNullOrWhiteSpace(keysPath) || !File.Exists(keysPath))
        {
            Console.Write("Путь не указан или Файл не найден. Введите путь заново: ");
            keysPath = Console.ReadLine()!.Trim('"');
        }
        LoadKeysRSA(keysPath, out BigInteger n, out BigInteger e, out BigInteger d);

        Console.WriteLine($"\nОткрытый ключ (e): {e.ToString().Substring(0, Math.Min(30, e.ToString().Length))}...");
        Console.WriteLine($"Открытый ключ (n): {n.ToString().Substring(0, Math.Min(30, n.ToString().Length))}...");
        Console.WriteLine();

        Console.Write("Введите путь к файлу с подписью (.sig): ");
        string sigPath = Console.ReadLine()!.Trim('"');

        if (string.IsNullOrWhiteSpace(sigPath) || !File.Exists(sigPath))
        {
            Console.Write("Путь не указан или Файл не найден. Введите путь заново: ");
            sigPath = Console.ReadLine()!.Trim('"');
        }

        BigInteger signature = LoadSignRSA(sigPath);

        string sigStr = signature.ToString();
        Console.WriteLine($"Подпись: {sigStr.Substring(0, 50)}...");
        Console.WriteLine();

        Console.WriteLine("\nВычисление SHA-256 хеша документа...");
        byte[] hash = SHA256Hash(documentText);
        Console.WriteLine($"Хеш документа (SHA-256): {Convert.ToHexStringLower(hash)}");

        Console.WriteLine("\nПроверка подписи с использованием открытого ключа (e, n)...");
        bool isValid = VerifySignature(hash, signature, e, n);

        if (isValid)
        {
            Console.WriteLine("Подпись верна! Документ аутентичен и не был изменен после подписания.");
        }
        else
        {
            Console.WriteLine("Подпись не ликвидна! Документ был изменен или подпись подделана.");
        }


        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }

    static void CreateAndSignGOST()
    {
        Console.Clear();
        Console.WriteLine("\nДействие 1: Создание и подписание документа");
        Console.WriteLine();

        Console.WriteLine("Генерация ключей по алгоритму ГОСТ 34.10 - 94");
        Console.WriteLine();

        Console.WriteLine($"Генерация p - 1024-битного и q - 256-битного простых чисел...");
        Console.WriteLine();

        (BigInteger p, BigInteger q) = GenGOSTParam();
        Console.WriteLine($"Простое {p.GetBitLength()}-битное число p = {p.ToString().Substring(0, Math.Min(30, p.ToString().Length))}...\n");
        Console.WriteLine($"Простое {q.GetBitLength()}-битное число q = {q.ToString().Substring(0, Math.Min(30, q.ToString().Length))}...\n");

        Console.WriteLine($"Вычисление образующего числа а ...");
        BigInteger a = FindA(p, q);
        Console.WriteLine($"Образующее число а = {a.ToString().Substring(0, Math.Min(30, a.ToString().Length))}...\n");

        Console.WriteLine($"Генерация открытого ключа x и закрытого y...");
        (BigInteger x, BigInteger y) = GenKeys(a, p, q);
        Console.WriteLine($"Закрытый ключ x = {x.ToString().Substring(0, Math.Min(30, x.ToString().Length))}...\n");
        Console.WriteLine($"Открытый ключ y = {y.ToString().Substring(0, Math.Min(30, y.ToString().Length))}...\n");

        Console.Write("Введите путь к документу Word (.docx): ");
        string filePath = Console.ReadLine()!.Trim('"');

        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            Console.Write("Путь не указан или Файл не найден. Введите путь заново: ");
            filePath = Console.ReadLine()!.Trim('"');
        }

        string documentText = ReadTextDataFromWord(filePath);
        if (string.IsNullOrWhiteSpace(documentText))
        {
            Console.WriteLine("Документ пуст или не содержит текста.");
            documentText = "Тестовый документ для подписания.";
        }

        Console.WriteLine($"\nТекст документа:");
        string preview = documentText.Length > 200 ? documentText.Substring(0, 200) + "..." : documentText;
        Console.WriteLine(preview);
        Console.WriteLine($"\nПолная длина текста: {documentText.Length} символов");

        SaveParamsGOST(filePath, p, q, a, x, y);

        Console.WriteLine("\nВычисление ГОСТ 34.11-94 хеша документа...");
        byte[] hashBytes = Gost94Hash(documentText);
        Console.WriteLine($"Хеш документа (ГОСТ 34.11-94): {Convert.ToHexStringLower(hashBytes)}\n");
        BigInteger hash = new BigInteger(hashBytes, true);
        hash = hash % q;

        Console.WriteLine("\nПодписание хеша с использованием закрытого ключа (x)...");
        (BigInteger r, BigInteger s) = Sign(hash, x, q, p, a);
        Console.WriteLine($"Цифровая подпись: \nr: {r.ToString().Substring(0, 50)}...\ns: {s.ToString().Substring(0, 50)}");

        SaveSignGOST(r, s, filePath);

        Console.WriteLine("\nПроверка создания подписи:");

        bool isValid = Verify(hash, r, s, y, q, p, a);

        if (isValid)
        {
            Console.WriteLine("\nПодпись верна! Документ успешно подписан.");
        }
        else
        {
            Console.WriteLine("\nПодпись не ликвидна! Подпись не прошла проверку.");
        }

        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }
    static void VerifySignatureGOST()
    {
        Console.Clear();
        Console.WriteLine("\nДействие 2: Проверка подписи документа");
        Console.WriteLine();

        Console.Write("Введите путь к документу Word (.docx): ");
        string filePath = Console.ReadLine()!.Trim('"');

        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            Console.Write("Путь не указан или Файл не найден. Введите путь заново: ");
            filePath = Console.ReadLine()!.Trim('"');
        }
        string documentText = ReadTextDataFromWord(filePath);

        Console.WriteLine($"\nТекст документа:");
        string preview = documentText.Length > 200 ? documentText.Substring(0, 200) + "..." : documentText;
        Console.WriteLine(preview);
        Console.WriteLine($"\nПолная длина текста: {documentText.Length} символов");

        Console.Write("Введите путь к файлу с ключами (.params): ");
        string keysPath = Console.ReadLine()!.Trim('"');

        if (string.IsNullOrWhiteSpace(keysPath) || !File.Exists(keysPath))
        {
            Console.Write("Путь не указан или Файл не найден. Введите путь заново: ");
            keysPath = Console.ReadLine()!.Trim('"');
        }
        LoadParamsGOST(keysPath, out BigInteger p, out BigInteger q, out BigInteger a, out BigInteger x, out BigInteger y);

        Console.WriteLine($"\nОткрытый ключ (y): {y.ToString().Substring(0, Math.Min(30, y.ToString().Length))}...");
        Console.WriteLine();

        Console.Write("Введите путь к файлу с подписью (.sig): ");
        string sigPath = Console.ReadLine()!.Trim('"');

        if (string.IsNullOrWhiteSpace(sigPath) || !File.Exists(sigPath))
        {
            Console.Write("Путь не указан или Файл не найден. Введите путь заново: ");
            sigPath = Console.ReadLine()!.Trim('"');
        }

        LoadSignGOST(sigPath, out BigInteger r, out BigInteger s);

        Console.WriteLine($"Цифровая подпись: \nr: {r.ToString().Substring(0, 50)}...\ns: {s.ToString().Substring(0, 50)}");
        Console.WriteLine();

        Console.WriteLine("\nВычисление ГОСТ 34.11-94 хеша документа...");
        byte[] hashBytes = Gost94Hash(documentText);
        Console.WriteLine($"Хеш документа (ГОСТ 34.11-94): {Convert.ToHexStringLower(hashBytes)}\n");
        BigInteger hash = new BigInteger(hashBytes, true);
        hash = hash % q;

        Console.WriteLine("Проверка подписи с использованием открытого ключа (y)...");

        bool isValid = Verify(hash, r, s, y, q, p, a);

        if(isValid)
        {
            Console.WriteLine("Подпись верна! Документ аутентичен и не был изменен после подписания.");
        }
        else
        {
            Console.WriteLine("Подпись не ликвидна! Документ был изменен или подпись подделана.");
        }

        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }

    static void MenuLab(ConsoleKeyInfo varLab)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Выберите действие:");
        Console.WriteLine();
        Console.WriteLine("  1 - Создание и подписание документа");
        Console.WriteLine();
        Console.WriteLine("  2 - Проверка подписи документа");
        Console.WriteLine();
        Console.WriteLine("  0 - Выход");
        Console.WriteLine();
        Console.Write("\nВыберите пункт меню: ");
        var varEx = Console.ReadKey();

        switch (varEx.Key, varLab.Key)
        {
            case (ConsoleKey.D1, ConsoleKey.D6) or (ConsoleKey.D1, ConsoleKey.D1):
                CreateAndSignRSA();
                break;
            case (ConsoleKey.D2, ConsoleKey.D6) or (ConsoleKey.D2, ConsoleKey.D1):
                VerifySignatureRSA();
                break;
            case (ConsoleKey.D1, ConsoleKey.D7) or (ConsoleKey.D1, ConsoleKey.D2):
                CreateAndSignGOST();
                break;
            case (ConsoleKey.D2, ConsoleKey.D7) or (ConsoleKey.D2, ConsoleKey.D2):
                VerifySignatureGOST();
                break;
            case (ConsoleKey.D0, _):
                Console.WriteLine("\nДо свидания!");
                return;
            default:
                Console.WriteLine("\nНеверный выбор. Нажмите любую клавишу...");
                Console.ReadKey();
                break;
        }
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "ЭЦП - Лабораторная работа 6 - 7";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\nЛабораторная работа 6-7 - Реализация элементов ЭЦП");
            Console.WriteLine();
            Console.Write("Выберите лабораторную работу: ");
            var varLab = Console.ReadKey();
            switch (varLab.Key)
            {
                case ConsoleKey.D6 or ConsoleKey.D1 or ConsoleKey.D7 or ConsoleKey.D2:
                    MenuLab(varLab);
                    break;
                case ConsoleKey.D0:
                    Console.WriteLine("\nДо свидания!");
                    return;
                default:
                    Console.WriteLine("\nНеверный выбор. Нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}