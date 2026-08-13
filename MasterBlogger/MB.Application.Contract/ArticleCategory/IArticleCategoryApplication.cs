namespace MB.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        Task<IReadOnlyList<ArticleCategoryViewModel>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task<EditArticleCategory?> GetForEditAsync(
            long id,
            CancellationToken cancellationToken = default);

        Task<OperationResult> CreateAsync(
            CreateArticleCategory command,
            CancellationToken cancellationToken = default);

        Task<OperationResult> EditAsync(
            EditArticleCategory command,
            CancellationToken cancellationToken = default);

        Task<OperationResult> DeleteAsync(
            long id,
            CancellationToken cancellationToken = default);

        Task<OperationResult> RestoreAsync(
            long id,
            CancellationToken cancellationToken = default);
    }
}
