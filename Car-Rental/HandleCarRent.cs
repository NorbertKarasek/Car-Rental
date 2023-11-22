using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars;
using Clients;

namespace Handle_Car_Rental
{
    internal class HandleRental

    {
        internal static void HandleRentCarOption()
        {
            while (true)
            {
                Console.WriteLine("W celu wynajęcia auta, podaj ID klienta: ");
                if (!int.TryParse(Console.ReadLine(), out int selectedClientId))
                {
                    Console.Write("Błędny format ID klienta, podaj numer: ");
                    continue; // Ask for input again
                }
                else if (selectedClientId < 1 || selectedClientId > Client.ClientList.Count)
                {
                    Console.Write("Nie ma klienta o takim numerze ID, podaj prawidłowy numer: ");
                    continue; // Ask for input again
                }

                Client selectedClient = Client.GetClientById(selectedClientId);

                Console.WriteLine($"Witamy, {selectedClient.FullName}");
                Console.Write("Który samochód chcesz wynająć? Podaj numer samochodu: ");

                if (!int.TryParse(Console.ReadLine(), out int selectedCarIndex))
                {
                    Console.Write("Błędny format ID samochodu, podaj numer: ");
                    continue; // Ask for input again
                }
                else if (selectedCarIndex < 1 || selectedCarIndex > Car.carsList.Count)
                {
                    Console.Write("Niepoprawny numer samochodu");
                    continue; // Ask for input again
                }
                else if (!Car.carsList[selectedCarIndex - 1].available)
                {
                    Console.Write("Samochód jest niedostępny");
                    continue;
                }
                Car selectedCar = Car.GetCarByIndex(selectedCarIndex);
                Console.WriteLine($"Cena za jeden dzień wynajmu {selectedCar.carBrand} to {selectedCar.price} PLN");

                Console.Write("Na ile dni chcesz wynająć auto? ");
                if (!int.TryParse(Console.ReadLine(), out int rentalDuration))
                {
                    Console.WriteLine("Błędny format tekstu, podaj liczbę");
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
    }
}
        
