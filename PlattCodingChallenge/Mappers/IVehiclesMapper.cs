using PlattCodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlattCodingChallenge.Mappers
{
    public interface IVehiclesMapper
    {
        public VehicleSummaryViewModel ToVehicleSummary(IEnumerable<PlattCodingChallenge.DataAccess.Models.Vehicles> vehicles);
    }
}
