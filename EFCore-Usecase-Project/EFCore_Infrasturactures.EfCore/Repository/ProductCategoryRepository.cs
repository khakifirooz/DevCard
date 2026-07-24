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

        public List<ProductCategoryViewModel> Search(string name)
        {
            //projection
            var query = _context.ProductCategories
                .Select(x => new ProductCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreationDate = x.CreationDate.ToString()
                });

            //filtering
            if(!string.IsNullOrWhiteSpace(name))
                query = query.Where(x => x.Name.Contains(name));

            //sorting
            return query.OrderByDescending(x => x.Id).ToList();
        }

        public EditProductCategory GetDetails(int id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory
            { 
                Id = x.Id,
                Name = x.Name,
            }).FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryViewModel
            { 
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}
