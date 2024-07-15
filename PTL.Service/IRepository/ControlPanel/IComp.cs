using PTL.Entity.Auth;
using PTL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTL.Service.IRepository.ControlPanel
{
    public interface IComp
    {
        public Task<ServiceResponse<EClassCompany>> GetCompanyInfo(string comcod);
        public Task<ServiceResponse<bool>> UpdateCompInfo(EClassCompany obj, string comcod);
        public Task<ServiceResponse<string>> UpdateCompInfoCompDB(EClassCompany obj, string comcod);
    }
}
