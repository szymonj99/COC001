/* **************************************************************** */
/*                        COC001 - ASSIGNMENT 2                     */
/* **************************************************************** */

//Compile with: /doc:Documentation.xml

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment2
{
    class UserMenu
    {
        //In the report, include sold and hired bikes.

        /// <summary>
        /// Program entry point.
        /// </summary>
        static void Main()
        {
            int iNewConsoleWidth = 230;
            Console.SetWindowSize(iNewConsoleWidth, Console.WindowHeight);

            //Parse inventory
            shop.GetInStockBikes();
            shop.GetSoldBikes();
            shop.GetHiredBikes();
            shop.GenerateHiredBikesList();
            shop.ClearAllBikesList();
            shop.CreateAllBikesList();
            shop.SortAllBikesList();
            shop.ReadFundsFile();
            //Create userMenu class.
            UserMenu userMenu = new UserMenu();
            userMenu.Menu();
        }

        /// <summary>
        /// Responsible for managing inventory.
        /// </summary>
        private static readonly Shop shop = new Shop();

        /// <summary>
        /// Creates a main menu for user with multiple input options.
        /// </summary>
        public void Menu()
        {
            Console.Clear();
            WriteCompanyFunds();
            string sAskingUser = "What do you wish to do?";
            //Find where to place the string for it to be in the middle.
            int iAskingUserMiddle = (Console.WindowWidth / 2) - (sAskingUser.Length / 2);
            Console.SetCursorPosition(iAskingUserMiddle, Console.CursorTop);
            Console.WriteLine(sAskingUser);
            //Automatically get allowed input range from method.
            int iNumOfOptions;
            iNumOfOptions = WriteMenuOptions();

            //Declaring bool to show if user input is valid.
            bool bValidInput = false;

            do
            {
                //int.TryParse() returns false if input is not int.
                if (int.TryParse(Console.ReadLine(), out int iUserInput) == false)
                {
                    Console.WriteLine("Input not recognised. Please input a number from 1 - {0}.", iNumOfOptions);
                }
                else
                {
                    if (iUserInput < 1 || iUserInput > iNumOfOptions)
                    {
                        Console.WriteLine("Input not recognised. Please input a number from 1 - {0}.", iNumOfOptions);
                    }

                    //if user input is valid
                    if (iUserInput >= 1 && iUserInput <= iNumOfOptions)
                    {
                        bValidInput = true;
                        switch (iUserInput)
                        {
                            case 1:
                                {
                                    //Display Bikes.
                                    //What bikes do you wish to display?
                                    //All, BMX, Child Bikes, Mountain Bikes, Road Bikes, Enter Bike Security Number.
                                    //Display a Specific Bike?
                                    Console.Clear();
                                    UserDisplayBikesChoice();
                                    break;
                                }

                            case 2:
                                {
                                    //Add/Buy bikes.
                                    //Do you wish to add or buy a bike?
                                    //Buying costs money, adding does not.
                                    Console.Clear();
                                    AddOrBuyChoice();
                                    break;
                                }

                            case 3:
                                {
                                    Console.Clear();
                                    RemoveOrSelectChoice();
                                    break;
                                }

                            case 4:
                                {
                                    Console.Clear();
                                    shop.EditBike();
                                    break;
                                }

                            case 5:
                                {
                                    Console.Clear();
                                    shop.GenerateHiredBikesList();
                                    HireOrRentChoice();                                    
                                    break;
                                }
                                
                            case 6:
                                {
                                    //Save Files
                                    Console.Clear();
                                    SaveFileChoice();
                                    break;
                                }
                                
                            case 7:
                                {
                                    //Save reports to file.
                                    Console.Clear();
                                    ReportsChoice();
                                    break;
                                }
                                
                            case 8:
                                {
                                    Environment.Exit(0);
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
            while (bValidInput == false);
        }

        /// <summary>
        /// Displays menu options for the user.
        /// </summary>
        public int WriteMenuOptions()
        {
            //How many options are there?
            //Have to change this manually after adding/removing an option.
            int iNumOfOptions = 8;
            string[] aOptionsArray = new string[iNumOfOptions];

            //Automatically iterate through array.
            int i = 0;

            //Set array options
            aOptionsArray[i++] = "1. Display Bikes";
            aOptionsArray[i++] = "2. Add/Buy Bikes";
            aOptionsArray[i++] = "3. Remove/Sell Bikes";
            aOptionsArray[i++] = "4. Modify Bikes";
            aOptionsArray[i++] = "5. Hire/Return Bike";
            aOptionsArray[i++] = "6. Save Files";
            aOptionsArray[i++] = "7. Show & Save Reports to File";
            aOptionsArray[i++] = "8. Exit";

            //reset iteration counter before calculating option middle
            i = 0;
            int j = 0;

            //store value of each option's middle point.
            int[] aOptionsMiddle = new int[iNumOfOptions];
            //Find where to start writing option strings to place them in the middle of width.
            foreach (string sOption in aOptionsArray)
            {
                aOptionsMiddle[i++] = (Console.WindowWidth / 2) - (aOptionsArray[j++].Length / 2);
            }

            //reset iteration before printing to console.
            i = 0;
            j = 0;

            //Print option choice to console.
            foreach (string str in aOptionsArray)
            {
                Console.SetCursorPosition(aOptionsMiddle[i++], Console.CursorTop);
                Console.WriteLine(aOptionsArray[j++]);
            }

            return iNumOfOptions;
        }

        /// <summary>
        /// Writes to middle console the company's funds.
        /// </summary>
        public void WriteCompanyFunds()
        {
            //Writes to the top right corner of console.
            string sCompanyFunds = "Company Funds: " + Shop.money.ToString();
            Console.SetCursorPosition((Console.WindowWidth - sCompanyFunds.Length), Console.CursorTop);
            Console.WriteLine(sCompanyFunds);
        }

        /// <summary>
        /// Ask user which bikes they want to see. EG. All bikes, BMX only, Road Bike only.
        /// </summary>
        public void UserDisplayBikesChoice()
        {
            Console.Clear();

            int iUserInput;
            int iNumOfChoices = 7;
            string[] aChoices = new string[iNumOfChoices];
            int i = 0;
            aChoices[i++] = "1. All Bikes";
            //aChoices[i++] = 

            do
            {
                Console.WriteLine("Which bikes do you wish to see?");
                Console.WriteLine("1. All Bikes");
                Console.WriteLine("2. Mountain Bikes");
                Console.WriteLine("3. Road Bikes");
                Console.WriteLine("4. Child Bikes");
                Console.WriteLine("5. BMX Bikes");
                Console.WriteLine("6. Specific Bike [Search by Security Number]");
                Console.WriteLine("7. Go Back");
                if (int.TryParse(Console.ReadLine(), out iUserInput) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input is not a recognized choice. Input a number 1 - {0}.", iNumOfChoices);
                    Console.ResetColor();
                    Console.ReadLine();
                    UserDisplayBikesChoice();
                }
                switch (iUserInput)
                {
                    case 1:
                        {
                            shop.ClearAllBikesList();
                            shop.CreateAllBikesList();
                            shop.SortAllBikesList();
                            Console.Clear();
                            WriteAllBikeHeadings();
                            shop.DisplayAllBikesList();
                            Console.ReadLine();
                            Menu();
                            break;
                        }

                    case 2:
                        {
                            Console.Clear();
                            WriteMountainBikeHeadings();
                            shop.DisplayMountainBikesList();
                            Console.ReadLine();
                            Menu();
                            break;
                        }

                    case 3:
                        {
                            Console.Clear();
                            WriteRoadBikeHeadings();
                            shop.DisplayRoadBikesList();
                            Console.ReadLine();
                            Menu();
                            break;
                        }

                    case 4:
                        {
                            Console.Clear();
                            WriteChildBikeHeadings();
                            shop.DisplayChildBikesList();
                            Console.ReadLine();
                            Menu();
                            break;
                        }

                    case 5:
                        {
                            Console.Clear();
                            WriteBMXBikeHeadings();
                            shop.DisplayBMXBikesList();
                            Console.ReadLine();
                            Menu();
                            break;
                        }

                    case 6:
                        {
                            Console.Clear();
                            shop.SearchBikeBySecurityNum();
                            break;
                        }

                    case 7:
                        {
                            Menu();
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
            while (iUserInput <= 0 || iUserInput > iNumOfChoices);
        }

        /// <summary>
        /// Allow user to decide between Adding or Buying bikes.
        /// </summary>
        public void AddOrBuyChoice()
        {
            Console.Clear();

            int iUserInput;
            int iNumOfOptions = 3;
            //Add Bike, Buy Bike, Go Back.

            do
            {
                Console.WriteLine("Do You want to add or buy a bike?");
                Console.WriteLine("1. Add Bike");
                Console.WriteLine("2. Buy Bike");
                Console.WriteLine("3. Go Back");

                if (int.TryParse(Console.ReadLine(), out iUserInput) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input is not a recognized choice. Input a number 1 - {0}.", iNumOfOptions);
                    Console.ResetColor();
                    Console.ReadLine();
                    AddOrBuyChoice();
                }
            }
            while (iUserInput <= 0 || iUserInput > iNumOfOptions);

            switch (iUserInput)
            {
                case 1:
                    {
                        shop.AddBike();
                        break;
                    }

                case 2:
                    {
                        shop.BuyBike();
                        break;
                    }

                case 3:
                    {
                        Menu();
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// Allow user to decide between removing or selling bikes.
        /// </summary>
        public void RemoveOrSelectChoice()
        {
            Console.Clear();

            int iUserInput;
            int iNumOfOptions = 3;
            //Remove Bike, Sell Bike, Go Back.

            do
            {
                Console.WriteLine("Do You want to remove or sell a bike?");
                Console.WriteLine("1. Remove Bike");
                Console.WriteLine("2. Sell Bike");
                Console.WriteLine("3. Go Back");

                if (int.TryParse(Console.ReadLine(), out iUserInput) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input is not a recognized choice. Input a number 1 - {0}.", iNumOfOptions);
                    Console.ResetColor();
                    Console.ReadLine();
                    AddOrBuyChoice();
                }
            }
            while (iUserInput <= 0 || iUserInput > iNumOfOptions);

            switch (iUserInput)
            {
                case 1:
                    {
                        shop.RemoveBike();
                        break;
                    }

                case 2:
                    {
                        shop.SellBike();
                        break;
                    }

                case 3:
                    {
                        Menu();
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// Allow user to decide between removing or selling bikes.
        /// </summary>
        public void HireOrRentChoice()
        {
            Console.Clear();

            int iUserInput;
            int iNumOfOptions = 3;
            //Hire Bike, Return Bike, Go Back.

            do
            {
                Console.WriteLine("Do You want to remove or sell a bike?");
                Console.WriteLine("1. Hire Bike");
                Console.WriteLine("2. Return Bike");
                Console.WriteLine("3. Go Back");

                if (int.TryParse(Console.ReadLine(), out iUserInput) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input is not a recognized choice. Input a number 1 - {0}.", iNumOfOptions);
                    Console.ResetColor();
                    Console.ReadLine();
                    HireOrRentChoice();
                }
            }
            while (iUserInput <= 0 || iUserInput > iNumOfOptions);

            switch (iUserInput)
            {
                case 1:
                    {
                        shop.HireBike();
                        break;
                    }

                case 2:
                    {
                        shop.ReturnBike();
                        break;
                    }

                case 3:
                    {
                        Menu();
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// Writes column headings with only properties present in Bike class.
        /// </summary>
        public void WriteAllBikeHeadings()
        {
                //Console.Clear();
                //Properties only present in Bike class.
                string sType = "Type";
                string sMake = "Make";
                string sModel = "Model";
                string sYear = "Year";
                string sWheelSize = "Wheel Size";
                string sFrameType = "Frame Type";
                string sSecurityCode = "Security Code";
                string sPurchaseDate = "Purchase Date";
                string sPurchaseCost = "Purchase Cost";
                string sSaleCost = "Sale Cost";
                Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7,-10}\t {8,-10}\t {9}",
                    sType, sMake, sModel, sYear, sWheelSize, sFrameType, sSecurityCode, sPurchaseDate, sPurchaseCost, sSaleCost);
        }

        /// <summary>
        /// Writes column headings with only properties present in GenericBike Class.
        /// </summary>
        public void WriteGenericHiredBikeHeadings()
        {
            string sType = "Type";
            string sMake = "Make";
            string sModel = "Model";
            string sYear = "Year";
            string sWheelSize = "Wheel Size";
            string sFrameType = "Frame Type";
            string sSecurityCode = "Security Code";
            string sPurchaseDate = "Purchase Date";
            string sPurchaseCost = "Purchase Cost";
            string sSaleCost = "Sale Cost";
            string sHiredToName = "Customer Name";
            string sHiredToNumber = "Customer Phone";
            string sHiredToAddress = "Customer Address";
            Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7,-10}\t {8,-10}\t {9,-10}\t {10,-15}\t {11,-10}\t {12}",
                sType, sMake, sModel, sYear, sWheelSize, sFrameType, sSecurityCode, sPurchaseDate, sPurchaseCost, sSaleCost, sHiredToName, sHiredToNumber, sHiredToAddress);
        }

        /// <summary>
        /// Writes column headings with all properties present in Mountain Bike Class
        /// </summary>
        public void WriteMountainBikeHeadings()
        {
            //Console.Clear();
            //Properties present in MountainBike class.
            string sType = "Type";
            string sMake = "Make";
            string sModel = "Model";
            string sYear = "Year";
            string sWheelSize = "Wheel Size";
            string sFrameType = "Frame Type";
            string sSecurityCode = "Security Code";
            string sPurchaseDate = "Purchase Date";
            string sPurchaseCost = "Purchase Cost";
            string sSaleCost = "Sale Cost";
            string sTireWidth = "Tire Width";
            Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7,-10}\t {8,-10}\t {9,-10}\t {10}",
                sType, sMake, sModel, sYear, sWheelSize, sFrameType, sSecurityCode, sPurchaseDate, sPurchaseCost, sSaleCost, sTireWidth);
        }

        /// <summary>
        /// Writes column headings with all properties present in Road Bike Class
        /// </summary>
        public void WriteRoadBikeHeadings()
        {
            //Console.Clear();
            //Properties present in RoadBike class.
            string sType = "Type";
            string sMake = "Make";
            string sModel = "Model";
            string sYear = "Year";
            string sWheelSize = "Wheel Size";
            string sFrameType = "Frame Type";
            string sSecurityCode = "Security Code";
            string sPurchaseDate = "Purchase Date";
            string sPurchaseCost = "Purchase Cost";
            string sSaleCost = "Sale Cost";
            string sSolidTires = "Has Solid Tires";
            Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7,-10}\t {8,-10}\t {9,-10}\t {10}",
                sType, sMake, sModel, sYear, sWheelSize, sFrameType, sSecurityCode, sPurchaseDate, sPurchaseCost, sSaleCost, sSolidTires);
        }

        /// <summary>
        /// Writes column headings with all properties present in Child Bike Class
        /// </summary>
        public void WriteChildBikeHeadings()
        {
            //Console.Clear();
            //Properties present in ChildBike class.
            string sType = "Type";
            string sMake = "Make";
            string sModel = "Model";
            string sYear = "Year";
            string sWheelSize = "Wheel Size";
            string sFrameType = "Frame Type";
            string sSecurityCode = "Security Code";
            string sPurchaseDate = "Purchase Date";
            string sPurchaseCost = "Purchase Cost";
            string sSaleCost = "Sale Cost";
            string sTrainingWheels = "Has Training Wheels";
            Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7,-10}\t {8,-10}\t {9,-10}\t {10}",
                sType, sMake, sModel, sYear, sWheelSize, sFrameType, sSecurityCode, sPurchaseDate, sPurchaseCost, sSaleCost, sTrainingWheels);
        }

        /// <summary>
        /// Writes column headings with all properties present in BMX Class
        /// </summary>
        public void WriteBMXBikeHeadings()
        {
            //Console.Clear();
            //Properties present in ChildBike class.
            string sType = "Type";
            string sMake = "Make";
            string sModel = "Model";
            string sYear = "Year";
            string sWheelSize = "Wheel Size";
            string sFrameType = "Frame Type";
            string sSecurityCode = "Security Code";
            string sPurchaseDate = "Purchase Date";
            string sPurchaseCost = "Purchase Cost";
            string sSaleCost = "Sale Cost";
            string sPegLength = "Peg Length";
            Console.WriteLine("{0,-10}\t {1,-10}\t {2,-10}\t {3,-5}\t {4,-10}\t {5,-30}\t {6,-10}\t {7,-10}\t {8,-10}\t {9,-10}\t {10}",
                sType, sMake, sModel, sYear, sWheelSize, sFrameType, sSecurityCode, sPurchaseDate, sPurchaseCost, sSaleCost, sPegLength);
        }

        /// <summary>
        /// Allows user to input Type of bike.
        /// </summary>
        /// <returns>String storing type of bike.</returns>
        public string InputType()
        {
            //Compare user input to allowed bikes.
            List<string> allowedBikeTypes = new List<string>
            {
                "bmx",
                "bmx bike",
                "road",
                "road bike",
                "child",
                "child bike",
                "mountain bike",
                "mountain",
            };

            //Two strings will be used to validate user input.
            string sType;
            string sTypeConfirmation = "Placeholder";

            do
            {
                Console.WriteLine("Enter Bike Type: [exit to Cancel]");
                sType = Console.ReadLine();
                //Check if user wants to exit.
                if (sType.ToLower() == "exit")
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }
                else if (allowedBikeTypes.Contains(sType.ToLower()))
                {
                    Console.WriteLine("Confirm Bike Type: [exit to Cancel]");
                    sTypeConfirmation = Console.ReadLine();
                    //Check if user wants to exit.
                    if (sTypeConfirmation.ToLower() == "exit")
                    {
                        Console.WriteLine("Bike input cancelled. Press any key to continue.");
                        Console.ReadLine();
                        Menu();
                    }
                    else if (allowedBikeTypes.Contains(sTypeConfirmation.ToLower()) && sType == sTypeConfirmation)
                    {
                        if (sType.ToLower() == "bmx" || sType.ToLower() == "bmx bike")
                        {
                            return "BMX";
                        }
                        else if (sType.ToLower() == "child" || sType.ToLower() == "child bike")
                        {
                            return "Child Bike";
                        }
                        else if (sType.ToLower() == "road" || sType.ToLower() == "road bike")
                        {
                            return "Road Bike";
                        }
                        else if (sType.ToLower() == "mountain" || sType.ToLower() == "mountain bike")
                        {
                            return "Mountain Bike";
                        }
                    }
                    else
                    {
                        Console.WriteLine("Confirmation entry does not match.");
                    }
                }
                else
                {
                    Console.WriteLine("Bike Type not recognized.");
                }
            }
            //repeat while sType and sTypeConfirmation do not match, or Length of sType is not bigger than 0.
            while (sType != sTypeConfirmation || sType.Length <= 0);

            return sType;
        }

        /// <summary>
        /// Allow user to confirm editing of bike.
        /// </summary>
        /// <returns>Bool of user's confirmation.</returns>
        public bool ConfirmBikeEdit()
        {
            bool bConfirm;

            Console.WriteLine("Do you wish to edit this bike?");
            //Do not have to compare all variations of capital letters.
            string sUserInput = Console.ReadLine().ToLower();
            if (sUserInput == "y" || sUserInput == "yes")
            {
                bConfirm = true;
            }

            else
            {
                bConfirm = false;
            }

            return bConfirm;
        }

        /// <summary>
        /// Allow user to input Make of bike.
        /// </summary>
        /// <returns>String storing Make of bike.</returns>
        public string InputMake()
        {
            //Two strings will be used to validate user input.
            string sMake;
            string sMakeConfirmation;

            do
            {
                Console.WriteLine("Enter Bike Make: [exit to Cancel]");
                sMake = Console.ReadLine();
                //Check if user wants to exit.
                if (sMake.ToLower() == "exit")
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }

                Console.WriteLine("Confirm Bike Make: [exit to Cancel]");
                sMakeConfirmation = Console.ReadLine();
                //Check if user wants to exit.
                if (sMakeConfirmation.ToLower() == "exit")
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }
            }
            //Repeat while sMake and sMakeConfirmation do not match, or Length of sMake is equal to or less than 0.
            while (sMake != sMakeConfirmation || sMake.Length <= 0);

            return sMake;
        }

        /// <summary>
        /// Allow user to input model of bike.
        /// </summary>
        /// <returns>String storing Model of bike.</returns>
        public string InputModel()
        {
            //Two strings will be used to validate user input.
            string sModel;
            string sModelConfirmation;

            do
            {
                Console.WriteLine("Enter Bike Model: [exit to Cancel]");
                sModel = Console.ReadLine();
                //Check if user wants to exit.
                if (sModel.ToLower() == "exit")
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }

                Console.WriteLine("Confirm Bike Model: [exit to Cancel]");
                sModelConfirmation = Console.ReadLine();
                //Check if user wants to exit.
                if (sModelConfirmation.ToLower() == "exit")
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }
            }
            //Repeat while sModel and sModelConfirmation do not match, or Length of sModel is less than or equal to 0.
            while (sModel != sModelConfirmation || sModel.Length <= 0);

            return sModel;
        }

        /// <summary>
        /// Allow user to input year of bike.
        /// </summary>
        /// <returns>Int storing Year of bike.</returns>
        public int InputYear()
        {
            //Two integers will be used to validate user input.
            int iYear;
            int iYearConfirmation;
            //Bikes older than 10 years will not be allowed.
            int iOldestBikeAge = 10;
            int iOldestBikesAllowed = DateTime.Now.Year - iOldestBikeAge;

            do
            {
                Console.WriteLine("Input Bike Year: [0 to Cancel]");
                //int.TryParse() returns false if input is not an int.
                if (int.TryParse(Console.ReadLine(), out iYear) == false)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not recognised.");
                    Console.ResetColor();
                }

                if (iYear == 0)
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }

                else if (iYear < iOldestBikesAllowed)
                {
                    Console.WriteLine("This bike is older than {0} years. Entry is not allowed.", iOldestBikeAge);
                }
            }
            while (iYear < iOldestBikesAllowed);

            do
            {
                Console.WriteLine("Confirm Bike Year: [0 to Cancel]");
                //int.TryParse() returns false if input is not an int.
                if (int.TryParse(Console.ReadLine(), out iYearConfirmation) == false)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not recognised.");
                    Console.ResetColor();
                }
                else if (iYearConfirmation == 0)
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }
                else if (iYearConfirmation != iYear)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The entry does not match.");
                    Console.ResetColor();
                }
            }
            //Ask user for input until both codes match.
            while (iYearConfirmation != iYear);

            return iYear;
        }

        /// <summary>
        /// Allow user to input wheel size of bike.
        /// </summary>
        /// <returns>Double storing Wheel Size of bike.</returns>
        public double InputWheelSize()
        {
            //Two strings will be used to validate user input.
            string sWheelSize;
            string sWheelSizeConfirmation;

            double dWheelSize;
            double dWheelSizeRounded;
            dWheelSizeRounded = 0;
            double dWheelSizeConfirmation;
            double dWheelSizeConfirmationRounded;

            do
            {
                Console.WriteLine("Enter Bike Wheel Size: [0 to Cancel]");
                sWheelSize = Console.ReadLine();
                double.TryParse(sWheelSize, out dWheelSize);
                if (double.TryParse(sWheelSize, out dWheelSize) == false)
                {
                    Console.WriteLine("Input not recognized.");
                    InputWheelSize();
                }
                else
                {
                    //Round dWheelSize to 2 decimal points.
                    dWheelSizeRounded = Math.Round(dWheelSize, 2, MidpointRounding.AwayFromZero);
                    if (dWheelSizeRounded < 0)
                    {
                        Console.WriteLine("Incorrect input. Wheel size cannot be less than 0.");
                        InputWheelSize();
                    }
                    else if (dWheelSizeRounded == 0)
                    {
                        Console.WriteLine("Bike input cancelled. Press any key to continue.");
                        Console.ReadLine();
                        Menu();
                    }
                }                

                Console.WriteLine("Confirm Bike Wheel Size: [0 to Cancel]");
                sWheelSizeConfirmation = Console.ReadLine();
                double.TryParse(sWheelSizeConfirmation, out dWheelSizeConfirmation);
                dWheelSizeConfirmationRounded = Math.Round(dWheelSizeConfirmation, 2, MidpointRounding.AwayFromZero);

                if (dWheelSizeConfirmationRounded < 0)
                {
                    Console.WriteLine("Incorrect input. Wheel size cannot be less than 0.");
                    InputWheelSize();
                }

                else if (dWheelSizeConfirmationRounded == 0)
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }
            }
            //Repeat while sWheelSize and sWheelSizeConfirmation do not match, or Length of sWheelSize is less than or equal to 0.
            while (dWheelSizeRounded != dWheelSizeConfirmationRounded || dWheelSizeRounded.ToString().Length <= 0);

            return dWheelSizeRounded;
        }

        /// <summary>
        /// Allow user to input Forks of bike.
        /// </summary>
        /// <returns>String storing Forks of bike.</returns>
        public string InputFrameType()
        {
            //Two strings will be used to validate user input.
            string sFrameType;
            string sFrameTypeConfirmation;

            do
            {
                Console.WriteLine("Enter Bike Frame Type: [exit to Cancel]");
                sFrameType = Console.ReadLine();
                if (sFrameType.ToLower() == "exit")
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }

                Console.WriteLine("Confirm Bike Frame Type: [exit to Cancel]");
                sFrameTypeConfirmation = Console.ReadLine();
                if (sFrameTypeConfirmation.ToLower() == "exit")
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }
            }
            //Repeat while sForks and sForksConfirmation do not match, or length of sForks is less than or equal to 0.
            //Can change 0 to a reasonable length of bike forks names length.
            while (sFrameType != sFrameTypeConfirmation || sFrameType.Length <= 0);

            return sFrameType;
        }

        /// <summary>
        /// Allow user to input how much the bike was bought from manufacturer for.
        /// </summary>
        /// <returns>Int of bike cost.</returns>
        public int InputPurchaseCost()
        {
            //Two integers will be used to validate user input.
            int iPurchaseCost;
            int iPurchaseCostConfirmation;

            do
            {
                Console.WriteLine("Input Bike Purchase Cost: [0 to Cancel]");
                //int.TryParse() returns false if input is not an int.
                if (int.TryParse(Console.ReadLine(), out iPurchaseCost) == false)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not recognised.");
                    Console.ResetColor();
                }

                if (iPurchaseCost == 0)
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }
            }
            while (iPurchaseCost < 0);

            do
            {
                Console.WriteLine("Confirm Bike Purchase Cost: [0 to Cancel]");
                //int.TryParse() returns false if input is not an int.
                if (int.TryParse(Console.ReadLine(), out iPurchaseCostConfirmation) == false)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not recognised.");
                    Console.ResetColor();
                }
                else if (iPurchaseCostConfirmation == 0)
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }
                else if (iPurchaseCostConfirmation != iPurchaseCost)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The entry does not match.");
                    Console.ResetColor();
                }
            }
            //Ask user for input until both codes match.
            while (iPurchaseCostConfirmation != iPurchaseCost);

            return iPurchaseCost;
        }

        /// <summary>
        /// Allow user to confirm saving of edited bike.
        /// </summary>
        /// <returns>Bool of user's confirmation.</returns>
        public bool ConfirmSavingEditedBike()
        {
            bool bConfirm;

            Console.WriteLine("Do you wish to save changes to this bike?");
            //Do not have to compare all variations of capital letters.
            string sUserInput = Console.ReadLine().ToLower();
            if (sUserInput == "y" || sUserInput == "yes")
            {
                bConfirm = true;
            }

            else
            {
                bConfirm = false;
            }

            return bConfirm;
        }

        /// <summary>
        /// Allows user to input Security Code of bike.
        /// </summary>
        /// <returns>Int storing Security Code of bike. If Security Code is not unique, returns -1.</returns>
        public int InputSecurityCode()
        {
            //Two integers will be used to validate user input.
            int iSecurityCode;
            int iSecurityCodeConfirmation;
            int iExitNum = 0;

            do
            {
                Console.WriteLine("Input Bike Security Code: [0 to Cancel]");
                //int.TryParse() returns false if input is not an int.
                if (int.TryParse(Console.ReadLine(), out iSecurityCode) == false)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not recognised.");
                    Console.ResetColor();
                }

                //Check if user wants to exit.
                if (iSecurityCode == iExitNum)
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }

                if (shop.allBikes.Find(bike => bike.SecurityCode == iSecurityCode) != null)
                {
                    Console.WriteLine("Duplicate Security Code detected. Bike not added.");
                }
            }
            //Checks if Security Code is bigger than 0, and if security code exists already in Bikes List.
            while (iSecurityCode <= 0 || shop.RetrieveBikesList().Any(bk => bk.SecurityCode == iSecurityCode) == true);

            do
            {
                Console.WriteLine("Confirm Bike Security Code: [0 to Cancel]");
                //int.TryParse() returns false if input is not an int.
                if (int.TryParse(Console.ReadLine(), out iSecurityCodeConfirmation) == false)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not recognised.");
                    Console.ResetColor();
                }
                else if (iSecurityCodeConfirmation == iExitNum)
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }
                else if (iSecurityCodeConfirmation != iSecurityCode)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The entry does not match.");
                    Console.ResetColor();
                }
            }
            //Ask user for input until both codes match.
            while (iSecurityCodeConfirmation != iSecurityCode);

            return iSecurityCode;
        }

        /// <summary>
        /// Allow user to input how much the bike will be sold for to the customer.
        /// </summary>
        /// <returns>Int of bike price</returns>
        public int InputSaleCost()
        {
            //Two integers will be used to validate user input.
            int iSaleCost;
            int iSaleCostConfirmation;
            int iExitNum = 0;

            do
            {
                Console.WriteLine("Input Bike Sale Price: [0 to Cancel]");
                //int.TryParse() returns false if input is not an int.
                if (int.TryParse(Console.ReadLine(), out iSaleCost) == false)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not recognised.");
                    Console.ResetColor();
                }

                //Check if user wants to exit.
                if (iSaleCost == iExitNum)
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }
            }
            //Checks if Security Code is bigger than 0, and if security code exists already in Bikes List.
            while (iSaleCost < 0);

            do
            {
                Console.WriteLine("Confirm Bike Sale Price: [0 to Cancel]");
                //int.TryParse() returns false if input is not an int.
                if (int.TryParse(Console.ReadLine(), out iSaleCostConfirmation) == false)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not recognised.");
                    Console.ResetColor();
                }
                else if (iSaleCostConfirmation == iExitNum)
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }
                else if (iSaleCostConfirmation != iSaleCost)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The entry does not match.");
                    Console.ResetColor();
                }
            }
            //Ask user for input until both codes match.
            while (iSaleCostConfirmation != iSaleCost);

            return iSaleCost;
        }

        /// <summary>
        /// Allow user to input Peg Length of bmx.
        /// </summary>
        /// <returns>Double of Peg Length</returns>
        public double InputPegLength()
        {
            //Two strings will be used to validate user input.
            string sPegLength;
            string sPegLengthConfirmation;

            double dPegLength;
            double dPegLengthRounded;
            dPegLengthRounded = 0;
            double dPegLengthConfirmation;
            double dPegLengthRoundedConfirmation;

            do
            {
                Console.WriteLine("Enter Peg Length: [0 to Cancel]");
                sPegLength = Console.ReadLine();
                double.TryParse(sPegLength, out dPegLength);
                if (double.TryParse(sPegLength, out dPegLength) == false)
                {
                    Console.WriteLine("Input not recognized.");
                    InputWheelSize();
                }
                else
                {
                    //Round dPegLength to 2 decimal points.
                    dPegLengthRounded = Math.Round(dPegLength, 2, MidpointRounding.AwayFromZero);
                    if (dPegLengthRounded < 0)
                    {
                        Console.WriteLine("Incorrect input. Peg Length cannot be less than 0.");
                        InputWheelSize();
                    }
                    else if (dPegLengthRounded == 0)
                    {
                        Console.WriteLine("Bike input cancelled. Press any key to continue.");
                        Console.ReadLine();
                        Menu();
                    }
                }

                Console.WriteLine("Confirm Peg Length: [0 to Cancel]");
                sPegLengthConfirmation = Console.ReadLine();
                double.TryParse(sPegLengthConfirmation, out dPegLengthConfirmation);
                dPegLengthRoundedConfirmation = Math.Round(dPegLengthConfirmation, 2, MidpointRounding.AwayFromZero);

                if (dPegLengthRoundedConfirmation < 0)
                {
                    Console.WriteLine("Incorrect input. Peg Length cannot be less than 0.");
                    InputWheelSize();
                }

                else if (dPegLengthRoundedConfirmation == 0)
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }
            }
            while (dPegLengthRounded != dPegLengthRoundedConfirmation || dPegLengthRounded.ToString().Length <= 0);

            return dPegLengthRounded;
        }

        /// <summary>
        /// Allow user to input if the Child Bike has Training wheels or not.
        /// </summary>
        /// <returns>Bool of Training wheels.</returns>
        public bool InputTrainingWheels()
        {
            bool bHasTrainingWheels = false;
            string sUserInput;

            do
            {
                Console.WriteLine("Does the bike have training wheels? [yes/no/exit to Cancel]");
                //Do not have to compare all variations of capital letters.
                sUserInput = Console.ReadLine().ToLower();
            }
            while (sUserInput != "yes" && sUserInput != "y" && sUserInput != "no" && sUserInput != "n" && sUserInput != "exit");

            if (sUserInput == "y" || sUserInput == "yes")
            {
                bHasTrainingWheels = true;
            }
            else if (sUserInput == "exit")
            {
                Console.WriteLine("Bike input cancelled.");
                Console.ReadLine();
                Menu();
            }
            else if (sUserInput == "n" || sUserInput == "no")
            {
                bHasTrainingWheels = false;
            }

            return bHasTrainingWheels;
        }

        /// <summary>
        /// Allow user to enter Mountain Bike's Tire Width.
        /// </summary>
        /// <returns>Double of Tire Width</returns>
        public double InputTireWidth()
        {
            //Two strings will be used to validate user input.
            string sTireWidth;
            string sTireWidthConfirmation;

            double dTireWidth;
            double dTireWidthRounded;
            dTireWidthRounded = 0;
            double dTireWidthConfirmation;
            double dTireWidthRoundedConfirmation;

            do
            {
                Console.WriteLine("Enter Tire Width: [0 to Cancel]");
                sTireWidth = Console.ReadLine();
                double.TryParse(sTireWidth, out dTireWidth);
                if (double.TryParse(sTireWidth, out dTireWidth) == false)
                {
                    Console.WriteLine("Input not recognized.");
                    InputWheelSize();
                }
                else
                {
                    //Round dPegLength to 2 decimal points.
                    dTireWidthRounded = Math.Round(dTireWidth, 2, MidpointRounding.AwayFromZero);
                    if (dTireWidthRounded < 0)
                    {
                        Console.WriteLine("Incorrect input. Tire Width cannot be less than 0.");
                        InputWheelSize();
                    }
                    else if (dTireWidthRounded == 0)
                    {
                        Console.WriteLine("Bike input cancelled. Press any key to continue.");
                        Console.ReadLine();
                        Menu();
                    }
                }

                Console.WriteLine("Confirm Tire Width: [0 to Cancel]");
                sTireWidthConfirmation = Console.ReadLine();
                double.TryParse(sTireWidthConfirmation, out dTireWidthConfirmation);
                dTireWidthRoundedConfirmation = Math.Round(dTireWidthConfirmation, 2, MidpointRounding.AwayFromZero);

                if (dTireWidthRoundedConfirmation < 0)
                {
                    Console.WriteLine("Incorrect input. Tire Width cannot be less than 0.");
                    InputWheelSize();
                }

                else if (dTireWidthRoundedConfirmation == 0)
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }
            }
            while (dTireWidthRounded != dTireWidthRoundedConfirmation || dTireWidthRounded.ToString().Length <= 0);

            return dTireWidthRounded;
        }

        /// <summary>
        /// Allow user to enter if Road Bike has solid tires or not.
        /// </summary>
        /// <returns>Bool of Solid Tires.</returns>
        public bool InputSolidTires()
        {
            bool bHasSolidTires = false;
            string sUserInput;

            do
            {
                Console.WriteLine("Does the bike have Solid Tires? [yes/no/exit to Cancel]");
                //Do not have to compare all variations of capital letters.
                sUserInput = Console.ReadLine().ToLower();
            }
            while (sUserInput != "yes" && sUserInput != "y" && sUserInput != "no" && sUserInput != "n" && sUserInput != "exit");

            if (sUserInput == "y" || sUserInput == "yes")
            {
                bHasSolidTires = true;
            }
            else if (sUserInput == "exit")
            {
                Console.WriteLine("Bike input cancelled.");
                Console.ReadLine();
                Menu();
            }
            else if (sUserInput == "n" || sUserInput == "no")
            {
                bHasSolidTires = false;
            }

            return bHasSolidTires;
        }

        /// <summary>
        /// Allow user to input customer name.
        /// </summary>
        /// <returns>String of Customer's name</returns>
        public string InputSoldToName()
        {
            //Two strings will be used to validate user input.
            string sCustomerName;
            string sCustomerNameConfirmation;

            do
            {
                Console.WriteLine("Enter Customer Name: [exit to Cancel]");
                sCustomerName = Console.ReadLine();
                if (sCustomerName.ToLower() == "exit")
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }

                Console.WriteLine("Confirm Customer Name: [exit to Cancel]");
                sCustomerNameConfirmation = Console.ReadLine();
                if (sCustomerNameConfirmation.ToLower() == "exit")
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }
            }
            while (sCustomerName != sCustomerNameConfirmation || sCustomerName.Length <= 0);

            return sCustomerName;
        }

        /// <summary>
        /// Allow user to input contact number of customer.
        /// </summary>
        /// <returns>Double of contact number.</returns>
        public double InputSoldToNumber()
        {
            //Two integers will be used to validate user input.
            double iCustomerPhone;
            double iCustomerPhoneConfirmation;
            double iExitNum = 0;
            int iPhoneNumberLength = 11;

            do
            {
                Console.WriteLine("Input Customer Phone Number: [0 to Cancel]");
                //int.TryParse() returns false if input is not an int.
                if (double.TryParse(Console.ReadLine(), out iCustomerPhone) == false)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not recognised.");
                    Console.ResetColor();
                }

                //Check if user wants to exit.
                if (iCustomerPhone == iExitNum)
                {
                    Console.WriteLine("Phone Number Input Cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }
            }
            //Check if phone number is lesss than 11 digits.
            while (iCustomerPhone.ToString().Length < iPhoneNumberLength);

            do
            {
                Console.WriteLine("Confirm Customer Phone Number: [0 to Cancel]");
                //int.TryParse() returns false if input is not an int.
                if (double.TryParse(Console.ReadLine(), out iCustomerPhoneConfirmation) == false)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not recognised.");
                    Console.ResetColor();
                }
                else if (iCustomerPhoneConfirmation == iExitNum)
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }
                else if (iCustomerPhoneConfirmation != iCustomerPhone)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The entry does not match.");
                    Console.ResetColor();
                }
            }
            //Ask user for input until both codes match.
            while (iCustomerPhoneConfirmation != iCustomerPhone);

            return iCustomerPhone;
        }

        /// <summary>
        /// Allow user to input customer's address.
        /// </summary>
        /// <returns>String of customer's address.</returns>
        public string InputSoldToAddress()
        {
            //Two strings will be used to validate user input.
            string sCustomerAddress;
            string sCustomerAddressConfirmation;

            do
            {
                Console.WriteLine("Enter Customer Address: [exit to Cancel]");
                sCustomerAddress = Console.ReadLine();
                if (sCustomerAddress.ToLower() == "exit")
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }

                Console.WriteLine("Confirm Customer Address: [exit to Cancel]");
                sCustomerAddressConfirmation = Console.ReadLine();
                if (sCustomerAddressConfirmation.ToLower() == "exit")
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }
            }
            while (sCustomerAddress != sCustomerAddressConfirmation || sCustomerAddress.Length <= 0);

            return sCustomerAddress;
        }

        /// <summary>
        /// Allow user to nput customer's name.
        /// </summary>
        /// <returns>String of Customer's name</returns>
        public string InputHiredToName()
        {
            //Two strings will be used to validate user input.
            string sCustomerName;
            string sCustomerNameConfirmation;

            do
            {
                Console.WriteLine("Enter Customer Name: [exit to Cancel]");
                sCustomerName = Console.ReadLine();
                if (sCustomerName.ToLower() == "exit")
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }

                Console.WriteLine("Confirm Customer Name: [exit to Cancel]");
                sCustomerNameConfirmation = Console.ReadLine();
                if (sCustomerNameConfirmation.ToLower() == "exit")
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }
            }
            while (sCustomerName != sCustomerNameConfirmation || sCustomerName.Length <= 0);

            return sCustomerName;
        }

        /// <summary>
        /// Allow user to input contact number of customer.
        /// </summary>
        /// <returns>Double of contact number.</returns>
        public double InputHiredToNumber()
        {
            //Two integers will be used to validate user input.
            double iCustomerPhone;
            double iCustomerPhoneConfirmation;
            double iExitNum = 0;
            int iPhoneNumberLength = 11;

            do
            {
                Console.WriteLine("Input Customer Phone Number: [0 to Cancel]");
                //int.TryParse() returns false if input is not an int.
                if (double.TryParse(Console.ReadLine(), out iCustomerPhone) == false)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not recognised.");
                    Console.ResetColor();
                }

                //Check if user wants to exit.
                if (iCustomerPhone == iExitNum)
                {
                    Console.WriteLine("Phone Number Input Cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }
            }
            //Check if phone number is less than 11 digits.
            while (iCustomerPhone.ToString().Length < iPhoneNumberLength);

            do
            {
                Console.WriteLine("Confirm Customer Phone Number: [0 to Cancel]");
                //int.TryParse() returns false if input is not an int.
                if (double.TryParse(Console.ReadLine(), out iCustomerPhoneConfirmation) == false)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input not recognised.");
                    Console.ResetColor();
                }
                else if (iCustomerPhoneConfirmation == iExitNum)
                {
                    Console.WriteLine("Bike input cancelled. Press any key to continue.");
                    Console.ReadLine();
                    Menu();
                }
                else if (iCustomerPhoneConfirmation != iCustomerPhone)
                {
                    //Make warning red.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The entry does not match.");
                    Console.ResetColor();
                }
            }
            //Ask user for input until both codes match.
            while (iCustomerPhoneConfirmation != iCustomerPhone);

            return iCustomerPhone;
        }

        /// <summary>
        /// Allow user to input customer's address.
        /// </summary>
        /// <returns>String of customer's address.</returns>
        public string InputHiredToAddress()
        {
            //Two strings will be used to validate user input.
            string sCustomerAddress;
            string sCustomerAddressConfirmation;

            do
            {
                Console.WriteLine("Enter Customer Address: [exit to Cancel]");
                sCustomerAddress = Console.ReadLine();
                if (sCustomerAddress.ToLower() == "exit")
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }

                Console.WriteLine("Confirm Customer Address: [exit to Cancel]");
                sCustomerAddressConfirmation = Console.ReadLine();
                if (sCustomerAddressConfirmation.ToLower() == "exit")
                {
                    Console.WriteLine("Input Cancelled.");
                    Console.ReadLine();
                    Menu();
                }
            }
            while (sCustomerAddress != sCustomerAddressConfirmation || sCustomerAddress.Length <= 0);

            return sCustomerAddress;
        }

        /// <summary>
        /// Allow user to save all files automatically when called.
        /// </summary>
        public void SaveFileChoice()
        {
            Console.Clear();

            shop.SaveFunds();
            shop.SaveHiredBikesFile();
            shop.SaveInStockFile();
            shop.SaveSoldBikesFile();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Files saved successfully.");
            Console.ResetColor();
            Console.ReadLine();
            Menu();
        }

        /// <summary>
        /// Allow user to input what report they wish to save to file.
        /// </summary>
        public void ReportsChoice()
        {
            Console.Clear();

            //How many types of reports are there? Hired/Sold/InStock
            int iNumOfOptions = 3;
            int iUserInput;

            Console.WriteLine("What reports do you wish to create?");
            Console.WriteLine();
            Console.WriteLine("1. Hired Bikes");
            Console.WriteLine("2. Sold Bikes");
            Console.WriteLine("3. In Stock Bikes");

            if (int.TryParse(Console.ReadLine(), out iUserInput) == false)
            {
                Console.WriteLine("Input is not valid. Try again.");
                Console.ReadLine();
                ReportsChoice();
            }
            else if (iUserInput > iNumOfOptions || iUserInput < 0)
            {
                Console.WriteLine("Input a number from 1 - 3.");
                Console.ReadLine();
                ReportsChoice();
            }
            else
            {
                switch (iUserInput)
                {
                    case 1:
                        {
                            shop.CreateReport("HiredBikes");
                            break;
                        }
                    case 2:
                        {
                            shop.CreateReport("SoldBikes");
                            break;
                        }
                    case 3:
                        {
                            shop.CreateReport("InStockBikes");
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                Menu();
            }
        }

        //Pelsmaeker, D., Leal, T., Greevey, F. and Bialko, S. (2012).
        //.NET File.WriteAllLines leaves empty line at the end of file.
        //[online] Stack Overflow.
        //Available at: https://stackoverflow.com/questions/11689337/net-file-writealllines-leaves-empty-line-at-the-end-of-file
        //[Accessed 26 Mar. 2019].
        /// <summary>
        /// Writes All Lines to file without leaving empty line at the end.
        /// </summary>
        /// <param name="path">Path of file written to.</param>
        /// <param name="lines">String array being written.</param>
        public static void WriteAllLinesBetter(string filePath, params string[] lines)
        {
            //exception handling
            if (filePath == null)
                throw new ArgumentNullException("path");
            if (lines == null)
                throw new ArgumentNullException("lines");

            //File is closed automatically.
            using (var stream = File.OpenWrite(filePath))
            {
                stream.SetLength(0);
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    if (lines.Length > 0)
                    {
                        for (var i = 0; i < lines.Length - 1; i++)
                        {
                            writer.WriteLine(lines[i]);
                        }
                        writer.Write(lines[lines.Length - 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Allows the user to confirm a specified action.
        /// </summary>
        /// <param name="action">What action user needs to confirm</param>
        /// <returns>True if user confirmed action, else false.</returns>
        public bool Confirm(string action)
        {
            action = action.ToLower();
            //What actions need to be input?
            //Add, Remove, Sale, Return, Purchase, Buy, Edit, (Save)
            if (action == "add")
            {
                Console.WriteLine("Do you wish to add this bike? [Yes/No]");
            }
            else if (action == "remove")
            {
                Console.WriteLine("Do you wish to remove this bike? [Yes/No]");
            }
            else if (action == "sell")
            {
                Console.WriteLine("Do you wish to sell this bike? [Yes/No]");
            }
            else if (action == "return")
            {
                Console.WriteLine("Do you wish to return this bike? [Yes/No]");
            }
            else if (action == "buy")
            {
                Console.WriteLine("Do you wish to buy this bike? [Yes/No]");
            }
            else if (action == "edit")
            {
                Console.WriteLine("Do you wish to edit this bike? [Yes/No]");
            }
            else if (action == "hire")
            {
                Console.WriteLine("Do you wish to hire this bike out? [Yes/No]");
            }
            return GetUserBool();
        }

        /// <summary>
        /// reads the next console line input.
        /// </summary>
        /// <returns>True if user enters "yes" or "y". else, false.</returns>
        public bool GetUserBool()
        {
            //Do not have to compare all variations of capital letters.
            string sUserInput = Console.ReadLine().ToLower();

            if (sUserInput == "yes" || sUserInput == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
