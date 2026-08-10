namespace MB.Domain.ArticleCategory
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> Getall();
        void Create(ArticleCategory articleCategory);
        void SaveChanges();
    }
}
