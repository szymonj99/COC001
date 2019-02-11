using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Methods
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Type in a string to find its length.");
            string Str = Console.ReadLine();
            Console.WriteLine("Length of string {0} is: {1}", Str, StringLength(Str));
            Console.ReadLine();
            Console.WriteLine("Please type in your name");
            string Name = Console.ReadLine();
            Console.WriteLine("How old are you? Insert an integer only.");
            int.TryParse(Console.ReadLine(), out int Age);
            NameAndAge(Name, Age);
            Console.ReadLine();
            Console.WriteLine("To find the area, insert a length in cm.");
            int.TryParse(Console.ReadLine(), out int length);
            Console.WriteLine("Insert breadt in cm.");
            int.TryParse(Console.ReadLine(), out int breadth);
            Console.WriteLine("The area of {0}cm by {1}cm is {2}cm^2", length, breadth, Area(length, breadth));
            Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Insert an integer to square.");
                int.TryParse(Console.ReadLine(), out int numToSquare);
                Console.WriteLine("The square of {0} is {1}.", numToSquare, Square(numToSquare));
            }
        }

        static int StringLength(string Str)
        {
            return Str.Length; //Find length of string.
        }

        static void NameAndAge(string name, int age)
        {
            Console.WriteLine("You are called {0} and are {1} years old.", name, age);
        }

        static int Area(int length, int breadth)
        {
            return length * breadth;
        }

        static int Square(int num)
        {
            return num * num;
        }
    }
}
