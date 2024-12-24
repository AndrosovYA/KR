
using System.Drawing;

static void SortTransportationsBySideNumberOfTheBus(List<PassengertTansportation> transportations)
{
    transportations.Sort((x, y) => x.sideNumberOfTheBus.CompareTo(y.sideNumberOfTheBus));
}

static void SortTransportationsTransportationsByBrandOfTheBus(List<PassengertTansportation> transportations)
{
    transportations.Sort((x, y) => x.brandOfTheBus.CompareTo(y.brandOfTheBus));
}

static void SortTransportationsTransportationsByRouteNumber(List<PassengertTansportation> transportations)
{
    transportations.Sort((x, y) => x.routeNumber.CompareTo(y.routeNumber));
}

static void SortTransportationsTransportationsByFullNameOfTheDriver(List<PassengertTansportation> transportations)
{
    transportations.Sort((x, y) => x.fullNameOfTheDriver.CompareTo(y.fullNameOfTheDriver));
}

static void SortTransportationsTransportationsByDateOfWork(List<PassengertTansportation> transportations)
{
    transportations.Sort((x, y) => x.dateOfWork.CompareTo(y.dateOfWork));
}

static List<PassengertTansportation> FindPassengerTransportationBySideNumberOfTheBus(List<PassengertTansportation> transportations, int sideNumberOfTheBus)
{
    return transportations.FindAll(x => x.sideNumberOfTheBus == sideNumberOfTheBus);
}

static List<PassengertTansportation> FindPassengerTransportationByBrandOfTheBus(List<PassengertTansportation> transportations, string brandOfTheBus)
{
    return transportations.FindAll(x => x.brandOfTheBus == brandOfTheBus);
}

static List<PassengertTansportation> FindPassengerTransportationByRouteNumber(List<PassengertTansportation> transportations, int routeNumber)
{
    return transportations.FindAll(x => x.routeNumber == routeNumber);
}

static List<PassengertTansportation> FindPassengerTransportationByDateOfWork(List<PassengertTansportation> transportations, DateOnly startTimeOfWork, DateOnly endTimeOfWork)
{
    return transportations.FindAll(x => x.dateOfWork >= startTimeOfWork && x.dateOfWork <= endTimeOfWork);
}

static List<PassengertTansportation> FindPassengerTransportationByFullNameOfTheDriver(List<PassengertTansportation> transportations, string fullNameOfTheDriver)
{
    return transportations.FindAll(x => x.fullNameOfTheDriver == fullNameOfTheDriver);
}

struct PassengertTansportation
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
    public string brand;
    public string fullName;
}