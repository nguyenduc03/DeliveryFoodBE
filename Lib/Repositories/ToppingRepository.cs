using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IToppingRepository : IRepository<Topping>
    {
        List<Topping> GetToppingList();
        List<Topping> GetToppingList(int code);
    }
    public class ToppingRepository : RepositoryBase<Topping>, IToppingRepository
    {
        public ToppingRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }
        public List<Topping> GetToppingList() {
            try
            {
                var query = _dbcontext.Topping;
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public List<Topping> GetToppingList(int code) {
            try
            {
                var query = _dbcontext.Topping.Where(s => s.ID_Category == code);
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
         
        }

       
    }
}
