﻿
using System.Drawing;

static int CompareTransportationsBySideNumberOfTheBus(PassengertTansportation a, PassengertTansportation b)
{
    return a.sideNumberOfTheBus!.CompareTo(b.sideNumberOfTheBus!);
}

static void SortTransportationsBySideNumberOfTheBus(PassengertTansportation[] transportations)
{
    Array.Sort(transportations, CompareTransportationsBySideNumberOfTheBus);
    Console.Clear();
}

static int CompareTransportationsByBrandOfTheBus(PassengertTansportation a, PassengertTansportation b)
{
    return a.brandOfTheBus!.CompareTo(b.brandOfTheBus!);
}

static void SortTransportationsTransportationsByBrandOfTheBus(PassengertTansportation[] transportations)
{
    Array.Sort(transportations, CompareTransportationsByBrandOfTheBus);
    Console.Clear();
}

static int CompareTransportationsByRouteNumber(PassengertTansportation a, PassengertTansportation b)
{
    return a.routeNumber!.CompareTo(b.routeNumber!);
}

static void SortTransportationsTransportationsByRouteNumber(PassengertTansportation[] transportations)
{
    Array.Sort(transportations, CompareTransportationsByRouteNumber);
    Console.Clear();
}

static int CompareTransportationsByFullNameOfTheDriver(PassengertTansportation a, PassengertTansportation b)
{
    return a.fullNameOfTheDriver!.CompareTo(b.fullNameOfTheDriver!);
}

static void SortTransportationsTransportationsByFullNameOfTheDriver(PassengertTansportation[] transportations)
{
    Array.Sort(transportations, CompareTransportationsByFullNameOfTheDriver);
    Console.Clear();
}

static int CompareTransportationsByDateOfWork(PassengertTansportation a, PassengertTansportation b)
{
    return a.dateOfWork!.CompareTo(b.dateOfWork!);
}

static void SortTransportationsTransportationsByDateOfWork(PassengertTansportation[] transportations)
{
    Array.Sort(transportations, CompareTransportationsByDateOfWork);
    Console.Clear();
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