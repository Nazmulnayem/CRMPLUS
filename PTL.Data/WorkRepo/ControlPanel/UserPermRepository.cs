using PTL.Data.Repository.IRepository;
using PTL.Service.IRepository.ControlPanel;

namespace PTL.Data.WorkRepo.ControlPanel
{
    public class UserPermRepository : IUserPerm
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public UserPermRepository (IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }
    }
}
