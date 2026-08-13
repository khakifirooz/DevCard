using MB.Domain.ArticleCategory;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrustructure.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ArticleCategory>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await _context.ArticleCategories
                .AsNoTracking()
                .OrderByDescending(x => x.CreationDate)
                .ToListAsync(cancellationToken);
        }

        public async Task<ArticleCategory?> GetByIdAsync(
            long id,
            CancellationToken cancellationToken = default)
        {
            return await _context.ArticleCategories
                .FirstOrDefaultAsync(
                    x => x.Id == id,
                    cancellationToken);
        }

        public async Task<bool> ExistsByTitleAsync(
            string title,
            long? excludeId = null,
            CancellationToken cancellationToken = default)
        {
            title = title.Trim();

            return await _context.ArticleCategories.AnyAsync(
                x => x.Title == title &&
                     (!excludeId.HasValue || x.Id != excludeId.Value),
                cancellationToken);
        }

        public async Task AddAsync(
            ArticleCategory articleCategory,
            CancellationToken cancellationToken = default)
        {
            await _context.ArticleCategories.AddAsync(
                articleCategory,
                cancellationToken);
        }

        public async Task SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
