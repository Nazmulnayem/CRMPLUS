using Microsoft.AspNetCore.Mvc;

namespace RealERP.WEB.Controllers
{
    public class ErrorController : Controller
    {
        //[HttpGet("Error404")]
        public IActionResult Error404()
        {
            return View();
        }

        //[HttpGet("PageNotFound")]
        public IActionResult ErrorDbNoConnect()
        {
            return View();
        }
    }
}
