
using Microsoft.Extensions.Configuration;
using PTL.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTL.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly IConfiguration db;
        public ISP_Call SP_Call { get; set; }
        public UnitOfWork(IConfiguration _db)
        {
            SP_Call = new SP_Call(_db);

        }
    }
}
