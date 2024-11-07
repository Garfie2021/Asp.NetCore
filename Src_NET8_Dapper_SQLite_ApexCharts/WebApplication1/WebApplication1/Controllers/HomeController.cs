using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Sqls;

namespace WebApplication1.Controllers
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
            var “úŒo•½‹ÏŠ”‰¿s = Sql“úŒo•½‹ÏŠ”‰¿.SelectAll();
            var “àŠts = Sql“àŠt.SelectAll();

            var viewModel = new IndexViewModel
            {
                “úŒo•½‹ÏŠ”‰¿List = “úŒo•½‹ÏŠ”‰¿s,
                “àŠtList = “àŠts
            };

            return View(viewModel);
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
