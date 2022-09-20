using Lib.Entity;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lib.Repositories
{
    public interface IFoodRepository : IRepository<Food>
    {
        List<Food> GetFoodList1(List<Food> input);
        List<Food> GetFoodList();
        List<Food> GetFoodList(int code);
        string UpdateFood(Food Food);
        List<Food> GetRecentFood();
        List<List<Food>> GetFoodDiscount();
        List<Food> GetMoreFood(int id);
        string InsertFood(Food st);
        List<Food> GetTopFood();
        double GetPrice(int id);
        List<Food> GetFoodByName(string name);
        List<Food> GetPopularFoodList();
    }
    public class FoodRepository : RepositoryBase<Food>, IFoodRepository
    {
        public FoodRepository(ApplicationDbContext dbContext) : base(dbContext) { 

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

        public List<Food> GetFoodList()
        {
                var query = _dbcontext.Food.Take(10);
                return query.ToList();
        }
        public string UpdateFood(Food food)
        {
            try
            {
                _dbcontext.Update(food);
                _dbcontext.SaveChanges();
                return "Done";
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
        }

        public string InsertFood(Food st)
        {
            try
            {
                _dbcontext.Food.Add(st);
                _dbcontext.SaveChanges ();
                return "Done";
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
        }

        public double GetPrice(int id)
        {
            return _dbcontext.Food.FirstOrDefault(s => s.ID_Food == id).Price;
        }
        public List<Food> GetPopularFoodList()
        {
            List<Food> list = GetFoodList();
            int[] count = new int[list.Count];
            Food[] foods = list.ToArray();
            List<InvoiceDetail> invoiceDetails = _dbcontext.InvoiceDetail.ToList();
            foreach (var item in invoiceDetails)
            {
                for (int i = 0; i < foods.Length; i++)
                {
                    if (item.ID_Food == foods[i].ID_Food)
                    {
                        count[i] += item.Quantity;
                    }
                }
            }
            return Sort(count, foods);

        }
        public List<Food> Sort(int[] count, Food[] foods)
        {
            for (int i = 0; i < foods.Length - 1; i++)
            {
                for (int j = i + 1; j < foods.Length; j++)
                {
                    if (count[i] < count[j])
                    {
                        Swap(count[i], count[j]);
                        Food food = foods[j];
                        foods[j] = food;
                        foods[i] = food;
                    }
                }
            }
            return foods.ToList();
        }
        private void Swap(int v1, int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;

        }
        static List<int> quicksort(List<int> list)
        {
            if (list.Count <= 1) return list;
            int pivotPosition = list.Count / 2;
            int pivotValue = list[pivotPosition];
            list.RemoveAt(pivotPosition);
            List<int> smaller = new List<int>(); 
            List<int> greater = new List<int>();
            foreach (int item in list)
            {
                if (item < pivotValue)
                {
                    smaller.Add(item);
                }
                else
                {
                    greater.Add(item);
                }
            }
            List<int> sorted = quicksort(smaller);
            sorted.Add(pivotValue);
            sorted.AddRange(quicksort(greater));
            return sorted;
        }

        public List<List<Food>> GetFoodDiscount()
        {
            List<Food> foods = _dbcontext.Food.ToList();
            List<List<Food>> list = new List<List<Food>>();
            List<Discount> discounts = _dbcontext.Discount.ToList();
            foreach (var item in discounts)
            {
                if(DateTime.Parse(item.Date_End) >= DateTime.Now.Date)
                {
                    List<Food> temp = new List<Food>();
                    foreach (var food in foods)
                    {
                        if(food.ID_Discount == item.ID_Discount)
                            temp.Add(food);
                    }
                    list.Add(temp);
                }
            }
            return list;
        }

        public List<Food> GetMoreFood(int id)
        {
            var foods = _dbcontext.Food.Where(s=>s.ID_Food>id && s.ID_Food<=(id+10) && s.Available==true ).ToList();
            return foods;
        }

        public List<Food> GetTopFood()
        {
            var foods = _dbcontext.Food.Where(s=>s.Available==true).OrderByDescending(s => s.Rating).Take(10);
            return foods.ToList();
        }
    }
}
