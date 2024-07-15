using PTL.Entity.ControlPanel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PTL.Entity.Enums.ModuleEnums;

namespace PTL.Data
{
    public class ConstantInfo
    {
        
        public static List<EUSRCOMPFRMINF> GetPermissionScope()
        {
            List<EUSRCOMPFRMINF> pagedata = new List<EUSRCOMPFRMINF>();

            #region GENERAL

            #region CRM

            #endregion

            #region Management/Control Panel_99

            pagedata.Add(new EUSRCOMPFRMINF { FRMGRP = "9901000", FRMID="9901001", FRMNAME="Company Page Permission", PAREA= "ControlPanel", PCONTROLLER= "CompPerm", PACTION= "CompPermIndex", QRYTYPE = "" });
            pagedata.Add(new EUSRCOMPFRMINF { FRMGRP = "9901000", FRMID = "9901002", FRMNAME = "User Page Permission", PAREA = "ControlPanel", PCONTROLLER = "UserPerm", PACTION = "UserPermIndex", QRYTYPE="" });


            #endregion


            #endregion


            #region HRM
            #endregion

            #region KPI
            #endregion

            return pagedata;
        }
        public static List<EMenuTable> AllMenuTable(ModuleList ModuleId)
        {
            List<EMenuTable> menuTables = new List<EMenuTable>();
            switch (ModuleId)
            {
                case ModuleList.CRM:                    
                    menuTables.Add(new EMenuTable("0201000000", "Code Book", "", "", "", "", "", false, "header"));
                    menuTables.Add(new EMenuTable("0201000001", "Page Text 1", "", "", "", "", "", true, "", ""));
                    menuTables.Add(new EMenuTable("0201000002", "Page Text 2", "", "", "", "", "", true, "", ""));
                    break;

                case ModuleList.Mgt:
                    menuTables.Add(new EMenuTable("0201000000", "One Time Input", "", "", "", "", "", false, "header", ""));
                    menuTables.Add(new EMenuTable("0201000001", "Company Page Permission", "ControlPanel", "CompPerm", "CompPermIndex", "", "", true, "", "9901001"));
                    menuTables.Add(new EMenuTable("0201000002", "User Page Permission", "ControlPanel", "UserPerm", "UserPermIndex", "", "", true, "", "9901002"));
                    break;
            }
            return menuTables;
        }


    }
}
