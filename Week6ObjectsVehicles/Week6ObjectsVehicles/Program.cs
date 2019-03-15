using System;
using System.Collections.Generic;
using System.Collections;

namespace Week6ObjectsVehicles
{
    class Program
    {
        static void Main()
        {
            int iTotalVehicleNumber;
            iTotalVehicleNumber = GetVehicleNumberFromUser();
            //Console.WriteLine("{0}", iVehicleNumber);

            Vehicle[] VehiclesArray = new Vehicle[iTotalVehicleNumber];

            for (int i = 1; i <= iTotalVehicleNumber; i++)
            {
                string sTempMake, sTempModel;
                int iTempEngineSize, iTempCost;

                (sTempMake, sTempModel, iTempEngineSize, iTempCost) = GetVehicleInfo(i);

                VehiclesArray[i - 1] = new Vehicle(sTempMake, sTempModel, iTempEngineSize, iTempCost);
            }

            Console.WriteLine("Info for all vehicles input successfully.");

            Console.WriteLine("Make\tModel\tEngine\tCost");

            foreach (var Vehicle in VehiclesArray)
            {
                Vehicle.Output();
            }

            //Finding Vehicle Object with highest cost
            int iHighestCost = 0;
            string sMake, sModel;
            sMake = "Placeholder";
            sModel = "Placeholder";
            foreach (var Vehicle in VehiclesArray)
            {
                if (Vehicle.iCost > iHighestCost)
                {
                    iHighestCost = Vehicle.iCost;
                    sMake = Vehicle.sMake;
                    sModel = Vehicle.sModel;
                }
            }

            Console.WriteLine("Highest Cost: {0}", iHighestCost);
            Console.WriteLine("Make: {0}", sMake);
            Console.WriteLine("Model: {0}", sModel);

            //Finding Vehicle Object with lowest cost
            //Set initial value to cost of vehicle at 0th index to compare to other values.
            int iLowestCost = VehiclesArray[0].iCost;
            foreach (var Vehicle in VehiclesArray)
            {
                if (iLowestCost > Vehicle.iCost)
                {
                    iLowestCost = Vehicle.iCost;
                    sMake = Vehicle.sMake;
                    sModel = Vehicle.sModel;
                }
            }

            Console.WriteLine("Lowest Cost: {0}", iLowestCost);
            Console.WriteLine("Make: {0}", sMake);
            Console.WriteLine("Model: {0}", sModel);

            //Finding Vehicle Object with biggest engine.
            int iBiggestEngine = 0;
            foreach (var Vehicle in VehiclesArray)
            {
                if (Vehicle.iEngineSize > iBiggestEngine)
                {
                    iBiggestEngine = Vehicle.iEngineSize;
                    sMake = Vehicle.sMake;
                    sModel = Vehicle.sModel;
                }
            }

            Console.WriteLine("Biggest Engine: {0}", iBiggestEngine);
            Console.WriteLine("Make: {0}", sMake);
            Console.WriteLine("Model: {0}", sModel);

            //Finding Vehicle Object with smallest engine.
            //Set initial value to engine size of vehicle at 0th index to compare to other values.
            int iSmallestEngine = VehiclesArray[0].iEngineSize;
            foreach (var Vehicle in VehiclesArray)
            {
                if (iSmallestEngine > Vehicle.iEngineSize)
                {
                    iSmallestEngine = Vehicle.iEngineSize;
                    sMake = Vehicle.sMake;
                    sModel = Vehicle.sModel;
                }
            }

            Console.WriteLine("Smallest Engine: {0}", iSmallestEngine);
            Console.WriteLine("Make: {0}", sMake);
            Console.WriteLine("Model: {0}", sModel);

            //Finding Average Engine.
            int iTotalEngine = 0;
            int iAverageEngine;
            foreach (var Vehicle in VehiclesArray)
            {
                iTotalEngine += Vehicle.iEngineSize;
            }
            iAverageEngine = (iTotalEngine / iTotalVehicleNumber);
            Console.WriteLine("Average Engine: {0}", iAverageEngine);

            Console.WriteLine("You have entered {0} vehicles.", iTotalVehicleNumber);
            Console.ReadLine();
        }

        public static int GetVehicleNumberFromUser()
        {
            int iVehicleCount;
            bool bValidInput = false;

            const int VEHICLELOWERLIMIT = 0;
            const int VEHICLEUPPERLIMIT = 10;

            do
            {
                Console.WriteLine("How many vehicles do you wish to input?");
                int.TryParse(Console.ReadLine(), out iVehicleCount);
                if (iVehicleCount > VEHICLELOWERLIMIT && iVehicleCount <= VEHICLEUPPERLIMIT)
                {
                    bValidInput = true;
                }
            }
            while (bValidInput == false);

            return iVehicleCount; 
        }

        public static (string, string, int, int) GetVehicleInfo(int iCurrentVehicleNumber)
        {
            Console.WriteLine("Make of Vehicle {0}:", iCurrentVehicleNumber);
            string sMake = Console.ReadLine();

            Console.WriteLine("Model of Vehicle {0}:", iCurrentVehicleNumber);
            string sModel = Console.ReadLine();

            //Error checking requirement: Engine sizes should be in the range 1000cc to 3000cc
            bool bCorrectEngineSize = false;
            int iEngineSize = 0;
            do
            {
                Console.WriteLine("Engine Size (1000cc - 3000cc) of Vehicle {0}:", iCurrentVehicleNumber);
                int.TryParse(Console.ReadLine(), out iEngineSize);
                if (iEngineSize >= 1000 && iEngineSize <= 3000)
                {
                    bCorrectEngineSize = true;
                }
            }
            while (bCorrectEngineSize == false);

            //Error checking requirement: Cost should be in the range of £5000 - £35000
            bool bCorrectCost = false;
            int iCost = 0;
            do
            {
                Console.WriteLine("Cost (£5000 - £35000) of Vehicle {0}:", iCurrentVehicleNumber);
                int.TryParse(Console.ReadLine(), out iCost);
                if (iCost >= 5000 && iCost <= 35000)
                {
                    bCorrectCost = true;
                }
            }
            while (bCorrectCost == false);

            return (sMake, sModel, iEngineSize, iCost);
        }
    }

    class Vehicle
    {
        public string sMake { get; set; }
        public string sModel { get; set; }
        public int iEngineSize { get; set; }
        public int iCost { get; set; }
        public static int iVehicleCount = 0;

        //Every time a new vehicle object is created, increment VehicleCount.
        public Vehicle()
        {
            iVehicleCount++;
            return;
        }

        public Vehicle(string make, string model, int engineSize, int cost)
        {
            sMake = make;
            sModel = model;
            iEngineSize = engineSize;
            iCost = cost;
            iVehicleCount++;
            return;
        }

        //Output vehicle properties.
        public void Output()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}", sMake, sModel, iEngineSize, iCost);
            return;
        }

        public int VehicleHighestCost(Array VehiclesArray)
        {
            
            return 1;
        }

        public int VehicleLowestCost()
        {
            return 1;
        }

        public int VehicleLargestEngine()
        {
            return 1;
        }

        public int VehicleSmallestEngine()
        {
            return 1;
        }

        public int GetAverageEngine()
        {
            return 1;
        }
    }
}
