namespace Лабораторные_работы
{
    public class LCGParameterSet
    {
        public int A { get; set; }
        public int B { get; set; }
        public int M { get; set; }

        public LCGParameterSet(int a, int b, int m)
        {
            A = a;
            B = b;
            M = m;
        }
    }
}