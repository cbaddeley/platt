using PlattCodingChallenge.DataAccess.Models;
using PlattCodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlattCodingChallenge.DataAccess.Services
{
    public interface IVehicleService
    {
        Task<VehicleSummaryViewModel> GetVehicleSummary();
    }
}
