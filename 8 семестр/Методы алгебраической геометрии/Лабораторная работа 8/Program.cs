using System.Text;
using static MyLibrary.MathUtils;
using static MyLibrary.StringUtils;
using static Лабораторная_работа_8.Consts;

namespace Лабораторная_работа_8
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var abm = new List<long> { 1, 1, 751 };
            Console.WriteLine($"Эллиптическая кривая: E{ToLowerIndex(abm[2])}({abm[0]}, {abm[1]}) => y² = x³ + x + 1");
            Coords P = new Coords(0, 1);
            Console.WriteLine($"\nГенерирующая точка P{P.print()}");

            menu(P);

        }

        static void menu(Coords P)
        {
            int sp = Console.CursorTop;
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1 - Зашифровать текст");
            Console.WriteLine("2 - Расшифровать текст");
            Console.WriteLine("0 - Выход в главное меню");
            Console.Write("\nВаш выбор: ");

            string choice = Console.ReadLine()!.Trim();
            int variant = 0;

            switch (choice)
            {
                case "1":
                    ClearLines(sp, Console.CursorTop);
                    Console.Write("\nВыберите вариант: ");
                    variant = int.Parse(Console.ReadLine()!.Trim());
                    EncryptText(P, variant);
                    break;
                case "2":
                    ClearLines(sp, Console.CursorTop);
                    Console.Write("\nВыберите вариант: ");
                    variant = int.Parse(Console.ReadLine()!.Trim());
                    //DecryptText(G, abm);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Нажмите любую клавишу...");
                    Console.ReadKey();
                    ClearLines(sp, Console.CursorTop);
                    menu(P);
                    break;
            }
        }

        static List<(Coords, Coords)> EncryptText(Coords P, int variant)
        {
            var abm = new List<long> { 1, 1, 751 };
            var CipherText = new List<(Coords, Coords)>(); 
            string OpenText = OpenTexts[variant];
            Coords Qb = PublicKeyB[variant];
            List<int> ks = RandK[variant];

            Console.WriteLine($"\nВариант {variant}: \nОткр.текст: {OpenText}; Qb{Qb.print()}; k:({string.Join(' ', ks)})\n");
            Console.WriteLine($"Шифрование:\n");
            var sb = new StringBuilder();

            for (int i = 0; i < OpenText.Length; i++)
            {
                int k = ks[i];
                Coords kp = SkalMul(P, k, abm);
                Coords kQb = SkalMul(Qb, k, abm);
                Console.WriteLine($"1) При k={k} => kP{kp.print()}");
                Console.WriteLine($"            => k * Qb = kQb{kQb.print()}\n");

                Coords M = Alph[OpenText[i]];
                Coords R = AddFunc(M, kQb, abm);
                Console.WriteLine($"2) R = M:{M.print()} + kQb:{kQb.print()} = {R.print()}\n");
                CipherText.Add((kp, R));
                Console.WriteLine($"Зашифрована буква `{OpenText[i]}`{M.print()} = {R.print()}\n");
                sb.Append($"`{OpenText[i]}` = ({kp.print()}, {R.print()});\n");
            }
            Console.WriteLine($"Весь шифртекст: \n{sb}");

            return CipherText;
        }

        
    }
}


