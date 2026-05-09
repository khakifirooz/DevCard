using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using TestDevCard.Models;

namespace TestDevCard.ViewComponents
{
    public class ProjectsViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var projects = new List<Project>
        {
            new Project {Id = 1 ,Name = "mm",Client = "mehrshad" , Description = "jsahdsbsh"},
            new Project {Id = 2 ,Name = "ll",Client = "ali" , Description = "jsahdsbsh"},
            new Project {Id = 3 ,Name = "ss",Client = "abas" , Description = "jsahdsbsh"},
            new Project {Id = 4 ,Name = "fgf",Client = "hosein" , Description = "jsahdsbsh"},
        };
            return View("_Projects",projects);
        }
    }
}
