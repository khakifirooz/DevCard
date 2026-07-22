using EFCore_Application.Contract.ProductCategory;

namespace EFCore.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {

        void Create(ProductCategory productCategory);

         bool Exist(string name);

        ProductCategory Get(int id);

        public List<ProductCategoryViewModel> GetAll(string name);

        public void SaveChanges();
    }
}
