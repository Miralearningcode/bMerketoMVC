using WebApp.Models.Dto;
using WebApp.Models.Entities;
using WebApp.Repositiories;

namespace WebApp.Services
{
    public class ProductService
    {
        #region Constructors & Private Fields

        private readonly ProductRepository _productRepo;
        private readonly ProductTagRepository _productTagRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(ProductRepository productRepo, ProductTagRepository productTagRepo, IWebHostEnvironment webHostEnvironment)
        {
            _productRepo = productRepo;
            _productTagRepo = productTagRepo;
            _webHostEnvironment = webHostEnvironment;
        }

        #endregion

        public async Task<Product> CreateAsync(ProductEntity entity)
        {
            var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
            if (_entity == null)
            {
                _entity = await _productRepo.AddAsync(entity);
                if (_entity != null)
                    return _entity;
            }

            return null!;
        }

        public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
        {
            foreach (var tag in tags)
            {
                await _productTagRepo.AddAsync(new ProductTagEntity
                {
                    ArticleNumber = entity.ArticleNumber,
                    TagId = int.Parse(tag)
                });
            }
        }

     
        public async Task<bool> UploadImageAsync(Product product, IFormFile image)
        {
            try
            {
                string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{product.ImageUrl}";
                await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
                return true;
            }
            catch {  return false; }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var items = await _productRepo.GetAllAsync();
            var list = new List<Product>();
            foreach (var item in items)
                list.Add(item);

            return list;
        }

        public async Task<Product> GetAsync(string id)
        {
            return await _productRepo.GetAsync(x => x.ArticleNumber == id);
        }
    }
}
