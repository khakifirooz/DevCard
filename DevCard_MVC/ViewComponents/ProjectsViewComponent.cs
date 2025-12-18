using DevCard_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevCard_MVC.ViewComponents
{
    public class ProjectsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var projects = new List<Project>
            {
                new Project(1,"تاکسی", "درخواست تاکسی آنلاین برای سفر های درون شهری","project-1.jpg","Snapp"),
                new Project(2,"زود فود", "درخواست غذا آنلاین برای سراسر کشور","project-2.jpg", "Zood food"),
                new Project(3,"مدارس", "سیسستم یکپارچه مدیریت مدارس ","project-3.jpg", "Monop"),
                new Project(4,"فضاپیما", "سیستم مدیریت فضاپیما های ناسا ","project-4.jpg", "Nasa"),

            };
            return View("_Projects", projects);
        }
    }
}
