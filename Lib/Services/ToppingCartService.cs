using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class ToppingCartService
    {
        private IToppingCartRepository ToppingCartRepository { get; set; }
        private ApplicationDbContext dbContext;
        public ToppingCartService(ApplicationDbContext dbContext, IToppingCartRepository ToppingCartRepository) {
            this.ToppingCartRepository = ToppingCartRepository;
            this.dbContext = dbContext;
        }
        public void Save() {
            dbContext.SaveChanges();
        }
        
        public List<ToppingDetailCart> GetToppingList(string SDT)
        {
            return ToppingCartRepository.GetToppingDetailCartList(SDT);
        }

        public string InsertToppingCart(ToppingDetailCart Topping) {
            try
            {
                dbContext.ToppingDetailCart.Add(Topping);
                Save();
                return "Done";
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
           
        }
        public string UpdateToppingCart(ToppingDetailCart Topping)
        {
            try
            {
                dbContext.ToppingDetailCart.Update(Topping);
                Save();
                return "Done";
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
        }
        public string DeleteToppingCart(ToppingDetailCart Topping)
        {
            try
            {
                dbContext.ToppingDetailCart.Remove(Topping);
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
