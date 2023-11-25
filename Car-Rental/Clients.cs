using System;
using System.Collections.Generic;
using System.ComponentModel.Design;


namespace Clients
{
    public class Client
    {
        public string FullName { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime LicenseDate;
        public static List<Client> ClientList = new List<Client>();
        public Client(string fullName, int year, int month, int day) // Constructor
        {
            FullName = fullName;
            Day = day;
            Month = month;
            Year = year;
            LicenseDate = new DateTime(year, month, day);
            ClientList.Add(this);
        }

        public static void GetClientsList() // Show clients list with all informations
        {
            Console.WriteLine("ID | IMIE I NAZWISKO | DATA UZYSKANIA PRAWA JAZDY");
            int i = 1;
            foreach (Client client in ClientList)
            {
                Console.WriteLine($"{i}| {client.FullName} | {client.LicenseDate.ToShortDateString()} ");
                i++;
            }
        }
        public static Client GetClientById(int clientId) // Get client from a clients list by index
        {
            if (clientId >= 1 && clientId <= Client.ClientList.Count)
            {
                return Client.ClientList[clientId - 1];
            }
            return null; // Client ID is out of range
        }
    }
}