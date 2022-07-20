using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetCategoryList();
        List<Category> GetCategoryList(int code);
    }
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }
        public List<Category> GetCategoryList() {
            try
            {
                var query = _dbcontext.Category;
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public List<Category> GetCategoryList(int code) {
            try
            {
               
                var query = _dbcontext.Category.Where(s => s.ID_Category == code);
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
         
        }

       
    }
}
