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
        public static int ID { get; set; }
        public static Dictionary<KeyValuePair<int, int>, int> DefaultMillegeBrackets { get; set; }
        public static Dictionary<KeyValuePair<int, int>, int> DefaultYearBrackets { get; set; }

        public static Dictionary<VehicleType, Dictionary<KeyValuePair<int, int>, int>> ExtraMillegeCosts { get; set; }
        public static Dictionary<VehicleType, Dictionary<KeyValuePair<int, int>, int>> ExtraYearCosts { get; set; }
        public static Dictionary<VehicleType, KeyValuePair<SpecificationType,int>> ExtraSpecificationCost { get; set; }
        public static Dictionary<VehicleType, KeyValuePair<ServiceType, int>> ExtraServiceHistoryCost { get; set; }

        public int Millege { get; set; }
        public SpecificationType SpecificationLevel { get; set; }
        public ServiceType ServiceHistory { get; set; }
        public ColorType ColorShade { get; set; }
        public VehicleType TypeOfVehicle { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double BasePrice { get; private set; }
        public double SalePrice { get; private set; }
        
        public Vehicle()
        {
            ID++;
        }

    }
}
