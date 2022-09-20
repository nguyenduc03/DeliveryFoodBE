using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        Discount GetDiscount(int IdDiscount);
        List<Discount> GetDiscountAvailable();

    }
    public class DiscountRepository : RepositoryBase<Discount>, IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }

        public Discount GetDiscount(int IdDiscount)
        {
            var discount = _dbcontext.Discount.FirstOrDefault(s => s.ID_Discount == IdDiscount);
            return discount;
        }

        public List<Discount> GetDiscountAvailable()
        {
           var discounts = _dbcontext.Discount.Where(s => s.Available == true).Take(10);
            return discounts.ToList();
        }
    }
}
