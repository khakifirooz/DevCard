using DevCard_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevCard_MVC.ViewComponents
{
    public class LatestArticlesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var articles = new List<Article>
            {
                new Article(1, "آموزش asp.net core mvc",
                "کامل ترین آموزش asp.net core mvc","blog-post-thumb-card-1.jpg"),
                new Article(2, "آموزش Git and Github",
                "کامل ترین آموزش Git and Github","blog-post-thumb-card-2.jpg"),
                new Article(3, "آموزش Onion Architecture",
                "کامل ترین آموزش Onion Architecture","blog-post-thumb-card-3.jpg"),
                new Article(4, "آموزش Javascript & Html Css",
                "کامل ترین آموزش Javascript & Html Css","blog-post-thumb-card-4.jpg"),
            };
            return View("_LatestArticles", articles);
        }
    }
}
