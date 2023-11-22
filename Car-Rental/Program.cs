using System;
using System.Runtime.ConstrainedExecution;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Handle_Car_Rental;

class Program
{
    private const string ListCarsOption = "1";
    private const string ListClientsOption = "2";
    private const string RentCarOption = "3";
    private const string ExitOption = "4";
    static void Main()
    {
        Console.WriteLine("!! Witamy w wypożyczalni samochodów !!");

        //Cars Data
        Car car1 = new Car("Škoda Citigo", "mini", "benzyna", 2014, 70);
        Car car2 = new Car("Toyota Aygo", "mini", "benzyna", 2020, 90);
        Car car3 = new Car("Fiat 500", "mini", "elektryczny", 2022, 110);
        Car car4 = new Car("Ford Focus", "kompakt", "diesel", 2018, 160);
        Car car5 = new Car("Kia Ceed", "kompakt", "benzyna", 2018, 150);
        Car car6 = new Car("Volkswagen Golf", "kompakt", "benzyna", 2019, 160);
        Car car7 = new Car("Hyundai Kona Electric", "kompakt", "elektryczny", 2021, 180);
        Car car8 = new Car("Audi A6 Allroad", "premium", "diesel", 2020, 290);
        Car car9 = new Car("Mercedes E270 AMG", "premium", "benzyna", 2019, 320);
        Car car10 = new Car("Tesla Model S", "premium", "elektryczny", 2022, 350);

        //Client Data
        Client client1 = new Client("Norbert Karasek", 2014, 01, 05);
        Client client2 = new Client("Magdalena Jaborska", 2013, 02, 15);
        Client client3 = new Client("Jan Nowak", 2021, 03, 04);
        Client client4 = new Client("Zofia Plucinska", 2010, 12, 18);
        Client client5 = new Client("Abroży Zbujnicki", 2022, 10, 11);



        while (true)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Lista  samochodów");
            Console.WriteLine("2. Lista klientów");
            Console.WriteLine("3. Wynajem auta");
            Console.WriteLine("4. Zakoncz");
            Console.Write("Wybierz opcję: ");
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