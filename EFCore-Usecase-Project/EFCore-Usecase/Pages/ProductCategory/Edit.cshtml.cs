using EFCore_Application.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_Usecase.Pages.ProductCategory
{
    public class EditModel : PageModel
    {
        public EditProductCategory command;
        private readonly IProductCategoryApplication productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(int id)
        {
            command = productCategoryApplication.GetDetails(id);
        }

        public RedirectToPageResult OnPost(EditProductCategory command)
        {
            productCategoryApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
