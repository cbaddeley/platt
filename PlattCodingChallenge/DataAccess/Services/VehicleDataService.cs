using PlattCodingChallenge.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlattCodingChallenge.DataAccess.Services
{
    public class VehicleDataService : IVehicleDataService
    {
        private readonly string _swVehiclesApiUrl;
        private readonly IHttpClientFactory _httpFactory;

        public VehicleDataService(IHttpClientFactory factory)
        {
            this._httpFactory = factory;
            this._swVehiclesApiUrl = "https://swapi.dev/api/vehicles/";
        }
        public async Task<IEnumerable<Vehicles>> GetAllVehicles()
        {
            var vehicles = new List<Vehicles>();
            var httpClient = this._httpFactory.CreateClient("VehicleResource");
            var nextVehicleUrl = this._swVehiclesApiUrl;

            while (!string.IsNullOrEmpty(nextVehicleUrl))
            {
                var res = await httpClient.GetAsync(nextVehicleUrl);

                if (res.IsSuccessStatusCode)
                {
                    var contentStream = await res.Content.ReadAsStringAsync();

                    var response = JsonSerializer.Deserialize<ResponseBody<Vehicles>>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    vehicles.AddRange(response.results);

                    nextVehicleUrl = response.next;

                    
                }
            }
            return vehicles;
        }
    }
}
