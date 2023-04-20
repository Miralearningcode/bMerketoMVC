using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            ModelState.AddModelError("", "Incorrect email or password");
            return View(viewModel);
        }
    }
}
