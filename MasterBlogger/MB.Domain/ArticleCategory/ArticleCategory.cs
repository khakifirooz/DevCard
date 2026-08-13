namespace MB.Domain.ArticleCategory
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }

        public ArticleCategory(string title)
        {
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.UtcNow;
        }

        public void Edit(string title)
        {
            Title = title;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            IsDeleted = false;
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException(
                    "عنوان دسته‌بندی نمی‌تواند خالی باشد.",
                    nameof(title));

            title = title.Trim();

            if (title.Length > 100)
                throw new ArgumentException(
                    "عنوان دسته‌بندی نمی‌تواند بیشتر از ۱۰۰ کاراکتر باشد.",
                    nameof(title));

            Title = title;
        }
    }
}
