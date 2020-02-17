using System;
using System.Collections.Generic;
using System.Text;
using CarDealership.Models;

namespace CarDealership.Logic
{
    public class DealershipLogic
    {
        public Dictionary<KeyValuePair<int,int>,int> MillegeBrackets { get; set; }

        public Dictionary<KeyValuePair<int, int>, int> YearBrackets { get; set; }

        private List<Vehicle> Vehicles { get; set; }

        public DealershipLogic()
        {
            MillegeBrackets = new Dictionary<KeyValuePair<int, int>, int>();
            YearBrackets = new Dictionary<KeyValuePair<int, int>, int>();

            MillegeBrackets.Add(new KeyValuePair<int,int>(0, 100000), 30000);
            MillegeBrackets.Add(new KeyValuePair<int, int>(100000, 150000), 15000);
            MillegeBrackets.Add(new KeyValuePair<int, int>(150000, 0), 5000);

            YearBrackets.Add(new KeyValuePair<int, int>(0, 2011), 5000);
            YearBrackets.Add(new KeyValuePair<int, int>(2011, 2018), 10000);
            YearBrackets.Add(new KeyValuePair<int, int>(2018, 0), 30000);

        }

    }
}
