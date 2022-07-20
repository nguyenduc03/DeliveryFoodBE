using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        List<Invoice> GetInvoiceList();
        List<Invoice> GetInvoiceList(string SDT);
    }
    public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }
        public List<Invoice> GetFoodList() {
            try
            {
                var query = _dbcontext.Invoice;
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public List<Invoice> GetInvoiceList(string SDT) {
            try
            {
                var query = _dbcontext.Invoice.Where(s => s.SDT == SDT);
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        public List<Invoice> GetInvoiceList()
        {
            throw new NotImplementedException();
        }

      
    }
}
