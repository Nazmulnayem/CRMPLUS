using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PTL.Entity;
using PTL.Entity.Auth;
using PTL.Service.IRepository.ControlPanel;
using static PTL.Entity.Auth.ELogin;

namespace RealERP.WEB.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class CompController : Controller
    {
        private readonly IComp _comp;

        public CompController(IComp comp)
        {
            _comp = comp;
        }

        private void CallJsFunction(Confirmation conf)
        {
            ViewBag.JavascriptFunction = $"swal(`{conf.title}`, `{conf.text}`, `{conf.icon}`);";
        }

        public IActionResult CompIndex()
        {
            ViewData["Title"] = "Company Information Page";
            var sessionLog = JsonConvert.DeserializeObject<List<SessionLog>>(User.FindFirst("SessionLog")?.Value ?? JsonConvert.SerializeObject(new List<SessionLog>()));
            var result = _comp.GetCompanyInfo(sessionLog[0].comcod).Result;
            if (!result.IsSuccess || result.Data == null)
            {
                var text = result.UIMessage;
                CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                return View();
            }
            return View(result.Data);
        }


        [HttpPost]
        public async Task<IActionResult> CompIndex(EClassCompany obj)
        {
            ViewData["Title"] = "Company Information Page";
            var sessionLog = JsonConvert.DeserializeObject<List<SessionLog>>(User.FindFirst("SessionLog")?.Value ?? JsonConvert.SerializeObject(new List<SessionLog>()));

            var resultDB = await _comp.UpdateCompInfo(obj, sessionLog[0].comcod);
            if (!resultDB.IsSuccess)
            {
                var text = resultDB.UIMessage;
                CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                return View(obj);
            }

            var resultAccessDB = _comp.UpdateCompInfoCompDB(obj, sessionLog[0].comcod).Result;
            if (!resultAccessDB.IsSuccess)
            {
                var text = resultAccessDB.UIMessage;
                CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                return View(obj);
            }
            else
            {
                var text = "Information updated successfully!";
                CallJsFunction(new Confirmation { icon = AlertIcons.success, title = "Success", text = text });
                return View(obj);
            }

        }
    }
}
