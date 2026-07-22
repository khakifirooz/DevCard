using EFCore_Application.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_Usecase.Pages.ProductCategory
{
    public class IndexModel : PageModel
    {
        public List<ProductCategoryViewModel> ProductCategories { get; set; }
        private readonly IProductCategoryApplication productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(string name)
        {
            ProductCategories = productCategoryApplication.Search(name);
        }
    }
}
