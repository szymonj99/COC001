using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Arrays
{
    class Program
    {
        static void Main()
        {
            const int ARRAYLENGTH = 4; //Declare constant of array length.
            string[] myAnimals; //Declare string array
            myAnimals = new string[ARRAYLENGTH]; //Array of length 4
            myAnimals[0] = "Lion"; //1st value of array
            myAnimals[1] = "Monkey"; //2nd value of array
            myAnimals[2] = "Hen"; //3rd value of array
            myAnimals[3] = "Ant"; //4th value of array

            string[] mySpecies; //Declare string mySpecies
            mySpecies = new string[ARRAYLENGTH];
            mySpecies[0] = "Mammal"; //1st value of array
            mySpecies[1] = "Fish"; //2nd value of array
            mySpecies[2] = "Insect"; //3rd value of array
            mySpecies[3] = "Bird"; //4th value of array

            Console.WriteLine("A {0} is a {1}", myAnimals[0], mySpecies[0]); //Lion is a mammal.
            Console.WriteLine("A {0} is a {1}", myAnimals[2], mySpecies[3]); //Hen is a bird.
            Console.WriteLine("A {0}s and {1}s are {2}s", myAnimals[0], myAnimals[1], mySpecies[0]);
            Console.ReadLine();

            const int INTARRAYLENGTH = 10;
            int[] intArray; //declare intArray
            intArray = new int[INTARRAYLENGTH]; //New array of length INTARRAYLENGTH

            int intArrayTotal; //Declare variable to count total in array.
            intArrayTotal = 0;

            for (int i = 0; i < INTARRAYLENGTH; i++)
            {
                intArray[i] = (i + 1); //intArray = 1 + the index.
                Console.WriteLine("Position {0} is {1}", i, intArray[i]);
                intArrayTotal += intArray[i]; //Calculate total of all numbers in array.
            }

            Console.WriteLine(intArrayTotal);
            Console.ReadLine();

            for (int i = 0; i < INTARRAYLENGTH; i++)
            {
                intArray[i] = ((i + 1) * 2); //Change values of array to 2 * (index + 1)
                Console.WriteLine(intArray[i]);
            }

            Console.ReadLine();
        }
    }
}
