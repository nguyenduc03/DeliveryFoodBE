using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class CartService
    {
        private ICartRepository CartRepository { get; set; }
        private IInvoiceRepository invoiceRepository { get; set; }
        private IInvoiceDetailRepository invoiceDetailRepository { get; set; }
        private ApplicationDbContext dbContext;
        public CartService(ApplicationDbContext dbContext, ICartRepository CartRepository,IInvoiceRepository invoiceRepository, IInvoiceDetailRepository invoiceDetailRepository) {
            this.CartRepository = CartRepository;
            this.dbContext = dbContext;
            this.invoiceRepository = invoiceRepository;
     
            this.invoiceDetailRepository = invoiceDetailRepository;
        }
        
        public void Save() {
            dbContext.SaveChanges();
        }
        public List<Cart> GetCart(Account account) {
            return CartRepository.GetCartlList(account.SDT);
        }
        
        public string UpdateCart(Cart Cart)
        {
            try
            {
                dbContext.Cart.Update(Cart);
                Save();
                return "Done";
            }
            catch (Exception e )
            {
                return e.Message;
                throw;
            }
        }

        public string Payment(Account account) {

            try
            {
                List<Cart> carts=   CartRepository.GetCartlList(account.SDT);
                if (carts.Count == 0)
                    return "Null";
             // init Invoice
                Invoice invoice = new Invoice();
                invoice.SDT = account.SDT;
                invoice.Date_Create = DateTime.Now.ToShortDateString();
                invoice.Total_Money = 0;
                invoiceRepository.Add(invoice);
                dbContext.SaveChanges();
                // them vao deatil      // xoa cart 
                // luu 
                foreach (var item in carts)
                {
                    InvoiceDetail invoiceDetail = new InvoiceDetail();
                    invoiceDetail.ID_invoice = invoice.ID_invoice;
                    invoiceDetail.ID_Food = item.ID_Food;
                    invoiceDetail.Quantity = item.Quantity;
                    invoiceDetail.Price = dbContext.Food.FirstOrDefault(f => f.ID_Food == item.ID_Food).Price;
                    invoiceDetail.Total_Money = invoiceDetail.Price * invoiceDetail.Quantity;
                    invoice.Total_Money += (float) invoiceDetail.Total_Money;
                    dbContext.InvoiceDetail.Add(invoiceDetail);
                    dbContext.SaveChanges();
                    dbContext.Cart.Remove(item);
                    dbContext.SaveChanges();
                }
                string result= "Done";
                Save();
                return result;
            }
            catch (Exception e )
            {
                return e.Message;
                throw;
            }
        }

        public string  InsertCart(Cart Cart) {
            try
            {
                dbContext.Cart.Add(Cart);
                Save();
                return "Done";
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
        }
        public string GetQR (Account account)
        {
            return CartRepository.GetQR(account.SDT,account.Password);
        }
    }
}
