using CongestionApp.Processors;
using Contracts.Models;
using System;

namespace CongestionApp
{
    public static class ItemExtensions
    {
        public static BaseVehicleProcessor MapToItemProcessor(this Vehicle item)
        {
            if (item.EntranceTime > item.ExitTime)
            {
                throw new Exception("Invalid time expression! The end time cannot be earlier than start time");
            }
            return item.VehiceType switch
            {
                "Car" => new CarProcessor(),
                "Motorbike" => new MotorbikeProcessor(),
                "Van" => new VanProcessor()
            };
        }
    }
}

