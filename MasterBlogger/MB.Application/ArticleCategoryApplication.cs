using MB.Application.Contracts;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategory;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _repository;

        public ArticleCategoryApplication(
            IArticleCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<ArticleCategoryViewModel>>
            GetAllAsync(CancellationToken cancellationToken = default)
        {
            var categories =
                await _repository.GetAllAsync(cancellationToken);

            return categories
                .Select(x => new ArticleCategoryViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreationDate = x.CreationDate,
                    IsDeleted = x.IsDeleted
                })
                .ToList();
        }

        public async Task<OperationResult> CreateAsync(
            CreateArticleCategory command,
            CancellationToken cancellationToken = default)
        {
            var operation = new OperationResult();
            var title = command.Title.Trim();

            var titleExists =
                await _repository.ExistsByTitleAsync(
                    title,
                    cancellationToken: cancellationToken);

            if (titleExists)
                return operation.Failed(
                    "دسته‌بندی دیگری با این عنوان وجود دارد.");

            var category = new ArticleCategory(title);

            await _repository.AddAsync(category, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return operation.Succeeded(
                "دسته‌بندی با موفقیت ایجاد شد.");
        }

        public async Task<EditArticleCategory?> GetForEditAsync(
            long id,
            CancellationToken cancellationToken = default)
        {
            var category =
                await _repository.GetByIdAsync(id, cancellationToken);

            if (category is null)
                return null;

            return new EditArticleCategory
            {
                Id = category.Id,
                Title = category.Title
            };
        }

        public async Task<OperationResult> EditAsync(
            EditArticleCategory command,
            CancellationToken cancellationToken = default)
        {
            var operation = new OperationResult();

            var category =
                await _repository.GetByIdAsync(
                    command.Id,
                    cancellationToken);

            if (category is null)
                return operation.Failed(
                    "دسته‌بندی موردنظر پیدا نشد.");

            var title = command.Title.Trim();

            var titleExists =
                await _repository.ExistsByTitleAsync(
                    title,
                    command.Id,
                    cancellationToken);

            if (titleExists)
                return operation.Failed(
                    "دسته‌بندی دیگری با این عنوان وجود دارد.");

            category.Edit(title);

            await _repository.SaveChangesAsync(cancellationToken);

            return operation.Succeeded(
                "دسته‌بندی با موفقیت ویرایش شد.");
        }

        public async Task<OperationResult> DeleteAsync(
            long id,
            CancellationToken cancellationToken = default)
        {
            var operation = new OperationResult();

            var category =
                await _repository.GetByIdAsync(id, cancellationToken);

            if (category is null)
                return operation.Failed(
                    "دسته‌بندی موردنظر پیدا نشد.");

            if (category.IsDeleted)
                return operation.Failed(
                    "این دسته‌بندی قبلاً حذف شده است.");

            category.Delete();

            await _repository.SaveChangesAsync(cancellationToken);

            return operation.Succeeded(
                "دسته‌بندی با موفقیت حذف شد.");
        }

        public async Task<OperationResult> RestoreAsync(
            long id,
            CancellationToken cancellationToken = default)
        {
            var operation = new OperationResult();

            var category =
                await _repository.GetByIdAsync(id, cancellationToken);

            if (category is null)
                return operation.Failed(
                    "دسته‌بندی موردنظر پیدا نشد.");

            if (!category.IsDeleted)
                return operation.Failed(
                    "این دسته‌بندی درحال‌حاضر فعال است.");

            category.Restore();

            await _repository.SaveChangesAsync(cancellationToken);

            return operation.Succeeded(
                "دسته‌بندی با موفقیت بازگردانی شد.");
        }
    }
}
