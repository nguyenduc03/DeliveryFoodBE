using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Services;

namespace Lib.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        List<Cart> GetCartlList();
        List<Cart> GetCartlList(string SDT);
    }
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }

        public List<Cart> GetCartlList()
        {
            
            throw new NotImplementedException();
        }

        public List<Cart> GetCartlList(string SDTInput)
        {
            try
            {

                var query = _dbcontext.Cart.Where(s => s.SDT == SDTInput);
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public void CleanCart (string sdt)
        {
            List<Cart> carts = GetCartlList(sdt);
            foreach (var item in carts)
            {
                _dbcontext.Cart.Remove(item);
                _dbcontext.SaveChanges();
            }
        }

    }
}
