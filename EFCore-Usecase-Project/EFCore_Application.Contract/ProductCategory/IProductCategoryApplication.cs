namespace EFCore_Application.Contract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        void Create(CreateProductCategory command);
        void Edite(EditProductCategory command);
        List<ProductCategoryViewModel> Search(string name);
    }
}
