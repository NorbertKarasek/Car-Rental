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
                    Console.WriteLine("Nie ma klienta o takim numerze ID, podaj prawidłowy numer: ");
                    continue; // Ask for input again
                }

                Client selectedClient = Client.GetClientById(selectedClientId); // Set selected client in variable
                int DLicenseDuration = DateTime.Now.Year - selectedClient.LicenseDate.Year; // check lenght of driver license

                Console.WriteLine($"Witamy, {selectedClient.FullName}");
                Console.WriteLine("Który samochód chcesz wynająć? Podaj numer samochodu: ");


                if (!int.TryParse(Console.ReadLine(), out int selectedCarIndex)) // if id is not int
                {
                    Console.WriteLine("Błędny format ID samochodu");
                    continue; // Ask for input again
                }
                else if (selectedCarIndex < 1 || selectedCarIndex > Car.carsList.Count) // if its out of cars list index
                {
                    Console.WriteLine("Niepoprawny numer samochodu");
                    continue; // Ask for input again
                }
                else if (!Car.carsList[selectedCarIndex - 1].available) // if car is unavailable
                {
                    Console.WriteLine("Samochód jest niedostępny");
                    continue;
                }

                Car selectedCar = Car.GetCarByIndex(selectedCarIndex); // Set selected car in variable
                if (DLicenseDuration < 4 && selectedCar.carSegment == "premium")
                {
                    Console.WriteLine("Z uwagi na krótki okres posiadania prawa jazdy, nie możesz wynjąć auta segmentu premium");
                    continue;
                }

                Console.WriteLine($"Cena za jeden dzień wynajmu {selectedCar.carBrand} to {selectedCar.price} PLN");
                Console.Write("Na ile dni chcesz wynająć auto? ");

                if (!int.TryParse(Console.ReadLine(), out int rentalDuration)) // if amount of days is not int
                {
                    Console.WriteLine("Błędny format tekstu, podaj liczbę");
                    continue; // Ask for input again
                }

                int TotalCost = DLicenseDuration < 4 ? (int)(rentalDuration * (selectedCar.price * 1.20)) : rentalDuration * selectedCar.price; // Price grows by 20% if Driver license shorter than 4 years
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

                Console.WriteLine($"Całkowity koszt wynajmu to {TotalCost}");
                Console.WriteLine($"Samochód należy oddać w dniu {ReturnDate.ToShortDateString()}");
                Car.RentCar(selectedCar);
                break;
            }
        }
    }
}
        
