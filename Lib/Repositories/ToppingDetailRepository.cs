using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IToppingDetailRepository : IRepository<ToppingDetailInvoice>
    {
        List<ToppingDetailInvoice> GetToppingDetailList();
        List<ToppingDetailInvoice> GetToppingDetailList(int code);
    }
    public class ToppingDetailRepository : RepositoryBase<ToppingDetailInvoice>, IToppingDetailRepository
    {
        public ToppingDetailRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }

     

        public List<ToppingDetailInvoice> GetToppingDetailList() {
            try
            {
                var query = _dbcontext.ToppingDetail;
                return query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public List<ToppingDetailInvoice> GetToppingDetailList(int code) {
            try
            {
           
                var query = _dbcontext.ToppingDetail.Where(s => s.ID_invoice == code);
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
         
        }

       
    }
}
