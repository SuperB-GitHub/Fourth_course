class Lab3
{
    static void Main()
    {
        List<Книга> книгаs = new List<Книга>
        {
           new Книга(1001, "Лев Толстой", 2005, 120),
           new Книга(1002, "Фёдор Достоевский", 2010, 80),
           new Книга(1003, "Лев Толстой", 2012, 150),
           new Книга(1004, "Александр Пушкин", 2007, 200),
           new Книга(1005, "Лев Толстой", 2017, 100),
           new Книга(1006, "Фёдор Достоевский", 2015, 90),
           new Книга(1007, "Александр Пушкин", 2018, 60),
           new Книга(1008, "Михаил Лермонтов", 2011, 75),
           new Книга(1009, "Лев Толстой", 2009, 130),
           new Книга(1010, "Фёдор Достоевский", 2006, 95)
        };

        Console.Write("Введите имя автора: ");
        string Автор = Console.ReadLine();
        int Количество = ПодсчётЭкземпляров(книгаs, Автор);

        Console.WriteLine($"Общее количество экземпляров книг автора \"{Автор}\", изданных с 2007 по 2016 гг.: {Количество}");
        Console.ReadKey();
    }

    static int ПодсчётЭкземпляров(List<Книга> книги, string автор)
    {
        int sum = 0;
        foreach (var книга in книги)
        {
            if (книга.Автор.Contains(автор) && книга.Год >= 2007 && книга.Год <= 2016)
            {
                sum += книга.Кол_во;
            }
        }
        return sum;
    }
}

class Книга
{
    private long _ЕРН;
    private string? _Автор;
    private int _Год;
    private int _Кол_во;

    public Книга(long ЕРН, string Автор, int Год, int Кол_во)
    {
        _ЕРН = ЕРН;
        _Автор = Автор;
        _Год = Год;
        _Кол_во = Кол_во;
    }

    public long ЕРН
    {
        get { return _ЕРН; }
        set { _ЕРН = value; }
    }

    public string Автор
    {
        get { return _Автор; }
        set
        {
            if (value.Length > 20)
                throw new ArgumentException("Автор не может содержать более 20 символов.");
            _Автор = value;
        }
    }
    public int Год
    {
        get { return _Год; }
        set { _Год = value; }
    }

    public int Кол_во
    {
        get { return _Кол_во; }
        set { _Кол_во = value; }
    }

    public void ВыводИнфо()
    {
        Console.WriteLine($"Единый регистрационный номер: {_ЕРН}");
        Console.WriteLine($"Автор: {_Автор}");
        Console.WriteLine($"Год издания: {_Год}");
        Console.WriteLine($"Количество экземпляров: {_Кол_во}");
        Console.WriteLine(new string('-', 30));
    }
}