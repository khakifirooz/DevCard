using DotNet9Learning.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet9Learning.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var item = new Items("Mehrshad");
            return View(item);
        }
    }
}
