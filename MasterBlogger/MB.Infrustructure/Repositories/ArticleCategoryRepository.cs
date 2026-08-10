using MB.Domain.ArticleCategory;

namespace MB.Infrustructure.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context;
        }

        public void Create(ArticleCategory articleCategory)
        {
            _context.ArticleCategories.Add(articleCategory);
            SaveChanges();
        }

        public List<ArticleCategory> Getall()
        {
            return _context.ArticleCategories.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
