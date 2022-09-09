using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IProvinceRepository : IRepository<Province>
    {
        List<Province> GetProvinceList();

    }
    public class ProvinceRepository : RepositoryBase<Province>, IProvinceRepository
    {
        public ProvinceRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }

        public List<Province> GetProvinceList()
        {
            var query = _dbcontext.Province;
            return query.ToList();
            throw new NotImplementedException();
        }
    }
}
