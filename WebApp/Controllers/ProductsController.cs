using Microsoft.AspNetCore.Mvc;
using WebApp.Contexts;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        #region constructors & private fields

        private readonly ProductService _productService;
        private readonly IdentityContext _identityContext;

        public ProductsController(ProductService productService, IdentityContext identityContext)
        {
            _productService = productService;
            _identityContext = identityContext;
        }

        #endregion
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();

            var viewModel = new ProductsIndexViewModel
            {
                All = new GridCollectionViewModel
                {
                    LoadMore = false,
                    GridItems = _identityContext.Products.Select(i => new GridCollectionItemViewModel
                    {
                        ArticleNumber = i.ArticleNumber,
                        Name = i.Name,
                        Price = i.Price,
                        ImageUrl = i.ImageUrl
                    }).ToList()
                }
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
