using System;
using CarDealership.Logic;
using CarDealership.Models;

namespace CarDealership
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input="";
            DealershipLogic VarunsMotors = new DealershipLogic();
            //VarunsMotors.RecordVehicle(input);
            VarunsMotors.SellVehicle(input);

            Console.ReadKey();
        }
    }
}
