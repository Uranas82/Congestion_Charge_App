using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CongestionApp
{
    public class CongestionApp
    {
        private readonly IList<Vehicle> _items;

        public CongestionApp(IList<Vehicle> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                var itemProcessor = item.MapToItemProcessor();

                itemProcessor.CalculateVehicleCharge(item);
            }
        } 
    }
}

