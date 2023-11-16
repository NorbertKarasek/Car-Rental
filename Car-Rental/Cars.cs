using System;
using System.Collections.Generic;

class Car
{
    public string carBrand;
    public string carSegment;
    public string fuel;
    public int productionYear;
    public int price;
    public bool available;
    public static List<Car> carsList = new List<Car>();

    public Car(string carBrand, string carSegment, string fuel, int productionYear, int price, bool available = true)
    {
        this.carBrand = carBrand;
        this.carSegment = carSegment;
        this.fuel = fuel;
        this.productionYear = productionYear;
        this.price = price;
        this.available = available;
        carsList.Add(this);
    }

    public void getInformation()
    {
        Console.WriteLine($"Samochód:\n{this.carBrand}\n{this.productionYear}");
    }

    public static void GetCarsList()
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

    public static void RentCar(Car oneCar)
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
}

