using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class DiscountService
    {
        private IDiscountRepository DiscountRepository { get; set; }
        private ApplicationDbContext dbContext;
        public DiscountService(ApplicationDbContext dbContext, IDiscountRepository discountRepository)
        {
            this.DiscountRepository = discountRepository;
            this.dbContext = dbContext;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
        public Discount GetDiscount(int Id_Discount)
        {
            return DiscountRepository.GetDiscount(Id_Discount);
        }
        public List<Discount> GetDiscountAvailable()
        {
            return DiscountRepository.GetDiscountAvailable();
        }
        
            public List<Discount> GetDiscountInvoice()
        {
            return DiscountRepository.GetDiscountInvoice();
        }
    }
}
