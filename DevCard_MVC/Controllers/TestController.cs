using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevCard_MVC.Controllers
{
    public class TestController : Controller
    {
        // GET: TestController
        public IActionResult Index()
        {
          //  return new StatusCodeResult(896);
          //return new BadRequestResult();
          return new OkResult();
        }

        //public RedirectToActionResult Index()
        //{
        //    return RedirectToAction("Contact", "Home");
        //}
    }
}
