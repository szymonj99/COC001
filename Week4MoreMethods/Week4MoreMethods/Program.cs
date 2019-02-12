using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4MoreMethods
{
    class Program
    {
        static void Main()
        {
            ////Squaring a number that user input
            //Console.WriteLine("What number do you wish to square?");
            //int.TryParse(Console.ReadLine(), out int iToSquare);
            //Console.WriteLine(Square(iToSquare));
            //Console.ReadLine();

            ////Finding length of user's string
            //Console.WriteLine("Insert a string to find its length.");
            //string iUserInput = Console.ReadLine();
            //Console.WriteLine(FindStringLength(iUserInput));
            //Console.ReadLine();

            ////Finding area of circle with radius of user's choice
            //Console.WriteLine("Insert radius of circle to find its area");
            //int.TryParse(Console.ReadLine(), out int iRadius);
            //Console.WriteLine(FindCircleArea(iRadius));
            //Console.ReadLine();

            int[] myArray = { 7, 2, 11, 4, 9, 3, 6, 12, 14, 5 }; ; //make new array with 10 elements
            Console.WriteLine(myArray[2]);
            Console.WriteLine(myArray[4]);
            Console.WriteLine(myArray[9]);
            Console.ReadLine();
            int iArrayTotal = 0;
            int iArrayHighest = 0;
            int iArrayLowest = int.MaxValue;
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write("{0} ", myArray[i]);
                iArrayTotal += myArray[i];
                if (myArray[i] >= iArrayHighest)
                {
                    iArrayHighest = myArray[i];
                }

                if (iArrayLowest > myArray[i])
                {
                    iArrayLowest = myArray[i];
                }
            }
            Console.WriteLine();
            double dArrayAverage = iArrayTotal / (myArray.Length);
            Console.WriteLine("Amount of values in array: {0}", myArray.Length);
            Console.WriteLine("Array Highest: {0}", iArrayHighest);
            Console.WriteLine("Array Lowest: {0}", iArrayLowest);
            Console.WriteLine("Array total: {0}", iArrayTotal);
            Console.WriteLine("Array average: {0}", dArrayAverage);
            Console.ReadLine();
        }

        static int Square(int iToSquare) //Squaring method
        {
            return iToSquare *= iToSquare;
        }

        static int FindStringLength(string iUserInput) //Find string length method
        {
            return iUserInput.Length;
        }

        static double FindCircleArea(int iRadius) //Find circle area method
        {
            double iCircleArea;
            const double pi = 3.142;
            iCircleArea = pi * (iRadius * iRadius);
            return iCircleArea;
        }
    }
}
