using Microsoft.AspNetCore.Mvc;
using PTL.Service.IRepository.ControlPanel;

namespace RealERP.WEB.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class UserPermController : Controller
    {
        private readonly IUserPerm _userPerm;

        public UserPermController (IUserPerm userPerm)
        {
            _userPerm = userPerm;
        }

        public IActionResult UserPermIndex()
        {
            ViewData["Title"] = "User Permission Page";
            return View();
        }
    }
}
