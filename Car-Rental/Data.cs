using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental
{
    internal class Data
    {
        public static void CreateCars()
        {
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
        }

        public static void CreateClients()
        {
            //Clients Data
            Client client1 = new Client("Norbert Karasek", 2014, 01, 05);
            Client client2 = new Client("Magdalena Jaborska", 2013, 02, 15);
            Client client3 = new Client("Jan Nowak", 2021, 03, 04);
            Client client4 = new Client("Zofia Plucinska", 2010, 12, 18);
            Client client5 = new Client("Abroży Zbujnicki", 2022, 10, 11);
        }
    }
}
