using PTL.Data.Repository.IRepository;
using PTL.Entity;
using PTL.Service.IRepository;
using static PTL.Entity.Auth.ECommon;

namespace PTL.Data.WorkRepo
{
    public class CommonRepository : ICommon
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public CommonRepository(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }


        public async Task<ServiceResponse<IEnumerable<EModule>>> GetCompanyModule(string comcod, string usrid)
        {
            ClassProAccessParams parms = new ClassProAccessParams();
            parms.StoredProcedure = "SP_UTILITY_LOGIN_MGT";
            parms.Calltype = "GETCOMMODULE";
            parms.Comp1 = comcod;
            parms.Desc01 = usrid;
            var response = await Task.FromResult(_unitOfWork.SP_Call.ListServiceResponse<EModule>(parms));
            return response;
        }


    }
}
