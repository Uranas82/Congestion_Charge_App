using System;

namespace Contracts.Models
{
    public class Vehicle
    {
        public string VehiceType { get; set; }

        public DateTime EntranceTime { get; set; }

        public DateTime ExitTime { get; set; }

        public override string ToString()
        {
            return $"{VehiceType}: {EntranceTime:dd\\/MM\\/yyyy HH:mm} - {ExitTime:dd\\/MM\\/yyyy HH:mm}";
        }
    }
}
