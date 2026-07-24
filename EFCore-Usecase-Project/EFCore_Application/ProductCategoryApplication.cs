using EFCore.Domain.ProductCategoryAgg;
using EFCore_Application.Contract.ProductCategory;
using EFCore_Infrasturactures.EfCore.Repository;

namespace EFCore_Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }
        public void Create(CreateProductCategory command)
        {
            if (productCategoryRepository.Exist(command.Name))
                return;

            var productCategory = new ProductCategory(command.Name);
            productCategoryRepository.Create(productCategory);
            productCategoryRepository.SaveChanges();
        }

        public void Edit(EditProductCategory command)
        {
            var productCategory = productCategoryRepository.Get(command.Id);
            if (productCategory == null)
                return;

            productCategory.Edit(command.Name);
            productCategoryRepository.SaveChanges();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return productCategoryRepository.GetAll();
        }

        public EditProductCategory GetDetails(int id)
        {
            return productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            return productCategoryRepository.Search(name);
        }
    }
}
