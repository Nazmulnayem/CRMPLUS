using PTL.Data.Repository.IRepository;
using PTL.Entity;
using PTL.Entity.ControlPanel;
using PTL.Service.IRepository.ControlPanel;

namespace PTL.Data.WorkRepo.ControlPanel
{
    public class CompPermRepository : ICompPerm
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public CompPermRepository(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public async Task<ServiceResponse<IEnumerable<EUSRCOMPFRMINF>>> GetUserCompanyFrm(string comcod, string moduleid="")
        {
            ClassProAccessParams parms = new ClassProAccessParams();
            parms.StoredProcedure = "SP_UTILITY_LOGIN_MGT";
            parms.Calltype = "GETUSRCOMPFRMINF";
            parms.Comp1 = comcod;
            parms.Desc01 = moduleid;
            var response = await Task.FromResult(_unitOfWork.SP_Call.ListServiceResponse<EUSRCOMPFRMINF>(parms));
            return response;
        }
    }
}
