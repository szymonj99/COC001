using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpaceAdventure
{
    public class GameVars //Class to determine current game vars
    {
        //Game wide variables
        public const int RANDOMATTACKCHANCE = 35; //% chance of random attacks occuring when changing rooms

        private const int RIDDLELOWERLIMIT = 1;
        private const int RIDDLEUPPERLIMIT = 4096;
        public static int iCurrentRoom = 1; //stores value of current room
        public static bool bRoom3Accessed = false; //Stores bool of player accessing a locked room, so they don't have to enter riddle more than once.
        public static int iRiddleOne;
        public static int iRiddleTwo;
        public static int iRiddleThree;
        public static int iRiddleFour;
        public static int iRiddleFive;
        public static bool bBossKilled = false;
        public static bool bPlayerLoadedGame = false;

        //The following code is really bad.
        //It determines what Letters to hide on the map of each room
        public static bool bHideA = false;

        public static bool bHideB = false;
        public static bool bHideC = false;
        public static bool bHideD = false;
        public static bool bHideE = false;
        public static bool bHideF = false;
        public static bool bHideG = false;
        public static bool bHideH = false;
        public static bool bHideI = false;
        public static bool bHideJ = false;
        public static bool bHideK = false;
        public static bool bHideL = false;
        public static bool bHideM = false;
        public static bool bHideN = false;
        public static bool bHideO = false;
        public static bool bHideP = false;

        public readonly static string SAVEFILENAME = "savefile.txt";
        public readonly static string HIGHSCORESFILENAME = "highscores.txt";

        public static void UpdateCurrentRoom() //used to draw map of room the user went to. Clear Console after every change -- FINISH
        {
            switch (iCurrentRoom)
            {
                case 1:
                    {
                        RoomLayout.DrawRoomOne();
                        break;
                    }

                case 2:
                    {
                        RoomLayout.DrawRoomTwo();
                        break;
                    }

                case 3:
                    {
                        RoomLayout.DrawRoomThree();
                        break;
                    }

                case 4:
                    {
                        RoomLayout.DrawRoomFour();
                        break;
                    }

                case 5:
                    {
                        RoomLayout.DrawRoomFive();
                        break;
                    }

                case 6:
                    {
                        RoomLayout.DrawRoomSix();
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

            RandomEncounter.GetRandomDamage();
            RandomEncounter.GetEncounter();
        }

        public static void UpdateRiddleVars() //Generate random riddles.
        {
            Random rnd = new Random();
            iRiddleOne = rnd.Next(RIDDLELOWERLIMIT, RIDDLEUPPERLIMIT);
            iRiddleTwo = rnd.Next(RIDDLELOWERLIMIT, RIDDLEUPPERLIMIT);
            iRiddleThree = rnd.Next(RIDDLELOWERLIMIT, RIDDLEUPPERLIMIT);
            iRiddleFour = rnd.Next(RIDDLELOWERLIMIT, RIDDLEUPPERLIMIT);
            iRiddleFive = rnd.Next(RIDDLELOWERLIMIT, RIDDLEUPPERLIMIT);
        }
    }

    public class RoomLayout //Used to show ASCII art of rooms
    {
        public static void DrawRoomOne() //Drawing Room One, using global vars from GameVars
        {
            string sRoomOneLayout;
            sRoomOneLayout =
                "###########------###########\n" +
                "#C                         #\n" +
                "#                      A   #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#             X            #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#             B            #\n" +
                "#                          #\n" +
                "############################";

            if (GameVars.bHideA == true) //using global variable to control room design.
            {
                sRoomOneLayout = sRoomOneLayout.Replace("A", " "); //Hide A
            }

            if (GameVars.bHideB == true)
            {
                sRoomOneLayout = sRoomOneLayout.Replace("B", " "); //Hide B
            }

            if (GameVars.bHideC == true)
            {
                sRoomOneLayout = sRoomOneLayout.Replace("C", " "); //Hide C
            }
            Console.Clear();
            Console.WriteLine(sRoomOneLayout);
            Console.WriteLine("You are in room: {0}", GameVars.iCurrentRoom);
            Console.WriteLine("The beginning room. This was the control room. Now, it is demolished, and on the brink of invasion by the Zarkonions. " +
                "There's a large window on the side of the ship, allowing you to see out into space. The rest of the room is a mess; what would you expect " +
                "after being invaded.");
        }

        public static void DrawRoomTwo() //Drawing Room Two, using global vars from GameVars
        {
            string sRoomTwoLayout;
            sRoomTwoLayout =
                "############################\n" +
                "#             E            #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "|                          #\n" +
                "| F           X            #\n" +
                "|                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#D                         #\n" +
                "###########------###########";

            if (GameVars.bHideD == true)
            {
                sRoomTwoLayout = sRoomTwoLayout.Replace("D", " ");
            }

            if (GameVars.bHideE == true)
            {
                sRoomTwoLayout = sRoomTwoLayout.Replace("E", " ");
            }

            if (GameVars.bHideF == true)
            {
                sRoomTwoLayout = sRoomTwoLayout.Replace("F", " ");
            }

            Console.Clear();
            Console.WriteLine(sRoomTwoLayout);
            Console.WriteLine("You are in room: {0}", GameVars.iCurrentRoom);
            Console.WriteLine("The room isn't much cleaner than the first. The windows are on the opposite side, with two doors. One leading further into the ship, " +
                "and one taking you back to the beginning.");
        }

        public static void DrawRoomThree() //Drawing Room Three, using global vars from GameVars
        {
            string sRoomThreeLayout;
            sRoomThreeLayout =
                "############################\n" +
                "#             G            #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          |\n" +
                "#             X            |\n" +
                "#                          |\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#             H            #\n" +
                "###########------###########";

            if (GameVars.bHideG == true)
            {
                sRoomThreeLayout = sRoomThreeLayout.Replace("G", " ");
            }

            if (GameVars.bHideH == true)
            {
                sRoomThreeLayout = sRoomThreeLayout.Replace("H", " ");
            }

            Console.Clear();
            Console.WriteLine(sRoomThreeLayout);
            Console.WriteLine("You are in room: {0}", GameVars.iCurrentRoom);
            Console.WriteLine("This is one of the storage rooms. Not much of it is left. Various lockers and chests are scattered, not leaving much for you to try and gather.");
        }

        public static void DrawRoomFour() //Drawing Room Four, using global vars from GameVars
        {
            string sRoomFourLayout;
            sRoomFourLayout =
                "###########------###########\n" +
                "#I                         #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "|                          #\n" +
                "|             X            #\n" +
                "|                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                         J#\n" +
                "############################";

            if (GameVars.bHideI == true)
            {
                sRoomFourLayout = sRoomFourLayout.Replace("I", " ");
            }

            if (GameVars.bHideJ == true)
            {
                sRoomFourLayout = sRoomFourLayout.Replace("J", " ");
            }

            Console.Clear();
            Console.WriteLine(sRoomFourLayout);
            Console.WriteLine("You are in room: {0}", GameVars.iCurrentRoom);
            Console.WriteLine("One of the engine rooms. You see some random tools, wrenches, and screwdrivers laying around. MAybe someone fought off the Zarkonions with them. " +
                "They won't be of much use to you.");
        }

        public static void DrawRoomFive() //Drawing Room Five, using global vars from GameVars
        {
            string sRoomFiveLayout;
            sRoomFiveLayout =
                "###########------###########\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          |\n" +
                "#             X           L|\n" +
                "#                          |\n" +
                "#                          #\n" +
                "#             M            #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "############################";

            if (GameVars.bHideK == true)
            {
                sRoomFiveLayout = sRoomFiveLayout.Replace("K", " ");
            }

            if (GameVars.bHideL == true)
            {
                sRoomFiveLayout = sRoomFiveLayout.Replace("L", " ");
            }

            if (GameVars.bHideM == true)
            {
                sRoomFiveLayout = sRoomFiveLayout.Replace("M", " ");
            }

            Console.Clear();
            Console.WriteLine(sRoomFiveLayout);
            Console.WriteLine("You are in room: {0}", GameVars.iCurrentRoom);
            Console.WriteLine("Yet another storage room. Again, Zarkonions got to your utilities and weapons before you could. The Zarkonions destroyed and plundered.");
        }

        public static void DrawRoomSix() //Drawing Room Six, using global vars from GameVars
        {
            string sRoomSixLayout;
            sRoomSixLayout = "";
            if (GameVars.bBossKilled == false)
            {
                sRoomSixLayout =
                "#--------------------------#\n" +
                "#|____|____|____|____|____|#\n" +
                "#             <>           #\n" +
                "#             /\\           #\n" +
                "#             \\/           #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "###########-------##########";
            }

            else
            {
                sRoomSixLayout =
                "#--------------------------#\n" +
                "#|____|____|____|____|____|#\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "#                          #\n" +
                "###########-------##########";
            }

            if (GameVars.bHideN == true)
            {
                sRoomSixLayout = sRoomSixLayout.Replace("N", " ");
            }

            if (GameVars.bHideO == true)
            {
                sRoomSixLayout = sRoomSixLayout.Replace("O", " ");
            }

            if (GameVars.bHideP == true)
            {
                sRoomSixLayout = sRoomSixLayout.Replace("P", " ");
            }

            Console.Clear();
            Console.WriteLine(sRoomSixLayout);
            Console.WriteLine("You are in room: {0}", GameVars.iCurrentRoom);
            Console.WriteLine("The room's quite spacious; as it should be, to hold the escape pods. You're ready to leave.");
        }

        public static void DrawWholeShip() //Draws ASCII art of whole ship.
        {
            string sWholeShip;
            sWholeShip =
                "#########---###################################################\n" +
                "#                    #                    #                   #\n" +
                "#                    #                    |                   #\n" +
                "#         6          #         3          |          2        #\n" +
                "#                    #                    |                   #\n" +
                "#                    #                    #                   #\n" +
                "#########---##################---###################---########\n" +
                "#                    #                    #                   #\n" +
                "#                    |                    #                   #\n" +
                "#         5          |         4          #          1        #\n" +
                "#                    |                    #                   #\n" +
                "#                    #                    #                   #\n" +
                "###############################################################";

            Console.Clear();
            Console.WriteLine(sWholeShip);
            Console.WriteLine("You are in room: {0}", GameVars.iCurrentRoom);
        }

        public static void DrawEscapePod() //Draws art of escape pod
        {
            string sEscapePod;
            sEscapePod =
                "     /\\ \n" +
                "    /  \\ \n" +
                "   /    \\ \n" +
                "  /      \\ \n" +
                " /        \\ \n" +
                "/__________\\ \n" +
                "|          | \n" +
                "|          | \n" +
                "|          | \n" +
                "|          | \n" +
                "|          | \n" +
                "|__________| \n";

            Console.WriteLine(sEscapePod);
        }

        public static void DrawGameOver() //ASCII art of "Game Over".
        {
            string sGameOver;
            sGameOver =
                "  /$$$$$$   /$$$$$$  /$$      /$$ /$$$$$$$$        /$$$$$$  /$$    /$$ /$$$$$$$$ /$$$$$$$ \n" +
                " /$$__  $$ /$$__  $$| $$$    /$$$| $$_____/       /$$__  $$| $$   | $$| $$_____/| $$__  $$\n" +
                "| $$  \\__/| $$  \\ $$| $$$$  /$$$$| $$            | $$  \\ $$| $$   | $$| $$      | $$  \\ $$\n" +
                "| $$ /$$$$| $$$$$$$$| $$ $$/$$ $$| $$$$$         | $$  | $$|  $$ / $$/| $$$$$   | $$$$$$$/\n" +
                "| $$|_  $$| $$__  $$| $$  $$$| $$| $$__/         | $$  | $$ \\  $$ $$/ | $$__/   | $$__  $$\n" +
                "| $$  \\ $$| $$  | $$| $$\\  $ | $$| $$            | $$  | $$  \\  $$$/  | $$      | $$  \\ $$\n" +
                "|  $$$$$$/| $$  | $$| $$ \\/  | $$| $$$$$$$$      |  $$$$$$/   \\  $/   | $$$$$$$$| $$  | $$\n" +
                " \\______/ |__/  |__/|__/     |__/|________/       \\______/     \\_/    |________/|__/  |__/\n";

            Console.Clear();
            Console.WriteLine(sGameOver);
        }
    }

    public class MainScreen //Used to show main menu screen to player.
    {
        public static void Menu()
        {
            string sSpaceAdventureASCII;
            sSpaceAdventureASCII =
                "  /$$$$$$  /$$$$$$$   /$$$$$$   /$$$$$$  /$$$$$$$$        /$$$$$$  /$$$$$$$  /$$    /$$ /$$$$$$$$ /$$   /$$ /$$$$$$$$ /$$   /$$ /$$$$$$$  /$$$$$$$$ \n" +
                " /$$__  $$| $$__  $$ /$$__  $$ /$$__  $$| $$_____/       /$$__  $$| $$__  $$| $$   | $$| $$_____/| $$$ | $$|__  $$__/| $$  | $$| $$__  $$| $$_____/ \n" +
                "| $$  \\__/| $$  \\ $$| $$  \\ $$| $$  \\__/| $$            | $$  \\ $$| $$  \\ $$| $$   | $$| $$      | $$$$| $$   | $$   | $$  | $$| $$  \\ $$| $$ \n" +
                "|  $$$$$$ | $$$$$$$/| $$$$$$$$| $$      | $$$$$         | $$$$$$$$| $$  | $$|  $$ / $$/| $$$$$   | $$ $$ $$   | $$   | $$  | $$| $$$$$$$/| $$$$$ \n" +
                " \\____  $$| $$____/ | $$__  $$| $$      | $$__/         | $$__  $$| $$  | $$ \\  $$ $$/ | $$__/   | $$  $$$$   | $$   | $$  | $$| $$__  $$| $$__/ \n" +
                " /$$  \\ $$| $$      | $$  | $$| $$    $$| $$            | $$  | $$| $$  | $$  \\  $$$/  | $$      | $$\\  $$$   | $$   | $$  | $$| $$  \\ $$| $$ \n" +
                "|  $$$$$$/| $$      | $$  | $$|  $$$$$$/| $$$$$$$$      | $$  | $$| $$$$$$$/   \\  $/   | $$$$$$$$| $$ \\  $$   | $$   |  $$$$$$/| $$  | $$| $$$$$$$$ \n" +
                " \\______/ |__/      |__/  |__/ \\______/ |________/      |__/  |__/|_______/     \\_/    |________/|__/  \\__/   |__/    \\______/ |__/  |__/|________/ \n";

            //string sWelcome;
            //sWelcome = "Welcome to Space Adventure. The aim of the game is to escape the spaceship, which is being attacked by the nasty Zarkonions." +
            //    "You will complete various riddles, talk with variety of characters, and escape either solo, or with a friend.";

            string sAimOfGame;
            sAimOfGame = "The aim of the game is to escape the spaceship, which is being attacked by the nasty Zarkonions." +
                "You will complete various riddles, talk with variety of characters, and escape either solo, or with a friend. You will navigate in the game by typing " +
                "which actions you which to perform, such as \"goto\", \"attack\", \"heal\", etc.";

            Console.Clear();
            //Console.WriteLine(sWelcome);
            Console.WriteLine(sSpaceAdventureASCII);
            Console.WriteLine();
            Console.WriteLine(sAimOfGame);
            Console.WriteLine();
            Console.WriteLine("Select an option from below:");
            Console.WriteLine();
            string sOptionOne; //New Game
            string sOptionTwo; //Load Game
            string sOptionThree; //High scores
            string sOptionFour; //Exit

            sOptionOne = "1. New Game";
            sOptionTwo = "2. Load Game";
            sOptionThree = "3. High Scores";
            sOptionFour = "4. Exit";

            //Calculate where to start writing strings to place them in the middle of the screen.
            int iOptionOneMiddle = (Console.WindowWidth / 2) - (sOptionOne.Length / 2);
            int iOptionTwoMiddle = (Console.WindowWidth / 2) - (sOptionTwo.Length / 2);
            int iOptionThreeMiddle = (Console.WindowWidth / 2) - (sOptionThree.Length / 2);
            int iOptionFourMiddle = (Console.WindowWidth / 2) - (sOptionFour.Length / 2);

            Console.SetCursorPosition(iOptionOneMiddle, Console.CursorTop);
            Console.WriteLine(sOptionOne);
            Console.SetCursorPosition(iOptionTwoMiddle, Console.CursorTop);
            Console.WriteLine(sOptionTwo);
            Console.SetCursorPosition(iOptionThreeMiddle, Console.CursorTop);
            Console.WriteLine(sOptionThree);
            Console.SetCursorPosition(iOptionFourMiddle, Console.CursorTop);
            Console.WriteLine(sOptionFour);

            int.TryParse(Console.ReadLine(), out int iUserChoice);

            while (iUserChoice < 1 || iUserChoice > 4)
            {
                Console.WriteLine("You must select a valid option.");
                int.TryParse(Console.ReadLine(), out iUserChoice);
            }

            switch (iUserChoice)
            {
                case 1:
                    {
                        return;
                    }

                case 2:
                    {
                        SaveFileManagment.LoadSaveFile();
                        GameVars.bPlayerLoadedGame = true;
                        return;
                    }

                case 3:
                    {
                        SaveFileManagment.LoadHighScores();
                        Menu();
                        return;
                    }

                case 4:
                    {
                        Environment.Exit(0);
                        return;
                    }

                default:
                    {
                        return;
                    }
            }
        }
    }

    public class Introduction //Used to print introduction for user.
    {
        public static void PrintIntroduction() //Writes introduction to the screen.
        {
            string sIntroduction; //Initialise string.
            sIntroduction = "A savage race is attacking your ship.\n" +
                "The Zarkonions have been attacking every ship they come across in the galaxy.\n" +
                "Their mission: to colonize and destroy.\n" +
                "The Zarkonions are coming for you.\n" +
                "Find a way out. Look for clues all the rooms on your ship.\n" +
                "The savage race has changed the escape pod security key. Find it, and get out of here."; //\n is used to denote new paragraph.
            Console.WriteLine(sIntroduction); //Writes sIntroduction to screen.
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public class Player //Player class used to make Player object.
    {
        //The following variables will be used by Player object. EG. Player.SPlayerName
        public static string SPlayerName { get; set; } //Initialise public string SPlayerName

        public static int IPlayerHealth { get; set; } //Initialise public int IPlayerHealth
        public static string SPlayerClass { get; set; } //Initialise public string SPlayerClass
        public static int ICurrentRoom { get; set; } //initialise public int ICurrentRoom
        public static bool BPlayerHasFriend { get; set; } //initialise public bool BPlayerHasFriend
        public static int IPlayerDamage { get; set; } //initialise public int IPlayerDamage

        public Player(string sPlayerName, int iPlayerHealth, string sPlayerClass, int iCurrentRoom, bool bPlayerHasFriend, int iPlayerDamage) //Sets Player variables to passed arguments
        {
            SPlayerName = sPlayerName; //Set SPlayerName to argument sPlayerName
            IPlayerHealth = iPlayerHealth;
            SPlayerClass = sPlayerClass;
            ICurrentRoom = iCurrentRoom;
            BPlayerHasFriend = bPlayerHasFriend;
            IPlayerDamage = iPlayerDamage;
        }
    }

    public class Friend //Friend class used to make Friend object.
    {
        //The following variables will be used by Friend object. EG. Friend.SPlayerName
        public static string SFriendName { get; set; } //initialise public string SFriendName

        public static int IFriendHealth { get; set; } //Initialise public integer IFriendHealth
        public static string SFriendClass { get; set; } //Initialise public string SFriendClass
        public static int IFriendDamage { get; set; }

        public Friend(string sFriendName, int iFriendHealth, string sFriendClass, int iFriendDamage) //Sets Friend variables to passed arguments
        {
            SFriendName = sFriendName; //Set SFriendName to argument sFriendName
            IFriendHealth = iFriendHealth;
            SFriendClass = sFriendClass;
            IFriendDamage = iFriendDamage;
        }
    }

    public class Item //Item class used to make Item objects. Not implemented.
    {
        public string SItemName { get; set; } //initialise public string SItemName
        public int IItemDamage { get; set; } //Initialise public int IItemDamage
        public string SItemEquippedBy { get; set; } //Initialise public string SItemEquippedBy

        public Item(string sItemName, int iItemDamage, string sItemEquippedBy) //Sets Item variables to passed arguments
        {
            SItemName = sItemName;
            IItemDamage = iItemDamage;
            SItemEquippedBy = sItemEquippedBy;
        }
    }

    public class Enemy //Create Enemy object
    {
        public static string SEnemyName { get; set; }
        public static int IEnemyDamage { get; set; }
        public static int IEnemyHealth { get; set; }

        public Enemy(string sEnemyName, int iEnemyDamage, int iEnemyHealth)
        {
            SEnemyName = sEnemyName;
            IEnemyDamage = iEnemyDamage;
            IEnemyHealth = iEnemyHealth;
        }
    }

    public class Boss //Create Boss object
    {
        public static string SBossName { get; set; }
        public static int IBossDamage { get; set; }
        public static int IBossHealth { get; set; }

        public Boss(string sBossName, int iBossDamage, int iBossHealth)
        {
            SBossName = sBossName;
            IBossDamage = iBossDamage;
            IBossHealth = iBossHealth;
        }
    }

    public class SetUpPlayerVars //Class to determine Player variables
    {
        public static string GetPlayerName() //Class used to get player name from user input
        {
            string sPlayerName, sPlayerNameConfirmation; //Initialise string variables

            do //Repeat until condition is met
            {
                Console.WriteLine("What is your name? [Cannot be empty.]");
                sPlayerName = Console.ReadLine();
                Console.WriteLine("Please enter your name again.");
                sPlayerNameConfirmation = Console.ReadLine(); //Validation check, compares two user entries.
            }
            while (sPlayerName != sPlayerNameConfirmation || sPlayerName == null || sPlayerName == ""); //sPlayerName and sPlayerNameConfirmation must be the same.

            return sPlayerName; //Return string sPlayerName to method caller.
        }

        public static string GetPlayerClass() //Class used to get player class from user input
        {
            string sClassOne, sClassTwo, sClassThree, sPlayerClass; //Initialise variables
            sPlayerClass = "PlaceHolder"; //Default value
            sClassOne = "Captain";
            sClassTwo = "Space Engineer";
            sClassThree = "Ensign";
            Console.WriteLine("What is your class?\n" +
                "1. {0}\n" +
                "2. {1}\n" +
                "3. {2}", sClassOne, sClassTwo, sClassThree); //Write class choice to screen
            int.TryParse(Console.ReadLine(), out int iPlayerClassChoice); //Will create int iPlayerClassChoice from user input.

            while (iPlayerClassChoice != 1 && iPlayerClassChoice != 2 && iPlayerClassChoice != 3) //iPlayerClassChoice must be 1 || 2 || 3.
            {
                int.TryParse(Console.ReadLine(), out iPlayerClassChoice); //Try parse input as int
                Console.WriteLine("You must select a class by typing an integer from 1 to 3."); //Write command to screen for the user.
            }
            if (iPlayerClassChoice > 0 && iPlayerClassChoice < 4) //iPlayerClassChoice == 1 || 2 || 3
                switch (iPlayerClassChoice) //Select user's class.
                {
                    case 1:
                        {
                            sPlayerClass = sClassOne; //Set sPlayerClass var
                            Console.WriteLine("You are a {0}.", sPlayerClass); //Print out player class
                            break;
                        }

                    case 2:
                        {
                            sPlayerClass = sClassTwo;
                            Console.WriteLine("You are a {0}.", sPlayerClass);
                            break;
                        }

                    case 3:
                        {
                            sPlayerClass = sClassThree;
                            Console.WriteLine("You are an {0}.", sPlayerClass);
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            return sPlayerClass; //Return value of sPlayerClass to method caller.
        }
    }

    public class SetUpFriendVars //Class to determine Friend variables
    {
        public static bool DoesPlayerHaveFriend() //Decide if player plays with friend
        {
            string sDoesPlayerHaveFriend; //initialise string for user input
            do //Do while loop, prompt user for a yes or no answer.
            {
                Console.WriteLine("Do you wish to play with a friend? [yes/no]"); //Ask user question
                sDoesPlayerHaveFriend = Console.ReadLine(); //Parse input as variable
            }
            while (sDoesPlayerHaveFriend != "yes" && sDoesPlayerHaveFriend != "no"); //End loop if player answers "yes" or "no"
            if (sDoesPlayerHaveFriend == "yes")
            {
                return true; //return true to method caller.
            }
            else
            {
                return false; //return false to method caller.
            }
        }

        public static string GetFriendName() //Get Friend's name
        {
            string sFriendName, sFriendNameConfirmation;
            do
            {
                Console.WriteLine("What is your friend's name? [Cannot be empty.]");
                sFriendName = Console.ReadLine();
                Console.WriteLine("Confirm your friend's name.");
                sFriendNameConfirmation = Console.ReadLine();
            }
            while (sFriendName != sFriendNameConfirmation || sFriendName == null || sFriendName == "");

            return sFriendName;
        }

        public static string GetFriendClass() //Get Friend's class
        {
            string sClassOne, sClassTwo, sClassThree, sFriendClass; //Initialise variables
            sFriendClass = "PlaceHolder"; //Default value.
            sClassOne = "Captain";
            sClassTwo = "Space Engineer";
            sClassThree = "Ensign";
            Console.WriteLine("What is your friend's class?\n" +
                "1. {0}\n" +
                "2. {1}\n" +
                "3. {2}", sClassOne, sClassTwo, sClassThree);
            int.TryParse(Console.ReadLine(), out int iFriendClassChoice); //Set iFriendClassChoice as integer input from user.

            while (iFriendClassChoice != 1 && iFriendClassChoice != 2 && iFriendClassChoice != 3) //iFriendClassChoice must be 1 || 2 || 3
            {
                int.TryParse(Console.ReadLine(), out iFriendClassChoice); //Repeat until user picks 1 || 2 || 3
                Console.WriteLine("You must select a class by typing an integer from 1 to 3."); //Print command to screen
            }

            if (iFriendClassChoice > 0 && iFriendClassChoice < 4)
            {
                switch (iFriendClassChoice)
                {
                    case 1:
                        {
                            sFriendClass = sClassOne;
                            Console.WriteLine("Your friend is a {0}.", sFriendClass);
                            break;
                        }

                    case 2:
                        {
                            sFriendClass = sClassTwo;
                            Console.WriteLine("Your friend is a {0}.", sFriendClass);
                            break;
                        }

                    case 3:
                        {
                            sFriendClass = sClassThree;
                            Console.WriteLine("Your friend is an {0}.", sFriendClass);
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }
            return sFriendClass;
        }
    }

    public class RandomEncounter //Class responsible for generating random encounters.
    {
        public static void GetEncounter()
        {
            Random rnd = new Random();
            int iAttackChance = rnd.Next(0, 101);
            if (GameVars.RANDOMATTACKCHANCE > iAttackChance)
            {
                //Add encounter battle here.
                Console.WriteLine("You encountered an enemy!");
                int iEnemyHealth = rnd.Next(30, 101); //Enemy will have random health value
                int iEnemyDamage = rnd.Next(5, 16); //Enemy will have random attack value
                int iEnemyNamePosition = rnd.Next(0, 10); //Pick random int from 0 to 9. Used to get name from 10 string array.
                string sEnemyName = GetEnemyNameFromArray(iEnemyNamePosition); //randomise enemy name from array.
                Enemy Enemy = new Enemy(sEnemyName, iEnemyDamage, iEnemyHealth); //create enemy object
                int iTurn = 0; //Decides who's turn it is.
                while (Player.IPlayerHealth > 0 && Enemy.IEnemyHealth > 0)
                {
                    if ((iTurn % 2) == 0)
                    {
                        Player.IPlayerHealth -= Enemy.IEnemyDamage; //Enemy deals damage to player.
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} attacked you for {1} damage. You have {2} health left.", Enemy.SEnemyName, Enemy.IEnemyDamage, Player.IPlayerHealth);

                        if (Player.BPlayerHasFriend == true)
                        {
                            Friend.IFriendHealth -= Enemy.IEnemyDamage; //Enemy deals damage to friend.
                            Console.WriteLine("{0} attacked your friend, {1} for {2} damage. Your friend has {3} health left.", Enemy.SEnemyName, Friend.SFriendName, Enemy.IEnemyDamage, Friend.IFriendHealth);
                        }

                        Console.ForegroundColor = ConsoleColor.Gray;
                        System.Threading.Thread.Sleep(1000);
                        iTurn += 1;
                    }
                    if ((iTurn % 2) == 1)
                    {
                        string sUserInput;
                        do
                        {
                            Console.WriteLine("What do you wish to do? [attack/heal]");
                            sUserInput = Console.ReadLine();
                        }
                        while (sUserInput != "attack" && sUserInput != "heal" && sUserInput != "a" && sUserInput != "h");

                        if (sUserInput == "attack" || sUserInput == "a")
                        {
                            Enemy.IEnemyHealth -= Player.IPlayerDamage;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You attacked {0} for {1} damage. The enemy has {2} health left.", Enemy.SEnemyName, Player.IPlayerDamage, Enemy.IEnemyHealth);

                            if (Player.BPlayerHasFriend == true)
                            {
                                Enemy.IEnemyHealth -= Friend.IFriendDamage;
                                Console.WriteLine("Your friend attacked {0} for {1}. The enemy has {2} health left.", Enemy.SEnemyName, Friend.IFriendDamage, Enemy.IEnemyHealth);
                            }

                            Console.ForegroundColor = ConsoleColor.Gray;
                            System.Threading.Thread.Sleep(1000);
                            iTurn += 1;
                        }

                        if (sUserInput == "heal" || sUserInput == "h")
                        {
                            int iPlayerHealsFor = rnd.Next(10, 36);
                            Player.IPlayerHealth += iPlayerHealsFor;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You healed yourself for {0} health. You have {1} health left.", iPlayerHealsFor, Player.IPlayerHealth);

                            if (Player.BPlayerHasFriend == true)
                            {
                                Friend.IFriendHealth += iPlayerHealsFor;
                                Console.WriteLine("Your friend healed themselves for {0} health. They have {1} health left.", iPlayerHealsFor, Friend.IFriendHealth);
                            }

                            Console.ForegroundColor = ConsoleColor.Gray;
                            System.Threading.Thread.Sleep(1000);
                            iTurn += 1;
                        }
                    }
                }

                if (Enemy.IEnemyHealth <= 0)
                {
                    Console.WriteLine("Congratulations! You won!");
                    return;
                }
                else if (Player.IPlayerHealth <= 0)
                {
                    Console.WriteLine("You lost.");
                    RoomLayout.DrawGameOver();
                    Console.ReadKey();
                    Environment.Exit(0); //Quit
                    return;
                }
            }
            else
            {
                return;
            }
        }

        public static string GetEnemyNameFromArray(int iArrayIndex)
        {
            string[] aEnemyNames = new string[10];
            aEnemyNames[0] = "Graham";
            aEnemyNames[1] = "Matt";
            aEnemyNames[2] = "George";
            aEnemyNames[3] = "Jack";
            aEnemyNames[4] = "Bennie";
            aEnemyNames[5] = "James";
            aEnemyNames[6] = "Andrew";
            aEnemyNames[7] = "Michael";
            aEnemyNames[8] = "Simon";
            aEnemyNames[9] = "Scotty";
            //These names have been picked randomly.

            return aEnemyNames[iArrayIndex];
        }

        public static void GetRandomDamage() //One of the checkpoints needed to pass this course work.
        {
            const int RANDOMDAMAGECHANCE = 10;
            Random rnd = new Random();

            if (rnd.Next(0, 101) < RANDOMDAMAGECHANCE)
            {
                if (Player.SPlayerClass == "Captain")
                {
                    Console.WriteLine("As a Captain, you took some damage leading the way. -5 HP");
                    Player.IPlayerHealth -= 5;
                }

                if (Player.SPlayerClass == "Space Engineer")
                {
                    Console.WriteLine("Your brain starts to struggle. Maybe being a Space Engineer wasn't the best idea. -2 HP");
                    Player.IPlayerHealth -= 2;
                }

                else
                {
                    Console.WriteLine("You took some damage from the debris laying around. -3 HP");
                    Player.IPlayerHealth -= 3;
                }
            }
        }
    }

    public class PlayerNextAction //Class to determine user's next action
    {
        public static void NextAction()
        {
            Console.WriteLine();
            Console.WriteLine("What is your next action?");
            string userNextAction = Console.ReadLine(); //user input read as string

            switch (userNextAction.ToLower()) //Check user's action, compare string. Not sure of a better way to handle so many commands. No longer case sensitive with .ToLower().
            {
                case "help": //user inputs "help"
                    {
                        Console.WriteLine("You have asked for help.\n" +
                            "Commands which you can use are, \"help\", \"ship\", \"room\", \"info\", \"goto room x\", \n" +
                            "\"goto x\", \"look\", \"save\", \"load\", \"kill\", \"escape\".");
                        Console.WriteLine();
                        break;
                    }

                case "ship": //draw map of whole ship
                    {
                        RoomLayout.DrawWholeShip(); //draw map of ship
                        break;
                    }

                case "room": //draw map of current room
                    {
                        DrawRoomMap();
                        break;
                    }

                case "intro":
                    {
                        Introduction.PrintIntroduction(); //Print introduction to screen
                        break;
                    }

                case "info": //Print out info about player and friend if player has friend.
                    {
                        WritePlayerInfo();
                        break;
                    }

                case "look":
                    {
                        switch (GameVars.iCurrentRoom)
                        {
                            case 1: //iCurrentRoom == 1
                                {
                                    Console.WriteLine("You look around, still dazed. You see some objects around you. Try interacting with them, before moving onto the next room.");
                                    break;
                                }

                            case 2: //iCurrentRoom == 2
                                {
                                    Console.WriteLine("You continue looking, and notice more objects scattered. The Zarkonions destroyed almost everything. They also locked the door to the next room.");
                                    break;
                                }

                            case 3: //iCurrentRoom == 3
                                {
                                    Console.WriteLine("You see two figures in the room. What do they have to say?");
                                    break;
                                }

                            case 4: //iCurrentRoom == 4
                                {
                                    Console.WriteLine("You see a gambler in the room. Go on, play. . .");
                                    break;
                                }

                            case 5: //iCurrentRoom == 5
                                {
                                    Console.WriteLine("In the room ahead, you see the escape pods.");
                                    break;
                                }

                            case 6: //iCurrentRoom == 6
                                {
                                    Console.WriteLine("After killing the boss, you notice the scape pods. Now is your chance, escape! [escape]");
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        break;
                    }

                case "save":
                    {
                        Console.WriteLine("Saving your progress.");
                        SaveFileManagment.SaveSaveFile();
                        break;
                    }

                case "load":
                    {
                        Console.WriteLine("Loading your progress.");
                        SaveFileManagment.LoadSaveFile();
                        break;
                    }

                case "goto room 1":
                    {
                        if (GameVars.iCurrentRoom == 2)
                        {
                            GameVars.iCurrentRoom = 1;
                            GameVars.UpdateCurrentRoom();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You cannot get to this room right now, or you are already in it.");
                            break;
                        }
                    }

                case "goto a":
                    {
                        UserGoesToA();
                        break;
                    }

                case "goto b":
                    {
                        UserGoesToB();
                        break;
                    }

                case "goto c":
                    {
                        UserGoesToC();
                        break;
                    }

                case "goto room 2":
                    {
                        UserGoesToRoom2();
                        break;
                    }

                case "goto d":
                    {
                        UserGoesToD();
                        break;
                    }

                case "goto e":
                    {
                        UserGoesToE();
                        break;
                    }

                case "goto f":
                    {
                        UserGoesToF();
                        break;
                    }

                case "goto room 3":
                    {
                        UserGoesToRoom3();
                        break;
                    }

                case "goto g":
                    {
                        UserGoesToG();
                        break;
                    }

                case "goto h":
                    {
                        UserGoesToH();
                        break;
                    }

                case "goto room 4":
                    {
                        UserGoesToRoom4();
                        break;
                    }

                case "goto i":
                    {
                        UserGoesToI();
                        break;
                    }

                case "goto j":
                    {
                        UserGoesToJ();
                        break;
                    }

                case "goto room 5":
                    {
                        UserGoesToRoom5();
                        break;
                    }

                case "goto k":
                    {
                        UserGoesToK();
                        break;
                    }

                case "goto l":
                    {
                        UserGoesToL();
                        break;
                    }

                case "goto m":
                    {
                        UserGoesToM();
                        break;
                    }

                case "goto room 6":
                    {
                        UserGoesToRoom6();
                        break;
                    }

                case "kill": //test case to test end game screen.
                    {
                        Player.IPlayerHealth = -1;
                        break;
                    }

                case "riddle":
                    {
                        UserAsksForRiddle();
                        break;
                    }

                case "escape":
                    {
                        UserEscapes();
                        break;
                    }

                default: //default behaviour
                    {
                        Console.WriteLine("Input not understood. Try Again.");
                        break; //exit out of statement
                    }
            }

            //After every command input, check if player died.
            if (Player.BPlayerHasFriend == false && Player.IPlayerHealth <= 0) //end game if player health is 0 or below.
            {
                RoomLayout.DrawGameOver(); //Game over
                Console.ReadKey();
                Environment.Exit(0); //Quit
                return;
            }

            if (Player.BPlayerHasFriend == true && (Player.IPlayerHealth <= 0 || Friend.IFriendHealth <= 0)) //if player has friend, and health of either is 0 or below, end game.
            {
                RoomLayout.DrawGameOver(); //Game over
                Console.ReadKey();
                Environment.Exit(0); //Quit
                return;
            }

            NextAction(); //repeat method.
            return; //end instance of this method.
        }

        public static void WritePlayerInfo()
        {
            Console.WriteLine("Player name: {0}\n" + //Print player info
                           "Player Class: {1}\n" +
                           "Player Health: {2}\n" +
                           "Player Damage: {3}", Player.SPlayerName, Player.SPlayerClass, Player.IPlayerHealth, Player.IPlayerDamage);

            if (Player.BPlayerHasFriend == true) //does player have friend
            {
                Console.WriteLine("Friend Name: {0}\n" +
                    "Friend Class: {1}\n" +
                    "Friend Health: {2}\n" +
                    "Friend Damage: {3}", Friend.SFriendName, Friend.SFriendClass, Friend.IFriendHealth, Friend.IFriendDamage);
            }

            return;
        }

        public static void DrawRoomMap()
        {
            switch (GameVars.iCurrentRoom) //Decides which room to print
            {
                case 1: //iCurrentRoom == 1
                    {
                        RoomLayout.DrawRoomOne(); //Draw first room
                        break;
                    }

                case 2: //iCurrentRoom == 2
                    {
                        RoomLayout.DrawRoomTwo(); //Draw second room
                        break;
                    }

                case 3: //iCurrentRoom == 3
                    {
                        RoomLayout.DrawRoomThree(); //Draw third room
                        break;
                    }

                case 4: //iCurrentRoom == 4
                    {
                        RoomLayout.DrawRoomFour(); //Draw Fourth room
                        break;
                    }

                case 5: //iCurrentRoom == 5
                    {
                        RoomLayout.DrawRoomFive(); //Draw Firth room
                        break;
                    }

                case 6: //iCurrentRoom == 6
                    {
                        RoomLayout.DrawRoomSix(); //Draw sixth room
                        break;
                    }

                default: //default behaviour when none of the above matches
                    {
                        break; //exit the statement
                    }
            }

            //Console.WriteLine("You are in room: {0}", GameVars.iCurrentRoom);
            return; //exit the statement
        }

        public static void UserGoesToA()
        {
            if (GameVars.iCurrentRoom == 1) //if user is in room one
            {
                if (GameVars.bHideA == false) //A has not been visited before
                {
                    Console.WriteLine("You pick up what looks like a piece of paper, with some numbers written on it; {0}.", GameVars.iRiddleOne); //First piece of puzzle given to user
                    GameVars.bHideA = true; //Hide A from room map
                    return;
                }
                else //If A was visited before
                {
                    Console.WriteLine("You picked this item up already.");
                    return;
                }
            }
            else //if user is not in room one.
            {
                Console.WriteLine("You are in the wrong room.");
                return;
            }
        }

        public static void UserGoesToB()
        {
            if (GameVars.iCurrentRoom == 1) //if user is in room 1
            {
                if (GameVars.bHideB == false) //and B is not visited before
                {
                    Console.WriteLine("You turn around and look at one of the spaceship windows. You see a lot of ugly Zarkonions, ready to invade your ship.");
                    GameVars.bHideB = true; //Hide B from map of room
                    return;
                }
                else //B is visited before
                {
                    Console.WriteLine("You picked this item up already.");
                    return;
                }
            }
            else //if user is not in room 1
            {
                Console.WriteLine("You are in the wrong room.");
                return;
            }
        }

        public static void UserGoesToC()
        {
            if (GameVars.iCurrentRoom == 1) //if user is in room 1
            {
                if (GameVars.bHideC == false) //C is not visited before
                {
                    Console.WriteLine("You pick up a magnetic key card up from the ground. You must have lost it upon impact " +
                        "with the Zarkonions' ship. You suspect you can use this to gain access to the adjacent room.");
                    GameVars.bHideC = true; //Hide C from map of room
                    return;
                }
                else //if C is visited before
                {
                    Console.WriteLine("You picked this item up already.");
                    return;
                }
            }
            else //if user is not in room 1
            {
                Console.WriteLine("You are in the wrong room.");
                return;
            }
        }

        public static void UserGoesToRoom2()
        {
            if (GameVars.bHideC == true && (GameVars.iCurrentRoom == 1 || GameVars.iCurrentRoom == 3)) //if key is picked up (C), and user is in room 1 or 3.
            {
                GameVars.iCurrentRoom = 2; //Change room var to room2
                GameVars.UpdateCurrentRoom(); //Write map of new room.
                return;
            }
            else //if c is not visited before, or user is not in room 1 or 3.
            {
                Console.WriteLine("To open the door, you need to pick up a key in room one, and must be adjacent to the room you're trying to access."); //give info to user on what to do.
                return;
            }
        }

        public static void UserGoesToD()
        {
            if (GameVars.iCurrentRoom == 2) //if user is in room 2
            {
                if (GameVars.bHideD == false) //and D is not visited before
                {
                    Console.WriteLine("You pick up another piece of the puzzle; {0}", GameVars.iRiddleTwo); //Give user second piece of riddle
                    GameVars.bHideD = true; //Hide D from map of room
                    return;
                }
                else //if D is visited before
                {
                    Console.WriteLine("You picked this item up already.");
                    return;
                }
            }
            else //if user is not in room 2
            {
                Console.WriteLine("You are in the wrong room.");
                return;
            }
        }

        public static void UserGoesToE()
        {
            if (GameVars.iCurrentRoom == 2) //if user is in room 2
            {
                if (GameVars.bHideE == false) // and E was not visited before
                {
                    Console.WriteLine("You pick up another piece of the puzzle; {0}", GameVars.iRiddleThree); //Give user third piece of riddle
                    GameVars.bHideE = true; //Hide E from map of ship
                    return;
                }
                else //if E was visited before
                {
                    Console.WriteLine("You picked this item up already.");
                    return;
                }
            }
            else //if user is not in room 2
            {
                Console.WriteLine("You are in the wrong room.");
                return;
            }
        }

        public static void UserGoesToF()
        {
            if (GameVars.iCurrentRoom == 2) //if user is in room 2
            {
                if (GameVars.bHideF == false) //ensures buff is applied on first encounter only
                {
                    Random rnd = new Random(); //initialise random
                    int i = rnd.Next(1, 16); //Random value from 1 - 15, added to player's attack damage.
                    Console.WriteLine("You approach a decently-sized figure, standing in the room. " +
                        "The figure says, \"To defeat the enemy, you need to be stronger. Here, have this; +{0} Attack Damage to you and your allies.\" ", i);
                    Player.IPlayerDamage += i; //Add i to player damage
                    if (Player.BPlayerHasFriend == true)
                    {
                        Friend.IFriendDamage += i; //Add Damage to friend if player has friend.
                    }
                    GameVars.bHideF = true; //Hide F from map of room.
                    return;
                }
                else //if F was visited before
                {
                    Console.WriteLine("You talked to this person already.");
                    return;
                }
            }
            else //if user is not in room 2.
            {
                Console.WriteLine("You are in the wrong room.");
                return;
            }
        }

        public static void UserGoesToRoom3()
        {
            if (GameVars.bRoom3Accessed == false) //if Room 3 was not accessed before
            {
                if (GameVars.bHideF == true && (GameVars.iCurrentRoom == 4 || GameVars.iCurrentRoom == 2)) //and user picked up F, and is in room 2 or 3
                {
                    //Could remove bHideF == true to remove hints from player, or could add (if all riddle pieces picked up) && (room == 2 || room == 4)
                    Console.WriteLine("The nasty Zarkonions made you solve a riddle; what is the sum of all the numbers you got so far?");
                    int.TryParse(Console.ReadLine(), out int iUserInput); //Try parsing user input as an integer.
                    if (iUserInput == (GameVars.iRiddleOne + GameVars.iRiddleTwo + GameVars.iRiddleThree)) //what is the sum of all three riddle pieces so far?
                    {
                        GameVars.iCurrentRoom = 3; //Change current room to 3
                        GameVars.bRoom3Accessed = true; //Room 3 is now visited. Riddle won't need to be solved again
                        GameVars.UpdateCurrentRoom(); //Update room map to room 3
                        return;
                    }
                    else //if user does not enter an integer, or enters wrong integer.
                    {
                        Console.WriteLine("Oops, you're wrong.");
                        return;
                    }
                }
                else //if 3rd piece of riddle was not picked up
                {
                    Console.WriteLine("To get access to this room, try talking to an NPC you met before, and be in a room adjacent to the one you want to access.");
                    return;
                }
            }
            else //if room 3 was visited before
            {
                GameVars.iCurrentRoom = 3; //Move to room 3 without having to solve a riddle again
                GameVars.UpdateCurrentRoom(); //print map of room 3
                return;
            }
        }

        public static void UserGoesToG()
        {
            if (GameVars.iCurrentRoom == 3) //If user is in room 3
            {
                if (GameVars.bHideG == false) //and G was not picked up before. One Time offer for user only.
                {
                    Console.WriteLine("You approach the first figure in the room. They look friendly. \"How does +15 Attack Damage sound?\" They ask. " +
                        "\"For e merely price of 5 Health. . .\" The figure adds. " +
                        "\"Do you wish to accept my bargain?\"");
                    string sUserSacrifice; //initialise string. USed to get a yes or no answer from player
                    do
                    {
                        Console.WriteLine("Do you wish to accept the sacrifice? [yes/no]");
                        sUserSacrifice = Console.ReadLine(); //parse string as sUserSacrifice
                    }
                    while (sUserSacrifice != "yes" && sUserSacrifice != "no"); //string must be either "yes" or "no"
                    if (sUserSacrifice == "yes") //if user wants to accept exchange
                    {
                        Console.WriteLine("You accepted the sacrifice...");
                        Player.IPlayerDamage += 15; //add 15 damage to player
                        Player.IPlayerHealth -= 5; //minus 5 health from player
                        if (Player.BPlayerHasFriend == true) //if player plays with friend
                        {
                            Friend.IFriendDamage += 15; //add 15 damage to friend
                            Friend.IFriendHealth -= 5; //minus 5 health from friend
                        }
                    }
                    else //is sUserSacrifice == "no"
                    {
                        Console.WriteLine("You declined the sacrifice.");
                    }
                    GameVars.bHideG = true; //Hide G from map of room
                    return;
                }
                else //if G was visited already, no matter if user declined or accepted sacrifice.
                {
                    Console.WriteLine("You already talked to this figure.");
                    return;
                }
            }
            else //If user is not in room 3
            {
                Console.WriteLine("You are in the wrong room.");
                return;
            }
        }

        public static void UserGoesToH()
        {
            if (GameVars.iCurrentRoom == 3) //if User is in room 3
            {
                if (GameVars.bHideH == false) //and H was not visited before
                {
                    Console.WriteLine("You approach another figure. This one, looking like a gambler. Seems like there's plenty of them where you come from. " +
                        "He tries to persuade you into accepting a secret deal. \"Hey, you. Your type likes to play, don't ya\"");
                    string sUserAccepts; //initialise string
                    do
                    {
                        Console.WriteLine("Do you wish to gamble with the man? [yes/no]");
                        sUserAccepts = Console.ReadLine(); //parse user input as a string sUserAccepts
                    }
                    while (sUserAccepts != "yes" && sUserAccepts != "no"); //Repeat loop whilst user does not enter "yes" or "no"
                    if (sUserAccepts == "yes") //if user accepts gift
                    {
                        Random rnd = new Random(); //intiialise random var
                        int iItemDamage = rnd.Next(-10, 11); //pick random int from -10 to 10
                        int iPlayerHealth = rnd.Next(-5, 11); //pick random int from -5 to 10
                        Console.WriteLine("You and your allies received {0} Attack Damage, and {1} Health", iItemDamage, iPlayerHealth); //use random numbers to buff player
                        Player.IPlayerDamage += iItemDamage; //add iItemDamage to player
                        Player.IPlayerHealth += iPlayerHealth; //add iPlayerHealth to player
                        if (Player.BPlayerHasFriend == true) //if user plays with friend
                        {
                            Friend.IFriendDamage += iItemDamage; //Add iItemDamage to friend
                            Friend.IFriendHealth += iPlayerHealth; //add iPlayerHealth to friend
                        }
                    }
                    else //if user enters "no"
                    {
                        Console.WriteLine("You did not accept the random gift.");
                    }

                    GameVars.bHideH = true; //Hide H from map of room
                    return;
                }
                else //if user visited H before
                {
                    Console.WriteLine("You already talked to this figure.");
                    return;
                }
            }
            else //if user is not in room 3
            {
                Console.WriteLine("You are in the wrong room.");
                return;
            }
        }

        public static void UserGoesToRoom4()
        {
            if (GameVars.iCurrentRoom == 5 || GameVars.iCurrentRoom == 3) //if user is in room 5 or 3
            {
                GameVars.iCurrentRoom = 4;
                GameVars.UpdateCurrentRoom();
                return;
            }
            else //if user is not in room 5 or 3
            {
                Console.WriteLine("You are in the wrong room.");
                return;
            }
        }

        public static void UserGoesToI()
        {
            //This could be the gambling NPC, giving user a random stat every time he talks. The Gambler will not disappear.
            if (GameVars.iCurrentRoom == 4) //if user is in room 4
            {
                Console.WriteLine("You see a gambler. He can give you a random buff. Be careful, he can also make you weaker. Do you wish to approach him? [yes/no]");
                string sUserInput; //initialise string sUserInput
                sUserInput = Console.ReadLine(); //read user input
                if (sUserInput == "yes") //if user wants to gamble
                {
                    Random rnd = new Random(); //initialise new random int
                    int iValue = rnd.Next(-10, 11); //pick random int from -10 to 10
                    if (iValue < 0) //if iValue is negative
                    {
                        Console.WriteLine("The gambler decided to take away {0} Health and Attack Damage from you and your allies.", iValue);
                    }
                    else //if iValue is positive
                    {
                        Console.WriteLine("The gambler decided to add {0} Health and Attack Damage to you and your allies.", iValue);
                    }

                    Player.IPlayerDamage += iValue;
                    Player.IPlayerHealth += iValue;
                    if (Player.BPlayerHasFriend == true)
                    {
                        Friend.IFriendHealth += iValue;
                        Friend.IFriendDamage += iValue;
                    }

                    return;
                }
                else //if user declines gambler
                {
                    Console.WriteLine("You declined the gambler's offer.");
                    return;
                }
            }
            else //if user is not in room 4
            {
                Console.WriteLine("You are in the wrong room.");
                return;
            }
        }

        public static void UserGoesToJ()
        {
            //this could be a lever required to unlock the next room
            //could heal the player?
            if (GameVars.iCurrentRoom == 4) //if user is in room 4
            {
                if (GameVars.bHideJ == false) //if user didn't visit J beforehand
                {
                    Console.WriteLine("The door to the next room is now unlocked.");
                    GameVars.bHideJ = true; //hide J from map of room
                    return;
                }
            }
            else //if user is not in room 4
            {
                Console.WriteLine("You are in the wrong room.");
                return;
            }
        }

        public static void UserGoesToRoom5()
        {
            if (GameVars.iCurrentRoom == 4 || GameVars.iCurrentRoom == 6) //if user is in room 4 or 6
            {
                if (GameVars.bHideJ == true) //and player went to J beforehand
                {
                    GameVars.iCurrentRoom = 5; //change room to room 5
                    GameVars.UpdateCurrentRoom(); //print map of room 5
                    return;
                }
                else //if user did not activate J yet
                {
                    Console.WriteLine("The door to this room is locked.");
                    return;
                }
            }
            else //if user is not in room 4 or 6
            {
                Console.WriteLine("You are in the wrong room.");
                return;
            }
        }

        public static void UserGoesToK()
        {
            if (GameVars.iCurrentRoom == 5) //if user is in room 5
            {
                if (GameVars.bHideK == false) //if user did not go to K before
                {
                    Console.WriteLine("You see some health kits on the ground. You pick them up, and apply some bandages and antiseptic to yourself and allies.");
                    Player.IPlayerHealth += 50; //add 50 health to player
                    if (Player.BPlayerHasFriend == true) //if player has friend
                    {
                        Friend.IFriendHealth += 50; //add 50 health to friend object
                    }
                    GameVars.bHideK = true; //hide K from map of room
                    return;
                }
                else
                {
                    Console.WriteLine("You have picked the bandages up before.");
                    return;
                }
            }
            else //if user is not in room 5
            {
                Console.WriteLine("You are in the wrong room.");
                return;
            }
        }

        public static void UserGoesToL()
        {
            if (GameVars.iCurrentRoom == 5)
            {
                if (GameVars.bHideL == false)
                {
                    Console.WriteLine("You discovered another piece of the riddle; {0}", GameVars.iRiddleFour);
                    GameVars.bHideL = true;
                }
                else
                {
                    Console.WriteLine("You visited this riddle piece before.");
                }
            }
            else
            {
                Console.WriteLine("You are in the wrong room.");
            }

            return;
        }

        public static void UserGoesToM()
        {
            if (GameVars.iCurrentRoom == 5)
            {
                if (GameVars.bHideM == false)
                {
                    Console.WriteLine("You discovered the last piece of the riddle; {0}", GameVars.iRiddleFive);
                    GameVars.bHideM = true;
                }
                else
                {
                    Console.WriteLine("You visited this riddle piece before.");
                }
            }
            else
            {
                Console.WriteLine("You are in the wrong room.");
            }

            return;
        }

        public static void UserGoesToRoom6()
        {
            if (GameVars.bHideL == true && GameVars.bHideM == true)
            {
                if (GameVars.bBossKilled == false)
                {
                    Console.WriteLine("What is the product of the last two riddles?");
                    int.TryParse(Console.ReadLine(), out int iUserInput);
                    if (iUserInput == (GameVars.iRiddleFour * GameVars.iRiddleFive))
                    {
                        const string sBossName = "Zarkonion";
                        const int iBossHealth = 140;
                        const int iBossDamage = 15;
                        Random rnd = new Random();
                        Console.WriteLine("You encounter the final boss on the ship. Are you ready to fight him? [yes/no]");
                        string sUserInput;
                        sUserInput = Console.ReadLine();
                        if (sUserInput == "yes" || sUserInput == "y")
                        {
                            Console.WriteLine("You start to fight the boss.");
                            Boss Boss = new Boss(sBossName, iBossDamage, iBossHealth);

                            int iTurn = 0;
                            while (Player.IPlayerHealth > 0 && Boss.IBossHealth > 0)
                            {
                                if ((iTurn % 2) == 0)
                                {
                                    Player.IPlayerHealth -= Boss.IBossDamage;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("{0} attacked you for {1} damage. You have {2} health left.", Boss.SBossName, Boss.IBossDamage, Player.IPlayerHealth);
                                    if (Player.BPlayerHasFriend == true)
                                    {
                                        Friend.IFriendHealth -= Boss.IBossDamage;
                                        Console.WriteLine("{0} attacked your friend, {1} for {2} damage. Your friend has {3} health left.", Boss.SBossName, Friend.SFriendName, Boss.IBossDamage, Friend.IFriendHealth);
                                    }
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    System.Threading.Thread.Sleep(1000);
                                    iTurn += 1;
                                }
                                if ((iTurn % 2) == 1)
                                {
                                    do
                                    {
                                        Console.WriteLine("What do you wish to do? [attack/heal]");
                                        sUserInput = Console.ReadLine();
                                    }
                                    while (sUserInput != "attack" && sUserInput != "heal" && sUserInput != "a" && sUserInput != "h");

                                    if (sUserInput == "attack" || sUserInput == "a")
                                    {
                                        Boss.IBossHealth -= Player.IPlayerDamage;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("You attacked {0} for {1} damage. The enemy has {2} health left.", Boss.SBossName, Player.IPlayerDamage, Boss.IBossHealth);
                                        if (Player.BPlayerHasFriend == true)
                                        {
                                            Boss.IBossHealth -= Friend.IFriendDamage;
                                            Console.WriteLine("Your friend attacked {0} for {1}. The enemy has {2} health left.", Boss.SBossName, Friend.IFriendDamage, Boss.IBossHealth);
                                        }
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        System.Threading.Thread.Sleep(1000);
                                        iTurn += 1;
                                    }

                                    if (sUserInput == "heal" || sUserInput == "h")
                                    {
                                        int iPlayerHealsFor = rnd.Next(10, 36);
                                        Player.IPlayerHealth += iPlayerHealsFor;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("You healed yourself for {0} health. You have {1} health left.", iPlayerHealsFor, Player.IPlayerHealth);
                                        if (Player.BPlayerHasFriend == true)
                                        {
                                            Friend.IFriendHealth += iPlayerHealsFor;
                                            Console.WriteLine("Your friend healed themselves for {0} health. They have {1} health left.", iPlayerHealsFor, Friend.IFriendHealth);
                                        }
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        System.Threading.Thread.Sleep(1000);
                                        iTurn += 1;
                                    }
                                }
                            }

                            if (Boss.IBossHealth <= 0)
                            {
                                Console.WriteLine("Congratulations! You won!");
                                GameVars.bBossKilled = true;
                                GameVars.iCurrentRoom = 6;
                                GameVars.UpdateCurrentRoom();
                                return;
                            }
                            else if (Player.IPlayerHealth <= 0)
                            {
                                Console.WriteLine("You lost.");
                                RoomLayout.DrawGameOver();
                                Console.ReadKey();
                                Environment.Exit(0);
                                return;
                            }
                        }
                        else if (sUserInput == "no" || sUserInput == "n")
                        {
                            Console.WriteLine("You decided to not fight the boss for now.");
                            GameVars.iCurrentRoom = 5;
                            GameVars.UpdateCurrentRoom();
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again.");
                        return;
                    }
                }
                else
                {
                    GameVars.iCurrentRoom = 6;
                    GameVars.UpdateCurrentRoom();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Collect the last two riddle pieces.");
                return;
            }
        }

        public static void UserAsksForRiddle()
        {
            if (GameVars.bHideA == true)
            {
                Console.WriteLine("The first part of the riddle is: {0}", GameVars.iRiddleOne);
            }

            if (GameVars.bHideD == true)
            {
                Console.WriteLine("The second part of the riddle is: {0}", GameVars.iRiddleTwo);
            }

            if (GameVars.bHideE == true)
            {
                Console.WriteLine("The third part of the riddle is: {0}", GameVars.iRiddleThree);
            }

            if (GameVars.bHideL == true)
            {
                Console.WriteLine("The fourth part of the riddle is: {0}", GameVars.iRiddleFour);
            }

            if (GameVars.bHideM == true)
            {
                Console.WriteLine("The fifth part of the riddle is: {0}", GameVars.iRiddleFive);
            }
            return;
        }

        public static void UserEscapes()
        {
            if (GameVars.bBossKilled == true && GameVars.iCurrentRoom == 6)
            {
                Console.Clear();

                int iHighScore;
                iHighScore = (Player.IPlayerDamage + Player.IPlayerHealth) * 15; //15 is a random number.
                bool bProperInput = false;
                string sUserInput;

                do
                {
                    Console.WriteLine("You escaped the ship in your escape pod!");
                    RoomLayout.DrawEscapePod();
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Congratulations, you completed the game. Would you wish to save your high score of: {0}? [yes/no]", iHighScore);
                    sUserInput = Console.ReadLine();

                    if (sUserInput.ToLower() == "yes" || sUserInput.ToLower() == "y" || sUserInput.ToLower() == "no" || sUserInput.ToLower() == "n")
                    {
                        bProperInput = true;
                    }
                }
                while (bProperInput == false);

                if (sUserInput.ToLower() == "yes" || sUserInput.ToLower() == "y") //Finish up high scores. Could just save them, without any order.
                {
                    //Save high score here. Would have to arrange the high scores in descending values.
                    //Maybe show high scores, readLine, then exit?
                    //High scores will unfortunately not store player names - makes it a lot easier to rearrange the values.
                    try
                    {
                        List<string> lHighScores = File.ReadAllLines(GameVars.HIGHSCORESFILENAME).ToList(); //Loading High Score file into string list.

                        List<int> lHighScoresIntList = new List<int>(); //Creating new int list.

                        foreach (var tempString in lHighScores)
                        {
                            lHighScoresIntList.Add(int.Parse(tempString)); //Parsing every item in string list as int and adding to int list.
                        }

                        lHighScoresIntList.Add(iHighScore); //Adding current user's high score to the list.

                        lHighScoresIntList.Sort(); //List is sorted in ascending order.
                        lHighScoresIntList.Reverse(); //Reverse to have list in descending order - highest score at the top.

                        //Then write new sorted high scores.

                        File.Delete(GameVars.HIGHSCORESFILENAME);
                        File.WriteAllText(GameVars.HIGHSCORESFILENAME, string.Empty);

                        foreach (var tempVar in lHighScoresIntList)
                        {
                            string toWrite;
                            toWrite = tempVar.ToString();

                            File.AppendAllText(GameVars.HIGHSCORESFILENAME, toWrite + Environment.NewLine);
                        }

                        int iLinesInFile = File.ReadAllLines(GameVars.HIGHSCORESFILENAME).Count();

                        if (iLinesInFile > 10)
                        {
                            Console.WriteLine("Removing lowest scores.");
                            int iToRemove;
                            iToRemove = lHighScoresIntList.Count - 10;
                            lHighScoresIntList.RemoveRange(10, iToRemove); //Removing every lowest score including index of 10.
                        }

                        File.Delete(GameVars.HIGHSCORESFILENAME);

                        foreach (var tempVar in lHighScoresIntList)
                        {
                            string toWrite;
                            toWrite = tempVar.ToString();

                            File.AppendAllText(GameVars.HIGHSCORESFILENAME, toWrite + Environment.NewLine);
                        }

                        Console.ReadLine();
                    }
                    catch (IOException exception)
                    {
                        Console.WriteLine("The file could not be read:");
                        Console.WriteLine(exception.Message);
                        return;
                    }

                    Environment.Exit(0);
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }

    public class SaveFileManagment //Class responsible for saving, loading, and high scores.
    {
        public static void LoadSaveFile()
        {
            try
            {
                GameVars.bPlayerLoadedGame = true;

                //Repetitive code inbound...
                //Getting Game Variables from save file
                GameVars.bHideA = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(0).Take(1).First().ToString());
                GameVars.bHideB = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(1).Take(1).First().ToString());
                GameVars.bHideC = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(2).Take(1).First().ToString());
                GameVars.bHideD = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(3).Take(1).First().ToString());
                GameVars.bHideE = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(4).Take(1).First().ToString());
                GameVars.bHideF = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(5).Take(1).First().ToString());
                GameVars.bHideG = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(6).Take(1).First().ToString());
                GameVars.bHideH = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(7).Take(1).First().ToString());
                GameVars.bHideI = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(8).Take(1).First().ToString());
                GameVars.bHideJ = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(9).Take(1).First().ToString());
                GameVars.bHideK = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(10).Take(1).First().ToString());
                GameVars.bHideL = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(11).Take(1).First().ToString());
                GameVars.bHideM = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(12).Take(1).First().ToString());
                GameVars.bHideN = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(13).Take(1).First().ToString());
                GameVars.bHideO = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(14).Take(1).First().ToString());
                GameVars.bHideP = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(15).Take(1).First().ToString());
                GameVars.bRoom3Accessed = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(16).Take(1).First().ToString());
                GameVars.bBossKilled = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(17).Take(1).First().ToString());
                GameVars.iCurrentRoom = int.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(18).Take(1).First().ToString());
                //Console.WriteLine("{0} {1}", GameVars.bHideA, GameVars.bHideP); //Test Debug

                //Getting Player Variables from save file

                string sPlayerName, sPlayerClass;
                int iPlayerHealth, iPlayerDamage, iCurrentRoom;
                bool bPlayerHasFriend;

                sPlayerName = File.ReadLines(GameVars.SAVEFILENAME).Skip(19).Take(1).First();
                sPlayerClass = File.ReadLines(GameVars.SAVEFILENAME).Skip(20).Take(1).First();
                iPlayerHealth = int.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(21).Take(1).First());
                iPlayerDamage = int.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(22).Take(1).First());
                iCurrentRoom = int.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(23).Take(1).First());
                bPlayerHasFriend = bool.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(24).Take(1).First().ToString());

                //Creating player Object
                Player Player = new Player(sPlayerName, iPlayerHealth, sPlayerClass, iCurrentRoom, bPlayerHasFriend, iPlayerDamage);

                Console.WriteLine("Player Name: {0}\n" +
                    "Player Class: {1}\n" +
                    "Player Health: {2}\n" +
                    "Player Damage: {3}\n" +
                    "Player Room: {4}", sPlayerName, sPlayerClass, iPlayerHealth, iPlayerDamage, iCurrentRoom);

                if (bPlayerHasFriend == true) //bPlayerHasFriend references above bool.Parse after reading string from save file.
                {
                    //Getting Friend Variables from save file.

                    string sFriendName, sFriendClass;
                    int iFriendHealth, iFriendDamage;

                    sFriendName = File.ReadLines(GameVars.SAVEFILENAME).Skip(25).Take(1).First();
                    sFriendClass = File.ReadLines(GameVars.SAVEFILENAME).Skip(26).Take(1).First();
                    iFriendHealth = int.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(27).Take(1).First());
                    iFriendDamage = int.Parse(File.ReadLines(GameVars.SAVEFILENAME).Skip(28).Take(1).First());

                    //Creating Friend Object
                    Friend Friend = new Friend(sFriendName, iFriendHealth, sFriendClass, iFriendDamage);

                    Console.WriteLine(); //Formatting, looks better when outputting text to player.
                    Console.WriteLine("Friend Name: {0}\n" +
                        "Friend Class: {1}\n" +
                        "Friend Health: {2}\n" +
                        "Friend Damage: {3}\n", sFriendName, sFriendClass, iFriendHealth, iFriendDamage);
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(exception.Message);
                return;
            }

            Console.ReadLine();
            return;
        }

        public static void SaveSaveFile()
        {
            //Storing Format - Game Variables -> Player Variables -> Friend (If Exists) Variables.
            string[] aGameLines =
            {
                GameVars.bHideA.ToString(),
                GameVars.bHideB.ToString(),
                GameVars.bHideC.ToString(),
                GameVars.bHideD.ToString(),
                GameVars.bHideE.ToString(),
                GameVars.bHideF.ToString(),
                GameVars.bHideG.ToString(),
                GameVars.bHideH.ToString(),
                GameVars.bHideI.ToString(),
                GameVars.bHideJ.ToString(),
                GameVars.bHideK.ToString(),
                GameVars.bHideL.ToString(),
                GameVars.bHideM.ToString(),
                GameVars.bHideN.ToString(),
                GameVars.bHideO.ToString(),
                GameVars.bHideP.ToString(),
                GameVars.bRoom3Accessed.ToString(),
                GameVars.bBossKilled.ToString(),
                GameVars.iCurrentRoom.ToString()
            }; //Storing Game Variables in an array.

            File.WriteAllLines(GameVars.SAVEFILENAME, aGameLines); //Writing Game Variable Array to file.

            string[] aPlayerLines =
            {
                Player.SPlayerName.ToString(),
                Player.SPlayerClass.ToString(),
                Player.IPlayerHealth.ToString(),
                Player.IPlayerDamage.ToString(),
                Player.ICurrentRoom.ToString(),
                Player.BPlayerHasFriend.ToString()
            };

            File.AppendAllLines(GameVars.SAVEFILENAME, aPlayerLines); //Appending Player Variables to Save File.

            if (Player.BPlayerHasFriend == true)
            {
                string[] aFriendLines =
                {
                    Friend.SFriendName.ToString(),
                    Friend.SFriendClass.ToString(),
                    Friend.IFriendHealth.ToString(),
                    Friend.IFriendDamage.ToString()
                }; //Make array for friend vars

                File.AppendAllLines(GameVars.SAVEFILENAME, aFriendLines); //Appending Friend Variables to save file.
            }

            Console.WriteLine("Done saving your progress.");
            return;
        }

        public static void CreateEmptyHighScores()
        {
            File.Create(GameVars.HIGHSCORESFILENAME).Dispose();
        }

        public static void LoadHighScores() //Finish
        {
            if (File.Exists(GameVars.HIGHSCORESFILENAME) == true)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(GameVars.HIGHSCORESFILENAME))
                    {
                        Console.WriteLine("These are the players' high scores:");
                        string aHighScores = sr.ReadToEnd();
                        Console.WriteLine(aHighScores);
                    }
                }
                catch (IOException exception)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(exception.Message);
                }
            }
            else
            {
                CreateEmptyHighScores();
            }

            Console.ReadLine();
            return;
        }
    }

    public class Program
    {
        public static void Main()
        {
            const int DEFAULTHEALTH = 100; //Set default health const to 100. Used when making player & friend objects.
            const int DEFAULTROOM = 1; //Set beginning room to room 1. Used when making player object.
            const int DEFAULTDAMAGE = 20; //set starting damage to 15. Used when making friend & player objects.

            Console.SetWindowSize(150, 45); //Making console window bigger to fit SPACE ADVENTURE ASCII art.

            GameVars.UpdateRiddleVars(); //Generate random riddle variables

            MainScreen.Menu();

            //if some other method == load for example, create player object from save file, do next action
            //Else, create new player object from input

            Console.Clear();

            if (GameVars.bPlayerLoadedGame == false)
            {
                Introduction.PrintIntroduction(); //Writes Introduction to screen.

                string sPlayerName, sPlayerClass;
                sPlayerName = SetUpPlayerVars.GetPlayerName(); //Set up player name
                sPlayerClass = SetUpPlayerVars.GetPlayerClass(); //Set up player class

                bool bPlayerHasFriend; //initialise bool variable
                bPlayerHasFriend = SetUpFriendVars.DoesPlayerHaveFriend(); //returns true if player plays with friend, else returns false
                Player Player = new Player(sPlayerName, DEFAULTHEALTH, sPlayerClass, DEFAULTROOM, bPlayerHasFriend, DEFAULTDAMAGE); //Create Player Object for this method only

                if (bPlayerHasFriend == true) //if player plays with friend
                {
                    string sFriendName, sFriendClass;
                    sFriendName = SetUpFriendVars.GetFriendName(); //get string returned by method
                    sFriendClass = SetUpFriendVars.GetFriendClass(); //get string returned by method
                    Friend Friend = new Friend(sFriendName, DEFAULTHEALTH, sFriendClass, DEFAULTDAMAGE); //Create Friend Object.
                }
                else //player plays solo
                {
                    Console.WriteLine("You are playing Solo.");
                }

                RoomLayout.DrawWholeShip();
                GameVars.UpdateCurrentRoom();
                PlayerNextAction.NextAction(); //Lets player decide next action.
            }
            else
            {
                RoomLayout.DrawWholeShip();
                GameVars.UpdateCurrentRoom();
                PlayerNextAction.NextAction();
            }
        }
    }
}

//Pointers for self:
//Objects created in one method, can only be referenced inside that method only.