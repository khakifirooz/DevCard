using EFCore.Domain.ProductCategoryAgg;
using EFCore_Application.Contract.ProductCategory;

namespace EFCore_Infrasturactures.EfCore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly EfContext _context;

        public ProductCategoryRepository(EfContext context)
        {
            _context = context;
        }

        public void Create(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            SaveChanges();
        }

        public bool Exist(string name)
        {
            return _context.ProductCategories.Any(c => c.Name == name);
        }

        public ProductCategory Get(int id)
        {
            return _context.ProductCategories.FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetAll(string name)
        {
            var query = _context.ProductCategories
                .Select(x => new ProductCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreationDate = x.Name
                });

            if(!string.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.Name.Contains(name));

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
