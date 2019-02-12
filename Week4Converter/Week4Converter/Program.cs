using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4Converter
{
    class Program
    {
        static void Main()
        {

            MainMenu();
            
        }

        static void MainMenu()
        {
            for (int i = 0; i < 5; i++)
            {
                Converter();
                Console.ReadLine();
            }
        }

        static void Converter()
        {
            Console.WriteLine("What conversion do you wish to do?");
            Console.WriteLine("1. Celcius to Farenheit.\n" +
                "2. Farenheit to Celcius.\n" +
                "3. Kilometres to Miles.\n" +
                "4. Miles to Kilometres.\n" +
                "5. Metres to Yards.\n" +
                "6. Yards to Metres.");
            int.TryParse(Console.ReadLine(), out int iUserInput);
            switch (iUserInput)
            {
                case 1:
                    {
                        Console.WriteLine("Insert temp. in Celcius.");
                        double.TryParse(Console.ReadLine(), out double celcius);
                        CelciusToFarenheit(celcius);
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("Insert temp. in Farenheit");
                        double.TryParse(Console.ReadLine(), out double farenheit);
                        FarenheitToCelcius(farenheit);
                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("Insert kilometres.");
                        double.TryParse(Console.ReadLine(), out double kilometres);
                        KilometresToMiles(kilometres);
                        break;
                    }

                case 4:
                    {
                        Console.WriteLine("Insert miles.");
                        double.TryParse(Console.ReadLine(), out double miles);
                        MilesToKilometres(miles);
                        break;
                    }

                case 5:
                    {
                        Console.WriteLine("Inster metres");
                        double.TryParse(Console.ReadLine(), out double metres);
                        MetresToYards(metres);
                        break;
                    }

                case 6:
                    {
                        Console.WriteLine("Insert yards.");
                        double.TryParse(Console.ReadLine(), out double yards);
                        YardsToMetres(yards);
                        break;
                    }
            }
        }

        static void CelciusToFarenheit(double celcius)
        {
            double farenheit = ((celcius * (9 / 5)) + 32);
            Console.WriteLine(farenheit);
        }

        static void FarenheitToCelcius(double farenheit)
        {
            double celcius;
            celcius = ((farenheit - 32) * (5 / 9));
            Console.WriteLine(celcius);
        }

        static void KilometresToMiles(double kilometres)
        {
            double miles = kilometres / 1.609;
            Console.WriteLine(miles);
        }

        static void MilesToKilometres(double miles)
        {
            double kilometres = miles * 1.609;
            Console.WriteLine(kilometres);
        }

        static void MetresToYards(double metres)
        {
            double yards = metres * 1.094;
            Console.WriteLine(yards);
        }

        static void YardsToMetres(double yards)
        {
            double metres = yards / 1.094;
            Console.WriteLine(metres);
        }
    }
}
