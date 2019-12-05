using Service.Pattern;
using PiDev.Domain.Entities;
using Solution.Data.Infrastructure;

namespace PiDev.Service
{
    public class ClaimService : Service<claim>,IClaimService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(factory);
        public ClaimService():base(utk)
        {

        }

    }
}
