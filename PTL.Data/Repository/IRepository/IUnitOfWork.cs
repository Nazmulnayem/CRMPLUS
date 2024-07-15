using System;
using System.Collections.Generic;
using System.Text;

namespace PTL.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ISP_Call SP_Call { get; }
    }
}
