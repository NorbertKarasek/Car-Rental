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
            while (true)
            {
                Console.WriteLine("Podaj ID klienta: ");
                if (!int.TryParse(Console.ReadLine(), out int selectedClientId))
                {
                    Console.WriteLine("Niepoprawny numer ID klienta");
                    continue; // Ask for input again
                }

                Client selectedClient = GetClientById(selectedClientId);

                if (selectedClientId < 1 || selectedClientId > Client.ClientList.Count)
                {
                    Console.WriteLine("Niepoprawny numer ID klienta");
                    continue; // Ask for input again
                }

                Console.WriteLine($"Witamy, {selectedClient.FullName}");
                Console.Write("Który samochód chcesz wynająć? Podaj numer samochodu: ");

                if (!int.TryParse(Console.ReadLine(), out int selectedCarIndex))
                {
                    Console.WriteLine("Niepoprawny numer samochodu.");
                    continue; // Ask for input again
                }

                if (selectedCarIndex < 1 || selectedCarIndex > Car.carsList.Count || !Car.carsList[selectedCarIndex - 1].available)
                {
                    Console.WriteLine("Niepoprawny numer samochodu");
                    continue; // Ask for input again
                }

                Car selectedCar = GetCarByIndex(selectedCarIndex);
                Console.WriteLine($"Cena za jeden dzień wynajmu {selectedCar.carBrand} to {selectedCar.price} PLN");

                Console.Write("Na ile dni chcesz wynająć auto? ");
                if (!int.TryParse(Console.ReadLine(), out int rentalDuration))
                {
                    Console.WriteLine("Niepoprawna liczba dni.");
                    continue; // Ask for input again
                }

                int DLicenseDuration = DateTime.Now.Year - selectedClient.LicenseDate.Year;
                int TotalCost;

                if (DLicenseDuration < 4)
                {
                    TotalCost = (int)(rentalDuration * (selectedCar.price * 1.20));
                }
                else
                {
                    TotalCost = rentalDuration * selectedCar.price;
                }
                var ReturnDate = DateTime.Now.AddDays(rentalDuration);
                Console.WriteLine($"Całkowity koszt wynajmu to {TotalCost}");
                Console.WriteLine($"Samochód należy oddać w dniu {ReturnDate.ToShortDateString()}");
                Car.RentCar(selectedCar);
                break;
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
        
