using Contracts.Models;
using System;
using System.Collections.Generic;

namespace CongestionApp
{
    public static class Program
    {

        public static void Main()
        {

            IList<Vehicle> items = new List<Vehicle>{
                new Vehicle
                {
                    VehiceType = "Car",
                    EntranceTime = new DateTime(2008, 4, 24, 11, 32, 0),
                    ExitTime = new DateTime(2008, 4, 24, 14, 42, 0)
                },

                new Vehicle
                {
                    VehiceType = "Motorbike",
                    EntranceTime = new DateTime(2008, 4, 24, 17, 0, 0),
                    ExitTime = new DateTime(2008, 4, 24, 22, 11, 0)
                },

                new Vehicle
                {
                    VehiceType = "Van",
                    EntranceTime = new DateTime(2008, 4, 25, 10, 23, 0),
                    ExitTime = new DateTime(2008, 4, 28, 9, 2, 0)
                },

            };

            var appCongestion = new CongestionApp(items);

            foreach (var t in items)
            {
                Console.WriteLine();
                Console.WriteLine(t.ToString());
            }

            Console.WriteLine();

            appCongestion.UpdateQuality();



        }
    }
}
