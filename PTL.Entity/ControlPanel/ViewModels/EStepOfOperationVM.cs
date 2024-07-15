using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PTL.Entity.Enums.ModuleEnums;

namespace PTL.Entity.ControlPanel.ViewModels
{
    public class EStepOfOperationVM
    {
        public ModuleList id { get; set; }
        public string SelectedCompany { get; set; }
        public string HeaderText { get; set; }
        public List<EMenuTable> EMenuTable { get; set; } = new List<EMenuTable>();
        public List<SelectListItem> ModuleList { get; set; }
        public List<SelectListItem> CompanyList { get; set; }

    }
}
