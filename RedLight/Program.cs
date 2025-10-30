using System;

namespace RedLight
{
    internal class Program
    {
        /// <summary>
        /// This is a console program that calculates the maximum number of cars that can pass a red light with 
        /// constant acceleration and identical driving conditions for a specified time period and user-defined
        /// conditions, and analyzes the maximum number according to the problem data.
        /// </summary>


        static void Main(string[] args)
        {
            Console.Title = "RedLight";

            // Display ASCII art banner
            const string banner = @"
     ____          _   _     _       _     _    
    |  _ \ ___  __| | | |   (_) __ _| |__ | |_  
    | |_) / _ \/ _` | | |   | |/ _` | '_ \| __| 
    |  _ <  __/ (_| | | |___| | (_| | | | | |_  
    |_| \_\___|\__,_| |_____|_|\__, |_| |_|\__| 
                            |___/      
                                 By Amir Arzani";

            PrintWithColor(banner, ConsoleColor.DarkRed);


            // Get red light duration from user
            short _greenLightTime;
            while (true)
            {
                try
                {
                    PrintWithColor("\n\n    [+] Enter the red light time (sec) : ", ConsoleColor.Green);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    _greenLightTime = Convert.ToInt16(Console.ReadLine());
                    if (_greenLightTime > 0)
                    {
                        ConsoleClear(banner);
                        break;
                    }
                    else
                    {
                        PrintWithColor("\n    [!] Please enter a positive value", ConsoleColor.Red);
                    }
                }
                catch { PrintWithColor("\n    [!] Please enter valid value", ConsoleColor.Red); }
            }


            // Get car length from user
            double _carLong;
            while (true)
            {
                try
                {
                    PrintWithColor("\n\n    [+] Enter the length of the car (metr) : ", ConsoleColor.Green);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    _carLong = Convert.ToDouble(Console.ReadLine());
                    if (_carLong > 0)
                    {
                        ConsoleClear(banner);
                        break;
                    }
                    else
                    {
                        PrintWithColor("\n    [!] Please enter a positive value", ConsoleColor.Red);
                    }
                }
                catch { PrintWithColor("\n    [!] Please enter valid value", ConsoleColor.Red); }
            }


            // Get minimum distance between cars from user
            double _distanceToMove;
            while (true)
            {
                try
                {
                    PrintWithColor("\n\n    [+] Enter the distance required for each car to start moving (metr) : ", ConsoleColor.Green);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    _distanceToMove = Convert.ToDouble(Console.ReadLine());
                    if (_distanceToMove > 0)
                    {
                        ConsoleClear(banner);
                        break;
                    }
                    else
                    {
                        PrintWithColor("\n    [!] Please enter a positive value", ConsoleColor.Red);
                    }
                }
                catch { PrintWithColor("\n    [!] Please enter valid value", ConsoleColor.Red); }
            }


            // Get car acceleration from user
            double _carsAcceleration;
            while (true)
            {
                try
                {
                    PrintWithColor("\n\n    [+] Enter the acceleration of the cars (m/s^2) : ", ConsoleColor.Green);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    _carsAcceleration = Convert.ToDouble(Console.ReadLine());
                    if (_carsAcceleration > 0)
                    {
                        ConsoleClear(banner);
                        break;
                    }
                    else
                    {
                        PrintWithColor("\n    [!] Please enter a positive value", ConsoleColor.Red);
                    }
                }
                catch { PrintWithColor("\n    [!] Please enter valid value", ConsoleColor.Red); }
            }

            // Display all input parameters
            PrintWithColor($"\n\n\n    [#] Green Light Time            :   {_greenLightTime} Sec", ConsoleColor.Cyan);
            PrintWithColor($"\n\n    [#] Car Long                    :   {_carLong} Metr", ConsoleColor.Cyan);
            PrintWithColor($"\n\n    [#] Distance required to move   :   {_distanceToMove} Metr", ConsoleColor.Cyan);
            PrintWithColor($"\n\n    [#] Car acceleration            :   {_carsAcceleration} m/s^2", ConsoleColor.Cyan);

            // Calculate and display the number of cars that can pass
            uint _carCount = RedLightCalculator(Convert.ToUInt16(_greenLightTime), _carLong, _distanceToMove, _carsAcceleration);
            PrintWithColor("\n\n\n    [>] Count of all the cars can move from red light : ", ConsoleColor.Green);
            PrintWithColor(_carCount.ToString(), ConsoleColor.Magenta);

            PrintWithColor("\n\n\n    [+] Press any key to exit ...", ConsoleColor.Green);
            Console.ReadKey();

        }

        // Calculate how many cars can pass through the traffic light
        // Uses physics formulas for uniformly accelerated motion
        static uint RedLightCalculator(ushort greenLightTime, double carLong, double distanceToMove, double carsAcceleration)
        {
            uint i = 1;
            // Calculate time gap between each car starting to move
            double t_gap = Math.Sqrt(2 * distanceToMove / carsAcceleration);

            while (true)
            {
                // Calculate start time for car i
                double t_start = (i - 1) * t_gap;
                // Calculate time needed to move the distance (car length * number of cars)
                double t_move = Math.Sqrt(2 * (carLong * i) / carsAcceleration);
                // Total time for car i to completely pass
                double totalTime = t_start + t_move;

                if (totalTime > greenLightTime)
                    return i - 1;

                i++;
            }
        }

        // Helper method to print text
        static void Print(string text)
        {
            Console.Write(text);
        }

        // Helper method to print colored text
        static void PrintWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        // Clear console and redisplay banner
        static void ConsoleClear(string banner)
        {
            Console.Clear();
            PrintWithColor(banner, ConsoleColor.DarkRed);
        }
    }
}