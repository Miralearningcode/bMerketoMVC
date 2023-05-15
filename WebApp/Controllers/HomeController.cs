using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly IdentityContext _identityContext;

    public HomeController(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public IActionResult Index()
    {

        var viewModel = new HomeIndexViewModel
        {
            BestCollection = new GridCollectionViewModel
            {
                Title = "Best Collection",
                LoadMore = true,
                Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptops", "Mobile", "Beauty" },
                GridItems = _identityContext.Products.Take(8).Select(i => new GridCollectionItemViewModel
                {
                    ArticleNumber = i.ArticleNumber,
                    Name = i.Name,
                    Price = i.Price,
                    ImageUrl = i.ImageUrl
                }).ToList()

            },

            UpToSaleCollection = new CollectionContentViewModel
            {
                GridItems = _identityContext.Products.Take(1).Select(i => new GridCollectionItemViewModel
                {
                    ArticleNumber = i.ArticleNumber,
                    Name = i.Name,
                    Price = i.Price,
                    ImageUrl = i.ImageUrl
                }).ToList()
            },

            UpToSaleCard = new CollectionContentViewModel
            {
                Item = new List<CollectionContentItemViewModel>
                {
                    new CollectionContentItemViewModel { TitleRed = "UP TO SALE", Title = "50% OFF", Ingress = "Get the Best Price", Text = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki" , Link = "Discover More"}
                }
            },

            TopSellingCollection = new RowCollectionViewModel
            {
                Title = "Top selling products in this week",
                GridItems = _identityContext.Products.Take(7).Select(i => new GridCollectionItemViewModel
                {
                    ArticleNumber = i.ArticleNumber,
                    Name = i.Name,
                    Price = i.Price,
                    ImageUrl = i.ImageUrl
                }).ToList()

            },
            
            
            
        };
    

        return View(viewModel);
    }
}
