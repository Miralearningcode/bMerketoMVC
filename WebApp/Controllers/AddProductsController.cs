using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AddProductsController : Controller
    {
        #region constructors & private fields

        private readonly TagService _tagService;
        private readonly ProductService _productService;
        public AddProductsController(TagService tagService, ProductService productService)
        {
            _tagService = tagService;
            _productService = productService;
        }

        #endregion


        public async Task<IActionResult> Index()
        {

            ViewBag.Tags = await _tagService.GetTagsAsync();
            return View();
        }

      

        [HttpPost]
        public async Task<IActionResult> Index(ProductRegistrationViewModel viewModel, string[] tags)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.CreateAsync(viewModel))
                {
                    await _productService.AddProductTagsAsync(viewModel, tags);
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Something went wrong.");
            }

            ViewBag.Tags = await _tagService.GetTagsAsync(tags);
            return View(viewModel);
        }
    }
}
