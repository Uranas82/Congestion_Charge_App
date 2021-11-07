using Contracts.Models;
using System;
using System.Globalization;

namespace CongestionApp.Processors
{
    public class VanProcessor : BaseVehicleProcessor
    {
        public override void CalculateVehicleCharge(Vehicle item)
        {
            var calculatedCharge = CalculateVehicleTime(item);

            var charge = new ChargeType
            {
                AmRate = 2.00M,
                PmRate = 2.50M
            };

            var chargeForAm = Math.Floor((decimal)calculatedCharge.AmHours.TotalHours * charge.AmRate * 10) / 10;
            
            var chargeForPm = Math.Floor((decimal)calculatedCharge.PmHours.TotalHours * charge.PmRate * 10) / 10;
            
            var totalCharge = chargeForAm + chargeForPm;
    
            Console.WriteLine($"{item.VehiceType}");
            Console.WriteLine($"Charge for {calculatedCharge.AmHours.Hours}h {calculatedCharge.AmHours.Minutes}m (AM rate): {chargeForAm.ToString("C", new CultureInfo("en-GB"))}");
            Console.WriteLine($"Charge for {calculatedCharge.PmHours.Hours}h {calculatedCharge.PmHours.Minutes}m (PM rate): {chargeForPm.ToString("C", new CultureInfo("en-GB"))}");
            Console.WriteLine($"Total Charge: {totalCharge.ToString("C", new CultureInfo("en-GB"))}");
            Console.WriteLine();
        }
    }
}

