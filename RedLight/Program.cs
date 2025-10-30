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
";
            Console.WriteLine();
        }

        static uint RedLightCalculaator(ushort greenLightTime , double carLong , double distanceToMove , double carsAcceleration)
        {
            int i = 1;

            while (true)
            {
                double lastCarMoveDistance = carLong * i;
                double lastCarWaitTime = i - 1;
                double lastCarArriveTime = Math.Sqrt(((2*lastCarMoveDistance) / carsAcceleration));

                double totalTime = lastCarWaitTime + lastCarArriveTime;

                if(totalTime > greenLightTime)
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

        static void PrintWithColor(string text,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
        }
    }
}
