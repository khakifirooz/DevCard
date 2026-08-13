using System.ComponentModel.DataAnnotations;

namespace MB.Application.Contracts.ArticleCategory
{
    public class EditArticleCategory
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "عنوان دسته‌بندی الزامی است.")]
        [MaxLength(
            100,
            ErrorMessage = "عنوان نمی‌تواند بیشتر از ۱۰۰ کاراکتر باشد.")]
        public string Title { get; set; } = string.Empty;
    }
}
