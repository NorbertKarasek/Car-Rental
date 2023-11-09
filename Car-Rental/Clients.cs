using System;
using System.Collections.Generic;

public class Client
{
    public string FullName { get; set; }
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public DateTime LicenseDate { get; set; }
    public DateTime ActualTime { get; set; }
    public static List<Client> ClientList = new List<Client>();

    public Client(string fullName, int year, int month, int day)
    {
        FullName = fullName;
        Day = day;
        Month = month;
        Year = year;
        LicenseDate = new DateTime(year, month, day);
        ActualTime = DateTime.Now;
        ClientList.Add(this);
    }

    public static void GetClientsList()
    {
        Console.WriteLine("ID | IMIE I NAZWISKO | DATA UZYSKANIA PRAWA JAZDY");
        int i = 1;
        foreach (Client client in ClientList)
        {
            Console.WriteLine($"{i}| {client.FullName} | {client.LicenseDate.ToShortDateString()} ");
            i++;
        }
    }
}