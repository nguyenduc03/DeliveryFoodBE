using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IToppingCartRepository : IRepository<ToppingDetailCart>
    {
        List<ToppingDetailCart> GetToppingDetailCartList(string SDT);
    }
    public class ToppingCartRepository : RepositoryBase<ToppingDetailCart>, IToppingCartRepository
    {
        public ToppingCartRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }

        public List<ToppingDetailCart> GetToppingDetailCartList(string SDT)
        {
            try
            {
                var query = _dbcontext.ToppingDetailCart.Where(s => s.SDT == SDT);
                return query.ToList();
            }
            catch (Exception )
            {
                throw;
            }
            throw new NotImplementedException();
        }
    }
}
