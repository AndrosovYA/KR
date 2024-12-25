using System.Drawing;
using System.Text;

public static void Main()
{
    Console.OutputEncoding = Encoding.UTF8;
    Console.Clear();

    StreamReader srReferenceBookOfBrandOfTheBus = new("..\\..\\..\\DataFiles\\ReferenceBookOfBrandOfTheBus.txt"),
    srReferenceBookOfFullNameOfTheDriver = new("..\\..\\..\\DataFiles\\ReferenceBookOfFullNameOfTheDriver.txt"),
    srTransportation = new("..\\..\\..\\DataFiles\\Transportations.txt");
    List<Transportation> transportations = ReadTransportationsFromFile(srTransportation);
    List<ReferenceBook> referenceBookOfBrandOfTheBus = ReadReferenceBookFromFile(srReferenceBookOfBrandOfTheBus),
    referenceBookOfFullNameOfTheDriver = ReadReferenceBookFromFile(srReferenceBookOfFullNameOfTheDriver);
    srReferenceBookOfBrandOfTheBus.Close();
    srReferenceBookOfFullNameOfTheDriver.Close();
    srTransportation.Close();
}

public static void MainMenu(List<Transportation> transportations,
                     List<ReferenceBook> referenceBookOfBrandOfTheBus,
                     List<ReferenceBook> srReferenceBookOfFullNameOfTheDriver)
{
    while (true)
    {
        Console.WriteLine("Выберете один из вариантов работы с Базой данных:");
        Console.WriteLine("1) Редактирование БД");
        Console.WriteLine("2) Редактирование справочников");
        Console.WriteLine("3) Вывод данных");
        Console.WriteLine("4) Поиск в БД");
        Console.WriteLine("5) Сортировка записей");
        Console.WriteLine("6) Создать отчёт");
        Console.WriteLine("0) Сохранить и выйти");
        Console.ResetColor();
        if (IsValidOption(out int option))
        {
            Console.Clear();
            switch (option)
            {
                case 1:
                    EditDBMenu(transportations, referenceBookOfBrandOfTheBus, srReferenceBookOfFullNameOfTheDriver);
                    break;
                case 2:
                    EditReferenceBooksMenu(referenceBookOfBrandOfTheBus, srReferenceBookOfFullNameOfTheDriver);
                    break;
                case 3:
                    OutputMenu(transportations, referenceBookOfBrandOfTheBus, srReferenceBookOfFullNameOfTheDriver);
                    break;
                case 4:
                    SearchMenu(transportations, referenceBookOfBrandOfTheBus, srReferenceBookOfFullNameOfTheDriver);
                    break;
                case 5:
                    SortMenu(transportations, referenceBookOfBrandOfTheBus, srReferenceBookOfFullNameOfTheDriver);
                    break;
                case 6:
                    ReportMenu(transportations, referenceBookOfBrandOfTheBus, srReferenceBookOfFullNameOfTheDriver);
                    break;
                case 0:
                    Console.WriteLine("Выход из программы");
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Отсутствует опция под номером {option}");
                    Console.ResetColor();
                    break;
            }
        }
    }
}


#region Read
public static List<Transportation> ReadTransportationsFromFile(StreamReader srTransportation)
{
    Type type = new Transportation().GetType();
    int n = srTransportation.ReadToEnd().Split('\n').Length / type.GetFields().Length;
    srTransportation.BaseStream.Position = 0;

    List<Transportation> transportations = [];
    for (int i = 0; i < n; i++)
    {
        transportations.Add(ReadTransportationFromFile(srTransportation));
    }
    return transportations;
}
public static Transportation ReadTransportationFromFile(StreamReader srTransportation)
{
    Transportation transportation = new()
    {
        sideNumberOfTheBus = Convert.ToInt32(srTransportation.ReadLine()),
        brandOfTheBus = srTransportation.ReadLine()!,
        routeNumber = Convert.ToInt32(srTransportation.ReadLine()),
        fullNameOfTheDriver = srTransportation.ReadLine()!,
        dateOfWork = DateOnly.Parse(srTransportation.ReadLine()!),
        startTimeOfWork = DateOnly.Parse(srTransportation.ReadLine()!),
        endTimeOfWork = DateOnly.Parse(srTransportation.ReadLine()!),
        revenue = Convert.ToDouble(srTransportation.ReadLine()!)
    };
    return transportation;
}
public static List<ReferenceBook> ReadReferenceBookFromFile(StreamReader srReferenceBook)
{
    int n = srReferenceBook.ReadToEnd().Split('\n').Length;
    srReferenceBook.BaseStream.Position = 0;

    List<ReferenceBook> referenceBook = [];
    ReferenceBook item;
    for (int i = 0; i < n; i++)
    {
        item.title = srReferenceBook.ReadLine()!;
        item.ID = i;
        referenceBook.Add(item);
    }
    return referenceBook;
}
#endregion

#region Sort
static void SortTransportationsBySideNumberOfTheBus(List<Transportation> transportations)
{
    transportations.Sort((x, y) => x.sideNumberOfTheBus.CompareTo(y.sideNumberOfTheBus));
}

static void SortTransportationsByBrandOfTheBus(List<Transportation> transportations)
{
    transportations.Sort((x, y) => x.brandOfTheBus.CompareTo(y.brandOfTheBus));
}

static void SortTransportationsByRouteNumber(List<Transportation> transportations)
{
    transportations.Sort((x, y) => x.routeNumber.CompareTo(y.routeNumber));
}

static void SortTransportationsByFullNameOfTheDriver(List<Transportation> transportations)
{
    transportations.Sort((x, y) => x.fullNameOfTheDriver.CompareTo(y.fullNameOfTheDriver));
}

static void SortTransportationsByDateOfWork(List<Transportation> transportations)
{
    transportations.Sort((x, y) => x.dateOfWork.CompareTo(y.dateOfWork));
}
#endregion

#region Search
static List<Transportation> FindTransportationBySideNumberOfTheBus(List<Transportation> transportations, int sideNumberOfTheBus)
{
    return transportations.FindAll(x => x.sideNumberOfTheBus == sideNumberOfTheBus);
}

static List<Transportation> FindTransportationByBrandOfTheBus(List<Transportation> transportations, string brandOfTheBus)
{
    return transportations.FindAll(x => x.brandOfTheBus == brandOfTheBus);
}

static List<Transportation> FindTransportationByRouteNumber(List<Transportation> transportations, int routeNumber)
{
    return transportations.FindAll(x => x.routeNumber == routeNumber);
}

static List<Transportation> FindTransportationByDateOfWork(List<Transportation> transportations, DateOnly startTimeOfWork, DateOnly endTimeOfWork)
{
    return transportations.FindAll(x => x.dateOfWork >= startTimeOfWork && x.dateOfWork <= endTimeOfWork);
}

static List<Transportation> FindTransportationByFullNameOfTheDriver(List<Transportation> transportations, string fullNameOfTheDriver)
{
    return transportations.FindAll(x => x.fullNameOfTheDriver == fullNameOfTheDriver);
}
#endregion

#region IsValid

public static bool IsValid(out int option, int? start = null, int? end = null)
{
    if (int.TryParse(Console.ReadLine(), out option) && (start == null || option >= start) && (end == null || option <= end))
    {
        return true;
    }
    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Неверный ввод, повторите попытку ввода");
        Console.ResetColor();
        return false;
    }
}

public static bool IsValidOption(out int option)
{
    return IsValid(out option, 0);
}
#endregion

struct Transportation
{
    public int sideNumberOfTheBus;
    public string brandOfTheBus;
    public int routeNumber;
    public string fullNameOfTheDriver;
    public DateOnly dateOfWork;
    public DateOnly startTimeOfWork;
    public DateOnly endTimeOfWork;
    public double revenue;
}

struct ReferenceBook
{
    public int ID;
    public string title;
}