using learn_basic_csharp_web.Models;
using learn_basic_csharp_web.Models.EF;
using Microsoft.AspNetCore.Mvc;

namespace learn_basic_csharp_web.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ModelContext _context;

        public AuthController(ILogger<AuthController> logger, ModelContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            //var model = new RoleVM
            //{
            //    Roles = _context.Roles.ToList(),
            //};

            var model = new AuthVM.Register();

            return View(model);
        }

        [HttpPost]
        public IActionResult Register(AuthVM.Register model)
        {
            if (ModelState.IsValid)
            {
                AuthVM.Register.saveUserByRole(model);

                return RedirectToAction("Login");
            }

            return RedirectToAction("Register");
        }
    }
}
