using EFCore_Application.Contract.Product;
using EFCore_Application.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCore_Usecase.Pages.Product
{
    public class CreateModel : PageModel
    {
        public SelectList ProducCategories;
        private readonly IProductApplication productApplication;
        private readonly IProductCategoryApplication productCategoryApplication;
        public CreateModel(IProductApplication productApplication, 
            IProductCategoryApplication productCategoryApplication)
        {
            this.productApplication = productApplication;
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
            ProducCategories = new SelectList(productCategoryApplication.GetAll(), "Id", "Name");
        }

        public RedirectToPageResult OnPost(CreateProduct command)
        {
            productApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
