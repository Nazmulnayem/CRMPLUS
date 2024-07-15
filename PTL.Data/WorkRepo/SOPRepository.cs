using PTL.Data.Repository.IRepository;
using PTL.Service.IRepository;

namespace PTL.Data.WorkRepo
{
    public class SOPRepository : ISOP
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public SOPRepository(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }


    }
}
