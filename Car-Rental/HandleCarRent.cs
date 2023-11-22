using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handle_Car_Rental
{
    internal class HandleRental

    {
        internal static void HandleRentCarOption()
        {
            Console.WriteLine("Podaj ID klienta: ");
            if (int.TryParse(Console.ReadLine(), out int selectedClientId))
            {
                Client selectedClient = GetClientById(selectedClientId);
                if (selectedClient != null)
                {
                    Console.WriteLine($"Witamy, {selectedClient.FullName}");

                    Console.Write("Który samochód chcesz wynająć? Podaj numer samochodu: ");
                    if (int.TryParse(Console.ReadLine(), out int selectedCarIndex))
                    {
                        Car selectedCar = GetCarByIndex(selectedCarIndex);
                        if (selectedCar != null && selectedCar.available)
                        {
                            Console.WriteLine($"Cena za jeden dzień wynajmu {selectedCar.carBrand} to {selectedCar.price} PLN");
                            Console.Write("Na ile dni chcesz wynająć auto? ");
                            if (int.TryParse(Console.ReadLine(), out int rentalDuration))
                            {
                                int TotalCost = rentalDuration * selectedCar.price;
                                Console.WriteLine($"Całkowity koszt wynajmu to {TotalCost}");
                                Car.RentCar(selectedCar);
                            }
                            else
                            {
                                Console.WriteLine("Niepoprawna liczba dni.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Niepoprawny numer samochodu");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawny numer samochodu.");
                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawny numer ID klienta");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawny numer ID");
            }
        }
        static Car GetCarByIndex(int index)
        {
            if (index >= 1 && index <= Car.carsList.Count)
            {
                return Car.carsList[index - 1];
            }

            return null; // Index is out of range
        }
        static Client GetClientById(int clientId)
        {
            if (clientId >= 1 && clientId <= Client.ClientList.Count)
            {
                return Client.ClientList[clientId - 1];
            }

            return null; // Client ID is out of range
        }
    }
}
        
