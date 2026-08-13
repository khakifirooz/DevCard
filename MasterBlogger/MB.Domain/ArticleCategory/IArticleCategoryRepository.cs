namespace MB.Domain.ArticleCategory
{
    public interface IArticleCategoryRepository
    {
        //List<ArticleCategory> Getall();
        //void Create(ArticleCategory articleCategory);
        //void SaveChanges();

        Task<IReadOnlyList<ArticleCategory>> GetAllAsync(
           CancellationToken cancellationToken = default);

        Task<ArticleCategory?> GetByIdAsync(
            long id,
            CancellationToken cancellationToken = default);

        Task<bool> ExistsByTitleAsync(
            string title,
            long? excludeId = null,
            CancellationToken cancellationToken = default);

        Task AddAsync(
            ArticleCategory articleCategory,
            CancellationToken cancellationToken = default);

        Task SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
