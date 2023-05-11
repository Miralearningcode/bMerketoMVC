using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        #region constructors & private fields

        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        #endregion
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();

            var viewModel = new ProductsIndexViewModel
            {
                Products = products
            };

            return View(viewModel);
        }
        public IActionResult Search()
        {
            ViewData["Title"] = "Search for products";
            return View();
        }
    }
}
