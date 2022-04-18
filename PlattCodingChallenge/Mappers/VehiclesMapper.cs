using PlattCodingChallenge.DataAccess.Models;
using PlattCodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlattCodingChallenge.Mappers
{
    public class VehiclesMapper : IVehiclesMapper
    {
        public VehicleSummaryViewModel ToVehicleSummary(IEnumerable<Vehicles> vehicles)
        {
            var filteredVehicles = vehicles.Where(v => !v.cost_in_credits.Equals("unknown"));
            var groupedVehicles = filteredVehicles.GroupBy(v => v.manufacturer).Select(m => {
                return new VehicleStatsViewModel()
                {
                    ManufacturerName = m.Key,
                    VehicleCount = m.Where(vh => vh.manufacturer.Equals(m.Key)).Count(),
                    AverageCost = m.Average(vh => Int32.Parse(vh.cost_in_credits))
                };
               }).OrderByDescending(v => v.VehicleCount).ThenByDescending(v => v.AverageCost);

            return new VehicleSummaryViewModel()
            {
                VehicleCount = filteredVehicles.Count(),
                ManufacturerCount = groupedVehicles.Count(),
                Details = groupedVehicles.ToList()
            };
        }
    }
}
