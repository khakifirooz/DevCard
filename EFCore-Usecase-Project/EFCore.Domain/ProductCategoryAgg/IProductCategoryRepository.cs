using EFCore_Application.Contract.ProductCategory;

namespace EFCore.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {

        void Create(ProductCategory productCategory);

        EditProductCategory GetDetails(int id);

        bool Exist(string name);
         
        ProductCategory Get(int id);

        public List<ProductCategoryViewModel> Search(string name);
        public List<ProductCategoryViewModel> GetAll();

        public void SaveChanges();
    }
}
