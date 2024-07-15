using Microsoft.AspNetCore.Mvc;

namespace RealERP.WEB.Areas.CRM.Controllers
{
    [Area("CRM")]
    public class CRMEntryController : Controller
    {
        public IActionResult AddLeadIndex()
        {
            ViewData["Title"] = "Create New Lead";

            return View();
        }
    }
}
