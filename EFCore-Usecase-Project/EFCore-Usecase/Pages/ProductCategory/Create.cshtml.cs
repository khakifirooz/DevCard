using EFCore_Application.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_Usecase.Pages.ProductCategory
{
    public class CreateModel : PageModel
    {

        public readonly IProductCategoryApplication ProductCategoryApplication;

        public CreateModel(IProductCategoryApplication productCategoryApplication)
        {
            ProductCategoryApplication = productCategoryApplication;
        }
        
        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(CreateProductCategory command)
        {
            ProductCategoryApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
