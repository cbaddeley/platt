using PlattCodingChallenge.DataAccess.Models;
using PlattCodingChallenge.Mappers;
using PlattCodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlattCodingChallenge.DataAccess.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleDataService vehicleDataService;
        private readonly IVehiclesMapper mapper;

        public VehicleService(IVehicleDataService vehicleDataService, IVehiclesMapper mapper)
        {
            this.vehicleDataService = vehicleDataService;
            this.mapper = mapper;
        }
        public async Task<VehicleSummaryViewModel> GetVehicleSummary()
        {
            var vehicles = await vehicleDataService.GetAllVehicles();
            var mappedVehicleSummary = mapper.ToVehicleSummary(vehicles);
            return mappedVehicleSummary;
        }
    }
}
