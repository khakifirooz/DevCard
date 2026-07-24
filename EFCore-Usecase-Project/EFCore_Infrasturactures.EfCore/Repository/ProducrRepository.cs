using EFCore.Domain.ProductAgg;
using EFCore_Application.Contract.Product;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Infrasturactures.EfCore.Repository
{
    public class ProducrRepository : IProductRepository
    {
        private readonly EfContext _context;

        public ProducrRepository(EfContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            SaveChanges();
        }

        public bool Exist(string name, int categoryId)
        {
            return _context.Products.Any(x => x.Name.Contains(name) && x.CategoryId == categoryId);
        }

        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public EditProduct GetDetails(int id)
        {
            return _context.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            //projection
            var query = _context.Products
                .Include(x => x.Category)
                .Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category.Name,
                    UnitPrice = x.UnitPrice,
                    CreationDate = x.CreationDate.ToString(),
                    IsRemoved = x.IsRemoved,
                });
            //filtering
            if(searchModel.IsRemoved == true)
                query = query.Where(x => x.IsRemoved == true);

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            //sort and better query performance (shut down the change tracker) we could used it in the end of the projection
            return query.OrderByDescending(x => x.Id).AsNoTracking().ToList();

        }
    }
}
