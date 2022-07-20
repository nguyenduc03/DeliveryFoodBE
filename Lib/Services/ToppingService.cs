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
    public class ToppingService
    {
        private IToppingRepository ToppingRepository { get; set; }
        private ApplicationDbContext dbContext;
        public ToppingService(ApplicationDbContext dbContext, IToppingRepository ToppingRepository) {
            this.ToppingRepository = ToppingRepository;
            this.dbContext = dbContext;
        }
        public void Save() {
            dbContext.SaveChanges();
        }
        
        public List<Topping> GetToppingList(int input)
        {
            return ToppingRepository.GetToppingList(input);
        }

        public string InsertTopping(Topping st) {
            try
            {
                dbContext.Topping.Add(st);
                Save();
                return "Done";
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
           
        }
        public string UpdateTopping(Topping st)
        {
            try
            {
                dbContext.Topping.Update(st);
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
