using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
