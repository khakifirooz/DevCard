using Microsoft.AspNetCore.Mvc;
using TestDevCard.Models;

namespace TestDevCard.ViewComponents
{
    public class ArticlesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var articles = new List<Article>
            {
                new Article {Id = 1, Title = "aaa", Description = "jjjj"},
                new Article {Id = 2, Title = "bbb", Description = "sss"},
                new Article {Id = 3, Title = "ccc", Description = "ddd"},

            };

            return View("_Articles",articles);
        }
    }
}
