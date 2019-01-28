using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Part 1, print out X asterisks.

            //bool bValidateInt;

            //Console.WriteLine("Enter an integer.");
            //bValidateInt = int.TryParse(Console.ReadLine(), out int iUserInput);
            //while (!bValidateInt)
            //{
            //    Console.WriteLine("Enter an integer.");
            //    bValidateInt = int.TryParse(Console.ReadLine(), out iUserInput);
            //}

            //for (int i=0; i<iUserInput; i++)
            //{
            //    Console.Write("*");
            //}

            //Console.ReadLine();


            ////Part 2, asking user for integer > 100.

            //string sInstruction;           
            //sInstruction = "Please enter a whole number that is greater than 100.";

            //Console.WriteLine(sInstruction);

            //bool bValidateInt;
            //bValidateInt = int.TryParse(Console.ReadLine(), out int iUserInput);

            //while (!bValidateInt || iUserInput < 100)
            //{
            //    Console.WriteLine(sInstruction);
            //    bValidateInt = int.TryParse(Console.ReadLine(), out iUserInput);
            //}

            //Console.WriteLine("You chose the integer: {0}", iUserInput);
            //Console.ReadLine();

            ////Part 3, user answers question.

            //string sQuestionOne;
            //sQuestionOne = ("What is the command keyword to exit a loop in C#? \n a. int \n b. continue \n c. break \n d. exit \n Enter your choice: ");

            //Console.WriteLine(sQuestionOne);
            //string sUserInput;
            //sUserInput = Console.ReadLine();

            //while (sUserInput != "c")
            //{

            //    if (sUserInput == "d" || sUserInput == "n")
            //    {
            //        Console.WriteLine("You stopped answering the question.");
            //        break;
            //    }

            //    else
            //    {
            //        Console.WriteLine("Try again.");
            //    }

            //    sUserInput = Console.ReadLine();

            //}

            //if (sUserInput == "c")
            //{
            //    Console.WriteLine("You are correct.");
            //}

            //Console.ReadLine();

            ////Part 4, printing out even numbers.

            //bool bAllNumPrinted;
            //bAllNumPrinted = false;
            //int iCurrentNum = 0;

            //while (bAllNumPrinted != true)
            //{
            //    if ((iCurrentNum % 2) == 0)
            //    {
            //        Console.Write("{0}, ", iCurrentNum);
            //    }

            //    if (iCurrentNum >= 100)
            //    {
            //        bAllNumPrinted = true;
            //    }

            //    iCurrentNum++;
            //}

            //Console.ReadLine();

            ////Part 5, print out times table of integer chosen by user.

            //Console.WriteLine("Choose an integer.");

            //bool validateInt;
            //validateInt = int.TryParse(Console.ReadLine(), out int iUserInput);

            //while (!validateInt)
            //{
            //    Console.WriteLine("Choose an integer");
            //    validateInt = int.TryParse(Console.ReadLine(), out iUserInput);
            //}

            //int iTimesTableLimit, iCurrentTimesTable;
            //iTimesTableLimit = 10;
            //iCurrentTimesTable = 1;

            //while (iCurrentTimesTable <= iTimesTableLimit)
            //{
            //    Console.WriteLine("{0} x {1} = {2}", iUserInput, iCurrentTimesTable, (iUserInput * iCurrentTimesTable));
            //    iCurrentTimesTable++;
            //}

            //Console.ReadLine();

            //Advanced Tasks

            //Task 1, Make an X . X grid of asterisks

            //Console.WriteLine("Enter an integer");

            //bool bValidateInt;
            //bValidateInt = int.TryParse(Console.ReadLine(), out int iUserInput);
            //while (!bValidateInt)
            //{
            //    Console.WriteLine("Enter an integer.");
            //    bValidateInt = int.TryParse(Console.ReadLine(), out iUserInput);
            //}

            //for (int i = 0; i < iUserInput; i++)
            //{
            //    for (int j = 0; j < iUserInput; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            //Console.ReadLine();

            ////Part 2, create a grid of multiples from 1 to 10.

            //int iStartingHorizontalNum, iStartingVerticalNum;
            //iStartingHorizontalNum = 10;
            //iStartingVerticalNum = 10;

            //while (iStartingVerticalNum > 0)
            //{
            //    while (iStartingHorizontalNum > 0)
            //    {
            //        Console.Write("{0} ", iStartingVerticalNum * iStartingHorizontalNum);
            //        iStartingHorizontalNum--;
            //    }
            //    iStartingHorizontalNum = 10;
            //    iStartingVerticalNum--;
            //    Console.WriteLine();
            //}

            //Console.ReadLine();

            //Part 3 a, printing out triangle of numbers.
            //int iCurrNum, iMaxNum, iCurrLine;
            //iCurrNum = 1;
            //iMaxNum = 10;
            //iCurrLine = 1;

            //for (iCurrLine = 1; iCurrLine < iMaxNum; iCurrLine++)
            //{
            //    for (iCurrNum = 1, iMaxNum = 10; iCurrNum <= iCurrLine; iCurrNum++)
            //    {
            //        Console.Write("{0}", iCurrNum);
            //    }
            //    Console.WriteLine();
            //}
            //Console.ReadLine();

            //Part 3b, print out skewed back-to-back triangle of numbers. Think triangle above, mirrored.
            /*
             * 1
             * 121
             * 12321
             * 1234321
             */

            //int iCurrNum, iMaxNum, iCurrLine;
            //iCurrNum = 1;
            //iMaxNum = 10;
            //iCurrLine = 1;

            //for (iCurrLine = 1; iCurrLine < iMaxNum; iCurrLine++)
            //{
            //    for (iCurrNum = 1, iMaxNum = 10; iCurrNum <= iCurrLine; iCurrNum++)
            //    {
            //        Console.Write("{0}", iCurrNum);
            //    }

            //    for (iCurrNum = (iCurrLine-1); iCurrNum > 0; iCurrNum--)
            //    {
            //        Console.Write("{0}", iCurrNum);
            //    }

            //    Console.WriteLine();
            //}
            //Console.ReadLine();

            //part 3c, print out the same triangle as above, but centred.
            /*
             *      1
             *     121
             *    12321
             *   1234321
             */

            int iCurrNum, iMaxNum, iCurrLine, iSpacesToWrite;
            iCurrNum = 1;
            iMaxNum = 10;
            iCurrLine = 1;
            iSpacesToWrite = 0;

            for (iCurrLine = 1; iCurrLine < iMaxNum; iCurrLine++)
            {
                for (iMaxNum = 10, iCurrNum = 1, iSpacesToWrite = (iMaxNum - iCurrLine - iCurrNum); iSpacesToWrite > 0; iSpacesToWrite--)
                {
                    Console.Write(" ");
                }

                for (iCurrNum = 1, iMaxNum = 10; iCurrNum <= iCurrLine; iCurrNum++)
                {
                    Console.Write("{0}", iCurrNum);
                }

                for (iCurrNum = (iCurrLine - 1); iCurrNum > 0; iCurrNum--)
                {
                    Console.Write("{0}", iCurrNum);
                }

                Console.WriteLine();
            }

            Console.ReadLine();

        }
    }
}
