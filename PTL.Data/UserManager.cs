using PTL.Entity.ControlPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PTL.Entity.Enums.ModuleEnums;

namespace PTL.Data
{
    public static class UserManager
    {
        public static List<EMenuTable> ShowModule(ModuleList Module)
        {
            List<EMenuTable> list = ConstantInfo.AllMenuTable(Module);
            

            return list;
        }

    }
}
