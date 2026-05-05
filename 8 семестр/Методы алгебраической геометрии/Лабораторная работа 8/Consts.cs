using static MyLibrary.MathUtils;

namespace Лабораторная_работа_8
{
    public static class Consts
    {
        public static Dictionary<char, Coords> Alph = new Dictionary<char, Coords>
        {
            {' ', new Coords(33, 355)},
            {'!', new Coords(33, 396)},
            {'"', new Coords(34, 74)},
            {'#', new Coords(34, 677)},
            {'$', new Coords(36, 87)},
            {'%', new Coords(36, 664)},
            {'&', new Coords(39, 171)},
            {'\'', new Coords(39, 580)},
            {'(', new Coords(43, 224)},
            {')', new Coords(43, 527)},
            {'*', new Coords(44, 366)},
            {'+', new Coords(44, 385)},
            {',', new Coords(45, 31)},
            {'-', new Coords(45, 720)},
            {'.', new Coords(47, 349)},
            {'/', new Coords(47, 402)},
            {'0', new Coords(48, 49)},
            {'1', new Coords(48, 702)},
            {'2', new Coords(49, 183)},
            {'3', new Coords(49, 568)},
            {'4', new Coords(53, 277)},
            {'5', new Coords(53, 474)},
            {'6', new Coords(56, 332)},
            {'7', new Coords(56, 419)},
            {'8', new Coords(58, 139)},
            {'9', new Coords(58, 612)},
            {':', new Coords(59, 365)},
            {';', new Coords(59, 386)},
            {'<', new Coords(61, 129)},
            {'=', new Coords(61, 622)},
            {'>', new Coords(62, 372)},
            {'?', new Coords(62, 379)},
            {'@', new Coords(66, 199)},
            {'A', new Coords(66, 552)},
            {'B', new Coords(67, 84)},
            {'C', new Coords(67, 667)},
            {'D', new Coords(69, 241)},
            {'E', new Coords(69, 510)},
            {'F', new Coords(70, 195)},
            {'G', new Coords(70, 556)},
            {'H', new Coords(72, 254)},
            {'I', new Coords(72, 497)},
            {'J', new Coords(73, 72)},
            {'K', new Coords(73, 679)},
            {'L', new Coords(74, 170)},
            {'M', new Coords(74, 581)},
            {'N', new Coords(75, 318)},
            {'O', new Coords(75, 433)},
            {'P', new Coords(78, 271)},
            {'Q', new Coords(78, 480)},
            {'R', new Coords(79, 111)},
            {'S', new Coords(79, 640)},
            {'T', new Coords(80, 318)},
            {'U', new Coords(80, 433)},
            {'V', new Coords(82, 270)},
            {'W', new Coords(82, 481)},
            {'X', new Coords(83, 373)},
            {'Y', new Coords(83, 378)},
            {'Z', new Coords(85, 35)},
            {'[', new Coords(85, 716)},
            {'\\', new Coords(86, 25)},
            {']', new Coords(86, 726)},
            {'^', new Coords(90, 21)},
            {'_', new Coords(90, 730)},
            {'`', new Coords(93, 267)},
            {'a', new Coords(93, 484)},
            {'b', new Coords(98, 338)},
            {'c', new Coords(98, 413)},
            {'d', new Coords(99, 295)},
            {'e', new Coords(99, 456)},
            {'f', new Coords(100, 364)},
            {'g', new Coords(100, 387)},
            {'h', new Coords(102, 267)},
            {'i', new Coords(102, 484)},
            {'j', new Coords(105, 369)},
            {'k', new Coords(105, 382)},
            {'l', new Coords(106, 24)},
            {'m', new Coords(106, 727)},
            {'n', new Coords(108, 247)},
            {'o', new Coords(108, 504)},
            {'p', new Coords(109, 200)},
            {'q', new Coords(109, 551)},
            {'r', new Coords(110, 129)},
            {'s', new Coords(110, 622)},
            {'t', new Coords(114, 144)},
            {'u', new Coords(114, 607)},
            {'v', new Coords(115, 242)},
            {'w', new Coords(115, 509)},
            {'x', new Coords(116, 92)},
            {'y', new Coords(116, 659)},
            {'z', new Coords(120, 147)},
            {'{', new Coords(120, 604)},
            {'|', new Coords(125, 292)},
            {'}', new Coords(125, 459)},
            {'~', new Coords(126, 33)},
            {'А', new Coords(189, 297)},
            {'Б', new Coords(189, 454)},
            {'В', new Coords(192, 32)},
            {'Г', new Coords(192, 719)},
            {'Д', new Coords(194, 205)},
            {'Е', new Coords(194, 546)},
            {'Ж', new Coords(197, 145)},
            {'З', new Coords(197, 606)},
            {'И', new Coords(198, 224)},
            {'Й', new Coords(198, 527)},
            {'К', new Coords(200, 30)},
            {'Л', new Coords(200, 721)},
            {'М', new Coords(203, 324)},
            {'Н', new Coords(203, 427)},
            {'О', new Coords(205, 372)},
            {'П', new Coords(205, 379)},
            {'Р', new Coords(206, 106)},
            {'С', new Coords(206, 645)},
            {'Т', new Coords(209, 82)},
            {'У', new Coords(209, 669)},
            {'Ф', new Coords(210, 31)},
            {'Х', new Coords(210, 720)},
            {'Ц', new Coords(215, 247)},
            {'Ч', new Coords(215, 504)},
            {'Ш', new Coords(218, 150)},
            {'Щ', new Coords(218, 601)},
            {'Ъ', new Coords(221, 138)},
            {'Ы', new Coords(221, 613)},
            {'Ь', new Coords(226, 9)},
            {'Э', new Coords(226, 742)},
            {'Ю', new Coords(227, 299)},
            {'Я', new Coords(227, 452)},
            {'а', new Coords(228, 271)},
            {'б', new Coords(228, 480)},
            {'в', new Coords(229, 151)},
            {'г', new Coords(229, 600)},
            {'д', new Coords(234, 164)},
            {'е', new Coords(234, 587)},
            {'ж', new Coords(235, 19)},
            {'з', new Coords(235, 732)},
            {'и', new Coords(236, 39)},
            {'й', new Coords(236, 712)},
            {'к', new Coords(237, 297)},
            {'л', new Coords(237, 454)},
            {'м', new Coords(238, 175)},
            {'н', new Coords(238, 576)},
            {'о', new Coords(240, 309)},
            {'п', new Coords(240, 442)},
            {'р', new Coords(243, 87)},
            {'с', new Coords(243, 664)},
            {'т', new Coords(247, 266)},
            {'у', new Coords(247, 485)},
            {'ф', new Coords(249, 183)},
            {'х', new Coords(249, 568)},
            {'ц', new Coords(250, 14)},
            {'ч', new Coords(250, 737)},
            {'ш', new Coords(251, 245)},
            {'щ', new Coords(251, 506)},
            {'ъ', new Coords(253, 211)},
            {'ы', new Coords(253, 540)},
            {'ь', new Coords(256, 121)},
            {'э', new Coords(256, 630)},
            {'ю', new Coords(257, 293)},
            {'я', new Coords(257, 458)},
        };
        public static Dictionary<int, string> OpenTexts = new Dictionary<int, string>
    {
        {1, "передряга"},
        {2, "латышский"},
        {3, "регрессор"},
        {4, "симметрия"},
        {5, "уверовать"},
        {6, "терновник"},
        {7, "терпеливо"},
        {8, "ремонтный"},
        {9, "ренессанс"},
        {10, "репарация"},
        {11, "пролежень"},
        {12, "прокрутка"},
        {13, "прокопать"},
        {14, "отступить"},
        {15, "отставной"},
        {16, "отслужить"},
        {17, "отследить"},
        {18, "новенький"},
        {19, "нищенский"},
        {20, "никелевый"},
        {21, "низменный"},
        {22, "неэтичный"},
        {23, "мысленный"},
        {24, "муштровка"},
        {25, "латентный"},
        {26, "купальщик"},
        {27, "излечимый"},
        {28, "звездочка"},
        {29, "аберрация"},
        {30, "белиберда"}
    };
        public static Dictionary<int, Coords> PublicKeyB = new Dictionary<int, Coords>
    {
        {1, new Coords(489, 468)},
        {2, new Coords(179, 275)},
        {3, new Coords(425, 663)},
        {4, new Coords(179, 275)},
        {5, new Coords(425, 663)},
        {6, new Coords(188, 93)},
        {7, new Coords(725, 195)},
        {8, new Coords(188, 93)},
        {9, new Coords(725, 195)},
        {10, new Coords(435, 663)},
        {11, new Coords(179, 275)},
        {12, new Coords(618, 206)},
        {13, new Coords(489, 468)},
        {14, new Coords(188, 93)},
        {15, new Coords(286, 136)},
        {16, new Coords(16, 416)},
        {17, new Coords(188, 93)},
        {18, new Coords(425, 663)},
        {19, new Coords(489, 468)},
        {20, new Coords(568, 355)},
        {21, new Coords(286, 136)},
        {22, new Coords(489, 468)},
        {23, new Coords(346, 242)},
        {24, new Coords(618, 206)},
        {25, new Coords(725, 195)},
        {26, new Coords(188, 93)},
        {27, new Coords(179, 275)},
        {28, new Coords(725, 195)},
        {29, new Coords(56, 419)},
        {30, new Coords(286, 136)}
    };
        public static Dictionary<int, List<int>> RandK = new Dictionary<int, List<int>>
    {
        {1, new List<int> {18, 15, 14, 18, 5, 10, 19, 14, 19}},
        {2, new List<int> {15, 17, 12, 2, 2, 4, 8, 6, 17}},
        {3, new List<int> {6, 12, 16, 4, 9, 4, 19, 9, 18}},
        {4, new List<int> {11, 17, 18, 19, 16, 6, 12, 8, 2}},
        {5, new List<int> {6, 14, 5, 7, 12, 11, 4, 9, 19}},
        {6, new List<int> {8, 14, 17, 17, 2, 10, 8, 2, 2}},
        {7, new List<int> {17, 5, 4, 17, 13, 2, 17, 14, 19}},
        {8, new List<int> {2, 2, 4, 18, 15, 19, 11, 2, 15}},
        {9, new List<int> {2, 19, 4, 8, 2, 2, 16, 10, 2}},
        {10, new List<int> {12, 11, 18, 7, 16, 18, 17, 2, 3}},
        {11, new List<int> {9, 5, 17, 2, 2, 3, 17, 15}},
        {12, new List<int> {10, 15, 16, 2, 3, 4, 2, 11, 16}},
        {13, new List<int> {3, 16, 17, 5, 16, 18, 3, 7, 15}},
        {14, new List<int> {7, 9, 3, 8, 18, 18, 8, 11, 16}},
        {15, new List<int> {5, 3, 3, 2, 4, 19, 2, 4, 10}},
        {16, new List<int> {2, 8, 4, 2, 6, 10, 3, 3, 18}},
        {17, new List<int> {19, 2, 13, 5, 19, 5, 7, 8, 5}},
        {18, new List<int> {19, 12, 13, 2, 12, 14, 19, 18, 12}},
        {19, new List<int> {2, 2, 7, 11, 19, 4, 2, 15, 6}},
        {20, new List<int> {9, 9, 2, 3, 8, 19, 6, 18, 9}},
        {21, new List<int> {12, 5, 7, 17, 18, 2, 12, 10, 11}},
        {22, new List<int> {14, 18, 11, 11, 6, 6, 17, 2, 5}},
        {23, new List<int> {6, 17, 18, 11, 18, 2, 4, 2, 12}},
        {24, new List<int> {5, 19, 8, 2, 5, 8, 15, 19, 6}},
        {25, new List<int> {9, 10, 13, 2, 2, 12, 12, 5, 7}},
        {26, new List<int> {17, 17, 9, 12, 17, 7, 15, 7, 16}},
        {27, new List<int> {10, 14, 2, 2, 10, 10, 14, 3, 7}},
        {28, new List<int> {11, 17, 10, 10, 5, 2, 10, 19, 4}},
        {29, new List<int> {16, 2, 17, 19, 8, 4, 3, 2, 8}},
        {30, new List<int> {2, 9, 18, 2, 19, 4, 5, 11, 9}}
    };
        public static List<(long, List<(Coords, Coords)>)> CipherTextCon = new List<(long, List<(Coords, Coords)>)>
        {
            (29, new List<(Coords, Coords)>{
                (new Coords(440, 539), new Coords(128, 672)),
                (new Coords(489, 468), new Coords(282, 341)),
                (new Coords(425, 663), new Coords(106, 24)),
                (new Coords(568, 355), new Coords(145, 608)),}),

            (12, new List<(Coords, Coords)>{
                (new Coords(16, 416),  new Coords(128, 672)),
                (new Coords(56, 419),  new Coords(59, 386)), 
                (new Coords(425, 663), new Coords(106, 24)),
                (new Coords(568, 355), new Coords(145, 608)),
                (new Coords(188, 93),  new Coords(279, 398)),
                (new Coords(425, 663), new Coords(99, 295)),
                (new Coords(179, 275), new Coords(269, 187)),
                (new Coords(188, 93),  new Coords(395, 337)),
                (new Coords(188, 93),  new Coords(311, 68)),
                (new Coords(135, 82),  new Coords(556, 484)),
                (new Coords(56, 419),  new Coords(106, 727)),
                (new Coords(16, 416),  new Coords(307, 693)),}),

            (0, new List<(Coords, Coords)>{
                (new Coords(179, 275), new Coords(663, 275)),
                (new Coords(1, 1),     new Coords(638, 131)),
                (new Coords(327, 108), new Coords(228, 480)),
                (new Coords(179, 275), new Coords(329, 447)),
                (new Coords(283, 258), new Coords(463, 736)),
                (new Coords(286, 136), new Coords(688, 741)),
                (new Coords(179, 275), new Coords(407, 669)),
                (new Coords(135, 669), new Coords(6, 218)),
                (new Coords(591, 555), new Coords(561, 140))}),
        };

        public static bool checkCoords(List<long> abm, Coords xy)
        {
            long x = Mod(FastPowMod(xy.x, 3, abm[2]) + abm[0] * xy.x + abm[1], abm[2]);
            long y = FastPowMod(xy.y, 2, abm[2]);
            return x == y;
        }
        public static Coords AddFunc(Coords P, Coords R, List<long> abm)
        {
            long m = abm[2];
            Coords nul = new Coords(0, 0);

            if (R.equals(nul))
            {
                return P;
            }
            else if (P.equals(nul))
            {
                return R;
            }
            else if (P.equals(R))
            {
                return MulFunc(P, abm);
            }
            else
            {
                long lambda1 = R.y - P.y;
                long lambda2 = R.x - P.x;
                if (lambda2 == 0)
                {
                    return new Coords(0, 0);
                }
                else
                {
                    long lambda = Mod(lambda1 * InversElem(lambda2, m), m);
                    Coords t = JokeFunc(R, P, m, lambda);
                    return t;
                }
            }
        }
        public static Coords MulFunc(Coords R, List<long> abm)
        {
            Coords nul = new Coords(0, 0);

            if (R.equals(nul))
            {
                return R;
            }
            else
            {
                long m = abm[2];
                long lambda1 = 3 * FastPowMod(R.x, 2, m) + abm[0];
                long lambda2 = 2 * R.y;
                if (lambda2 == 0)
                {
                    return nul;
                }
                else
                {
                    long lambda = Mod(lambda1 * InversElem(lambda2, m), m);
                    Coords t = JokeFunc(R, R, m, lambda);
                    return t;
                }
            }
        }
        public static Coords JokeFunc(Coords p, Coords q, long m, long lambda)
        {
            long x = Mod(FastPowMod(lambda, 2, m) - p.x - q.x, m);
            long y = Mod(lambda * (p.x - x) - p.y, m);
            return new Coords(x, y);
        }
        public static Coords SkalMul(Coords p, long n, List<long> abm)
        {
            List<long> bin = Convert.ToString(n, 2).Select(c => long.Parse(c.ToString())).ToList();

            Coords R = new Coords(0, 0);

            foreach (long item in bin)
            {
                R = MulFunc(R, abm);

                if (item == 1)
                {
                    R = AddFunc(p, R, abm);
                }
            }
            return R;
        }
    }
}
