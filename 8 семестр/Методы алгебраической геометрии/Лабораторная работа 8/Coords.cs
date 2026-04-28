using static MyLibrary.MathUtils;

namespace Лабораторная_работа_8
{
    public class Coords
    {
        public Coords()
        {
        }

        public Coords(long x, long y)
        {
            this.x = x;
            this.y = y;
        }

        public long x { get; set; }
        public long y { get; set; }

        public void insert(List<long> x_y)
        {
            x = x_y[0];
            y = x_y[1];
        }
        public string print()
        {
            return $"({x}, {y})";
        }
        public bool equals(Coords other)
        {
            return x == other.x && y == other.y ? true : false;
        }
        public bool contains(List<Coords> list)
        {
            foreach (Coords item in list)
            {
                if (x == item.x && y == item.y)
                {
                    return true;
                }
            }
            return false;
        }
        public long indexof(List<Coords> list)
        {
            for (long i = 0; i < list.Count(); i++)
            {
                Coords item = list[(int)i];
                if (x == item.x && y == item.y)
                {
                    return i;
                }
            }
            return -1;
        }
        public Coords invers(long m)
        {
            return new Coords(x, Mod(-y, m));
        }
    }
}
