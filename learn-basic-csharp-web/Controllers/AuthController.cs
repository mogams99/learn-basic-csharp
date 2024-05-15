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

        [HttpPost]
        public IActionResult Login(AuthVM.Login model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var auth = new AuthVM.Login
                    {
                        Username = model.Username,
                        Password = model.Password,
                    };

                    var role = auth.authUserByRole();

                    // check username and role validasi on database
                    TempData["Error"] = "Invalid username or password";
                    if (role == null) return View();

                    // setup session by username and role name
                    HttpContext.Session.SetString(".USERNAME", model.Username);
                    HttpContext.Session.SetString(".ROLE_NAME", role);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Invalid input form.";
                    return View();
                }
            }
            catch
            {
                TempData["Error"] = "An error occurred while processing your request.";
                return View("Error");
            }

        }

        [HttpGet]
        public IActionResult Register()
        {
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
            else
            {
                return RedirectToAction("Register");
            }

        }
    }
}
