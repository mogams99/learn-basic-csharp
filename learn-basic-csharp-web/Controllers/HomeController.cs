using learn_basic_csharp_web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace learn_basic_csharp_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var model = new Models.HomeVM.Index();
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public IActionResult Detail(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) throw new Exception("id harap diisi");

                var model = new Models.HomeVM.Detail(Convert.ToInt32(id));
                return View(model);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
