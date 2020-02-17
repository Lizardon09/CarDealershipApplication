using System;
using System.Collections.Generic;
using System.Text;
using CarDealership.Models;

namespace CarDealership.Logic
{
    public class DealershipLogic
    {
        public static Dictionary<KeyValuePair<int, int>, int> MillegeBrackets { get; set; }
        public static Dictionary<KeyValuePair<int, int>, int> YearBrackets { get; set; }

        public static Dictionary<VehicleType, Dictionary<KeyValuePair<int, int>, int>> ExtraMillegeCosts { get; set; }
        public static Dictionary<VehicleType, Dictionary<KeyValuePair<int, int>, int>> ExtraYearCosts { get; set; }

        private List<Vehicle> Vehicles { get; set; }

        public DealershipLogic()
        {
            Vehicle.DefaultMillegeBrackets = new Dictionary<KeyValuePair<int, int>, int>();
            Vehicle.DefaultYearBrackets = new Dictionary<KeyValuePair<int, int>, int>();

            Vehicle.DefaultMillegeBrackets.Add(new KeyValuePair<int, int>(0, 100000), 30000);
            Vehicle.DefaultMillegeBrackets.Add(new KeyValuePair<int, int>(100000, 150000), 15000);
            Vehicle.DefaultMillegeBrackets.Add(new KeyValuePair<int, int>(150000, 0), 5000);

            Vehicle.DefaultYearBrackets.Add(new KeyValuePair<int, int>(0, 2011), 5000);
            Vehicle.DefaultYearBrackets.Add(new KeyValuePair<int, int>(2011, 2018), 10000);
            Vehicle.DefaultYearBrackets.Add(new KeyValuePair<int, int>(2018, 0), 30000);

            Vehicle.ExtraMillegeCosts = new Dictionary<VehicleType, Dictionary<KeyValuePair<int, int>, int>>();
            Vehicle.ExtraYearCosts = new Dictionary<VehicleType, Dictionary<KeyValuePair<int, int>, int>>();

            Dictionary<KeyValuePair<int, int>, Dictionary<VehicleType,int>> ExtraMillegeTruck = new Dictionary<KeyValuePair<int, int>, Dictionary<VehicleType, int>>();
            Dictionary<KeyValuePair<int, int>, Dictionary<VehicleType, int>> ExtraYear = new Dictionary<KeyValuePair<int, int>, Dictionary<VehicleType, int>>();


        }

        public void CalculateSalePrice(Vehicle vehicle)
        {

        }

    }
}
