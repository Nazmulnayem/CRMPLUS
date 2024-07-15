using PTL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PTL.Entity.Auth.ECommon;

namespace PTL.Service.IRepository
{
    public interface ICommon
    {
        public Task<ServiceResponse<IEnumerable<EModule>>> GetCompanyModule(string comcod, string usrid);
    }
}
