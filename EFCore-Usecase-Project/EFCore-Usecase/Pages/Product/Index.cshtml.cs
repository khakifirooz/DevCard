using EFCore_Application.Contract.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_Usecase.Pages.Product
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> products { get; set; }
        private readonly IProductApplication productApplication;

        public IndexModel(IProductApplication productApplication)
        {
            this.productApplication = productApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            products = productApplication.Search(searchModel);
        }
    }
}
