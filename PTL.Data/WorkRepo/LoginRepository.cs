using PTL.Data.Repository.IRepository;
using PTL.Entity;
using PTL.Entity.Auth;
using PTL.Service.IRepository;
using System.Data;
using static PTL.Entity.Auth.EUserCompanyInformation;
using static PTL.Entity.Auth.EUserLoginInformation;


namespace PTL.Data.WorkRepo
{
    public class LoginRepository : ILogin
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private readonly IDataAccessOLDB _dataAccessOLDB;

        public LoginRepository(IUnitOfWork unitOfWork, IDataAccessOLDB dataAccessOLDB)
        {
            _unitOfWork = unitOfWork;
            _dataAccessOLDB = dataAccessOLDB;
        }

        public async Task<ServiceResponse<IEnumerable<EClassCompany>>> GetCompanyList()
        {
            string sqlQuery = "select slnum, comcod, comnam, comsnam,  comadd1+'<br />'+comadd2+' '+comadd3 as comadd, comadd1,comadd2, comadd3, comadd4, compcod , combranch from compinf order by slnum, comcod asc";
            var response = await _dataAccessOLDB.GetData(sqlQuery);
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<EClassCompany>>> GetHitCounter()
        {
            string sqlQuery = "select  cnumber  from hcntinf";
            var response = await _dataAccessOLDB.GetData(sqlQuery);
            return response;
        }

        public ServiceResponse<DataSet> GetHitCounterLimit()
        {
            string sqlQuery = "select  cntstep, cntval, cntdes   from hcntlmt order by cntstep";
            ServiceResponse<DataSet> response = _dataAccessOLDB.GetDataSet(sqlQuery);
            return response;
        }

        public ServiceResponse<DataSet> ExpDate()
        {
            string cmd = "select  date as expdate from expdinf";
            ServiceResponse<DataSet> response = _dataAccessOLDB.GetDataSet(cmd);
            return response;
        }

        public async Task<ServiceResponse<Tuple<IEnumerable<UserProperties>, IEnumerable<UserPropertieslmt>, IEnumerable<UserComInf>>>> GetCompanyInformation(string comcod)
        {
            ClassProAccessParams parms = new ClassProAccessParams();
            parms.StoredProcedure = "SP_UTILITY_LOGIN_MGT";
            parms.Calltype = "LOGIN";
            parms.Comp1 = comcod;

            var response = await Task.FromResult(_unitOfWork.SP_Call.ListServiceResponse<UserProperties, UserPropertieslmt, UserComInf>(parms));
            return response;
        }

        public async Task<ServiceResponse<Tuple<IEnumerable<UserInfo>, IEnumerable<UserPagePerm>, IEnumerable<UserImg>, IEnumerable<UserMenuList>, IEnumerable<UserUrl>, IEnumerable<UserSisterCompany>, IEnumerable<UserMenuPerm>>>> GetUserLoginInfo(string comcod, string username, string pass)
        {
            ClassProAccessParams parms = new ClassProAccessParams();
            parms.StoredProcedure = "SP_UTILITY_LOGIN_MGT";
            parms.Calltype = "LOGINUSER";
            parms.Comp1 = comcod;
            parms.Desc01 = username;
            parms.Desc02 = pass;

            var response = await Task.FromResult(_unitOfWork.SP_Call.ListServiceResponse<UserInfo, UserPagePerm, UserImg, UserMenuList, UserUrl, UserSisterCompany, UserMenuPerm>(parms));
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateTransInfo(string comcod, string dcnumber)
        {
            ClassProAccessParams parms = new ClassProAccessParams();
            parms.StoredProcedure = "SP_UTILITY_LOGIN_MGT";
            parms.Calltype = "UPDATEHCNTLMT";
            parms.Comp1 = comcod;
            parms.Desc01 = dcnumber;

            ServiceResponse<bool> response = await Task.FromResult(_unitOfWork.SP_Call.Execute14ServiceResponse(parms));
            return response;
        }

        public async Task<ServiceResponse<bool>> AddLogRecord(string comcod, string tempId, string usrid, string sesionid, string eventtype, string eventdesc, string eventdesc2)
        {
            ClassProAccessParams parms = new ClassProAccessParams();
            parms.StoredProcedure = "SP_ENTRY_EVENTLOG";
            parms.Calltype = "ADDEVENTLOG";
            parms.Comp1 = comcod;
            parms.Desc01 = tempId;
            parms.Desc02 = usrid;
            parms.Desc03 = sesionid;
            parms.Desc04 = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
            parms.Desc05 = eventtype;
            parms.Desc06 = eventdesc;
            parms.Desc07 = eventdesc2;

            ServiceResponse<bool> response = await Task.FromResult(_unitOfWork.SP_Call.Execute14ServiceResponse(parms, comcod));
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdatePassword(string comcod, string usrid, string oldPass, string newPass)
        {
            ClassProAccessParams parms = new ClassProAccessParams();
            parms.StoredProcedure = "SP_UTILITY_LOGIN_MGT";
            parms.Calltype = "UPDATEPASSWORD";
            parms.Comp1 = comcod;
            parms.Desc01 = usrid;
            parms.Desc02 = oldPass;
            parms.Desc03 = newPass;

            ServiceResponse<bool> response = await Task.Run(() => _unitOfWork.SP_Call.OneRecordServiceResponse<bool>(parms));
            return response;
        }

    }
}
