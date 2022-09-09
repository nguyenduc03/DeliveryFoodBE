using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IWardRepository : IRepository<Ward>
    {
        List<Ward> GetWardList(int id);

    }
    public class WardRepository : RepositoryBase<Ward>, IWardRepository
    {
        public WardRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }

        public List<Ward> GetWardList(int id)
        {
            var query = _dbcontext.Ward.Where(s=> s.Id_District == id ) ;
            return query.ToList();
            throw new NotImplementedException();
        }
    }
}
