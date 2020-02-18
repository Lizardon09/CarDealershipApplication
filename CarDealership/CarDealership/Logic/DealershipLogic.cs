using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarDealership.Models;

namespace CarDealership.Logic
{
    public class DealershipLogic
    {
        private List<Vehicle> Vehicles { get; set; }

        private List<string> MakeFilter { get; set; }

        private List<string> ModelFilter { get; set; }

        private Vehicle BoughtVehicle { get; set; }

        public DealershipLogic()
        {
            Vehicle.MillegeBrackets = new Dictionary<KeyValuePair<KeyValuePair<int, int>, int>, Dictionary<VehicleType, int>>();
            Vehicle.YearBrackets = new Dictionary<KeyValuePair<KeyValuePair<int, int>, int>, Dictionary<VehicleType, int>>();

            Vehicle.ExtraServiceHistoryCost = new Dictionary<VehicleType, Dictionary<ServiceType, int>>();
            Vehicle.ExtraSpecificationCost = new Dictionary<VehicleType, Dictionary<SpecificationType, int>>();

            Vehicle.MillegeBrackets.Add(new KeyValuePair<KeyValuePair<int, int>, int>(new KeyValuePair<int, int>(0, 100000), 30000), new Dictionary<VehicleType, int>() { { VehicleType.Truck, 40 }, { VehicleType.Bus, 40 } });
            Vehicle.MillegeBrackets.Add(new KeyValuePair<KeyValuePair<int, int>, int>(new KeyValuePair<int, int>(100000, 150000), 15000), new Dictionary<VehicleType, int>() { { VehicleType.Truck, 20 }, { VehicleType.Bus, 20 } });
            Vehicle.MillegeBrackets.Add(new KeyValuePair<KeyValuePair<int, int>, int>(new KeyValuePair<int, int>(150000, 0), 5000), new Dictionary<VehicleType, int>() { { VehicleType.Truck, 10 }, { VehicleType.Bus, 10 } });

            Vehicle.YearBrackets.Add(new KeyValuePair<KeyValuePair<int, int>, int>(new KeyValuePair<int, int>(0, 2011), 5000), new Dictionary<VehicleType, int>() { { VehicleType.Truck, 15 }, { VehicleType.Bus, 15 } });
            Vehicle.YearBrackets.Add(new KeyValuePair<KeyValuePair<int, int>, int>(new KeyValuePair<int, int>(2011, 2018), 10000), new Dictionary<VehicleType, int>() { { VehicleType.Truck, 10 }, { VehicleType.Bus, 10 } });
            Vehicle.YearBrackets.Add(new KeyValuePair<KeyValuePair<int, int>, int>(new KeyValuePair<int, int>(2018, 0), 30000), new Dictionary<VehicleType, int>() { { VehicleType.Truck, 5 }, { VehicleType.Bus, 5 } });

            Vehicle.ExtraServiceHistoryCost.Add(VehicleType.Truck, new Dictionary<ServiceType, int>() { { ServiceType.Full, 15 }, { ServiceType.Minor, 10 }, { ServiceType.None, 5 } });
            Vehicle.ExtraServiceHistoryCost.Add(VehicleType.Bus, new Dictionary<ServiceType, int>() { { ServiceType.Full, 15 }, { ServiceType.Minor, 10 }, { ServiceType.None, 5 } });

            Vehicles = new List<Vehicle>() { 
                new Vehicle(120000, SpecificationType.High, ServiceType.Minor, ColorType.Flat, VehicleType.Bus, 2020, "BMW", "S300", 250000),
                new Vehicle(135000, SpecificationType.Low, ServiceType.Full, ColorType.Flat, VehicleType.Truck, 2009, "BMW", "Z20", 150000),
                new Vehicle(197000, SpecificationType.Medium, ServiceType.Full, ColorType.Metalic, VehicleType.Car, 2016, "Honda", "H50T", 170000),
                new Vehicle(400000, SpecificationType.Low, ServiceType.None, ColorType.Flat, VehicleType.Truck, 2012, "Toyota", "T560", 210000),
                new Vehicle(90000, SpecificationType.Medium, ServiceType.Minor, ColorType.Metalic, VehicleType.Car, 2006, "Toyota", "T600", 300000),
                new Vehicle(200000, SpecificationType.Low, ServiceType.Full, ColorType.Metalic, VehicleType.Car, 2014, "Honda", "H5023", 167500),
                new Vehicle(360000, SpecificationType.Low, ServiceType.Minor, ColorType.Flat, VehicleType.Truck, 2008, "Toyota", "T634", 320000),
                new Vehicle(110000, SpecificationType.Medium, ServiceType.Full, ColorType.Flat, VehicleType.Bus, 2013, "Toyota", "T950", 280000)
            };

            MakeFilter = new List<string>();
            ModelFilter = new List<string>();

            foreach (var vehicle in Vehicles)
            {
                vehicle.SalePrice = CalculateSalePrice(vehicle);
                if (!MakeFilter.Contains(vehicle.Make))
                    MakeFilter.Add(vehicle.Make);
                if (!ModelFilter.Contains(vehicle.Model))
                    ModelFilter.Add(vehicle.Model);
            }
        }

        public void Run()
        {
            Console.WriteLine("\n---------------------------------------------\n");
            Console.WriteLine("\nPlease select one of the following options:\n\n");
            Console.WriteLine("\nRecord vehicles: R\n");
            Console.WriteLine("\nSell vehicles: S\n");
            Console.WriteLine("\nDisplay vehicles: D\n");
            Console.WriteLine("\nEnd Program: E\n");

            string input;

            do
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "R":
                        RecordVehicle(input);
                        break;
                    case "S":
                        SellVehicle(input);
                        break;
                    case "D":
                        foreach (var vehicle in Vehicles)
                        {
                            vehicle.DisplayVehicle();
                            Console.WriteLine();
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid Command, please try again\n");
                        break;
                }

            } while (input!="E");

            Console.WriteLine("\n---------------------------------------------\n");
            Console.WriteLine("\nProgram has ended...\n\n");
        }

        private void RecordVehicle(string input)
        {
            BoughtVehicle = new Vehicle();
            Array enumoptions;

            Console.WriteLine("\n---------------------------------------------\n");
            Console.WriteLine("\nRecord Bought Vehicle:\n");

            do { 
                Console.WriteLine("\nPlease enter vehicle baseprice (R):\n");
                input = Console.ReadLine();

                try
                {
                    if (double.Parse(input) > 0)
                    {
                        BoughtVehicle.BasePrice = double.Parse(input);
                        break;
                    }
                    Console.WriteLine("\nValue must be greater than 0, please try again\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid input, please input vehicle baseprice.\n");
                }
            } while (true);

            //--------------------------------------------------------------------------------------

            Console.WriteLine("\n---------------------------------------------\n");
            do
            {
                Console.WriteLine("\nPlease enter year of vehicle:\n");
                input = Console.ReadLine();

                try
                {
                    if (int.Parse(input) > 0)
                    {
                        BoughtVehicle.Year = int.Parse(input);
                        break;
                    }
                    Console.WriteLine("\nValue must be greater than 0, please try again\n");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid input, please input year of vehicle.\n");
                }
            } while (true);

            //--------------------------------------------------------------------------------------

            Console.WriteLine("\n---------------------------------------------\n");
            do
            {
                Console.WriteLine("\nPlease enter make of vehicle:\n");
                input = Console.ReadLine();

                try
                {
                    if (input.All(Char.IsLetter))
                    {
                        BoughtVehicle.Make = input.ToUpper(); ;
                        break;
                    }
                    Console.WriteLine("\nMake cannot contain numbers, please try again\n");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid input, please input make of vehicle.\n");
                }
            } while (true);

            //--------------------------------------------------------------------------------------

            Console.WriteLine("\n---------------------------------------------\n");
            do
            {
                Console.WriteLine("\nPlease enter model of vehicle:\n");
                input = Console.ReadLine();

                try
                {
                    if (input.All(Char.IsLetterOrDigit))
                    {
                        BoughtVehicle.Model = input;
                        break;
                    }
                    Console.WriteLine("\nInvalid input, please input model of vehicle.\n");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid input, please input model of vehicle.\n");
                }
            } while (true);

            //--------------------------------------------------------------------------------------

            Console.WriteLine("\n---------------------------------------------\n");
            Console.WriteLine("\nPlease select vehicle type from following\n\n");

            enumoptions = Enum.GetNames(typeof(VehicleType));

            for (int i = 0; i < enumoptions.Length; i++)
            {
                Console.WriteLine($"({i}) : {enumoptions.GetValue(i)}\n");
            }

            do
            {
                input = Console.ReadLine();

                try
                {
                    if (Convert.ToInt32(input) >=0 && Convert.ToInt32(input)<enumoptions.Length)
                    {
                        BoughtVehicle.TypeOfVehicle = (VehicleType)Enum.Parse(typeof(VehicleType), (enumoptions.GetValue(Convert.ToInt32(input))).ToString());
                        break;
                    }
                    Console.WriteLine("\nInvalid input, please input valid vehicle type.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid input, please input valid vehicle type.\n");
                }
            } while (true);

            //--------------------------------------------------------------------------------------

            Console.WriteLine("\n---------------------------------------------\n");
            Console.WriteLine("\nPlease select vehicle color from following\n\n");

            enumoptions = Enum.GetNames(typeof(ColorType));

            for (int i = 0; i < enumoptions.Length; i++)
            {
                Console.WriteLine($"({i}) : {enumoptions.GetValue(i)}\n");
            }

            do
            {
                input = Console.ReadLine();

                try
                {
                    if (Convert.ToInt32(input)>=0 && Convert.ToInt32(input)<enumoptions.Length)
                    {

                        if ((ColorType)Enum.Parse(typeof(ColorType), (enumoptions.GetValue(Convert.ToInt32(input))).ToString()) == ColorType.Metalic && (BoughtVehicle.TypeOfVehicle == VehicleType.Truck || BoughtVehicle.TypeOfVehicle == VehicleType.Bus))
                        {
                            Console.WriteLine($"{VehicleType.Truck} and {VehicleType.Bus} are not allowed to have metallic, input valid vehicle color.");
                        }

                        else
                        {
                            BoughtVehicle.ColorShade = (ColorType)Enum.Parse(typeof(ColorType), (enumoptions.GetValue(Convert.ToInt32(input))).ToString());
                            break;
                        }

                    }
                    Console.WriteLine("\nInvalid input, please input valid vehicle color.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid input, please input valid vehicle color.\n");
                }
            } while (true);

            //--------------------------------------------------------------------------------------

            Console.WriteLine("\n---------------------------------------------\n");
            Console.WriteLine("\nPlease select vehicle service history from following\n\n");

            enumoptions = Enum.GetNames(typeof(ServiceType));

            for (int i = 0; i < enumoptions.Length; i++)
            {
                Console.WriteLine($"({i}) : {enumoptions.GetValue(i)}\n");
            }

            do
            {
                input = Console.ReadLine();

                try
                {
                    if (Convert.ToInt32(input)>=0 && Convert.ToInt32(input)<enumoptions.Length)
                    {
                        BoughtVehicle.ServiceHistory = (ServiceType)Enum.Parse(typeof(ServiceType), (enumoptions.GetValue(Convert.ToInt32(input))).ToString());
                        break;
                    }
                    Console.WriteLine("\nInvalid input, please input valid vehicle service history.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid input, please input valid vehicle service history.\n");
                }
            } while (true);

            //--------------------------------------------------------------------------------------

            Console.WriteLine("\n---------------------------------------------\n");
            Console.WriteLine("\nPlease select vehicle specification level from following\n\n");

            enumoptions = Enum.GetNames(typeof(SpecificationType));

            for (int i = 0; i < enumoptions.Length; i++)
            {
                Console.WriteLine($"({i}) : {enumoptions.GetValue(i)}\n");
            }

            do
            {
                input = Console.ReadLine();

                try
                {
                    if (Convert.ToInt32(input)>=0 && Convert.ToInt32(input)<enumoptions.Length)
                    {
                        BoughtVehicle.SpecificationLevel = (SpecificationType)Enum.Parse(typeof(SpecificationType), (enumoptions.GetValue(Convert.ToInt32(input))).ToString());
                        break;
                    }
                    Console.WriteLine("\nInvalid input, please input valid vehicle specification level.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid input, please input valid vehicle specification level.\n");
                }
            } while (true);

            //--------------------------------------------------------------------------------------

            Console.WriteLine("\n---------------------------------------------\n");
            do
            {
                Console.WriteLine("\nPlease enter millege of vehicle:\n");
                input = Console.ReadLine();

                try
                {
                    if (int.Parse(input) >= 0)
                    {
                        BoughtVehicle.Millege = int.Parse(input);
                        break;
                    }
                    Console.WriteLine("\nValue must be greater than or equal to 0, please try again\n");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid input, please input millege of vehicle.\n");
                }
            } while (true);

            //--------------------------------------------------------------------------------------

            Console.WriteLine("\n---------------------------------------------\n");
            BoughtVehicle.SalePrice = CalculateSalePrice(BoughtVehicle);
            Vehicles.Add(BoughtVehicle);
            Console.WriteLine("\nVehicle added successfully!!:\n");
            BoughtVehicle.DisplayVehicle();
        }

        private void SellVehicle(string input)
        {
            VehicleType vehicleType;
            Vehicle vehicletosell;
            string maketosort;
            Array enumoptions;

            enumoptions = Enum.GetNames(typeof(VehicleType));

            //--------------------------------------------------------------------------------------

            Console.WriteLine("\n---------------------------------------------\n");
            Console.WriteLine("\nPlease select vehicle type from following\n\n");

            for (int i = 0; i < enumoptions.Length; i++)
            {
                Console.WriteLine($"({i}): {enumoptions.GetValue(i)}");
            }

            do
            {
                input = Console.ReadLine();

                try
                {
                    if (Convert.ToInt32(input)>=0 && Convert.ToInt32(input)<enumoptions.Length)
                    {
                        vehicleType = (VehicleType)Enum.Parse(typeof(VehicleType), (enumoptions.GetValue(Convert.ToInt32(input))).ToString());
                        break;
                    }
                    Console.WriteLine("\nInvalid input, please input valid vehicle type.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid input, please input valid vehicle type.\n");
                }
            } while (true);

            //--------------------------------------------------------------------------------------

            Console.WriteLine("\n---------------------------------------------\n");
            Console.WriteLine("\nPlease select vehicle make from following:\n\n");

            for (int i = 0; i < MakeFilter.Count; i++)
            {
                if (Vehicles.Exists(x => x.Make == MakeFilter[i] && x.TypeOfVehicle == vehicleType))
                    Console.WriteLine($"({i}): {MakeFilter[i]}\n");
            }

            do
            {
                input = Console.ReadLine();

                try
                {
                    if (Vehicles.Exists(x => x.Make == MakeFilter[Convert.ToInt32(input)] && x.TypeOfVehicle == vehicleType))
                    {
                        maketosort = MakeFilter[Convert.ToInt32(input)];
                        break;
                    }
                    Console.WriteLine("\nInvalid input, please input valid vehicle ID.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid input, please input valid vehicle ID.\n");
                }
            } while (true);

            //--------------------------------------------------------------------------------------

            Console.WriteLine("\n---------------------------------------------\n");
            Console.WriteLine("\nPlease select ID from following:\n\n");
            foreach (var vehicle in Vehicles)
            {
                if (vehicle.TypeOfVehicle == vehicleType && vehicle.Make==maketosort)
                    vehicle.DisplayVehicle();
            }

            do
            {
                input = Console.ReadLine();

                try
                {
                    if (Vehicles.Exists(x=>x.ID==Convert.ToInt32(input) && x.TypeOfVehicle==vehicleType && x.Make==maketosort))
                    {
                        vehicletosell = Vehicles.Find(x => x.ID == Convert.ToInt32(input));
                        break;
                    }
                    Console.WriteLine("\nInvalid input, please input valid vehicle ID.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid input, please input valid vehicle ID.\n");
                }
            } while (true);

            //--------------------------------------------------------------------------------------

            Console.WriteLine("\n---------------------------------------------\n");
            Console.WriteLine("\nConfirm Purchase of vehicle (Y/N):\n\n");

            vehicletosell.DisplayVehicle();

            do
            {
                input = Console.ReadLine();

                switch (input)
                {
                    case "Y":
                        Vehicles.Remove(vehicletosell);
                        Console.WriteLine("\nPurchase Made!!");
                        break;
                    case "N":
                        Console.WriteLine("\nPurchase Cancelled!!");
                        break;
                }

            } while (true);

        }

        private double CalculateSalePrice(Vehicle vehicle)
        {
            double saleprice = vehicle.BasePrice;
            double extrapercent = 0;

            //--------------------------------------------------------------------------------------

            foreach (var millegebracket in Vehicle.MillegeBrackets)
            {
                if ( (millegebracket.Key.Key.Key <= 0 && vehicle.Millege<millegebracket.Key.Key.Value) || (millegebracket.Key.Key.Value <= 0 && vehicle.Millege >= millegebracket.Key.Key.Key) || (vehicle.Millege >= millegebracket.Key.Key.Key && vehicle.Millege <= millegebracket.Key.Key.Value))
                {
                    saleprice += millegebracket.Key.Value;

                    foreach (var extramillegecost in millegebracket.Value)
                    {
                        if (extramillegecost.Key == vehicle.TypeOfVehicle)
                        {
                            saleprice += millegebracket.Key.Value * ((double)extramillegecost.Value / 100);
                            break;
                        }
                    }

                    break;
                }
            }

            //--------------------------------------------------------------------------------------

            foreach (var yearbracket in Vehicle.YearBrackets)
            {
                if ((yearbracket.Key.Key.Key <= 0 && vehicle.Year < yearbracket.Key.Key.Value) || (yearbracket.Key.Key.Value <= 0 && vehicle.Year >= yearbracket.Key.Key.Key) || (vehicle.Year >= yearbracket.Key.Key.Key && vehicle.Year <= yearbracket.Key.Key.Value))
                {
                    saleprice += yearbracket.Key.Value;

                    foreach (var extrayearcost in yearbracket.Value)
                    {
                        if (extrayearcost.Key == vehicle.TypeOfVehicle)
                        {
                            saleprice += yearbracket.Key.Value * ((double)extrayearcost.Value / 100);
                            break;
                        }
                    }
                    break;
                }
            }

            //--------------------------------------------------------------------------------------

            extrapercent = (double)vehicle.SpecificationLevel;

            foreach (var spec in Vehicle.ExtraSpecificationCost)
            {
                if(spec.Key==vehicle.TypeOfVehicle)
                {
                    foreach(var extraspeccost in spec.Value)
                    {
                        if(extraspeccost.Key==vehicle.SpecificationLevel)
                        {
                            extrapercent += extraspeccost.Value;
                            break;
                        }
                    }
                    break;
                }
            }

            saleprice += vehicle.BasePrice * (extrapercent / 100);

            //--------------------------------------------------------------------------------------

            extrapercent = (double)vehicle.ServiceHistory;

            foreach (var servicehistory in Vehicle.ExtraServiceHistoryCost)
            {
                if (servicehistory.Key == vehicle.TypeOfVehicle)
                {
                    foreach (var extrservicecost in servicehistory.Value)
                    {
                        if (extrservicecost.Key == vehicle.ServiceHistory)
                        {
                            extrapercent += extrservicecost.Value;
                            break;
                        }
                    }
                    break;
                }
            }

            saleprice += vehicle.BasePrice * (extrapercent / 100);

            //--------------------------------------------------------------------------------------

            extrapercent = 0;

            saleprice += (double)vehicle.ColorShade;

            return saleprice;

        }

    }
}
