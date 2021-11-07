using Contracts.Models;
using System;

namespace CongestionApp.Processors
{
    public abstract class BaseVehicleProcessor
    {
        public abstract void CalculateVehicleCharge(Vehicle item);

        protected static CalculatedTime CalculateVehicleTime(Vehicle item)
        {
            TimeSpan amHours = TimeSpan.Zero;

            TimeSpan pmHours = TimeSpan.Zero;

            for (DateTime date = item.EntranceTime.Date; date <= item.ExitTime.Date; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

                TimeSpan startChargeTime = ChargeTime.Am7;

                TimeSpan endChargeTime = ChargeTime.Pm7;

                if (item.EntranceTime.Date == date && item.EntranceTime.TimeOfDay > ChargeTime.Am7)
                {
                    startChargeTime = item.EntranceTime.TimeOfDay;
                }

                if (item.ExitTime.Date == date && item.ExitTime.TimeOfDay < ChargeTime.Pm7)
                {
                    endChargeTime = item.ExitTime.TimeOfDay;
                }

                if (endChargeTime > startChargeTime)
                {
                    if (startChargeTime < ChargeTime.Pm12 && endChargeTime < ChargeTime.Pm12)
                    {
                        amHours += endChargeTime - startChargeTime;
                    }
                    else if (startChargeTime < ChargeTime.Pm12 && endChargeTime > ChargeTime.Pm12)
                    {
                        amHours += ChargeTime.Pm12 - startChargeTime;
                        pmHours += endChargeTime - ChargeTime.Pm12;
                    }
                    else if (startChargeTime > ChargeTime.Pm12 && endChargeTime > ChargeTime.Pm12)
                    {
                        pmHours += endChargeTime - startChargeTime;
                    }
                }
            }
            return new CalculatedTime
            {
                AmHours = amHours,
                PmHours = pmHours
            };

        }
    }

}

