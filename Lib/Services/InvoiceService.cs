using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class InvoiceService
    {
        private IInvoiceRepository InvoiceRepository { get; set; }
        private ApplicationDbContext dbContext;
        public InvoiceService(ApplicationDbContext dbContext, IInvoiceRepository invoiceRepository) {
            this.InvoiceRepository = invoiceRepository;
            this.dbContext = dbContext;
        }
        public void Save() {
            dbContext.SaveChanges();
        }
        public List<Invoice> GetInvoiceList() {
            return InvoiceRepository.GetInvoiceList();
        }
        public List<Invoice> GetInvoiceList(string code)
        {
            return InvoiceRepository.GetInvoiceList(code);
        }
        public string InsertInvoice(Invoice st) {
            try
            {
                dbContext.Invoice.Add(st);
                Save();
                return "Done";
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
        }
    }
}
