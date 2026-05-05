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

            var abm = new List<long> { 750, 1, 751 };
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
                    DecryptText(variant);
                    break;
                case "0":
                    for (int _ = 0; _ < Alph.Count; _++)
                    {
                        Console.WriteLine($"{Alph.ElementAt(_).Key} - {Alph.ElementAt(_).Value.print()} - " +
                            $"{checkCoords([750, 1, 751], Alph.ElementAt(_).Value)}");
                    }
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
            var abm = new List<long> { 750, 1, 751 };
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
                //sb.Append($"`{OpenText[i]}` = ({kQb.print()}, {R.print()});\n");
            }
            Console.WriteLine($"Весь шифртекст: \n{sb}");

            return CipherText;
        }

        static List<(Coords, Coords)> DecryptText(int variant)
        {
            var abm = new List<long> { 750, 1, 751 };
            long ab = CipherTextCon[variant].Item1;
            var CipherText = CipherTextCon[variant].Item2;
            Dictionary<Coords, char> revAlph = Alph.ToDictionary(x => x.Value, x => x.Key);

            Console.WriteLine($"\nВариант {variant}: \nab = {ab}; Шифр.текст:\n");
            Console.WriteLine($"Расшифрование:\n");
            var sb = new StringBuilder();

            for (int i = 0; i < CipherText.Count; i++)
            {
                if(variant == 2)
                {
                    Coords kqb = CipherText[i].Item1.invers(abm[2]);
                    Coords R = CipherText[i].Item2;

                    Coords M = AddFunc(R, kqb, abm);
                    Console.WriteLine($"2) M = R:{R.print()} - kQb:{kqb.print()} = {M.print()}\n");

                    char name = Alph.First(x => x.Value.equals(M)).Key;
                    Console.WriteLine($"Расшифрована буква {M.print()} = `{name}`\n");
                    sb.Append(name);
                }
                else
                {
                    Coords kp = CipherText[i].Item1;
                    Coords R = CipherText[i].Item2;
                    if (!checkCoords(abm, kp) || !checkCoords(abm, R))
                    {
                        Console.WriteLine($"Точки не лежат на кривой!\n");
                    }
                    else
                    {
                        Coords mul = SkalMul(kp, ab, abm);
                        Console.WriteLine($"1) При ab = {ab} => ab * kP{kp.print()} = {mul.print()}");


                        mul = mul.invers(abm[2]);
                        Coords M = AddFunc(R, mul, abm);
                        Console.WriteLine($"2) M = R:{R.print()} - ab * kP:{mul.print()} = {M.print()}\n");

                        char name = Alph.First(x => x.Value.equals(M)).Key;
                        Console.WriteLine($"Расшифрована буква {M.print()} = `{name}`\n");
                        sb.Append(name);
                    }
                }
            }
            Console.WriteLine($"Весь расшифрованный текст: \n{sb}");

            return CipherText;
        }
    }
}


