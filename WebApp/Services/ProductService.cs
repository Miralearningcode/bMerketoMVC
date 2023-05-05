using WebApp.Models.Entities;
using WebApp.Repositiories;

namespace WebApp.Services
{
    public class ProductService
    {
        #region Constructors & Private Fields

        private readonly ProductRepository _productRepo;
        private readonly ProductTagRepository _productTagRepo;

        public ProductService(ProductRepository productRepo, ProductTagRepository productTagRepo)
        {
            _productRepo = productRepo;
            _productTagRepo = productTagRepo;
        }

        #endregion

        public async Task<bool> CreateAsync(ProductEntity entity)
        {
            var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
            if (_entity == null)
            {
                _entity = await _productRepo.AddAsync(entity);
                if (entity != null)
                    return true;
            }

            return false;
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
    }
}
