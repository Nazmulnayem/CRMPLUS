using PTL.Data.Repository.IRepository;
using PTL.Entity.Auth;
using PTL.Entity;
using PTL.Service.IRepository.ControlPanel;

namespace PTL.Data.WorkRepo.ControlPanel
{
    public class CompRepository : IComp
    {
        private IUnitOfWork _unitOfWork { get; set; }
        private readonly IDataAccessOLDB _dataAccessOLDB;

        public CompRepository(IUnitOfWork unitOfWork, IDataAccessOLDB dataAccessOLDB)
        {
            _unitOfWork = unitOfWork;
            _dataAccessOLDB = dataAccessOLDB;
        }

        public async Task<ServiceResponse<EClassCompany>> GetCompanyInfo(string comcod)
        {
            string sqlQuery = "select  comsnam, comnam, comadd1, comadd2, comadd3  from compinf where comcod = @comcod";
            var response = await _dataAccessOLDB.GetCompanyInfo(sqlQuery, comcod);
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateCompInfo(EClassCompany obj, string comcod)
        {
            ClassProAccessParams parms = new ClassProAccessParams();
            parms.StoredProcedure = "SP_UTILITY_LOGIN_MGT";
            parms.Calltype = "UPDATECOMPINFO";
            parms.Comp1 = comcod;
            parms.Desc01 = obj.comsnam;
            parms.Desc02 = obj.comnam;
            parms.Desc03 = obj.comadd1;
            parms.Desc04 = obj.comadd2;
            parms.Desc05 = obj.comadd3;

            ServiceResponse<bool> response = await Task.Run(() => _unitOfWork.SP_Call.OneRecordServiceResponse<bool>(parms));
            return response;
        }

        public async Task<ServiceResponse<string>> UpdateCompInfoCompDB(EClassCompany obj, string comcod)
        {
            string sqlQuery = "update compinf set comsnam = '" + obj.comsnam + "', comnam = '" + obj.comnam + "', comadd1 = '" + obj.comadd1 + "', comadd2 = '" + obj.comadd2 + "', comadd3 = '" + obj.comadd3 + "' where comcod = '" + comcod + "'";
            var response = await _dataAccessOLDB.UpdateCompInfo(sqlQuery, obj, comcod);
            return response;
        }
    }
}
