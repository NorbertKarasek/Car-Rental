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
        internal static void HandleRentCarOption() // Whole procedure of renting car
        {// TRZEBA TERAZ PODZIELIC ABY CONTINUE WRACAŁO DO AKTUALNEGO READLINE NIE ZAWSZE DO POCZATKU!
            while (true)
            {
                Console.WriteLine("Wynajem auta, podaj ID klienta: ");
                if (!int.TryParse(Console.ReadLine(), out int selectedClientId)) // if ID is not int
                {
                    Console.WriteLine("Błędny format ID klienta, podaj numer: ");
                    continue; // Ask for input again
                }
                else if (selectedClientId < 1 || selectedClientId > Client.ClientList.Count) // If its out of client list index
                {
                    Console.WriteLine("Nie ma klienta o takim numerze ID, podaj prawidłowy ID: ");
                    continue; // Ask for input again
                }

                Client selectedClient = Client.GetClientById(selectedClientId); // Set selected client in variable
                int DLicenseDuration = DateTime.Now.Year - selectedClient.LicenseDate.Year; // check lenght of driver license

                Console.WriteLine($"Witamy, {selectedClient.FullName}");
                Console.WriteLine("Który samochód chcesz wynająć? Podaj numer samochodu: ");

                CarIdRetry:
                if (!int.TryParse(Console.ReadLine(), out int selectedCarIndex)) // if id is not int
                {
                    Console.Write("Błędny format ID samochodu, podaj numer: ");
                    goto CarIdRetry; // Ask for input again
                }
                else if (selectedCarIndex < 1 || selectedCarIndex > Car.carsList.Count) // if its out of cars list index
                {
                    Console.Write("Nie ma takiego samochodu, wybierz poprawy numer: ");
                    goto CarIdRetry; // Ask for input again
                }
                else if (!Car.carsList[selectedCarIndex - 1].available) // if car is unavailable
                {
                    Console.Write("Samochód jest niedostępny, wybierz inny: ");
                    goto CarIdRetry;
                }

                Car selectedCar = Car.GetCarByIndex(selectedCarIndex); // Set selected car in variable

                if (DLicenseDuration < 4 && selectedCar.carSegment == "premium") // check car segment and dlicense duration
                {
                    Console.Write("Z uwagi na krótki okres posiadania prawa jazdy, nie możesz wynjąć auta segmentu premium\nWybierz inny samochód: ");
                    goto CarIdRetry;
                }
                int priceForClient = DLicenseDuration < 4 ? (int)(selectedCar.price * 1.20) : selectedCar.price;
                Console.WriteLine($"Cena za jeden dzień wynajmu {selectedCar.carBrand} to {priceForClient} PLN");
                Console.WriteLine("Na ile dni chcesz wynająć auto? ");

                RentDaysRetry:
                if (!int.TryParse(Console.ReadLine(), out int rentalDuration)) // if amount of days is not int
                {
                    Console.Write("Błędny format tekstu, podaj liczbę dni: ");
                    goto RentDaysRetry; // Ask for input again
                }

                int TotalCost = priceForClient * rentalDuration;
                var additionalDays = 0;

                if (rentalDuration >= 7 && rentalDuration < 30)
                {
                    additionalDays = 1;
                }
                else if (rentalDuration >= 30)
                {
                    additionalDays = 3;
                }

                var ReturnDate = DateTime.Now.AddDays(rentalDuration + additionalDays);

                Console.WriteLine($"Samochód należy oddać w dniu {ReturnDate.ToShortDateString()}");
                Console.WriteLine($"Całkowity koszt wynajmu to {TotalCost}");
                Car.RentCar(selectedCar);
                break;
            }
        }
    }
}
        
