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
    }
}
