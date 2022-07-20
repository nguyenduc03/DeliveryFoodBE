using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IInvoiceDetailRepository : IRepository<InvoiceDetail>
    {
        List<InvoiceDetail> GetInvoiceDetail(int coID_Invoicede);
    }
    public class InvoiceDetailRepository : RepositoryBase<InvoiceDetail>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }


        List<InvoiceDetail> IInvoiceDetailRepository.GetInvoiceDetail( int ID_Invoice)
        {
            try
            {
                var temp = _dbcontext.InvoiceDetail.Where(s => s.ID_invoice == ID_Invoice);

                return temp.ToList(); 
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }
    }
}
