using System;
using System.Collections.Generic;

class Car
{
    private string carBrand;
    private string carSegment;
    private string fuel;
    private int productionYear;
    private int price;
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
        Console.WriteLine("ID | MODEL | SEGMENT | RODZAJ PALIWA | ROK PRODUKCJI | DOSTĘPNOŚĆ");
        int i = 1;
        foreach (Car car in carsList)
        {
            string availability = car.available ? "dostępny" : "niedostępny";
            Console.WriteLine($"{i}|  {car.carBrand}  |  {car.carSegment}  |  {car.fuel}  |  {car.productionYear} | {availability}");
            i++;
        }
    }

    public static void carRent(Car oneCar)
    {
        if (oneCar.available)
        {
            oneCar.available = false;
        }
        else
        {
            Console.WriteLine("Samochód jest niedostępny");
        }

    }
}

