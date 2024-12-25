using System.Drawing;



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