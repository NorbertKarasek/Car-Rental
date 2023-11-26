using System;
using System.Runtime.ConstrainedExecution;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Car_Rental;

class Program
{
    private const string ListCarsOption = "1";
    private const string ListClientsOption = "2";
    private const string RentCarOption = "3";
    private const string ExitOption = "4";
    static void Main()
    {
        Data.CreateCars();
        Data.CreateClients();

        while (true)
        {
            HandleRental.ShowMenu();
            string option = Console.ReadLine();

            switch (option)
            {
                case ListCarsOption:
                    Car.GetCarsList();
                    break;

                case ListClientsOption:
                    Client.GetClientsList();
                    break;

                case RentCarOption:
                    HandleRental.HandleRentCarOption();
                    break;

                case ExitOption:
                    return;
                default:
                    Console.WriteLine("Niepoprawny wybór");
                    break;
            }
        }
    }
}