using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PTL.Data;
using PTL.Entity;
using System.Data;
using System.Security.Claims;
using static PTL.Entity.Auth.ELogin;
using PTL.Entity.Auth.VM_Auth;
using Microsoft.AspNetCore.Mvc.Rendering;
using static PTL.Entity.Auth.EClass_Login;
using PTL.Service.IRepository;
using PTL.Entity.Auth;

namespace RealERP.WEB.Controllers
{
    public class HomeController : Controller
    {
        public static int day = 0;
        private readonly ILogin _login;
        private readonly ICommon _common;

        public HomeController(ILogin login, ICommon common)
        {
            _login = login;
            _common = common;
        }

        private void CallJsFunction(Confirmation conf)
        {
            ViewBag.JavascriptFunction = $"swal(`{conf.title}`, `{conf.text}`, `{conf.icon}`);";
        }

        public Task<ServiceResponse<IEnumerable<EClassCompany>>> GetCompanyFromCompDB()
        {
            var result = _login.GetCompanyList();
            return result;
        }

        private EHitCounterReturn GetHitCounter()
        {
            var ds1 = _login.GetHitCounter().Result.Data?.FirstOrDefault()?.cnumber;
            string comcod = "3101";
            var ds51 = _login.GetCompanyInformation(comcod).Result;
            if (!ds51.IsSuccess || ds51.Data == null)
            {
                TempData["ErrorText"] = ds51.ExceptionMessage;
                return new EHitCounterReturn { result = false, dcnumber = -1 };
            }
            double cnumber = Convert.ToDouble(ds1);
            double dcnumber = Convert.ToDouble(ds51.Data.Item2.ToList()[0].cnumber);
            double cntlim3, dcntlim3;
            cntlim3 = Convert.ToDouble(_login.GetHitCounterLimit().Data?.Tables[0].Rows[2]["cntval"].ToString());
            dcntlim3 = Convert.ToDouble(ds51.Data.Item1.ToList()[2].cntval);

            DateTime expDay = Convert.ToDateTime(_login.ExpDate().Data?.Tables[0].Rows[0]["expdate"]);
            DateTime today = System.DateTime.Today;
            day = UtilityClass.Datediffday(expDay, today);

            if ((cnumber >= cntlim3) || (day <= 0) || (dcnumber >= dcntlim3))
            {
                string text = "Could Not Loaded MktLIB.dll. Please Repair Selected File!";
                TempData["ErrorText"] = text;
                return new EHitCounterReturn { result = false, dcnumber = -1 };
            }
            return new EHitCounterReturn { result = true, dcnumber = dcnumber };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Login()
        {
            var vm = new VMLogin();
            bool resultHitCounter = GetHitCounter().result;
            if (!resultHitCounter)
            {
                return RedirectToAction("ErrorDbNoConnect", "Error");
            }

            var result = GetCompanyFromCompDB().Result;
            if (!result.IsSuccess || result.Data == null)
            {
                vm.listCompanies = new List<SelectListItem>();
                CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = result.UIMessage });
                return View(vm);
            }
            vm.listCompanies = result.Data.Select(x => new SelectListItem { Value = x.comcod, Text = x.comsnam }).ToList();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(VMLogin obj)
        {
            try
            {
                var resultCompany = GetCompanyFromCompDB().Result;
                if (!resultCompany.IsSuccess || resultCompany.Data == null)
                {
                    obj.listCompanies = new List<SelectListItem>();
                    string text = resultCompany.UIMessage;
                    CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                    return View(obj);
                }
                obj.listCompanies = resultCompany.Data.Select(x => new SelectListItem { Value = x.comcod, Text = x.comsnam }).ToList();

                //--------------Change Password Block-------------
                if (obj.OldPassword != null && obj.NewPassword != null)
                {
                    ModelState.Remove(nameof(obj.Password));
                    if (ModelState.IsValid)
                    {
                        var encryptedOldPass = UtilityClass.EncodePassword(obj.OldPassword.Trim());
                        var encryptedNewPass = UtilityClass.EncodePassword(obj.NewPassword.Trim());
                        var result = await _login.UpdatePassword(obj.SelectedComcod, obj.UserName, encryptedOldPass, encryptedNewPass);

                        if (result.Data == true)
                        {
                            string text = "Password changed successfully!";
                            CallJsFunction(new Confirmation { icon = AlertIcons.success, title = "Success", text = text });
                            return View(obj);
                        }
                        else
                        {
                            string text = "Old password didn't match!";
                            CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                            return View(obj);
                        }
                    }
                    else
                    {
                        string text = "Please Enter Required Field!";
                        CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                        return View(obj);
                    }
                }
                //--------------Log In Block-------------
                else
                {
                    ModelState.Remove(nameof(obj.OldPassword));
                    ModelState.Remove(nameof(obj.NewPassword));
                    if (ModelState.IsValid)
                    {
                        // Sign out the user and remove their authentication cookie
                        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                        // Clear the current user's claims
                        HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());
                        // Clear all session data
                        HttpContext.Session.Clear();

                        string comcod = obj.SelectedComcod;

                        bool resultHitCounter = GetHitCounter().result;
                        if (!resultHitCounter)
                        {
                            return RedirectToAction("ErrorDbNoConnect", "Error");
                        }

                        string username = obj.UserName;
                        string defaultPassword = obj.Password;
                        string pass = UtilityClass.EncodePassword(defaultPassword.Trim());
                        string HostAddress = HttpContext.Request.Host.ToString();

                        if ((comcod == "3365" || comcod == "3101") && defaultPassword == "123")
                        {
                            string text = "Please reset your default password!";
                            CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                            return View(obj);
                        }

                        var ds5 = await _login.GetUserLoginInfo(comcod, username, pass);
                        if (!ds5.IsSuccess || ds5.Data == null)
                        {
                            string text = ds5.UIMessage;
                            CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                            return View(obj);
                        }

                        var dt = ds5.Data.Item1.ToList();
                        if (dt.Count == 0)
                        {
                            string text = "Please Enter Correct Name & Password!";
                            CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                            return View(obj);
                        }
                        if (dt == null)
                        {
                            string text = "Something went wrong!";
                            CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                            return View(obj);
                        }

                        var result = await _login.UpdateTransInfo(comcod, (GetHitCounter().dcnumber + 1).ToString());
                        if (!result.IsSuccess)
                        {
                            string text = result.UIMessage;
                            CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                            return View(obj);
                        }
                        if (!result.Data)
                        {
                            string text = "Something went wrong!";
                            CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                            return View(obj);
                        }


                        var company = resultCompany.Data.Where(x => x.comcod == comcod).FirstOrDefault();

                        var companyModule = _common.GetCompanyModule(comcod, dt[0].usrid).Result;
                        if(!companyModule.IsSuccess)
                        {
                            string text = result.UIMessage;
                            CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                            return View(obj);
                        }
                        if (companyModule.Data == null)
                        {
                            string text = "Something went wrong!";
                            CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                            return View(obj);
                        }
                        string sessionid = (UtilityClass.RandNumber(111111, 999999)).ToString();

                        List<SessionLog> sessionLog = [
                            new() {
                                comcod = comcod,
                                deptcode = Convert.ToString(dt[0].deptcode),
                                dptdesc = Convert.ToString(dt[0].dptdesc),
                                modulenam = "",
                                username = Convert.ToString(dt[0].usrsname),
                                userfname = Convert.ToString(dt[0].usrname),
                                compname = HostAddress,
                                usrid = Convert.ToString(dt[0].usrid),
                                password = defaultPassword,
                                session = sessionid,
                                trmid = "",
                                commod = "1",
                                compsms = Convert.ToString(dt[0].compsms),
                                ssl = Convert.ToString(dt[0].ssl),
                                opndate = Convert.ToString(dt[0].opndate),
                                empid = Convert.ToString(dt[0].empid),
                                teamid = Convert.ToString(dt[0].teamid),
                                mcomcod = Convert.ToString(ds5.Data.Item6.ToList()[0].mcomcod),
                                usrdesig = Convert.ToString(dt[0].usrdesig),
                                events = Convert.ToString(dt[0].eventspanel),
                                usrrmrk = Convert.ToString(dt[0].usrrmrk),
                                userrole = Convert.ToString(dt[0].userrole),
                                compmail = Convert.ToString(dt[0].compmail),
                                userimg = Convert.ToString(dt[0].IMGURL),
                                ddldesc = Convert.ToString(dt[0].ddldesc),
                                portnum = Convert.ToString(dt[0].portnum),
                                comunpost = Convert.ToString(dt[0].comunpost),
                                homeurl = Convert.ToString(dt[0].homeurl),
                                invtype = Convert.ToString(dt[0].invtype),
                                mrfname = Convert.ToString(dt[0].mrfname),
                                iscalpv = Convert.ToString(dt[0].iscalpv),
                                nsheetpv = Convert.ToString(dt[0].nsheetpv),
                                nsheetfv = Convert.ToString(dt[0].nsheetfy),
                                tyjantodec = Convert.ToString(dt[0].ty_jantodec),
                                isnsheetsfrmbking = Convert.ToString(dt[0].isnsheetsfrmbking),
                                iscrmtdwise = Convert.ToString(dt[0].iscrmtdwise),
                                isnotification = Convert.ToString(dt[0].isnotific),
                                isdepdet = Convert.ToString(dt[0].isdepdet),
                                issynwithfup = Convert.ToString(dt[0].issynwithfup)
                            }
                        ];

                        string companyJson = JsonConvert.SerializeObject(company);
                        string sessionLogJson = JsonConvert.SerializeObject(sessionLog);

                        var claims = new List<Claim>
                        {
                            new Claim("Comcod", comcod),
                            new Claim("UserId", dt[0].usrid),
                            new Claim("Company", companyJson),
                            new Claim("SessionLog", sessionLogJson),
                        };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        var userpermpage = ds5.Data.Item2.ToList();
                        var shortcutMenuList = ds5.Data.Item4.ToList();
                        var sisterOfCompany = ds5.Data.Item6.ToList();
                        var menuPrivilege = ds5.Data.Item7.ToList();
                        
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "UserPermissionPage", userpermpage);
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "ShortcutPage", shortcutMenuList);
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "SisterCompany", sisterOfCompany);
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "MenuPrivilege", menuPrivilege);
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "CompanyModule", companyModule.Data);

                        string eventtype = "1";
                        string eventdesc = "Login into the system!";
                        string eventdesc2 = "";
                        await _login.AddLogRecord(comcod, HostAddress, Convert.ToString(dt[0].usrid) ?? "", sessionid, eventtype, eventdesc, eventdesc2);

                        var RedirectUrl = ds5.Data.Item5.ToList();

                        if (RedirectUrl.Count == 0)
                        {
                            string text = "No Page Found To Navigate!";
                            CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                            return View(obj);
                        }
                        return RedirectToAction(RedirectUrl[0].paction, RedirectUrl[0].pcont);
                    }
                    else
                    {
                        string text = "Please Enter Required Field!";
                        CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                        return View(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                string text = ex.Message;
                CallJsFunction(new Confirmation { icon = AlertIcons.error, title = "Error", text = text });
                return View(obj);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public Task<RedirectToActionResult> Logout()
        {
            // Sign out the user and remove their authentication cookie
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Clear the current user's claims
            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());
            // Clear all session data
            HttpContext.Session.Clear();

            // Clear a specific session variable data
            //HttpContext.Session.Remove("UserPermissionPage");

            return Task.FromResult(RedirectToAction("Login", "Home"));
        }
    }
}
