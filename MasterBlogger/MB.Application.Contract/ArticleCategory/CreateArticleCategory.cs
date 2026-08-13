using System.ComponentModel.DataAnnotations;

namespace MB.Application.Contracts.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage = "عنوان دسته‌بندی الزامی است.")]
        [MaxLength(100, ErrorMessage = "عنوان نمی‌تواند بیشتر از ۱۰۰ کاراکتر باشد.")]
        public string Title { get; set; } = string.Empty;
    }
}
