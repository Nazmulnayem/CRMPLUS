using PTL.Entity.ControlPanel;
using PTL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTL.Service.IRepository.ControlPanel
{
    public interface ICompPerm
    {
        public Task<ServiceResponse<IEnumerable<EUSRCOMPFRMINF>>> GetUserCompanyFrm(string comcod, string moduleid = "");
    }
}
