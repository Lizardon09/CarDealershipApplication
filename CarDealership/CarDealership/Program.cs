using System;
using CarDealership.Logic;
using CarDealership.Models;

namespace CarDealership
{
    public class Program
    {
        static void Main(string[] args)
        {
            DealershipLogic VarunsMotors = new DealershipLogic();
            VarunsMotors.Run();

            Console.ReadKey();
        }
    }
}
