using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models
{
    public enum SpecificationType
    {
        High = 30,
        Medium = 15,
        Low = 1
    }

    public enum ServiceType
    {
        Full = 40,
        Minor = 30,
        None = 1
    }

    public enum ColorType
    {
        Metalic = 0,
        Flat = 5000,
    }

    public enum VehicleType
    {
        Car,
        Truck,
        Bus
    }

    public class Vehicle
    {
        public int ID { get; set; }

        private static int AccumultatedID { get; set; } = 0;

        public static Dictionary<KeyValuePair<KeyValuePair<int, int>, int>, Dictionary<VehicleType, int>> MillegeBrackets { get; set; }

        public static Dictionary<KeyValuePair<KeyValuePair<int, int>, int>, Dictionary<VehicleType, int>> YearBrackets { get; set; }

        public static Dictionary<VehicleType, Dictionary<SpecificationType,int>> ExtraSpecificationCost { get; set; }
        public static Dictionary<VehicleType, Dictionary<ServiceType, int>> ExtraServiceHistoryCost { get; set; }

        public int Millege { get; set; }
        public SpecificationType SpecificationLevel { get; set; }
        public ServiceType ServiceHistory { get; set; }
        public ColorType ColorShade { get; set; }
        public VehicleType TypeOfVehicle { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double BasePrice { get; set; }
        public double SalePrice { get; set; }
        
        public Vehicle()
        {
            ID = AccumultatedID;
            AccumultatedID++;
        }

        public Vehicle(int millege, SpecificationType spectype, ServiceType servtype, ColorType color, VehicleType typeofvehicle, int year, string make, string model, double baseprice)
        {
            ID = AccumultatedID;
            AccumultatedID++;
            Millege = millege;
            SpecificationLevel = spectype;
            ServiceHistory = servtype;
            ColorShade = color;
            TypeOfVehicle = typeofvehicle;
            Year = year;
            Make = make;
            Model = model;
            BasePrice = baseprice;
        }

        public void DisplayVehicle()
        {
            Console.WriteLine($"\nVehicle Details:\n" +
                              $"\nID: {ID}" +
                              $"\nMillege: {Millege}" +
                              $"\nSpecification Level: {SpecificationLevel}" +
                              $"\nColorShade: {ColorShade}" +
                              $"\nTypeOfVehicle: {TypeOfVehicle}" +
                              $"\nYear: {Year}" +
                              $"\nMake: {Make}" +
                              $"\nModel: {Model}" +
                              $"\nBasePrice: R{BasePrice}" +
                              $"\nSalePrice: R{SalePrice}" +
                              $"\nProfit: R{SalePrice-BasePrice}\n");
        }

    }
}
