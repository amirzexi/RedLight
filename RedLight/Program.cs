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



            double _carLong;
            while (true)
            {
                try
                {
                    PrintWithColor("\n\n    [+] Enter the length of the car (metr) : ", ConsoleColor.Green);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    _carLong = Convert.ToDouble(Console.ReadLine());
                    if(_carLong >0)
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


            PrintWithColor($"\n\n\n    [#] Green Light Time            :   {_greenLightTime} Sec", ConsoleColor.Cyan);
            PrintWithColor($"\n\n    [#] Car Long                    :   {_carLong} Metr", ConsoleColor.Cyan);
            PrintWithColor($"\n\n    [#] Distance required to move   :   {_distanceToMove} Metr", ConsoleColor.Cyan);
            PrintWithColor($"\n\n    [#] Car acceleration            :   {_carsAcceleration} m/s^2", ConsoleColor.Cyan);


            uint _carCount = RedLightCalculaator(Convert.ToUInt16(_greenLightTime), _carLong, _distanceToMove, _carsAcceleration);
            PrintWithColor("\n\n\n    [>] Count of all the cars can move from red light : ", ConsoleColor.Green);
            PrintWithColor(_carCount.ToString(), ConsoleColor.Magenta);

            PrintWithColor("\n\n\n    [+] Press any key to exit ...",ConsoleColor.Green);
            Console.ReadKey();

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

        static void ConsoleClear(string banner)
        {
            Console.Clear();
            PrintWithColor(banner, ConsoleColor.DarkRed);
        }
    }
}
