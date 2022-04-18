using Microsoft.AspNetCore.Mvc;
using PlattCodingChallenge.DataAccess.Services;
using PlattCodingChallenge.Models;
using System.Threading.Tasks;

namespace PlattCodingChallenge.Controllers
{
	public class HomeController : Controller
	{
		private readonly IVehicleService vehicleService;

		public HomeController(IVehicleService vehicleService)
        {
			this.vehicleService = vehicleService;
        }
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult GetAllPlanets()
		{
			var model = new AllPlanetsViewModel();

			// TODO: Implement this controller action

			return View(model);
		}

		public ActionResult GetPlanetById(int planetid)
		{
			var model = new SinglePlanetViewModel();

			// TODO: Implement this controller action

			return View(model);
		}

		public ActionResult GetResidentsOfPlanet(string planetname)
		{
			var model = new PlanetResidentsViewModel();

			// TODO: Implement this controller action

			return View(model);
		}

		public async Task<ActionResult> VehicleSummary()
		{
			var model = await vehicleService.GetVehicleSummary();

			return View(model);
		}
    }
}
