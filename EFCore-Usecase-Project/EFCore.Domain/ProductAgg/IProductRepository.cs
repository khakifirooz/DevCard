using EFCore_Application.Contract.Product;

namespace EFCore.Domain.ProductAgg
{
    public interface IProductRepository
    {
        Product Get(int id);
        EditProduct GetDetails(int id);
        void Create(Product product);
        void SaveChanges();
        bool Exist(string name, int categoryId);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
