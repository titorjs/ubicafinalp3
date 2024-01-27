using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UbicuaFinal.Data;
using UbicuaFinal.Models;

namespace UbicuaFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Service _service;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _service = new Service(new UbicuaDbContext());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            List<Dato> datos = _service.datos();
            return View(datos);
        }

        public IActionResult Visual()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public List<object> GetGiroX()
        {
            List<object> data = new List<object>();

            var datos = _service.datos().OrderByDescending(x => x.date);

            List<string> labels = datos.Select(x => x.date.ToString()).ToList();

            data.Add(labels);

            List<float> gx = datos.Select(x => x.gx).ToList();

            data.Add(gx);

            List<float> gy = datos.Select(x => x.gy).ToList();

            data.Add(gy);

            List<float> gz = datos.Select(x => x.gz).ToList();

            data.Add(gz);

            List<float> tem = datos.Select(x => x.temp).ToList();

            data.Add(tem);

            List<float> hum = datos.Select(x => x.hum).ToList();

            data.Add(hum);

            return data;
        }
    }
}
