using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserRepository _userRepository;

        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var usrs = _userRepository.GetAllUsers();
            return View("~/Views/Home/Index.cshtml", usrs);
        }

        public IActionResult Details(int id)
        {
            Usr? usr = _userRepository.GetUserById(id);
            if (usr == null)
            {
                return NotFound();
            }
            return View(usr);
        }

    }
}
