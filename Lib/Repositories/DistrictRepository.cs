using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IDistrictRepository : IRepository<District>
    {
        List<District> GetDistrictList(int Id_Province);

    }
    public class DistrictRepository : RepositoryBase<District>, IDistrictRepository
    {
        public DistrictRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }

        public List<District> GetDistrictList(int Id_Province)
        {
            var query = _dbcontext.District.Where(x => x.Id_Province == Id_Province);
            return query.ToList();
            throw new NotImplementedException();
        }
    }
}
