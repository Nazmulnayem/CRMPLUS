using PTL.Entity;
using PTL.Entity.Auth;
using System.Data;
using static PTL.Entity.Auth.EUserCompanyInformation;
using static PTL.Entity.Auth.EUserLoginInformation;


namespace PTL.Service.IRepository
{

    public interface ILogin
    {
        public Task<ServiceResponse<IEnumerable<EClassCompany>>> GetCompanyList();
        public Task<ServiceResponse<IEnumerable<EClassCompany>>> GetHitCounter();
        public ServiceResponse<DataSet> GetHitCounterLimit();
        public ServiceResponse<DataSet> ExpDate();
        public Task<ServiceResponse<Tuple<IEnumerable<UserProperties>, IEnumerable<UserPropertieslmt>, IEnumerable<UserComInf>>>> GetCompanyInformation(string comcod);
        public Task<ServiceResponse<Tuple<IEnumerable<UserInfo>, IEnumerable<UserPagePerm>, IEnumerable<UserImg>, IEnumerable<UserMenuList>, IEnumerable<UserUrl>, IEnumerable<UserSisterCompany>, IEnumerable<UserMenuPerm>>>> GetUserLoginInfo(string comcod, string username, string pass);
        public Task<ServiceResponse<bool>> UpdateTransInfo(string comcod, string dcnumber);
        public Task<ServiceResponse<bool>> AddLogRecord(string comcod, string tempId, string usrid, string sesionid, string eventtype, string eventdesc, string eventdesc2);
        public Task<ServiceResponse<bool>> UpdatePassword(string comcod, string usrid, string oldPass, string newPass);
    }
}
