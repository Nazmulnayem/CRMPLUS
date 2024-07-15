using Microsoft.AspNetCore.Mvc.Rendering;
using PTL.Entity;
using PTL.Entity.ControlPanel;

namespace RealERP.WEB.Areas.ControlPanel.ViewModels
{
    public class VMCompPermindex
    {
        public class VMModule
        {
            public List<SelectListItem> listModules { get; set; } = new List<SelectListItem>(); 
            public List<EUSRCOMPFRMINF> compFrmInf { get; set; } 
            public Pager pager { get; set; }
            public bool ShowAll { get; set; }=false;
            public string moduleid { get; set; }
            public int pgSize { get; set; } = 10;
            public int pg { get; set; } = 1;
        }
    }
}
