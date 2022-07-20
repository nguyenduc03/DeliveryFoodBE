using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class InvoiceDetailService
    {
        private IInvoiceDetailRepository InvoiceDetailRepository { get; set; }
        private ApplicationDbContext dbContext;
        public InvoiceDetailService(ApplicationDbContext dbContext, IInvoiceDetailRepository invoiceDetailRepository) {
            this.InvoiceDetailRepository = invoiceDetailRepository;
            this.dbContext = dbContext;
        }
        public void Save() {
            dbContext.SaveChanges();
        }
       
        public List<InvoiceDetail> GetInvoiceDetail(int ID_Invoice)
        {
            return InvoiceDetailRepository.GetInvoiceDetail(ID_Invoice);
        }
       
    }
}
