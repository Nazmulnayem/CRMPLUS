using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PTL.Entity;
using PTL.Service.IRepository;
using PTL.Service.IRepository.ControlPanel;
using static PTL.Entity.Auth.ELogin;
using static RealERP.WEB.Areas.ControlPanel.ViewModels.VMCompPermindex;

namespace RealERP.WEB.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class CompPermController : Controller
    {
        private readonly ICompPerm _compPerm;
        private readonly ICommon _common;

        public CompPermController(ICompPerm compPerm, ICommon common)
        {
            _compPerm = compPerm;
            _common = common;
        }

        private void CallJsFunction(Confirmation conf)
        {
            ViewBag.JavascriptFunction = $"swal(`{conf.title}`, `{conf.text}`, `{conf.icon}`);";
        }

        public IActionResult CompPermIndex(bool ShowAll=false, string moduleid="",  string pgSize = "10", int pg = 1)
        {
            var vm = new VMModule();
            var sessionLog = JsonConvert.DeserializeObject<List<SessionLog>>(User.FindFirst("SessionLog")?.Value ?? JsonConvert.SerializeObject(new List<SessionLog>()));
            ViewData["Title"] = "Company Permission Page";

            var result = _common.GetCompanyModule(sessionLog[0].comcod, sessionLog[0].usrid).Result;
            if (!result.IsSuccess || result.Data == null)
            {
                vm.listModules = new List<SelectListItem>();
                CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = result.UIMessage });
                return View(vm);
            }
            vm.listModules = result.Data.Select(x => new SelectListItem { Value = x.moduleid, Text = x.modulename}).ToList();

            var compFrmList = _compPerm.GetUserCompanyFrm(sessionLog[0].comcod, moduleid).Result;
            if (!compFrmList.IsSuccess || compFrmList.Data == null)
            {
                var text = compFrmList.UIMessage;
                CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                return View(vm);
            }
            var CompForm = compFrmList.Data;
            if (!ShowAll)
            {
                CompForm = CompForm.Where(x => x.CHKPER == true).ToList();
            }
            int pageSize = Convert.ToInt16(pgSize);
            if (pg < 1) pg = 1;
            int recsCount = CompForm.Count();
            var pager = new Pager(recsCount, pg, "CompPermIndex", "CompPerm", pageSize, "ControlPanel");
            int recsSkip = (pg - 1) * pageSize;
            var data = CompForm.Skip(recsSkip).Take(pager.PageSize).ToList();
            //vm.pg = 
            ViewBag.CompFrmList = data;
            ViewBag.Pager = pager;
            ViewBag.PageSize = pageSize;
            return View(vm);
        }


    }
}
