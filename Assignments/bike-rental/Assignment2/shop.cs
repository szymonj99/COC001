using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Assignment2
{
    class Shop
    {
        /// <summary>
        /// Responsible for interacting with UserMenu.cs.
        /// </summary>
        private readonly UserMenu userMenu = new UserMenu();

        //Where are the bikes currently in stock stored.
        public static string sInStockFile = "BikesInStock.txt";
        //Where are sold bikes stored.
        public static string sSoldBikesFile = "SoldBikes.txt";
        //Where are the hired bikes stored.
        public static string sHiredBikesFile = "HiredBikes.txt";
        //Where are company funds stored.
        public static string sMoneyFile = "Money.txt";
        //How much money does the company have. Later changed by reading money file.
        public static int money = 0;

        //How many variables each bike has assigned to it + a blank line.
        //E.G InStockBikes have 13 properties, + 1 (blank line) = 14.
        const int iBikeVarNum = 13;
        //In-Stock bikes variables
        const int iInStockBikesVarNum = 14;
        //Hired Bikes variables
        const int iHiredBikesVarNum = 17;
        //sold Bikes variables
        const int iSoldBikesVarNum = 17;

        //Create lists to store all bmx objects.
        private List<BMX> bmxes = new List<BMX>();
        private List<HiredBMX> hiredBMXes = new List<HiredBMX>();
        private List<SoldBMX> soldBMXes = new List<SoldBMX>();

        //create lists to store all mountain bikes objects.
        private List<MountainBike> mountainBikes = new List<MountainBike>();
        private List<HiredMountainBike> hiredMountainBikes = new List<HiredMountainBike>();
        private List<SoldMountainBike> soldMountainBikes = new List<SoldMountainBike>();

        //Create lists to store all road bike objects.
        private List<RoadBike> roadBikes = new List<RoadBike>();
        private List<HiredRoadBike> hiredRoadBikes = new List<HiredRoadBike>();
        private List<SoldRoadBike> soldRoadBikes = new List<SoldRoadBike>();

        //Create Lists to store all child bike objects.
        private List<ChildBike> childBikes = new List<ChildBike>();
        private List<HiredChildBike> hiredChildBikes = new List<HiredChildBike>();
        private List<SoldChildBike> soldChildBikes = new List<SoldChildBike>();

        //Create list to store all hired bike objects without bike type specific properties eg. peg length.
        private List<GenericHiredBike> hiredBikes = new List<GenericHiredBike>();
        //Create list to store all sold bike objects without bike type specific properties eg. peg length.
        private List<GenericSoldBike> soldBikes = new List<GenericSoldBike>();

        /// <summary>
        /// Clears hiredBikes list then for every hired bike type, adds the hired bike to hiredBikes list.
        /// </summary>
        public void GenerateHiredBikesList()
        {
            hiredBikes.Clear();

            foreach (var bmx in hiredBMXes)
            {
                GenericHiredBike genericHiredBMX = new GenericHiredBike(bmx.Type, bmx.Make, bmx.Model, bmx.Year, bmx.WheelSize, bmx.FrameType, bmx.SecurityCode,
                    bmx.PurchaseDate.Date, bmx.PurchaseCost, bmx.SaleCost, bmx.HiredToName, bmx.HiredToPhoneNumber, bmx.HiredToAddress);
                hiredBikes.Add(genericHiredBMX);
            }

            foreach (var cb in hiredChildBikes)
            {
                GenericHiredBike genericHiredChildBike = new GenericHiredBike(cb.Type, cb.Make, cb.Model, cb.Year, cb.WheelSize, cb.FrameType,
                    cb.SecurityCode, cb.PurchaseDate.Date, cb.PurchaseCost, cb.SaleCost, cb.HiredToName, cb.HiredToPhoneNumber, cb.HiredToAddress);
                hiredBikes.Add(genericHiredChildBike);
            }
            
            foreach (var mb in hiredMountainBikes)
            {
                GenericHiredBike genericHiredMtdBike = new GenericHiredBike(mb.Type, mb.Make, mb.Model, mb.Year, mb.WheelSize,
                    mb.FrameType, mb.SecurityCode, mb.PurchaseDate.Date, mb.PurchaseCost, mb.SaleCost, mb.HiredToName,
                    mb.HiredToPhoneNumber, mb.HiredToAddress);
                hiredBikes.Add(genericHiredMtdBike);
            }

            foreach (var rb in hiredRoadBikes)
            {
                GenericHiredBike genericHiredRoadBike = new GenericHiredBike(rb.Type, rb.Make, rb.Model, rb.Year, rb.WheelSize, rb.FrameType,
                    rb.SecurityCode, rb.PurchaseDate.Date, rb.PurchaseCost, rb.SaleCost, rb.HiredToName, rb.HiredToPhoneNumber, rb.HiredToAddress);
                hiredBikes.Add(genericHiredRoadBike);
            }
        }

        //Will store various bike types here, to display to user, without including type-specific properties.
        /// <summary>
        /// Stores all in stock bikes without bike-specific properties.
        /// </summary>
        public List<Bike> allBikes = new List<Bike>();

        /// <summary>
        /// Reads inventory.txt text file.
        /// </summary>
        /// <returns>Array of inventory file contents.</returns>
        private string[] ReadInStockFile()
        {
            if (File.Exists(sInStockFile))
            {
                //If file exists, read.
                string[] inStock = File.ReadAllLines(sInStockFile);
                return inStock;
            }
            else
            {
                //Return blank array.
                string[] inStock = new string[0];
                return inStock;
            }
        }

        /// <summary>
        /// Creates Bike objects from inventory file, and adds them to Bikes List.
        /// </summary>
        public void GetInStockBikes()
        {
            if (File.Exists(sInStockFile) == true)
            {
                //Set string array to contents of inventory file.
                string[] linesInStock = ReadInStockFile();
                //Used to increment position of currently read line.
                int invCounter = 0;
                //works out the number of bikes in the inventory.txt file
                int invLength = linesInStock.Length / iInStockBikesVarNum;

                //for each bike
                for (int i = 0; i <= invLength; i++)
                {
                    //assign variables to contents of inventory file.
                    string type = linesInStock[i + invCounter++];
                    string make = linesInStock[i + invCounter++];
                    string model = linesInStock[i + invCounter++];
                    int year = int.Parse(linesInStock[i + invCounter++]);
                    double wheelSize = double.Parse(linesInStock[i + invCounter++]);
                    string frameType = linesInStock[i + invCounter++];
                    int securityCode = int.Parse(linesInStock[i + invCounter++]);
                    //purchaseDate is given a default value of  HH:MM:SS of 00:00:00.
                    DateTime purchaseDate = DateTime.ParseExact(linesInStock[i + invCounter++], "d/M/yyyy", CultureInfo.InvariantCulture).Date;
                    int purchaseCost = int.Parse(linesInStock[i + invCounter++]);
                    int saleCost = int.Parse(linesInStock[i + invCounter++]);
                    //These are always false in StockFile.
                    bool isHired = bool.Parse(linesInStock[i + invCounter++]);
                    bool isSold = bool.Parse(linesInStock[i + invCounter++]);

                    //Final bike variable changes for each bike type.
                    if (type == "BMX")
                    {
                        double pegLength = double.Parse(linesInStock[i + invCounter++]);
                        BMX bk = new BMX(make, model, year, wheelSize, frameType, securityCode, purchaseDate.Date, purchaseCost, saleCost, pegLength);
                        bmxes.Add(bk);
                    }
                    else if (type == "Mountain Bike")
                    {
                        double tireWidth = double.Parse(linesInStock[i + invCounter++]);
                        MountainBike bk = new MountainBike(make, model, year, wheelSize, frameType, securityCode, purchaseDate, purchaseCost, saleCost, tireWidth);
                        mountainBikes.Add(bk);
                    }
                    else if (type == "Road Bike")
                    {
                        bool hasSolidTires = bool.Parse(linesInStock[i + invCounter++]);
                        RoadBike bk = new RoadBike(make, model, year, wheelSize, frameType, securityCode, purchaseDate, purchaseCost, saleCost, hasSolidTires);
                        roadBikes.Add(bk);
                    }
                    else if (type == "Child Bike")
                    {
                        bool hasTrainingWheels = bool.Parse(linesInStock[i + invCounter++]);
                        ChildBike bk = new ChildBike(make, model, year, wheelSize, frameType, securityCode, purchaseDate, purchaseCost, saleCost, hasTrainingWheels);
                        childBikes.Add(bk);
                    }
                }
            }
            else
            {
                Console.WriteLine("Inventory file does not exist. Creating new empty file now. Input any key to Continue.");
                Console.ReadLine();
                CreateNewInStockFile();
            }
        }

        /// <summary>
        /// Creates empty text file to store bikes currently in store.
        /// </summary>
        public void CreateNewInStockFile()
        {
            //Creates blank file then closes it to prevent I/O errors.
            File.Create(sInStockFile).Close();
        }

        /// <summary>
        /// Reads sold bikes from file
        /// </summary>
        /// <returns>Array of sold bikes information/</returns>
        private string[] ReadSoldBikesFile()
        {
            if (File.Exists(sSoldBikesFile))
            {
                string[] sold = File.ReadAllLines(sSoldBikesFile);
                return sold;
            }
            else
            {
                CreateNewSoldBikesFile();
                string[] sold = File.ReadAllLines(sSoldBikesFile);
                return sold;
            }
        }

        /// <summary>
        /// Reads hired bikes from file
        /// </summary>
        /// <returns>Array of hired bikes information/</returns>
        private string[] ReadHiredBikesFile()
        {
            if (File.Exists(sHiredBikesFile))
            {
                string[] hired = File.ReadAllLines(sHiredBikesFile);
                return hired;
            }
            else
            {
                CreateNewHiredBikesFile();
                string[] hired = File.ReadAllLines(sHiredBikesFile);
                return hired;
            }
        }

        /// <summary>
        /// Parses Sold Bikes into objects.
        /// </summary>
        public void GetSoldBikes()
        {
            if (File.Exists(sSoldBikesFile) == true)
            {
                //Set string array to contents of sold bikes file.
                string[] linesSold = ReadSoldBikesFile();
                //Used to increment position of currently read line.
                int invCounter = 0;
                //works out the number of bikes in the inventory.txt file
                int invLength = linesSold.Length / iSoldBikesVarNum;

                //for each bike
                for (int i = 1; i <= invLength; i++)
                {
                    //assign variables to contents of sold bikes file.
                    string type = linesSold[i + invCounter++];
                    string make = linesSold[i + invCounter++];
                    string model = linesSold[i + invCounter++];
                    int year = int.Parse(linesSold[i + invCounter++]);
                    double wheelSize = double.Parse(linesSold[i + invCounter++]);
                    string frameType = linesSold[i + invCounter++];
                    int securityCode = int.Parse(linesSold[i + invCounter++]);
                    //purchaseDate is given a default value of  HH:MM:SS of 00:00:00.
                    DateTime purchaseDate = DateTime.ParseExact(linesSold[i + invCounter++], "d/M/yyyy", CultureInfo.InvariantCulture).Date;
                    int purchaseCost = int.Parse(linesSold[i + invCounter++]);
                    int saleCost = int.Parse(linesSold[i + invCounter++]);
                    //These are always false in StockFile.
                    bool isHired = bool.Parse(linesSold[i + invCounter++]);
                    bool isSold = bool.Parse(linesSold[i + invCounter++]);
                    switch (type)
                    {
                        //Not the best way to do this.
                        //Bike specific variable occurs before variables present in all sold bikes.
                        case "BMX":
                            {
                                double pegLength = double.Parse(linesSold[i + invCounter++]);
                                string soldToName = linesSold[i + invCounter++];
                                double soldToPhoneNumber = double.Parse(linesSold[i + invCounter++]);
                                string soldToAddress = linesSold[i + invCounter++];
                                SoldBMX soldbmx = new SoldBMX(make, model, year, wheelSize, frameType, securityCode, purchaseDate, purchaseCost, saleCost, pegLength, soldToName, soldToPhoneNumber, soldToAddress);
                                soldBMXes.Add(soldbmx);
                                break;
                            }

                        case "Mountain Bike":
                            {
                                double tireWidth = double.Parse(linesSold[i + invCounter++]);
                                string soldToName = linesSold[i + invCounter++];
                                double soldToPhoneNumber = double.Parse(linesSold[i + invCounter++]);
                                string soldToAddress = linesSold[i + invCounter++];
                                SoldMountainBike soldmtdbike = new SoldMountainBike(make, model, year, wheelSize, frameType, securityCode, purchaseDate, purchaseCost, saleCost, tireWidth, soldToName, soldToPhoneNumber, soldToAddress);
                                soldMountainBikes.Add(soldmtdbike);
                                break;
                            }

                        case "Road Bike":
                            {
                                bool hasSolidTires = bool.Parse(linesSold[i + invCounter++]);
                                string soldToName = linesSold[i + invCounter++];
                                double soldToPhoneNumber = double.Parse(linesSold[i + invCounter++]);
                                string soldToAddress = linesSold[i + invCounter++];
                                SoldRoadBike soldroadbike = new SoldRoadBike(make, model, year, wheelSize, frameType, securityCode, purchaseDate, purchaseCost, saleCost, hasSolidTires, soldToName, soldToPhoneNumber, soldToAddress);
                                soldRoadBikes.Add(soldroadbike);
                                break;
                            }

                        case "Child Bike":
                            {
                                bool hasTrainingWheels = bool.Parse(linesSold[i + invCounter++]);
                                string soldToName = linesSold[i + invCounter++];
                                double soldToPhoneNumber = double.Parse(linesSold[i + invCounter++]);
                                string soldToAddress = linesSold[i + invCounter++];
                                SoldChildBike soldchildbike = new SoldChildBike(make, model, year, wheelSize, frameType, securityCode, purchaseDate, purchaseCost, saleCost, hasTrainingWheels, soldToName, soldToPhoneNumber, soldToAddress);
                                soldChildBikes.Add(soldchildbike);
                                break;
                            }

                        default:
                            {
                                break;
                            }
                    }
                }
            }
            else
            {
                Console.WriteLine("Sold Bikes file does not exist. Creating new empty sold bikes file now. Input any key to Continue.");
                Console.ReadLine();
                CreateNewSoldBikesFile();
            }
        }

        /// <summary>
        /// Parses Hired Bikes into objects.
        /// </summary>
        public void GetHiredBikes()
        {
            if (File.Exists(sHiredBikesFile) == true)
            {
                //Set string array to contents of hired bikes file.
                string[] linesHired = ReadHiredBikesFile();
                //Used to increment position of currently read line.
                int invCounter = 0;
                //works out the number of bikes in the inventory.txt file
                int invLength = linesHired.Length / iHiredBikesVarNum;

                if (linesHired.Length > 1)
                {
                    //for each bike
                    for (int i = 0; i <= invLength; i++)
                    {
                        //assign variables to contents of sold bikes file.
                        string type = linesHired[i + invCounter++];
                        string make = linesHired[i + invCounter++];
                        string model = linesHired[i + invCounter++];
                        int year = int.Parse(linesHired[i + invCounter++]);
                        double wheelSize = double.Parse(linesHired[i + invCounter++]);
                        string frameType = linesHired[i + invCounter++];
                        int securityCode = int.Parse(linesHired[i + invCounter++]);
                        //purchaseDate is given a default value of  HH:MM:SS of 00:00:00.
                        DateTime purchaseDate = DateTime.ParseExact(linesHired[i + invCounter++], "d/M/yyyy", CultureInfo.InvariantCulture).Date;
                        int purchaseCost = int.Parse(linesHired[i + invCounter++]);
                        int saleCost = int.Parse(linesHired[i + invCounter++]);
                        //These are always false in StockFile.
                        bool isHired = bool.Parse(linesHired[i + invCounter++]);
                        bool isSold = bool.Parse(linesHired[i + invCounter++]);
                        switch (type)
                        {
                            //Not the best way to do this.
                            //Bike specific variable occurs before variables present in all sold bikes.
                            case "BMX":
                                {
                                    double pegLength = double.Parse(linesHired[i + invCounter++]);
                                    string hiredToName = linesHired[i + invCounter++];
                                    double hiredToPhoneNumber = double.Parse(linesHired[i + invCounter++]);
                                    string hiredToAddress = linesHired[i + invCounter++];
                                    HiredBMX hiredbmx = new HiredBMX(make, model, year, wheelSize, frameType, securityCode, purchaseDate, purchaseCost, saleCost, pegLength, hiredToName, hiredToPhoneNumber, hiredToAddress);
                                    hiredBMXes.Add(hiredbmx);
                                    break;
                                }

                            case "Mountain Bike":
                                {
                                    double tireWidth = double.Parse(linesHired[i + invCounter++]);
                                    string hiredToName = linesHired[i + invCounter++];
                                    double hiredToPhoneNumber = double.Parse(linesHired[i + invCounter++]);
                                    string hiredToAddress = linesHired[i + invCounter++];
                                    HiredMountainBike hiredmtdbike = new HiredMountainBike(make, model, year, wheelSize, frameType, securityCode, purchaseDate, purchaseCost, saleCost, tireWidth, hiredToName, hiredToPhoneNumber, hiredToAddress);
                                    hiredMountainBikes.Add(hiredmtdbike);
                                    break;
                                }

                            case "Road Bike":
                                {
                                    bool hasSolidTires = bool.Parse(linesHired[i + invCounter++]);
                                    string hiredToName = linesHired[i + invCounter++];
                                    double hiredToPhoneNumber = double.Parse(linesHired[i + invCounter++]);
                                    string hiredToAddress = linesHired[i + invCounter++];
                                    HiredRoadBike hiredroadbike = new HiredRoadBike(make, model, year, wheelSize, frameType, securityCode, purchaseDate, purchaseCost, saleCost, hasSolidTires, hiredToName, hiredToPhoneNumber, hiredToAddress);
                                    hiredRoadBikes.Add(hiredroadbike);
                                    break;
                                }

                            case "Child Bike":
                                {
                                    bool hasTrainingWheels = bool.Parse(linesHired[i + invCounter++]);
                                    string hiredToName = linesHired[i + invCounter++];
                                    double hiredToPhoneNumber = double.Parse(linesHired[i + invCounter++]);
                                    string hiredToAddress = linesHired[i + invCounter++];
                                    HiredChildBike hiredchildbike = new HiredChildBike(make, model, year, wheelSize, frameType, securityCode, purchaseDate, purchaseCost, saleCost, hasTrainingWheels, hiredToName, hiredToPhoneNumber, hiredToAddress);
                                    hiredChildBikes.Add(hiredchildbike);
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Hired Bikes file does not exist. Creating new empty sold bikes file now. Input any key to Continue.");
                Console.ReadLine();
                CreateNewHiredBikesFile();
            }
        }

        /// <summary>
        /// Read money.txt text file and set money variable to text file contents.
        /// </summary>
        public void ReadFundsFile()
        {
            if (File.Exists(sMoneyFile) == true)
            {
                //Set static variable to file content.
                money = int.Parse(File.ReadAllText(sMoneyFile));
            }
            else
            {
                Console.WriteLine("Company funds file was missing. Creating new empty file. Input any key to Continue.");
                Console.ReadLine();
                CreateNewFundsFile();
                UserInputsInitialCompanyFunds();
                UserMenu.WriteAllLinesBetter(sMoneyFile, money.ToString());
            }
        }

        /// <summary>
        /// Creates empty text file to store company funds.
        /// </summary>
        public void CreateNewFundsFile()
        {
            //Creates empty file then closes it to prevent I/O errors.
            File.Create(sMoneyFile).Close();
        }

        /// <summary>
        /// Creates empty text file to store sold bikes.
        /// </summary>
        public void CreateNewSoldBikesFile()
        {
            //Creates empty file then closes it to prevent I/O errors.
            File.Create(sSoldBikesFile).Close();
        }

        /// <summary>
        /// Creates empty text file to store sold bikes.
        /// </summary>
        public void CreateNewHiredBikesFile()
        {
            //Creates empty file then closes it to prevent I/O errors.
            File.Create(sHiredBikesFile).Close();
        }

        /// <summary>
        /// When new company funds file is created, asks user to input current funds amount to store in new text file.
        /// </summary>
        public void UserInputsInitialCompanyFunds()
        {
            //Asks user to enter how much money company has when creating new text file.
            int iCompanyFunds;
            int iCompanyFundsConfirmation;

            do
            {
                Console.WriteLine("Input Company Funds amount:");
                if (int.TryParse(Console.ReadLine(), out iCompanyFunds) == false)
                {
                    UserInputsInitialCompanyFunds();
                }
                Console.WriteLine("Confirm Company Funds amount:");
                if (int.TryParse(Console.ReadLine(), out iCompanyFundsConfirmation) == false)
                {
                    UserInputsInitialCompanyFunds();
                }
            }
            while (iCompanyFunds != iCompanyFundsConfirmation || iCompanyFunds < 0);

            money = iCompanyFunds;
        }

        /// <summary>
        /// Sort BMX List by Bike Security Number in Descending Order
        /// </summary>
        public void SortBMXList()
        {
            List<BMX> SortedBMX = new List<BMX>();
            SortedBMX = bmxes.OrderBy(bike => bike.SecurityCode).ToList();
            bmxes.Clear();
            bmxes = SortedBMX;
        }

        /// <summary>
        /// Sort Hired BMX List by Security Number in Descending Order.
        /// </summary>
        public void SortHiredBMXList()
        {
            List<HiredBMX> SortedHiredBMX = new List<HiredBMX>();
            SortedHiredBMX = hiredBMXes.OrderBy(bike => bike.SecurityCode).ToList();
            hiredBMXes.Clear();
            hiredBMXes = SortedHiredBMX;
        }

        /// <summary>
        /// Sort Sold BMX List by Security Number in Descending Order.
        /// </summary>
        public void SortSoldBMXList()
        {
            List<SoldBMX> SortedSoldBMX = new List<SoldBMX>();
            SortedSoldBMX = soldBMXes.OrderBy(bike => bike.SecurityCode).ToList();
            soldBMXes.Clear();
            soldBMXes = SortedSoldBMX;
        }

        /// <summary>
        /// Sort Mountain Bike List by Bike Security Number in Descending Order
        /// </summary>
        public void SortMountainBikeList()
        {
            List<MountainBike> SortedMountainBike = new List<MountainBike>();
            SortedMountainBike = mountainBikes.OrderBy(bike => bike.SecurityCode).ToList();
            mountainBikes.Clear();
            mountainBikes = SortedMountainBike;
        }

        /// <summary>
        /// Sort Hired Mountain Bikes List by Security Number in Descending Order.
        /// </summary>
        public void SortHiredMountainBikeList()
        {
            List<HiredMountainBike> SortedHiredMountainBike = new List<HiredMountainBike>();
            SortedHiredMountainBike = hiredMountainBikes.OrderBy(bike => bike.SecurityCode).ToList();
            hiredMountainBikes.Clear();
            hiredMountainBikes = SortedHiredMountainBike;
        }

        /// <summary>
        /// Sort Sold Mountain Bike List by Security Number in Descending Order.
        /// </summary>
        public void SortSoldMountainBikeList()
        {
            List<SoldMountainBike> SortedSoldMountainBike = new List<SoldMountainBike>();
            SortedSoldMountainBike = soldMountainBikes.OrderBy(bike => bike.SecurityCode).ToList();
            soldMountainBikes.Clear();
            soldMountainBikes = SortedSoldMountainBike;
        }

        /// <summary>
        /// Sort Road Bike List by Bike Security Number in Descending Order
        /// </summary>
        public void SortRoadBikeList()
        {
            List<RoadBike> SortedRoadBike = new List<RoadBike>();
            SortedRoadBike = roadBikes.OrderBy(bike => bike.SecurityCode).ToList();
            roadBikes.Clear();
            roadBikes = SortedRoadBike;
        }

        /// <summary>
        /// Sort Hired Road Bike List by Security Number in Descending Order.
        /// </summary>
        public void SortHiredRoadBikeList()
        {
            List<HiredRoadBike> SortedHiredRoadBike = new List<HiredRoadBike>();
            SortedHiredRoadBike = hiredRoadBikes.OrderBy(bike => bike.SecurityCode).ToList();
            hiredRoadBikes.Clear();
            hiredRoadBikes = SortedHiredRoadBike;
        }

        /// <summary>
        /// Sort Sold Road Bike List by Security Number in Descending Order.
        /// </summary>
        public void SortSoldRoadBikeList()
        {
            List<SoldRoadBike> SortedSoldRoadBike = new List<SoldRoadBike>();
            SortedSoldRoadBike = soldRoadBikes.OrderBy(bike => bike.SecurityCode).ToList();
            soldRoadBikes.Clear();
            soldRoadBikes = SortedSoldRoadBike;
        }

        /// <summary>
        /// Sort Child Bike List by Bike Security Number in Descending Order
        /// </summary>
        public void SortChildBikeList()
        {
            List<ChildBike> SortedChildBike = new List<ChildBike>();
            SortedChildBike = childBikes.OrderBy(bike => bike.SecurityCode).ToList();
            childBikes.Clear();
            childBikes = SortedChildBike;
        }

        /// <summary>
        /// Sort Hired Child Bikes List by Security Number in Descending Order.
        /// </summary>
        public void SortHiredChildBikeList()
        {
            List<HiredChildBike> SortedHiredChildBike = new List<HiredChildBike>();
            SortedHiredChildBike = hiredChildBikes.OrderBy(bike => bike.SecurityCode).ToList();
            hiredChildBikes.Clear();
            hiredChildBikes = SortedHiredChildBike;
        }

        /// <summary>
        /// Sort Sold Child Bike List by Security Number in Descending Order.
        /// </summary>
        public void SortSoldChildBikeList()
        {
            List<SoldChildBike> SortedSoldChildBike = new List<SoldChildBike>();
            SortedSoldChildBike = soldChildBikes.OrderBy(bike => bike.SecurityCode).ToList();
            soldChildBikes.Clear();
            soldChildBikes = SortedSoldChildBike;
        }

        /// <summary>
        /// Sorts all bikes lists with one method.
        /// </summary>
        public void SortAllBikeLists()
        {
            SortBMXList();
            SortHiredBMXList();
            SortSoldBMXList();
            SortMountainBikeList();
            SortHiredMountainBikeList();
            SortSoldMountainBikeList();
            SortRoadBikeList();
            SortHiredRoadBikeList();
            SortSoldRoadBikeList();
            SortChildBikeList();
            SortHiredChildBikeList();
            SortSoldChildBikeList();
        }
        
        /// <summary>
        /// Sorts allBikes List.
        /// </summary>
        public void SortAllBikesList()
        {
            List<Bike> SortedBikes = new List<Bike>();
            SortedBikes = allBikes.OrderBy(bike => bike.SecurityCode).ToList();
            allBikes.Clear();
            allBikes = SortedBikes;
        }

        /// <summary>
        /// Reads allBikes List.
        /// </summary>
        /// <returns>allBikes List</returns>
        public List<Bike> RetrieveBikesList()
        {
            return allBikes;
        }

        /// <summary>
        /// Clears allBikes List.
        /// </summary>
        public void ClearAllBikesList()
        {
            allBikes.Clear();
        }

        /// <summary>
        /// Creates blank allBikes List.
        /// </summary>
        public void CreateAllBikesList()
        {
            foreach (var bike in bmxes)
            {
                allBikes.Add(bike);
            }
            foreach (var bike in mountainBikes)
            {
                allBikes.Add(bike);
            }
            foreach (var bike in childBikes)
            {
                allBikes.Add(bike);
            }
            foreach (var bike in roadBikes)
            {
                allBikes.Add(bike);
            }
        }
        
        /// <summary>
        /// Writes to console all entries in allBikes List.
        /// </summary>
        public void DisplayAllBikesList()
        {
            int iBikeIndex = 0;

            foreach (var bike in allBikes)
            {
                //Alternate colour for entries.
                if (iBikeIndex % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11}",
                    bike.Type, bike.Make, bike.Model, bike.Year, bike.WheelSize, bike.FrameType, bike.SecurityCode, bike.PurchaseDate.Day, bike.PurchaseDate.Month,
                    bike.PurchaseDate.Year,  bike.PurchaseCost, bike.SaleCost);

                iBikeIndex++;
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Total number of bikes: {0}", Bike.iNumOfBikes);
        }

        /// <summary>
        /// Writes to console all entries in mountainBikes List.
        /// </summary>
        public void DisplayMountainBikesList()
        {
            int iBikeIndex = 0;

            foreach (var bike in mountainBikes)
            {
                //Alternate colours for entries.
                if (iBikeIndex % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                    bike.Type, bike.Make, bike.Model, bike.Year, bike.WheelSize, bike.FrameType, bike.SecurityCode, bike.PurchaseDate.Day, bike.PurchaseDate.Month,
                    bike.PurchaseDate.Year, bike.PurchaseCost, bike.SaleCost, bike.TireWidth);

                iBikeIndex++;
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Writes to console all entries in roadBikes List.
        /// </summary>
        public void DisplayRoadBikesList()
        {
            int iBikeIndex = 0;

            foreach (var bike in roadBikes)
            {
                //Alternate colours for entries.
                if (iBikeIndex % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12}",
                    bike.Type, bike.Make, bike.Model, bike.Year, bike.WheelSize, bike.FrameType, bike.SecurityCode, bike.PurchaseDate.Day, bike.PurchaseDate.Month,
                    bike.PurchaseDate.Year, bike.PurchaseCost, bike.SaleCost, bike.HasSolidTires);

                iBikeIndex++;
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Writes to console all entries in childBikes List.
        /// </summary>
        public void DisplayChildBikesList()
        {
            int iBikeIndex = 0;

            foreach (var bike in childBikes)
            {
                //Alternate colours for entries.
                if (iBikeIndex % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12}",
                    bike.Type, bike.Make, bike.Model, bike.Year, bike.WheelSize, bike.FrameType, bike.SecurityCode, bike.PurchaseDate.Day, bike.PurchaseDate.Month,
                    bike.PurchaseDate.Year, bike.PurchaseCost, bike.SaleCost, bike.HasTrainingWheels);

                iBikeIndex++;
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Writes to console all entries in BMXes List.
        /// </summary>
        public void DisplayBMXBikesList()
        {
            int iBikeIndex = 0;

            foreach (var bike in bmxes)
            {
                //Alternate colours for entries.
                if (iBikeIndex % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                    bike.Type, bike.Make, bike.Model, bike.Year, bike.WheelSize, bike.FrameType, bike.SecurityCode, bike.PurchaseDate.Day, bike.PurchaseDate.Month,
                    bike.PurchaseDate.Year, bike.PurchaseCost, bike.SaleCost, bike.PegLength);

                iBikeIndex++;
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Allows user to search for bike by typing security number.
        /// </summary>
        public void SearchBikeBySecurityNum()
        {
            Console.Clear();

            int iUserInput;

            do
            {
                Console.WriteLine("Insert Security Number of Bike you wish to search for: [0 to cancel]");
                //int.TryParse() returns false if input type != int.
                if (int.TryParse(Console.ReadLine(), out iUserInput) == false)
                {
                    Console.WriteLine("Input not recognized.");
                    Console.ReadLine();
                    SearchBikeBySecurityNum();
                }
                else
                {
                    if (iUserInput == 0)
                    {
                        //Allows user to cancel search.
                        userMenu.Menu();
                    }
                    else
                    {
                        //Clear and recreate allBikes list before searching.
                        ClearAllBikesList();
                        CreateAllBikesList();
                        Bike bike = allBikes.Find(Bike => Bike.SecurityCode == iUserInput);
                        //list.Find() returns null if no entry is found.
                        if (bike == null)
                        {
                            Console.WriteLine("Bike with Security Number {0} not found.", iUserInput);
                            Console.ReadLine();
                            userMenu.Menu();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("The following bike has been found:");
                            //Decide the type of bike, then write bike headings for the type of bike.
                            if (bike.Type == "BMX")
                            {
                                userMenu.WriteBMXBikeHeadings();
                                BMX bmx = bmxes.Find(BMX => BMX.SecurityCode == iUserInput);
                                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}", bmx.Type, bmx.Make, bmx.Model, bmx.Year, bmx.WheelSize, bmx.FrameType, bmx.SecurityCode, bmx.PurchaseDate.Day, bmx.PurchaseDate.Month, bmx.PurchaseDate.Year, bmx.PurchaseCost, bmx.SaleCost, bmx.PegLength);
                            }
                            else if (bike.Type == "Mountain Bike")
                            {
                                userMenu.WriteMountainBikeHeadings();
                                MountainBike mtBike = mountainBikes.Find(MountainBike => MountainBike.SecurityCode == iUserInput);
                                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}", mtBike.Type, mtBike.Make, mtBike.Model, mtBike.Year, mtBike.WheelSize, mtBike.FrameType, mtBike.SecurityCode, mtBike.PurchaseDate.Day, mtBike.PurchaseDate.Month, mtBike.PurchaseDate.Year, mtBike.PurchaseCost, mtBike.SaleCost, mtBike.TireWidth);
                            }
                            else if (bike.Type == "Child Bike")
                            {
                                userMenu.WriteChildBikeHeadings();
                                ChildBike childBike = childBikes.Find(chBike => chBike.SecurityCode == iUserInput);
                                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}", childBike.Type, childBike.Make, childBike.Model, childBike.Year, childBike.WheelSize, childBike.FrameType, childBike.SecurityCode, childBike.PurchaseDate.Day, childBike.PurchaseDate.Month, childBike.PurchaseDate.Year, childBike.PurchaseCost, childBike.SaleCost, childBike.HasTrainingWheels);
                            }
                            else if (bike.Type == "Road Bike")
                            {
                                userMenu.WriteRoadBikeHeadings();
                                RoadBike rdBike = roadBikes.Find(roadBike => roadBike.SecurityCode == iUserInput);
                                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}", rdBike.Type, rdBike.Make, rdBike.Model, rdBike.Year, rdBike.WheelSize, rdBike.FrameType, rdBike.SecurityCode, rdBike.PurchaseDate.Day, rdBike.PurchaseDate.Month, rdBike.PurchaseDate.Year, rdBike.PurchaseCost, rdBike.SaleCost, rdBike.HasSolidTires);
                            }
                            Console.ReadLine();
                            userMenu.Menu();
                        }
                    }
                }
            }
            while (iUserInput < 0);
        }

        /// <summary>
        /// Allows user to input and create new bike.
        /// </summary>
        public void AddBike()
        {
            Console.Clear();

            //Ask user for bike variables.
            string sType = userMenu.InputType();
            string sMake = userMenu.InputMake();
            string sModel = userMenu.InputModel();
            int iYear = userMenu.InputYear();
            double dWheelSize = userMenu.InputWheelSize();
            string sFrameType = userMenu.InputFrameType();
            //iSecurityCode is treated as a unique ID.
            int iSecurityCode = userMenu.InputSecurityCode();
            DateTime dtToday = DateTime.Today.Date;
            int iPurchaseCost = 0;
            int iSaleCost = userMenu.InputSaleCost();

            //Bike Type is retrieved, then user is asked to confirm the adding of bike to stock.
            if (sType == "BMX")
            {
                double dPegLength = userMenu.InputPegLength();

                Console.Clear();
                Console.WriteLine("You put in the following details:");
                userMenu.WriteBMXBikeHeadings();
                Console.WriteLine();
                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                    sType, sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday.Day, dtToday.Month,
                    dtToday.Year, iPurchaseCost, iSaleCost, dPegLength);

                if (userMenu.Confirm("add") == true)
                {
                    BMX bmx = new BMX(sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday, iPurchaseCost, iSaleCost, dPegLength);
                    bmxes.Add(bmx);
                    SaveInStockFile();
                    userMenu.Menu();
                }
                else
                {
                    Console.WriteLine("Bike input cancelled.");
                    Console.ReadLine();
                }
            }
            else if (sType == "Child Bike")
            {
                bool bHasTrainingWheels = userMenu.InputTrainingWheels();

                Console.Clear();
                Console.WriteLine("You put in the following details:");
                userMenu.WriteChildBikeHeadings();
                Console.WriteLine();
                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                    sType, sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday.Day, dtToday.Month,
                    dtToday.Year, iPurchaseCost, iSaleCost, bHasTrainingWheels);

                if (userMenu.Confirm("add") == true)
                {
                    ChildBike bike = new ChildBike(sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday, iPurchaseCost, iSaleCost, bHasTrainingWheels);
                    childBikes.Add(bike);
                    SaveInStockFile();
                    userMenu.Menu();
                }
                else
                {
                    Console.WriteLine("Bike input cancelled.");
                    Console.ReadLine();
                }
            }
            else if (sType == "Mountain Bike")
            {
                double dTireWidth = userMenu.InputTireWidth();

                Console.Clear();
                Console.WriteLine("You put in the following details:");
                userMenu.WriteMountainBikeHeadings();
                Console.WriteLine();
                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                    sType, sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday.Day, dtToday.Month,
                    dtToday.Year, iPurchaseCost, iSaleCost, dTireWidth);

                if (userMenu.Confirm("add") == true)
                {
                    MountainBike bike = new MountainBike(sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday, iPurchaseCost, iSaleCost, dTireWidth);
                    mountainBikes.Add(bike);
                    SaveInStockFile();
                    userMenu.Menu();
                }
                else
                {
                    Console.WriteLine("Bike input cancelled.");
                    Console.ReadLine();
                }
            }
            else if (sType == "Road Bike")
            {
                bool bHasSolidTires = userMenu.InputSolidTires();

                Console.Clear();
                Console.WriteLine("You put in the following details:");
                userMenu.WriteRoadBikeHeadings();
                Console.WriteLine();
                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                    sType, sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday.Day, dtToday.Month,
                    dtToday.Year, iPurchaseCost, iSaleCost, bHasSolidTires);

                if (userMenu.Confirm("add") == true)
                {
                    RoadBike bike = new RoadBike(sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday, iPurchaseCost, iSaleCost, bHasSolidTires);
                    roadBikes.Add(bike);
                    SaveInStockFile();
                    userMenu.Menu();
                }
                else
                {
                    Console.WriteLine("Bike input cancelled.");
                    Console.ReadLine();
                }
            }
            //Take user back to main menu after inputting a new bike.
            userMenu.Menu();
        }

        /// <summary>
        /// Allow user to buy bike.
        /// </summary>
        public void BuyBike()
        {
            Console.Clear();

            //Read funds before allowing user to buy bike
            ReadFundsFile();
            Console.WriteLine("Company Funds Left: {0}", Shop.money);

            //USer inputs bike variables.
            string sType = userMenu.InputType();
            string sMake = userMenu.InputMake();
            string sModel = userMenu.InputModel();
            int iYear = userMenu.InputYear();
            double dWheelSize = userMenu.InputWheelSize();
            string sFrameType = userMenu.InputFrameType();
            //iSecurityCode is treated as a unique ID.
            int iSecurityCode = userMenu.InputSecurityCode();
            DateTime dtToday = DateTime.Today.Date;
            int iPurchaseCost = userMenu.InputPurchaseCost();
            int iSaleCost = userMenu.InputSaleCost();

            //Bike type is retrieved, then user is asked to confirm the bike purchase.
            if (sType == "BMX")
            {
                double dPegLength = userMenu.InputPegLength();

                Console.Clear();
                Console.WriteLine("You put in the following details:");
                userMenu.WriteBMXBikeHeadings();
                Console.WriteLine();
                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                    sType, sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday.Day, dtToday.Month,
                    dtToday.Year, iPurchaseCost, iSaleCost, dPegLength);

                if (userMenu.Confirm("buy") == true)
                {
                    //If company has enough funds.
                    if (money >= iPurchaseCost)
                    {
                        money -= iPurchaseCost;
                        SaveFunds();
                        BMX bmx = new BMX(sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday, iPurchaseCost, iSaleCost, dPegLength);
                        bmxes.Add(bmx);
                        SaveInStockFile();
                        userMenu.Menu();
                    }
                    else
                    {
                        Console.WriteLine("Company does not have enough funds to pay for this purchase.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Bike input cancelled.");
                    Console.ReadLine();
                }
            }
            else if (sType == "Child Bike")
            {
                bool bHasTrainingWheels = userMenu.InputTrainingWheels();

                Console.Clear();
                Console.WriteLine("You put in the following details:");
                userMenu.WriteChildBikeHeadings();
                Console.WriteLine();
                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                    sType, sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday.Day, dtToday.Month,
                    dtToday.Year, iPurchaseCost, iSaleCost, bHasTrainingWheels);

                if (userMenu.Confirm("buy") == true)
                {
                    //if company has enough funds
                    if (money >= iPurchaseCost)
                    {
                        money -= iPurchaseCost;
                        SaveFunds();
                        ChildBike bike = new ChildBike(sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday, iPurchaseCost, iSaleCost, bHasTrainingWheels);
                        childBikes.Add(bike);
                        SaveInStockFile();
                        userMenu.Menu();
                    }
                    else
                    {
                        Console.WriteLine("Company does not have enough funds to pay for this purchase.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Bike input cancelled.");
                    Console.ReadLine();
                }
            }
            else if (sType == "Mountain Bike")
            {
                double dTireWidth = userMenu.InputTireWidth();

                Console.Clear();
                Console.WriteLine("You put in the following details:");
                userMenu.WriteMountainBikeHeadings();
                Console.WriteLine();
                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                    sType, sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday.Day, dtToday.Month,
                    dtToday.Year, iPurchaseCost, iSaleCost, dTireWidth);

                if (userMenu.Confirm("buy") == true)
                {
                    if (money >= iPurchaseCost)
                    {
                        //if company has enough funds
                        money -= iPurchaseCost;
                        SaveFunds();
                        MountainBike bike = new MountainBike(sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday, iPurchaseCost, iSaleCost, dTireWidth);
                        mountainBikes.Add(bike);
                        SaveInStockFile();
                        userMenu.Menu();
                    }
                    else
                    {
                        Console.WriteLine("Company does not have enough funds to pay for this purchase.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Bike input cancelled.");
                    Console.ReadLine();
                }
            }
            else if (sType == "Road Bike")
            {
                bool bHasSolidTires = userMenu.InputSolidTires();

                Console.Clear();
                Console.WriteLine("You put in the following details:");
                userMenu.WriteRoadBikeHeadings();
                Console.WriteLine();
                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                    sType, sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday.Day, dtToday.Month,
                    dtToday.Year, iPurchaseCost, iSaleCost, bHasSolidTires);

                if (userMenu.Confirm("buy") == true)
                {
                    if (money >= iPurchaseCost)
                    {
                        //if company has enough funds
                        money -= iPurchaseCost;
                        SaveFunds();
                        RoadBike bike = new RoadBike(sMake, sModel, iYear, dWheelSize, sFrameType, iSecurityCode, dtToday, iPurchaseCost, iSaleCost, bHasSolidTires);
                        roadBikes.Add(bike);
                        SaveInStockFile();
                        userMenu.Menu();
                    }
                    else
                    {
                        Console.WriteLine("Company does not have enough funds to pay for this purchase.");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Bike input cancelled.");
                    Console.ReadLine();
                }
            }
            //Take user back to main menu after inputting a new bike.
            userMenu.Menu();
        }

        /// <summary>
        /// Allow user to remove bike.
        /// </summary>
        public void RemoveBike()
        {
            Console.WriteLine("Enter Security Code of Bike that you wish to remove.");
            //int.TryParse outputs false if input is not int.
            if (int.TryParse(Console.ReadLine(), out int iSecurityNumToDelete) == false)
            {
                //Restart method if input type is not int.
                RemoveBike();
            }
            else
            {
                //Search list for occurance of iSecurityNumToDelete.
                Bike bk = allBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToDelete);
                //List.Find() returns null if entry is not found.
                if (bk == null)
                {
                    Console.WriteLine("Bike with Security Number {0} not found.", iSecurityNumToDelete);
                }
                else
                {
                    //Displays a specific bike with a specific security number.
                    Console.WriteLine("The following bike with security code of {0} has been found.", iSecurityNumToDelete);
                    Console.WriteLine();

                    //Bike type is retrieved, then user is asked to confirm bike deletion.
                    if (bk.Type == "BMX")
                    {
                        userMenu.WriteBMXBikeHeadings();
                        Console.WriteLine();
                        BMX bmxbike = bmxes.Find(Bike => Bike.SecurityCode == iSecurityNumToDelete);
                        Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                            bmxbike.Type, bmxbike.Make, bmxbike.Model, bmxbike.Year, bmxbike.WheelSize, bmxbike.FrameType, bmxbike.SecurityCode, bmxbike.PurchaseDate.Day,
                            bmxbike.PurchaseDate.Month, bmxbike.PurchaseDate.Year, bmxbike.PurchaseCost, bmxbike.SaleCost, bmxbike.PegLength);

                        Console.WriteLine();
                        if (userMenu.Confirm("remove") == true)
                        {
                            //Remove bike entry from list.
                            allBikes.Remove(bk);
                            //Set bk properties to null. Cleared from memory by gargabe collector.
                            bk = null;
                            bmxes.Remove(bmxbike);
                            bmxbike = null;
                            Bike.iNumOfBikes--;
                            Console.WriteLine("Bike Removed.");
                        }
                    }
                    else if (bk.Type == "Mountain Bike")
                    {
                        userMenu.WriteMountainBikeHeadings();
                        Console.WriteLine();
                        MountainBike mtdbike = mountainBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToDelete);
                        Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                            mtdbike.Type, mtdbike.Make, mtdbike.Model, mtdbike.Year, mtdbike.WheelSize, mtdbike.FrameType, mtdbike.SecurityCode, mtdbike.PurchaseDate.Day,
                            mtdbike.PurchaseDate.Month, mtdbike.PurchaseDate.Year, mtdbike.PurchaseCost, mtdbike.SaleCost, mtdbike.TireWidth);

                        Console.WriteLine();
                        if (userMenu.Confirm("remove") == true)
                        {
                            //Remove bike entry from list.
                            allBikes.Remove(bk);
                            //Set bk properties to null. Cleared from memory.
                            bk = null;
                            mountainBikes.Remove(mtdbike);
                            mtdbike = null;
                            Bike.iNumOfBikes--;
                            Console.WriteLine("Bike Removed.");
                        }
                    }
                    else if (bk.Type == "Child Bike")
                    {
                        userMenu.WriteMountainBikeHeadings();
                        Console.WriteLine();
                        ChildBike childbike = childBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToDelete);
                        Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                            childbike.Type, childbike.Make, childbike.Model, childbike.Year, childbike.WheelSize, childbike.FrameType, childbike.SecurityCode, childbike.PurchaseDate.Day,
                            childbike.PurchaseDate.Month, childbike.PurchaseDate.Year, childbike.PurchaseCost, childbike.SaleCost, childbike.HasTrainingWheels);

                        Console.WriteLine();
                        if (userMenu.Confirm("remove") == true)
                        {
                            //Remove bike entry from list.
                            allBikes.Remove(bk);
                            //Set bk properties to null. Cleared from memory.
                            bk = null;
                            childBikes.Remove(childbike);
                            childbike = null;
                            Bike.iNumOfBikes--;
                            Console.WriteLine("Bike Removed.");
                        }
                    }
                    else if (bk.Type == "Road Bike")
                    {
                        userMenu.WriteMountainBikeHeadings();
                        Console.WriteLine();
                        RoadBike roadbike = roadBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToDelete);
                        Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                            roadbike.Type, roadbike.Make, roadbike.Model, roadbike.Year, roadbike.WheelSize, roadbike.FrameType, roadbike.SecurityCode, roadbike.PurchaseDate.Day,
                            roadbike.PurchaseDate.Month, roadbike.PurchaseDate.Year, roadbike.PurchaseCost, roadbike.SaleCost, roadbike.HasSolidTires);

                        Console.WriteLine();
                        if (userMenu.Confirm("remove") == true)
                        {
                            //Remove bike entry from list.
                            allBikes.Remove(bk);
                            //Set bk properties to null. Cleared from memory.
                            bk = null;
                            roadBikes.Remove(roadbike);
                            roadbike = null;
                            Bike.iNumOfBikes--;
                            Console.WriteLine("Bike Removed.");
                        }
                    }
                }
            }
            SaveInStockFile();
            Console.ReadLine();
            userMenu.Menu();
        }

        /// <summary>
        /// Allow user to sell a bike to customer.
        /// </summary>
        public void SellBike()
        {
            Console.WriteLine("Enter Security Number of Bike that you wish to sell:");
            //int.TryParse() returns false if input is not int.
            if (int.TryParse(Console.ReadLine(), out int iSecurityNumToSell) == false)
            {
                SellBike();
            }
            else
            {
                //Search list for occurance of iSecurityNumToDelete.
                Bike bk = allBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToSell);
                //List.Find() returns null if entry is not found.
                if (bk == null)
                {
                    Console.WriteLine("Bike with Security Number {0} not found.", iSecurityNumToSell);
                    Console.ReadLine();
                    userMenu.Menu();
                }
                //Displays a specific bike with a specific security number.
                Console.WriteLine("The following bike with security code of {0} has been found.", iSecurityNumToSell);
                Console.WriteLine();

                //Bike type is retrieved, then user is asked to confirm sale of bike.
                if (bk.Type == "BMX")
                {
                    userMenu.WriteBMXBikeHeadings();
                    Console.WriteLine();
                    BMX bmxbike = bmxes.Find(Bike => Bike.SecurityCode == iSecurityNumToSell);
                    Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                        bmxbike.Type, bmxbike.Make, bmxbike.Model, bmxbike.Year, bmxbike.WheelSize, bmxbike.FrameType, bmxbike.SecurityCode, bmxbike.PurchaseDate.Day,
                        bmxbike.PurchaseDate.Month, bmxbike.PurchaseDate.Year, bmxbike.PurchaseCost, bmxbike.SaleCost, bmxbike.PegLength);

                    Console.WriteLine();
                    if (userMenu.Confirm("sell") == true)
                    {
                        string sSoldToName = userMenu.InputSoldToName();
                        double sSoldToPhoneNumber = userMenu.InputSoldToNumber();
                        string sSoldToAddress = userMenu.InputSoldToAddress();
                        //Make bike sold.
                        SoldBMX soldbmx = new SoldBMX(bmxbike.Make, bmxbike.Model, bmxbike.Year, bmxbike.WheelSize, bmxbike.FrameType, bmxbike.SecurityCode, bmxbike.PurchaseDate.Date,
                            bmxbike.PurchaseCost, bmxbike.SaleCost, bmxbike.PegLength, sSoldToName, sSoldToPhoneNumber, sSoldToAddress);
                        soldBMXes.Add(soldbmx);
                        SaveSoldBikesFile();
                        //Remove bike from stock and bikes lists.
                        allBikes.Remove(bk);
                        //Set bk properties to null. Cleared from memory.
                        bk = null;
                        bmxes.Remove(bmxbike);
                        bmxbike = null;
                        SaveInStockFile();
                        //Add funds to company.
                        money += soldbmx.SaleCost;
                        SaveFunds();
                        Bike.iNumOfBikes -= 1;
                        Console.WriteLine("Bike Sold.");
                    }
                    else
                    {
                        Console.WriteLine("Bike Sale Cancelled.");
                    }
                }
                else if (bk.Type == "Mountain Bike")
                {
                    userMenu.WriteMountainBikeHeadings();
                    Console.WriteLine();
                    MountainBike mtdbike = mountainBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToSell);
                    Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                        mtdbike.Type, mtdbike.Make, mtdbike.Model, mtdbike.Year, mtdbike.WheelSize, mtdbike.FrameType, mtdbike.SecurityCode, mtdbike.PurchaseDate.Day,
                        mtdbike.PurchaseDate.Month, mtdbike.PurchaseDate.Year, mtdbike.PurchaseCost, mtdbike.SaleCost, mtdbike.TireWidth);

                    Console.WriteLine();
                    if (userMenu.Confirm("sell") == true)
                    {
                        string sSoldToName = userMenu.InputSoldToName();
                        double sSoldToPhoneNumber = userMenu.InputSoldToNumber();
                        string sSoldToAddress = userMenu.InputSoldToAddress();
                        //Make bike sold.
                        SoldMountainBike soldmtdbike = new SoldMountainBike(mtdbike.Make, mtdbike.Model, mtdbike.Year, mtdbike.WheelSize, mtdbike.FrameType, mtdbike.SecurityCode, mtdbike.PurchaseDate.Date,
                            mtdbike.PurchaseCost, mtdbike.SaleCost, mtdbike.TireWidth, sSoldToName, sSoldToPhoneNumber, sSoldToAddress);
                        soldMountainBikes.Add(soldmtdbike);
                        SaveSoldBikesFile();
                        //Remove bike from stock and bikes lists.
                        allBikes.Remove(bk);
                        //Set bk properties to null. Cleared from memory.
                        bk = null;
                        mountainBikes.Remove(mtdbike);
                        mtdbike = null;
                        SaveInStockFile();
                        //Add funds to company.
                        money += soldmtdbike.SaleCost;
                        SaveFunds();
                        Bike.iNumOfBikes -= 1;
                        Console.WriteLine("Bike Sold.");
                    }
                    else
                    {
                        Console.WriteLine("Bike Sale Cancelled.");
                    }
                }
                else if (bk.Type == "Child Bike")
                {
                    userMenu.WriteMountainBikeHeadings();
                    Console.WriteLine();
                    ChildBike childbike = childBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToSell);
                    Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                        childbike.Type, childbike.Make, childbike.Model, childbike.Year, childbike.WheelSize, childbike.FrameType, childbike.SecurityCode, childbike.PurchaseDate.Day,
                        childbike.PurchaseDate.Month, childbike.PurchaseDate.Year, childbike.PurchaseCost, childbike.SaleCost, childbike.HasTrainingWheels);

                    Console.WriteLine();
                    if (userMenu.Confirm("sell") == true)
                    {
                        string sSoldToName = userMenu.InputSoldToName();
                        double sSoldToPhoneNumber = userMenu.InputSoldToNumber();
                        string sSoldToAddress = userMenu.InputSoldToAddress();
                        //Make bike sold.
                        SoldChildBike soldchildbike = new SoldChildBike(childbike.Make, childbike.Model, childbike.Year, childbike.WheelSize, childbike.FrameType, childbike.SecurityCode, childbike.PurchaseDate.Date,
                            childbike.PurchaseCost, childbike.SaleCost, childbike.HasTrainingWheels, sSoldToName, sSoldToPhoneNumber, sSoldToAddress);
                        soldChildBikes.Add(soldchildbike);
                        SaveSoldBikesFile();
                        //Remove bike from stock and bikes lists.
                        allBikes.Remove(bk);
                        //Set bk properties to null. Cleared from memory.
                        bk = null;
                        childBikes.Remove(childbike);
                        childbike = null;
                        SaveInStockFile();
                        //Add funds to company.
                        money += soldchildbike.SaleCost;
                        SaveFunds();
                        Bike.iNumOfBikes -= 1;
                        Console.WriteLine("Bike Sold.");
                    }
                    else
                    {
                        Console.WriteLine("Bike Sale Cancelled.");
                    }
                }
                else if (bk.Type == "Road Bike")
                {
                    userMenu.WriteMountainBikeHeadings();
                    Console.WriteLine();
                    RoadBike roadbike = roadBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToSell);
                    Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                        roadbike.Type, roadbike.Make, roadbike.Model, roadbike.Year, roadbike.WheelSize, roadbike.FrameType, roadbike.SecurityCode, roadbike.PurchaseDate.Day,
                        roadbike.PurchaseDate.Month, roadbike.PurchaseDate.Year, roadbike.PurchaseCost, roadbike.SaleCost, roadbike.HasSolidTires);

                    Console.WriteLine();
                    if (userMenu.Confirm("sell") == true)
                    {
                        string sSoldToName = userMenu.InputSoldToName();
                        double sSoldToPhoneNumber = userMenu.InputSoldToNumber();
                        string sSoldToAddress = userMenu.InputSoldToAddress();
                        //Make bike sold.
                        SoldRoadBike soldroadbike = new SoldRoadBike(roadbike.Make, roadbike.Model, roadbike.Year, roadbike.WheelSize, roadbike.FrameType, roadbike.SecurityCode, roadbike.PurchaseDate.Date,
                            roadbike.PurchaseCost, roadbike.SaleCost, roadbike.HasSolidTires, sSoldToName, sSoldToPhoneNumber, sSoldToAddress);
                        soldRoadBikes.Add(soldroadbike);
                        SaveSoldBikesFile();
                        //Remove bike from stock and bikes lists.
                        allBikes.Remove(bk);
                        //Set bk properties to null. Cleared from memory.
                        bk = null;
                        roadBikes.Remove(roadbike);
                        roadbike = null;
                        SaveInStockFile();
                        //Add funds to company.
                        money += soldroadbike.SaleCost;
                        SaveFunds();
                        Bike.iNumOfBikes -= 1;
                        Console.WriteLine("Bike Sold.");
                    }
                    else
                    {
                        Console.WriteLine("Bike Sale Cancelled.");
                    }
                }
            }
            Console.ReadLine();
            userMenu.Menu();
        }

        /// <summary>
        /// Allow user to edit bike present in Bikes List.
        /// </summary>
        public void EditBike()
        {
            Console.WriteLine("Enter Security Number of Bike that you wish to edit:");
            //int.TryParse() returns false if input is not int.
            if (int.TryParse(Console.ReadLine(), out int iSecurityNumToEdit) == false)
            {
                EditBike();
            }
            else
            {
                //Search list for occurance of iSecurityNumToDelete.
                Bike bk = allBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToEdit);
                //List.Find() returns null if entry is not found.
                if (bk == null)
                {
                    Console.WriteLine("Bike with Security Number {0} not found.", iSecurityNumToEdit);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The following bike with security code of {0} has been found.", iSecurityNumToEdit);
                    //Can implement this again. \/
                    //userMenu.DisplayParticularBike(iSecurityNumToEdit);
                    Console.WriteLine();

                    if (bk.Type == "BMX")
                    {
                        userMenu.WriteBMXBikeHeadings();
                        Console.WriteLine();
                        //Displays a specific bike with a specific security number.
                        BMX bmxbike = bmxes.Find(Bike => Bike.SecurityCode == iSecurityNumToEdit);
                        Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                           bmxbike.Type, bmxbike.Make, bmxbike.Model, bmxbike.Year, bmxbike.WheelSize, bmxbike.FrameType, bmxbike.SecurityCode, bmxbike.PurchaseDate.Day,
                           bmxbike.PurchaseDate.Month, bmxbike.PurchaseDate.Year, bmxbike.PurchaseCost, bmxbike.SaleCost, bmxbike.PegLength);
                        Console.WriteLine();

                        if (userMenu.ConfirmBikeEdit() == true)
                        {
                            //User will not be able to change type, security code, purchase date, purchase cost.
                            //Type, security code, purchase date, purchase cost can be changed after removing and buying/adding a new bike.
                            //User will not be able to change hired or sold bikes. These bikes have to be returned first.
                            string sMake = userMenu.InputMake();
                            string sModel = userMenu.InputModel();
                            int iYear = userMenu.InputYear();
                            double dWheelSize = userMenu.InputWheelSize();
                            string sFrameType = userMenu.InputFrameType();
                            int iSaleCost = userMenu.InputSaleCost();
                            double dPegLength = userMenu.InputPegLength();

                            if (userMenu.ConfirmSavingEditedBike() == true)
                            {
                                bmxbike.Make = sMake;
                                bmxbike.Model = sModel;
                                bmxbike.Year = iYear;
                                bmxbike.WheelSize = dWheelSize;
                                bmxbike.FrameType = sFrameType;
                                bmxbike.SaleCost = iSaleCost;
                                bmxbike.PegLength = dPegLength;
                                SaveInStockFile();
                            }
                            else
                            {
                                Console.WriteLine("Bike changes not saved.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bike editing cancelled.");
                        }
                    }
                    else if (bk.Type == "Mountain Bike")
                    {
                        userMenu.WriteMountainBikeHeadings();
                        Console.WriteLine();
                        //Displays a specific bike with a specific security number.
                        MountainBike mtdbike = mountainBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToEdit);
                        Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                           mtdbike.Type, mtdbike.Make, mtdbike.Model, mtdbike.Year, mtdbike.WheelSize, mtdbike.FrameType, mtdbike.SecurityCode, mtdbike.PurchaseDate.Day,
                           mtdbike.PurchaseDate.Month, mtdbike.PurchaseDate.Year, mtdbike.PurchaseCost, mtdbike.SaleCost, mtdbike.TireWidth);
                        Console.WriteLine();

                        if (userMenu.ConfirmBikeEdit() == true)
                        {
                            //User will not be able to change type, security code, purchase date, purchase cost.
                            //Type, security code, purchase date, purchase cost can be changed after removing and buying/adding a new bike.
                            //User will not be able to change hired or sold bikes. These bikes have to be returned first.
                            string sMake = userMenu.InputMake();
                            string sModel = userMenu.InputModel();
                            int iYear = userMenu.InputYear();
                            double dWheelSize = userMenu.InputWheelSize();
                            string sFrameType = userMenu.InputFrameType();
                            int iSaleCost = userMenu.InputSaleCost();
                            double dTireWidth = userMenu.InputTireWidth();

                            if (userMenu.ConfirmSavingEditedBike() == true)
                            {
                                mtdbike.Make = sMake;
                                mtdbike.Model = sModel;
                                mtdbike.Year = iYear;
                                mtdbike.WheelSize = dWheelSize;
                                mtdbike.FrameType = sFrameType;
                                mtdbike.SaleCost = iSaleCost;
                                mtdbike.TireWidth = dTireWidth;
                                SaveInStockFile();
                            }
                            else
                            {
                                Console.WriteLine("Bike changes not saved.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bike editing cancelled.");
                        }
                    }
                    else if (bk.Type == "Child Bike")
                    {
                        userMenu.WriteChildBikeHeadings();
                        Console.WriteLine();
                        //Displays a specific bike with a specific security number.
                        ChildBike childbike = childBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToEdit);
                        Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                           childbike.Type, childbike.Make, childbike.Model, childbike.Year, childbike.WheelSize, childbike.FrameType, childbike.SecurityCode, childbike.PurchaseDate.Day,
                           childbike.PurchaseDate.Month, childbike.PurchaseDate.Year, childbike.PurchaseCost, childbike.SaleCost, childbike.HasTrainingWheels);
                        Console.WriteLine();

                        if (userMenu.ConfirmBikeEdit() == true)
                        {
                            //User will not be able to change type, security code, purchase date, purchase cost.
                            //Type, security code, purchase date, purchase cost can be changed after removing and buying/adding a new bike.
                            //User will not be able to change hired or sold bikes. These bikes have to be returned first.
                            string sMake = userMenu.InputMake();
                            string sModel = userMenu.InputModel();
                            int iYear = userMenu.InputYear();
                            double dWheelSize = userMenu.InputWheelSize();
                            string sFrameType = userMenu.InputFrameType();
                            int iSaleCost = userMenu.InputSaleCost();
                            bool bHasTrainingWheels = userMenu.InputTrainingWheels();

                            if (userMenu.ConfirmSavingEditedBike() == true)
                            {
                                childbike.Make = sMake;
                                childbike.Model = sModel;
                                childbike.Year = iYear;
                                childbike.WheelSize = dWheelSize;
                                childbike.FrameType = sFrameType;
                                childbike.SaleCost = iSaleCost;
                                childbike.HasTrainingWheels = bHasTrainingWheels;
                                SaveInStockFile();
                            }
                            else
                            {
                                Console.WriteLine("Bike changes not saved.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bike editing cancelled.");
                        }
                    }
                    else if (bk.Type == "Road Bike")
                    {
                        userMenu.WriteRoadBikeHeadings();
                        Console.WriteLine();
                        //Displays a specific bike with a specific security number.
                        RoadBike roadbike = roadBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToEdit);
                        Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                           roadbike.Type, roadbike.Make, roadbike.Model, roadbike.Year, roadbike.WheelSize, roadbike.FrameType, roadbike.SecurityCode, roadbike.PurchaseDate.Day,
                           roadbike.PurchaseDate.Month, roadbike.PurchaseDate.Year, roadbike.PurchaseCost, roadbike.SaleCost, roadbike.HasSolidTires);
                        Console.WriteLine();

                        if (userMenu.ConfirmBikeEdit() == true)
                        {
                            //User will not be able to change type, security code, purchase date, purchase cost.
                            //Type, security code, purchase date, purchase cost can be changed after removing and buying/adding a new bike.
                            //User will not be able to change hired or sold bikes. These bikes have to be returned first.
                            string sMake = userMenu.InputMake();
                            string sModel = userMenu.InputModel();
                            int iYear = userMenu.InputYear();
                            double dWheelSize = userMenu.InputWheelSize();
                            string sFrameType = userMenu.InputFrameType();
                            int iSaleCost = userMenu.InputSaleCost();
                            bool bHasSolidTires = userMenu.InputSolidTires();

                            if (userMenu.ConfirmSavingEditedBike() == true)
                            {
                                roadbike.Make = sMake;
                                roadbike.Model = sModel;
                                roadbike.Year = iYear;
                                roadbike.WheelSize = dWheelSize;
                                roadbike.FrameType = sFrameType;
                                roadbike.SaleCost = iSaleCost;
                                roadbike.HasSolidTires = bHasSolidTires;
                                SaveInStockFile();
                            }
                            else
                            {
                                Console.WriteLine("Bike changes not saved.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bike editing cancelled.");
                        }
                    }
                }
            }
            Console.ReadLine();
            userMenu.Menu();
        }

        /// <summary>
        /// Allow user to save bikes to inventory file
        /// </summary>
        public void SaveInStockFile()
        {
            //What line is being saved
            int iCounter = 0;

            //How many lines in total need to be saved
            int iTotalBMXLinesToSave = iInStockBikesVarNum * bmxes.Count;
            int iTotalChildBikeLinesToSave = iInStockBikesVarNum * childBikes.Count;
            int iTotalRoadBikesLinesToSave = iInStockBikesVarNum * roadBikes.Count;
            int iTotalMountainBikesLinesToSave = iInStockBikesVarNum * mountainBikes.Count;
            int iTotalLinesToSave = iTotalBMXLinesToSave + iTotalChildBikeLinesToSave + iTotalMountainBikesLinesToSave + iTotalRoadBikesLinesToSave;

            string[] ToSave = new string[iTotalLinesToSave];

            //Split saving file into 4 parts.
            //BMX, Child Bike, Road Bike, Mountain Bike.
            //Each bike type has different variable.

            foreach(var bike in bmxes)
            {
                ToSave[iCounter++] = "BMX";
                ToSave[iCounter++] = bike.Make;
                ToSave[iCounter++] = bike.Model;
                ToSave[iCounter++] = bike.Year.ToString();
                ToSave[iCounter++] = bike.WheelSize.ToString();
                ToSave[iCounter++] = bike.FrameType;
                ToSave[iCounter++] = bike.SecurityCode.ToString();
                ToSave[iCounter++] = bike.PurchaseDate.Day.ToString() + "/" + bike.PurchaseDate.Month.ToString() + "/" + bike.PurchaseDate.Year.ToString();
                ToSave[iCounter++] = bike.PurchaseCost.ToString();
                ToSave[iCounter++] = bike.SaleCost.ToString();
                ToSave[iCounter++] = bike.IsHired.ToString();
                ToSave[iCounter++] = bike.IsSold.ToString();
                ToSave[iCounter++] = bike.PegLength.ToString();
                ToSave[iCounter++] = "";
            }

            foreach (var bike in childBikes) {
                ToSave[iCounter++] = "Child Bike";
                ToSave[iCounter++] = bike.Make;
                ToSave[iCounter++] = bike.Model;
                ToSave[iCounter++] = bike.Year.ToString();
                ToSave[iCounter++] = bike.WheelSize.ToString();
                ToSave[iCounter++] = bike.FrameType;
                ToSave[iCounter++] = bike.SecurityCode.ToString();
                ToSave[iCounter++] = bike.PurchaseDate.Day.ToString() + "/" + bike.PurchaseDate.Month.ToString() + "/" + bike.PurchaseDate.Year.ToString();
                ToSave[iCounter++] = bike.PurchaseCost.ToString();
                ToSave[iCounter++] = bike.SaleCost.ToString();
                ToSave[iCounter++] = bike.IsHired.ToString();
                ToSave[iCounter++] = bike.IsSold.ToString();
                ToSave[iCounter++] = bike.HasTrainingWheels.ToString();
                ToSave[iCounter++] = "";
            }

            foreach (var bike in mountainBikes)
            {
                ToSave[iCounter++] = "Mountain Bike";
                ToSave[iCounter++] = bike.Make;
                ToSave[iCounter++] = bike.Model;
                ToSave[iCounter++] = bike.Year.ToString();
                ToSave[iCounter++] = bike.WheelSize.ToString();
                ToSave[iCounter++] = bike.FrameType;
                ToSave[iCounter++] = bike.SecurityCode.ToString();
                ToSave[iCounter++] = bike.PurchaseDate.Day.ToString() + "/" + bike.PurchaseDate.Month.ToString() + "/" + bike.PurchaseDate.Year.ToString();
                ToSave[iCounter++] = bike.PurchaseCost.ToString();
                ToSave[iCounter++] = bike.SaleCost.ToString();
                ToSave[iCounter++] = bike.IsHired.ToString();
                ToSave[iCounter++] = bike.IsSold.ToString();
                ToSave[iCounter++] = bike.TireWidth.ToString();
                ToSave[iCounter++] = "";
            }

            foreach (var bike in roadBikes)
            {
                ToSave[iCounter++] = "Road Bike";
                ToSave[iCounter++] = bike.Make;
                ToSave[iCounter++] = bike.Model;
                ToSave[iCounter++] = bike.Year.ToString();
                ToSave[iCounter++] = bike.WheelSize.ToString();
                ToSave[iCounter++] = bike.FrameType;
                ToSave[iCounter++] = bike.SecurityCode.ToString();
                ToSave[iCounter++] = bike.PurchaseDate.Day.ToString() + "/" + bike.PurchaseDate.Month.ToString() + "/" + bike.PurchaseDate.Year.ToString();
                ToSave[iCounter++] = bike.PurchaseCost.ToString();
                ToSave[iCounter++] = bike.SaleCost.ToString();
                ToSave[iCounter++] = bike.IsHired.ToString();
                ToSave[iCounter++] = bike.IsSold.ToString();
                ToSave[iCounter++] = bike.HasSolidTires.ToString();
                ToSave[iCounter++] = "";
            }

            //Overwrites inventory file with bike information array using own File Writing method.
            UserMenu.WriteAllLinesBetter(sInStockFile, ToSave);
            Console.WriteLine("Stock File Saved Succesfully.");
            Console.ReadLine();
        }

        /// <summary>
        /// Allow user to save sold bikes to sold bikes file.
        /// </summary>
        public void SaveSoldBikesFile()
        {
            //What line is being saved
            int iCounter = 0;

            //How many lines in total need to be saved
            int iTotalBMXLinesToSave = iSoldBikesVarNum * soldBMXes.Count;
            int iTotalChildBikeLinesToSave = iSoldBikesVarNum * soldChildBikes.Count;
            int iTotalRoadBikesLinesToSave = iSoldBikesVarNum * soldRoadBikes.Count;
            int iTotalMountainBikesLinesToSave = iSoldBikesVarNum * soldMountainBikes.Count;
            int iTotalLinesToSave = iTotalBMXLinesToSave + iTotalChildBikeLinesToSave + iTotalMountainBikesLinesToSave + iTotalRoadBikesLinesToSave;

            string[] ToSave = new string[iTotalLinesToSave];

            //Split saving file into 4 parts.
            //BMX, Child Bike, Road Bike, Mountain Bike.
            //Each bike type has different variable.

            foreach (var bike in soldBMXes)
            {
                ToSave[iCounter++] = "BMX";
                ToSave[iCounter++] = bike.Make;
                ToSave[iCounter++] = bike.Model;
                ToSave[iCounter++] = bike.Year.ToString();
                ToSave[iCounter++] = bike.WheelSize.ToString();
                ToSave[iCounter++] = bike.FrameType;
                ToSave[iCounter++] = bike.SecurityCode.ToString();
                ToSave[iCounter++] = bike.PurchaseDate.Day.ToString() + "/" + bike.PurchaseDate.Month.ToString() + "/" + bike.PurchaseDate.Year.ToString();
                ToSave[iCounter++] = bike.PurchaseCost.ToString();
                ToSave[iCounter++] = bike.SaleCost.ToString();
                ToSave[iCounter++] = bike.IsHired.ToString();
                ToSave[iCounter++] = bike.IsSold.ToString();
                ToSave[iCounter++] = bike.PegLength.ToString();
                ToSave[iCounter++] = bike.SoldToName;
                ToSave[iCounter++] = bike.SoldToPhoneNumber.ToString();
                ToSave[iCounter++] = bike.SoldToAddress;
                ToSave[iCounter++] = "";
            }

            foreach (var bike in soldChildBikes)
            {
                ToSave[iCounter++] = "Child Bike";
                ToSave[iCounter++] = bike.Make;
                ToSave[iCounter++] = bike.Model;
                ToSave[iCounter++] = bike.Year.ToString();
                ToSave[iCounter++] = bike.WheelSize.ToString();
                ToSave[iCounter++] = bike.FrameType;
                ToSave[iCounter++] = bike.SecurityCode.ToString();
                ToSave[iCounter++] = bike.PurchaseDate.Day.ToString() + "/" + bike.PurchaseDate.Month.ToString() + "/" + bike.PurchaseDate.Year.ToString();
                ToSave[iCounter++] = bike.PurchaseCost.ToString();
                ToSave[iCounter++] = bike.SaleCost.ToString();
                ToSave[iCounter++] = bike.IsHired.ToString();
                ToSave[iCounter++] = bike.IsSold.ToString();
                ToSave[iCounter++] = bike.HasTrainingWheels.ToString();
                ToSave[iCounter++] = bike.SoldToName;
                ToSave[iCounter++] = bike.SoldToPhoneNumber.ToString();
                ToSave[iCounter++] = bike.SoldToAddress;
                ToSave[iCounter++] = "";
            }

            foreach (var bike in soldMountainBikes)
            {
                ToSave[iCounter++] = "Mountain Bike";
                ToSave[iCounter++] = bike.Make;
                ToSave[iCounter++] = bike.Model;
                ToSave[iCounter++] = bike.Year.ToString();
                ToSave[iCounter++] = bike.WheelSize.ToString();
                ToSave[iCounter++] = bike.FrameType;
                ToSave[iCounter++] = bike.SecurityCode.ToString();
                ToSave[iCounter++] = bike.PurchaseDate.Day.ToString() + "/" + bike.PurchaseDate.Month.ToString() + "/" + bike.PurchaseDate.Year.ToString();
                ToSave[iCounter++] = bike.PurchaseCost.ToString();
                ToSave[iCounter++] = bike.SaleCost.ToString();
                ToSave[iCounter++] = bike.IsHired.ToString();
                ToSave[iCounter++] = bike.IsSold.ToString();
                ToSave[iCounter++] = bike.TireWidth.ToString();
                ToSave[iCounter++] = bike.SoldToName;
                ToSave[iCounter++] = bike.SoldToPhoneNumber.ToString();
                ToSave[iCounter++] = bike.SoldToAddress;
                ToSave[iCounter++] = "";
            }

            foreach (var bike in soldRoadBikes)
            {
                ToSave[iCounter++] = "Road Bike";
                ToSave[iCounter++] = bike.Make;
                ToSave[iCounter++] = bike.Model;
                ToSave[iCounter++] = bike.Year.ToString();
                ToSave[iCounter++] = bike.WheelSize.ToString();
                ToSave[iCounter++] = bike.FrameType;
                ToSave[iCounter++] = bike.SecurityCode.ToString();
                ToSave[iCounter++] = bike.PurchaseDate.Day.ToString() + "/" + bike.PurchaseDate.Month.ToString() + "/" + bike.PurchaseDate.Year.ToString();
                ToSave[iCounter++] = bike.PurchaseCost.ToString();
                ToSave[iCounter++] = bike.SaleCost.ToString();
                ToSave[iCounter++] = bike.IsHired.ToString();
                ToSave[iCounter++] = bike.IsSold.ToString();
                ToSave[iCounter++] = bike.HasSolidTires.ToString();
                ToSave[iCounter++] = bike.SoldToName;
                ToSave[iCounter++] = bike.SoldToPhoneNumber.ToString();
                ToSave[iCounter++] = bike.SoldToAddress;
                ToSave[iCounter++] = "";
            }

            //Overwrites sold bikes file with bike information array using own File Writing method.
            UserMenu.WriteAllLinesBetter(sSoldBikesFile, ToSave);
            Console.WriteLine("Sold Bikes File Saved Succesfully.");
            Console.ReadLine();
        }

        /// <summary>
        /// Allow user to hire out a bike to a customer.
        /// </summary>
        public void HireBike()
        {
            Console.Clear();
            //User inputs security num of bike to rent out.
            Console.WriteLine("Enter Security Number of Bike that you wish to hire out:");
            //int.TryParse() returns false if input is not int.
            if (int.TryParse(Console.ReadLine(), out int iSecurityNumToHire) == false)
            {
                HireBike();
            }
            else
            {
                //Search list for occurance of iSecurityNumToHire.
                Bike bk = allBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToHire);
                //List.Find() returns null if entry is not found.
                if (bk == null)
                {
                    Console.WriteLine("Bike with Security Number {0} not found.", iSecurityNumToHire);
                }
                else
                {
                    Console.WriteLine("The following bike with security code of {0} has been found.", iSecurityNumToHire);
                    Console.WriteLine();

                    if (bk.Type == "BMX")
                    {
                        userMenu.WriteBMXBikeHeadings();
                        Console.WriteLine();
                        //Displays a specific bike with a specific security number.
                        BMX bmxbike = bmxes.Find(Bike => Bike.SecurityCode == iSecurityNumToHire);
                        Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                           bmxbike.Type, bmxbike.Make, bmxbike.Model, bmxbike.Year, bmxbike.WheelSize, bmxbike.FrameType, bmxbike.SecurityCode, bmxbike.PurchaseDate.Day,
                           bmxbike.PurchaseDate.Month, bmxbike.PurchaseDate.Year, bmxbike.PurchaseCost, bmxbike.SaleCost, bmxbike.PegLength);
                        Console.WriteLine();

                        if (userMenu.Confirm("hire") == true)
                        {
                            string sHiredToName = userMenu.InputHiredToName();
                            double dHiredToNumber = userMenu.InputHiredToNumber();
                            string sHiredToAddress = userMenu.InputHiredToAddress();
                            //Make bike hired.
                            HiredBMX hiredbmx = new HiredBMX(bmxbike.Make, bmxbike.Model, bmxbike.Year, bmxbike.WheelSize, bmxbike.FrameType, bmxbike.SecurityCode, bmxbike.PurchaseDate.Date,
                                bmxbike.PurchaseCost, bmxbike.SaleCost, bmxbike.PegLength, sHiredToName, dHiredToNumber, sHiredToAddress);
                            hiredBMXes.Add(hiredbmx);
                            SaveHiredBikesFile();
                            //Remove bike from stock and bikes lists.
                            allBikes.Remove(bk);
                            //Set bk properties to null. Cleared from memory.
                            bk = null;
                            bmxes.Remove(bmxbike);
                            bmxbike = null;
                            SaveInStockFile();
                            Bike.iNumOfBikes -= 1;
                            Console.WriteLine("Bike Hired.");
                        }
                        else
                        {
                            Console.WriteLine("Bike Sale Cancelled.");
                        }
                    }
                    else if (bk.Type == "Mountain Bike")
                    {
                        userMenu.WriteMountainBikeHeadings();
                        Console.WriteLine();
                        //Displays a specific bike with a specific security number.
                        MountainBike mtdbike = mountainBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToHire);
                        Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                           mtdbike.Type, mtdbike.Make, mtdbike.Model, mtdbike.Year, mtdbike.WheelSize, mtdbike.FrameType, mtdbike.SecurityCode, mtdbike.PurchaseDate.Day,
                           mtdbike.PurchaseDate.Month, mtdbike.PurchaseDate.Year, mtdbike.PurchaseCost, mtdbike.SaleCost, mtdbike.TireWidth);
                        Console.WriteLine();

                        if (userMenu.Confirm("hire") == true)
                        {
                            string sHiredToName = userMenu.InputHiredToName();
                            double dHiredToNumber = userMenu.InputHiredToNumber();
                            string sHiredToAddress = userMenu.InputHiredToAddress();
                            //Make bike hired.
                            HiredMountainBike hiredmtdbike = new HiredMountainBike(mtdbike.Make, mtdbike.Model, mtdbike.Year, mtdbike.WheelSize, mtdbike.FrameType, mtdbike.SecurityCode,
                                mtdbike.PurchaseDate.Date, mtdbike.PurchaseCost, mtdbike.SaleCost, mtdbike.TireWidth, sHiredToName, dHiredToNumber, sHiredToAddress);
                            hiredMountainBikes.Add(hiredmtdbike);
                            SaveHiredBikesFile();
                            //Remove bike from stock and bikes lists.
                            allBikes.Remove(bk);
                            //Set bk properties to null. Cleared from memory.
                            bk = null;
                            mountainBikes.Remove(mtdbike);
                            mtdbike = null;
                            SaveInStockFile();
                            Bike.iNumOfBikes -= 1;
                            Console.WriteLine("Bike Hired.");
                        }
                        else
                        {
                            Console.WriteLine("Bike Sale Cancelled.");
                        }
                    }
                    else if (bk.Type == "Road Bike")
                    {
                        userMenu.WriteRoadBikeHeadings();
                        Console.WriteLine();
                        //Displays a specific bike with a specific security number.
                        RoadBike roadbike = roadBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToHire);
                        Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                           roadbike.Type, roadbike.Make, roadbike.Model, roadbike.Year, roadbike.WheelSize, roadbike.FrameType, roadbike.SecurityCode, roadbike.PurchaseDate.Day,
                           roadbike.PurchaseDate.Month, roadbike.PurchaseDate.Year, roadbike.PurchaseCost, roadbike.SaleCost, roadbike.HasSolidTires);
                        Console.WriteLine();

                        if (userMenu.Confirm("hire") == true)
                        {
                            string sHiredToName = userMenu.InputHiredToName();
                            double dHiredToNumber = userMenu.InputHiredToNumber();
                            string sHiredToAddress = userMenu.InputHiredToAddress();
                            //Make bike hired.
                            HiredRoadBike hiredroadbike = new HiredRoadBike(roadbike.Make, roadbike.Model, roadbike.Year, roadbike.WheelSize, roadbike.FrameType, roadbike.SecurityCode,
                                roadbike.PurchaseDate.Date, roadbike.PurchaseCost, roadbike.SaleCost, roadbike.HasSolidTires, sHiredToName, dHiredToNumber, sHiredToAddress);
                            hiredRoadBikes.Add(hiredroadbike);
                            SaveHiredBikesFile();
                            //Remove bike from stock and bikes lists.
                            allBikes.Remove(bk);
                            //Set bk properties to null. Cleared from memory.
                            bk = null;
                            roadBikes.Remove(roadbike);
                            roadbike = null;
                            SaveInStockFile();
                            Bike.iNumOfBikes -= 1;
                            Console.WriteLine("Bike Hired.");
                        }
                        else
                        {
                            Console.WriteLine("Bike Sale Cancelled.");
                        }
                    }
                    else if (bk.Type == "Child Bike")
                    {
                        userMenu.WriteChildBikeHeadings();
                        Console.WriteLine();
                        //Displays a specific bike with a specific security number.
                        ChildBike childbike = childBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToHire);
                        Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12:00.0}",
                           childbike.Type, childbike.Make, childbike.Model, childbike.Year, childbike.WheelSize, childbike.FrameType, childbike.SecurityCode, childbike.PurchaseDate.Day,
                           childbike.PurchaseDate.Month, childbike.PurchaseDate.Year, childbike.PurchaseCost, childbike.SaleCost, childbike.HasTrainingWheels);
                        Console.WriteLine();

                        if (userMenu.Confirm("hire") == true)
                        {
                            string sHiredToName = userMenu.InputHiredToName();
                            double dHiredToNumber = userMenu.InputHiredToNumber();
                            string sHiredToAddress = userMenu.InputHiredToAddress();
                            //Make bike hired.
                            HiredChildBike hiredchildbike = new HiredChildBike(childbike.Make, childbike.Model, childbike.Year, childbike.WheelSize, childbike.FrameType, childbike.SecurityCode,
                                childbike.PurchaseDate.Date, childbike.PurchaseCost, childbike.SaleCost, childbike.HasTrainingWheels, sHiredToName, dHiredToNumber, sHiredToAddress);
                            hiredChildBikes.Add(hiredchildbike);
                            SaveHiredBikesFile();
                            //Remove bike from stock and bikes lists.
                            allBikes.Remove(bk);
                            //Set bk properties to null. Cleared from memory.
                            bk = null;
                            childBikes.Remove(childbike);
                            childbike = null;
                            SaveInStockFile();
                            Bike.iNumOfBikes -= 1;
                            Console.WriteLine("Bike Hired.");
                        }
                        else
                        {
                            Console.WriteLine("Bike Sale Cancelled.");
                        }
                    }
                }
            }
            Console.ReadLine();
            userMenu.Menu();
        }

        /// <summary>
        /// Allow user to save hired bikes to file.
        /// </summary>
        public void SaveHiredBikesFile()
        {
            //What line is being saved
            int iCounter = 0;

            //How many lines in total need to be saved
            int iTotalBMXLinesToSave = iHiredBikesVarNum * hiredBMXes.Count;
            int iTotalChildBikeLinesToSave = iHiredBikesVarNum * hiredChildBikes.Count;
            int iTotalRoadBikesLinesToSave = iHiredBikesVarNum * hiredRoadBikes.Count;
            int iTotalMountainBikesLinesToSave = iHiredBikesVarNum * hiredMountainBikes.Count;
            int iTotalLinesToSave = iTotalBMXLinesToSave + iTotalChildBikeLinesToSave + iTotalMountainBikesLinesToSave + iTotalRoadBikesLinesToSave;

            string[] ToSave = new string[iTotalLinesToSave];

            //Split saving file into 4 parts.
            //BMX, Child Bike, Road Bike, Mountain Bike.
            //Each bike type has different variable.

            foreach (var bike in hiredBMXes)
            {
                ToSave[iCounter++] = "BMX";
                ToSave[iCounter++] = bike.Make;
                ToSave[iCounter++] = bike.Model;
                ToSave[iCounter++] = bike.Year.ToString();
                ToSave[iCounter++] = bike.WheelSize.ToString();
                ToSave[iCounter++] = bike.FrameType;
                ToSave[iCounter++] = bike.SecurityCode.ToString();
                ToSave[iCounter++] = bike.PurchaseDate.Day.ToString() + "/" + bike.PurchaseDate.Month.ToString() + "/" + bike.PurchaseDate.Year.ToString();
                ToSave[iCounter++] = bike.PurchaseCost.ToString();
                ToSave[iCounter++] = bike.SaleCost.ToString();
                ToSave[iCounter++] = bike.IsHired.ToString();
                ToSave[iCounter++] = bike.IsSold.ToString();
                ToSave[iCounter++] = bike.PegLength.ToString();
                ToSave[iCounter++] = bike.HiredToName;
                ToSave[iCounter++] = bike.HiredToPhoneNumber.ToString();
                ToSave[iCounter++] = bike.HiredToAddress;
                ToSave[iCounter++] = "";
            }

            foreach (var bike in hiredChildBikes)
            {
                ToSave[iCounter++] = "Child Bike";
                ToSave[iCounter++] = bike.Make;
                ToSave[iCounter++] = bike.Model;
                ToSave[iCounter++] = bike.Year.ToString();
                ToSave[iCounter++] = bike.WheelSize.ToString();
                ToSave[iCounter++] = bike.FrameType;
                ToSave[iCounter++] = bike.SecurityCode.ToString();
                ToSave[iCounter++] = bike.PurchaseDate.Day.ToString() + "/" + bike.PurchaseDate.Month.ToString() + "/" + bike.PurchaseDate.Year.ToString();
                ToSave[iCounter++] = bike.PurchaseCost.ToString();
                ToSave[iCounter++] = bike.SaleCost.ToString();
                ToSave[iCounter++] = bike.IsHired.ToString();
                ToSave[iCounter++] = bike.IsSold.ToString();
                ToSave[iCounter++] = bike.HasTrainingWheels.ToString();
                ToSave[iCounter++] = bike.HiredToName;
                ToSave[iCounter++] = bike.HiredToPhoneNumber.ToString();
                ToSave[iCounter++] = bike.HiredToAddress;
                ToSave[iCounter++] = "";
            }

            foreach (var bike in hiredMountainBikes)
            {
                ToSave[iCounter++] = "Mountain Bike";
                ToSave[iCounter++] = bike.Make;
                ToSave[iCounter++] = bike.Model;
                ToSave[iCounter++] = bike.Year.ToString();
                ToSave[iCounter++] = bike.WheelSize.ToString();
                ToSave[iCounter++] = bike.FrameType;
                ToSave[iCounter++] = bike.SecurityCode.ToString();
                ToSave[iCounter++] = bike.PurchaseDate.Day.ToString() + "/" + bike.PurchaseDate.Month.ToString() + "/" + bike.PurchaseDate.Year.ToString();
                ToSave[iCounter++] = bike.PurchaseCost.ToString();
                ToSave[iCounter++] = bike.SaleCost.ToString();
                ToSave[iCounter++] = bike.IsHired.ToString();
                ToSave[iCounter++] = bike.IsSold.ToString();
                ToSave[iCounter++] = bike.TireWidth.ToString();
                ToSave[iCounter++] = bike.HiredToName;
                ToSave[iCounter++] = bike.HiredToPhoneNumber.ToString();
                ToSave[iCounter++] = bike.HiredToAddress;
                ToSave[iCounter++] = "";
            }

            foreach (var bike in hiredRoadBikes)
            {
                ToSave[iCounter++] = "Road Bike";
                ToSave[iCounter++] = bike.Make;
                ToSave[iCounter++] = bike.Model;
                ToSave[iCounter++] = bike.Year.ToString();
                ToSave[iCounter++] = bike.WheelSize.ToString();
                ToSave[iCounter++] = bike.FrameType;
                ToSave[iCounter++] = bike.SecurityCode.ToString();
                ToSave[iCounter++] = bike.PurchaseDate.Day.ToString() + "/" + bike.PurchaseDate.Month.ToString() + "/" + bike.PurchaseDate.Year.ToString();
                ToSave[iCounter++] = bike.PurchaseCost.ToString();
                ToSave[iCounter++] = bike.SaleCost.ToString();
                ToSave[iCounter++] = bike.IsHired.ToString();
                ToSave[iCounter++] = bike.IsSold.ToString();
                ToSave[iCounter++] = bike.HasSolidTires.ToString();
                ToSave[iCounter++] = bike.HiredToName;
                ToSave[iCounter++] = bike.HiredToPhoneNumber.ToString();
                ToSave[iCounter++] = bike.HiredToAddress;
                ToSave[iCounter++] = "";
            }

            //Overwrites hired bikes file with bike information array using own File Writing method.
            UserMenu.WriteAllLinesBetter(sHiredBikesFile, ToSave);
            Console.WriteLine("Hired Bikes File Saved Succesfully.");
            Console.ReadLine();
        }

        /// <summary>
        /// Allow user to return bike to shop from customer.
        /// </summary>
        public void ReturnBike()
        {
            Console.Clear();
            //User inputs security num of bike to return.
            Console.WriteLine("Enter Security Number of Bike that you wish to return:");
            //int.TryParse() returns false if input is not int.
            if (int.TryParse(Console.ReadLine(), out int iSecurityNumToReturn) == false)
            {
                ReturnBike();
            }
            else
            {
                //Search list for occurance of iSecurityNumToReturn.
                GenericHiredBike bk = hiredBikes.Find(Bike => Bike.SecurityCode == iSecurityNumToReturn);
                //List.Find() returns null if entry is not found.
                if (bk == null)
                {
                    Console.WriteLine("Bike with Security Number {0} not found.", iSecurityNumToReturn);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The following bike with security code of {0} has been found.", iSecurityNumToReturn);
                    Console.WriteLine();
                    userMenu.WriteGenericHiredBikeHeadings();
                    Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7:00}/{8:00}/{9,-5}\t £{10,-10}\t £{11,-10}\t {12,-15}\t {13,-5}\t {14}",
                        bk.Type, bk.Make, bk.Model, bk.Year, bk.WheelSize, bk.FrameType, bk.SecurityCode, bk.PurchaseDate.Day, bk.PurchaseDate.Month, bk.PurchaseDate.Year,
                        bk.PurchaseCost, bk.SaleCost, bk.HiredToName, bk.HiredToPhoneNumber, bk.HiredToAddress);
                    Console.WriteLine();

                    if (userMenu.Confirm("return") == true)
                    {
                        string sType = bk.Type;

                        switch (sType)
                        {
                            case "BMX":
                                {
                                    BMX returnedbmx = hiredBMXes.Find(bike => bike.SecurityCode == bk.SecurityCode);
                                    bmxes.Add(returnedbmx);
                                    HiredBMX hiredbmx = hiredBMXes.Find(bike => bike.SecurityCode == bk.SecurityCode);
                                    hiredBMXes.Remove(hiredbmx);
                                    hiredbmx = null;
                                    break;
                                }
                            case "Child Bike":
                                {
                                    ChildBike returnedchild = hiredChildBikes.Find(bike => bike.SecurityCode == bk.SecurityCode);
                                    childBikes.Add(returnedchild);
                                    HiredChildBike hiredchild = hiredChildBikes.Find(bike => bike.SecurityCode == bk.SecurityCode);
                                    hiredChildBikes.Remove(hiredchild);
                                    hiredchild = null;
                                    break;
                                }
                            case "Mountain Bike":
                                {
                                    MountainBike returnedmountain = hiredMountainBikes.Find(bike => bike.SecurityCode == bk.SecurityCode);
                                    mountainBikes.Add(returnedmountain);
                                    HiredMountainBike hiredmountain = hiredMountainBikes.Find(bike => bike.SecurityCode == bk.SecurityCode);
                                    hiredMountainBikes.Remove(hiredmountain);
                                    hiredmountain = null;
                                    break;
                                }
                            case "Road Bike":
                                {
                                    RoadBike returnedroad = hiredRoadBikes.Find(bike => bike.SecurityCode == bk.SecurityCode);
                                    roadBikes.Add(returnedroad);
                                    HiredRoadBike hiredroad = hiredRoadBikes.Find(bike => bike.SecurityCode == bk.SecurityCode);
                                    hiredRoadBikes.Remove(hiredroad);
                                    hiredroad = null;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        SaveInStockFile();
                        SaveHiredBikesFile();
                    }
                }
            }

            //Bring user to main menu.
            userMenu.Menu();
        }

        /// <summary>
        /// Deletes sMoneyFile then saves Shop.money.ToString() to it.
        /// </summary>
        public void SaveFunds()
        {
            //Delets then saves file.
            File.Delete(sMoneyFile);
            UserMenu.WriteAllLinesBetter(sMoneyFile, money.ToString());

            Console.WriteLine("Funds file saved successfully.");
        }

        /// <summary>
        /// Automatically create and save reports to text files.
        /// </summary>
        /// <param name="reportType">What types of reports you wish to save. EG. HiredBikes.</param>
        public void CreateReport(string reportType)
        {
            //Create each report with a new name based on date and report type.
            //eg HiredBikes 124013 25042019 for HiredBikes type, 13 seconds 40 minutes, 12 hours on 25th April 2019

            string sReportName = String.Concat(reportType, " ", DateTime.Now.Hour.ToString(), DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(), " ", DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), ".txt");

            //Report will be written as one bike per line.
            int iHiredToWrite = (hiredBMXes.Count + hiredChildBikes.Count + hiredMountainBikes.Count + hiredRoadBikes.Count);
            int iSoldToWrite = (soldBMXes.Count + soldChildBikes.Count + soldMountainBikes.Count + soldRoadBikes.Count);
            int iStockToWrite = (bmxes.Count + childBikes.Count + mountainBikes.Count + roadBikes.Count);

            switch (reportType.ToLower())
            {
                case "hiredbikes":
                    {
                        int iCounter = 0;
                        int iOffset = 2;
                        //offset by 2 to provide info at the top.
                        string[] saToWrite = new string[iHiredToWrite + iOffset];

                        saToWrite[iCounter++] = "This report shows bikes that are currently hired out.";
                        saToWrite[iCounter++] = "Type, Make, Model, Year, Wheel Size, Frame Type, Security Code, Purchase Date, Purchase Cost, Sale Cost, Hired To Name, Hired To Address, Hired To Phone Num.";

                        foreach (var bike in hiredBikes)
                        {
                            saToWrite[iCounter++] = String.Concat(bike.Type, " ", bike.Make, " ", bike.Model, " ", bike.Year.ToString(), " ", bike.WheelSize.ToString(), " ", bike.FrameType, " ",
                                bike.SecurityCode, " ", bike.PurchaseDate, " ", bike.PurchaseCost, " ", bike.SaleCost, " ", bike.HiredToName, " ", bike.HiredToAddress, " ", bike.HiredToPhoneNumber);
                        }

                        UserMenu.WriteAllLinesBetter(sReportName, saToWrite);
                        break;
                    }
                case "soldbikes":
                    {
                        int iCounter = 0;
                        int iOffset = 2;
                        //offset by 2 to provide info at the top.
                        string[] saToWrite = new string[iSoldToWrite + iOffset];

                        saToWrite[iCounter++] = "This report shows bikes that are currently hired out.";
                        saToWrite[iCounter++] = "Type, Make, Model, Year, Wheel Size, Frame Type, Security Code, Purchase Date, Purchase Cost, Sale Cost, Sold To Name, Sold To Address, Sold To Phone Num.";

                        foreach (var bike in soldBikes)
                        {
                            saToWrite[iCounter++] = String.Concat(bike.Type, " ", bike.Make, " ", bike.Model, " ", bike.Year.ToString(), " ", bike.WheelSize.ToString(), " ", bike.FrameType, " ",
                                bike.SecurityCode, " ", bike.PurchaseDate, " ", bike.PurchaseCost, " ", bike.SaleCost, " ", bike.SoldToName, " ", bike.SoldToAddress, " ", bike.SoldToPhoneNumber);
                        }

                        UserMenu.WriteAllLinesBetter(sReportName, saToWrite);
                        break;
                    }
                case "instockbikes":
                    {
                        int iCounter = 0;
                        int iOffset = 2;
                        //offset by 2 to provide info at the top.
                        string[] saToWrite = new string[iStockToWrite + iOffset];

                        saToWrite[iCounter++] = "This report shows bikes that are currently hired out.";
                        saToWrite[iCounter++] = "Type, Make, Model, Year, Wheel Size, Frame Type, Security Code, Purchase Date, Purchase Cost, Sale Cost.";

                        foreach (var bike in allBikes)
                        {
                            saToWrite[iCounter++] = String.Concat(bike.Type, " ", bike.Make, " ", bike.Model, " ", bike.Year.ToString(), " ", bike.WheelSize.ToString(), " ", bike.FrameType, " ",
                                bike.SecurityCode, " ", bike.PurchaseDate, " ", bike.PurchaseCost, " ", bike.SaleCost);
                        }

                        UserMenu.WriteAllLinesBetter(sReportName, saToWrite);
                        break;
                    }
            }
        }
    }
}
