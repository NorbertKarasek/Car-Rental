using System;
using System.Collections.Generic;

namespace Car_Rental
{
    class Car
    {
        public string carBrand;
        public string carSegment;
        public string fuel;
        public int productionYear;
        public int price;
        public bool available;
        public static List<Car> carsList = new List<Car>();

        public Car(string carBrand, string carSegment, string fuel, int productionYear, int price, bool available = true) // Constructor
        {
            this.carBrand = carBrand;
            this.carSegment = carSegment;
            this.fuel = fuel;
            this.productionYear = productionYear;
            this.price = price;
            this.available = available;
            carsList.Add(this);
        }

        public void getInformation() // Show information about one car
        {
            Console.WriteLine($"Samochód:\n{this.carBrand}\n{this.productionYear}");
        }

        public static void GetCarsList() // Show cars list with all informations
        {
            Console.WriteLine("ID | MODEL | SEGMENT | RODZAJ PALIWA | ROK PRODUKCJI | CENA | DOSTĘPNOŚĆ");
            int i = 1;
            foreach (Car car in carsList)
            {
                string availability = car.available ? "dostępny" : "niedostępny";
                Console.WriteLine($"{i}|  {car.carBrand}  |  {car.carSegment}  |  {car.fuel}  |  {car.productionYear} | {car.price} | {availability}");
                i++;
            }
        }

        public static void RentCar(Car oneCar) // Rent a car by changing availablity status
        {
            if (oneCar.available)
            {
                oneCar.available = false;
                Console.WriteLine($"Wynajęto samochód {oneCar.carBrand}");
            }
            else
            {
                Console.WriteLine("Samochód jest niedostępny");
            }
        }
        public static Car GetCarByIndex(int index) // Get car index from list of cars
        {
            if (index >= 1 && index <= Car.carsList.Count)
            {
                return Car.carsList[index - 1];
            }
            return null; // Index is out of range
        }

    }
}

