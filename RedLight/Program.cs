using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string banner = @"
     ____          _   _     _       _     _    
    |  _ \ ___  __| | | |   (_) __ _| |__ | |_  
    | |_) / _ \/ _` | | |   | |/ _` | '_ \| __| 
    |  _ <  __/ (_| | | |___| | (_| | | | | |_  
    |_| \_\___|\__,_| |_____|_|\__, |_| |_|\__| 
                            |___/      
                                   By Amir Arz";

            PrintWithColor(banner, ConsoleColor.DarkRed);



            
            ushort _greenLightTime;
            while (true)
            {
                try
                {
                    PrintWithColor("\n\n    Enter the red light time (sec) : ", ConsoleColor.Green);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    _greenLightTime = Convert.ToUInt16(Console.ReadLine());
                    break;
                }
                catch { PrintWithColor("\n    [!] Please enter valid value.",ConsoleColor.Red); }
            }


            PrintWithColor("\n\n    Enter the length of the car (metr) : ", ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Magenta;
            double _carLong = Convert.ToUInt16(Console.ReadLine());


            PrintWithColor("\n\n    Enter the distance required for each car to start moving (metr) : ", ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Magenta;
            double _distanceToMove = Convert.ToUInt16(Console.ReadLine());


            PrintWithColor("\n\n    Enter the acceleration of the cars (m/s^2) : ", ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Magenta;
            double _carsAcceleration = Convert.ToUInt16(Console.ReadLine());

        }

        static uint RedLightCalculaator(ushort greenLightTime, double carLong, double distanceToMove, double carsAcceleration)
        {
            int i = 1;

            while (true)
            {
                double lastCarMoveDistance = carLong * i;
                double lastCarWaitTime = i - 1;
                double lastCarArriveTime = Math.Sqrt(((2 * lastCarMoveDistance) / carsAcceleration));

                double totalTime = lastCarWaitTime + lastCarArriveTime;

                if (totalTime > greenLightTime)
                {
                    return Convert.ToUInt32(i - 1);
                }
                i++;
            }
        }

        static void Print(string text)
        {
            Console.Write(text);
        }

        static void PrintWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
        }
    }
}
