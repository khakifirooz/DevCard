using EFCore_Application.Contract.Product;
using EFCore_Application.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCore_Usecase.Pages.Product
{
    public class EditModel : PageModel
    {
        public EditProduct command;
        public SelectList productCategories;
        private readonly IProductApplication productApplication;
        private readonly IProductCategoryApplication productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication,
            IProductApplication productApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
            this.productApplication = productApplication;
        }

        public void OnGet(int id)
        {
            productCategories = new SelectList(productCategoryApplication.GetAll(), "Id", "Name");
            command = productApplication.GetDetails(id);
        }

        public RedirectToPageResult OnPost(EditProduct command)
        {
            productApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
