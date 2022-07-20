using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories
{
    public interface IFoodRepository : IRepository<Food>
    {
        List<Food> GetFoodList1(List<Food> input);
        List<Food> GetFoodList();
        List<Food> GetFoodList(int code);
        List<Food> UpdateFood(Food Food);
        List<Food> GetRecentFood();
        List<Food> GetFoodByName(string name);
    }
    public class FoodRepository : RepositoryBase<Food>, IFoodRepository
    {
        public FoodRepository(ApplicationDbContext dbContext) : base(dbContext) { 

        }
        public List<Food> GetFoodList() {
            try
            {
                var query = _dbcontext.Food;
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        public List<Food> GetFoodList(int code)
        {
            try
            {
                var query = _dbcontext.Food.Where(s => s.ID_Category == code);
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
           

        public List<Food> GetRecentFood()
        {
            var query = _dbcontext.Food.OrderByDescending(s => s.DateAdd);
            return query.ToList();
            throw new NotImplementedException();
        }
        public List<Food> GetFoodByName (string name)
        {
            List<Food> listFood = _dbcontext.Food.ToList();
            string[] lists = name.Split(" ");
            if(lists.Count() == 0)
                return null;
            List<Food> list = listFood.Where(s => s.Name_Food.Contains(name)).ToList();
            listFood = RemoveFood(listFood, list);
            foreach (var item in lists)
            {
                List<Food> query = listFood.Where(s => s.Name_Food.Contains(item)).ToList();
                listFood = RemoveFood(listFood, query);
                list.AddRange(query);;
            }
            return list;
        }

        private List<Food> RemoveFood(List<Food> foods,List<Food> foods1)
        {
            foreach (var item2 in foods1)
            {
                foods.Remove(item2);
            }
            return foods;
        }
        public List<Food> UpdateFood(Food Food)
        {
            Food temp = (Food)_dbcontext.Food.Where(s => s.ID_Food == Food.ID_Food);
            temp.Picture = Food.Picture;
            temp.Price = Food.Price;
            temp.ID_Category = Food.ID_Category;
            temp.DateAdd = Food.DateAdd;
            temp.Description = Food.Description;
            temp.Name_Food = Food.Name_Food;

            throw new NotImplementedException();
        }

        List<Food> IFoodRepository.GetFoodList()
        {
            return GetFoodList();
            throw new NotImplementedException();
        }

        public List<Food> GetFoodList1(List<Food> input)
        {
            List<Food> list = new List<Food>();
            foreach (var item in input)
            {
                list.Add(_dbcontext.Food.Find(item.ID_Food)) ;

            }
            return list;
            throw new NotImplementedException();
        }
    }
}
