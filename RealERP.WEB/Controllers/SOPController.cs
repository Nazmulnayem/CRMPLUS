using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PTL.Data;
using PTL.Entity.ControlPanel.ViewModels;
using PTL.Service.IRepository;
using static PTL.Entity.Auth.EUserLoginInformation;
using static PTL.Entity.Enums.ModuleEnums;

namespace RealERP.WEB.Controllers
{
    public class SOPController : Controller
    {
        private readonly ISOP _iSOP;
        private readonly ICommon _common;
        public SOPController(ISOP iSOP, ICommon common)
        {
            _iSOP = iSOP;
            _common = common;
        }

        public async Task<IActionResult> StepOfOperation(string id)
        {
            if (id == "")
            {
                //Show Error Message
                return RedirectToAction("Index", "Home");
            }

            string comcod = User.FindFirst("Comcod")?.Value ?? "";
            string userid= User.FindFirst("UserId")?.Value ?? "";

            ModuleList module = (ModuleList)Enum.Parse(typeof(ModuleList), id);
            var list = UserManager.ShowModule(module);
            EStepOfOperationVM vm = new EStepOfOperationVM();

            var modulelist = await _common.GetCompanyModule(comcod, userid);
            if(modulelist == null || !modulelist.IsSuccess || modulelist.Data == null)
            {
                //Show Error Message
                return RedirectToAction("Index", "Home");
            }

            vm.id = module;
            vm.SelectedCompany = comcod;
            vm.ModuleList = modulelist.Data.Select(x=> new SelectListItem { Text=x.modulename, Value=x.moduleid }).ToList();
            //vm.HeaderText = 
            vm.EMenuTable = list;

            return View(vm);
        }
    }
}
