using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class CategoryService
    {
        private ICategoryRepository CategoryRepository { get; set; }
        private ApplicationDbContext dbContext;
        public CategoryService(ApplicationDbContext dbContext, ICategoryRepository CategoryRepository) {
            this.CategoryRepository = CategoryRepository;
            this.dbContext = dbContext;
        }
        public void Save() {
            dbContext.SaveChanges();
        }
        public List<Category> GetCategoryList() {
            return CategoryRepository.GetCategoryList();
        }
        public List<Category> GetStudentList(int code)
        {
            return CategoryRepository.GetCategoryList(code);
        }
        public void InsertCategory(Category st) {
            dbContext.Category.Add(st);
            Save();
        }
    }
}
