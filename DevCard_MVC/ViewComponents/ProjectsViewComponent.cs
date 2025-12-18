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
                new Project(1,"تاکسی", "درخواست تاکسی آنلاین برای سفر های درون شهری", "Snapp"),
                new Project(2,"زود فود", "درخواست غذا آنلاین برای سراسر کشور", "Zood food"),
                new Project(3,"مدارس", "سیسستم یکپارچه مدیریت مدارس ", "Monop"),
                new Project(4,"فضاپیما", "سیستم مدیریت فضاپیما های ناسا ", "Nasa"),

            };
            return View("_Projects", projects);
        }
    }
}
