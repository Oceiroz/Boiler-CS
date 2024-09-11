using System;

namespace Boiler_Program
{
    class Program
    {
        public static int thermoLow = 10;
        public static int thermoHigh = 35;
        public static bool boilerStatus = false;
        static void Main(string[] args)
        {
            
            int roomTemp = 20;
            bool programShutdown = false;
            while (programShutdown == false)
            {
                BoilerState(roomTemp);
            }
        }

        static int GetInput(string inputMessage)
        {
            var rawInput = 0;
            while (true)
            {
                Console.WriteLine($"{inputMessage}\n");
                try
                {
                    rawInput = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException) 
                {
                    Console.WriteLine("invalid input, try again.\n");
                }
                
            }
            return rawInput;
        }
        static int SetTemp()
        {
            int thermoSetting = 0;
            while (true)
            {
                thermoSetting = GetInput("What temprature would you like to set");
                if (thermoSetting < thermoLow)
                {
                    Console.WriteLine("Temprature is too low");
                }
                else if (thermoSetting > thermoHigh)
                {
                    Console.WriteLine("Temprature is too high");
                }
                else if (thermoSetting >= thermoLow && thermoSetting <= thermoHigh)
                {
                    break;
                }
            }
            return thermoSetting;
        }
        static void BoilerState(int roomTemp)
        {

            int thermoSetting = SetTemp();
            if (roomTemp >= thermoSetting && boilerStatus == true)
            {
                boilerStatus = false;
                Console.WriteLine("Boiler is turned off");
            }
            else if (roomTemp < thermoSetting && boilerStatus == false)
            {
                boilerStatus = true;
                Console.WriteLine("Boiler is turned on");
            }
        }
    }
}
