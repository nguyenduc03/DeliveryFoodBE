using Lib.Entity;
using Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public class FoodService
    {
        private IFoodRepository FoodRepository { get; set; }
        private ApplicationDbContext dbContext;
        public FoodService(ApplicationDbContext dbContext, IFoodRepository FoodRepository) {
            this.FoodRepository = FoodRepository;
            this.dbContext = dbContext;
            
        }
        
        public void Save() {
            dbContext.SaveChanges();
        }
        public List<Food> GetFoodList() {
            return FoodRepository.GetFoodList();
        }
        public List<Food> GetFoodList(List<Food>input)
        {
            return FoodRepository.GetFoodList1(input);
        }
        public List<Food> GetFoodByCategory(int code)
        {
            return FoodRepository.GetFoodList(code);
        }
        public List<Food> GetFoodByName (string Name)
        {
            return FoodRepository.GetFoodByName (Name);
        }
        public string UpdateFood(Food food)
        {
            try
            {
                dbContext.Update(food);
                Save();
                return "Done";
            }
            catch (Exception e )
            {
                return e.Message;
                throw;
            }
        }

        public List<Food> GetRecentFood()
        {
            return FoodRepository.GetRecentFood();
        }

        public string  InsertFood(Food st) {
            try
            {
                dbContext.Food.Add(st);
                Save();
                return "Done";
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
        }

        public Food GetFoodByID(int ID_Input)
        {
            return FoodRepository.GetById(ID_Input);
        }

        public List<Food> GetPopularFoodList()
        {
            List<Food> list = GetFoodList();
            int [] count = new int [list.Count];
            Food [] foods = list.ToArray();
            List<InvoiceDetail> invoiceDetails = dbContext.InvoiceDetail.ToList();
            foreach (var item in invoiceDetails)
            {
                for (int i = 0; i < foods.Length; i++)
                {
                    if(item.ID_Food == foods[i].ID_Food)
                    {
                        count[i] += item.Quantity;
                    }
                }
            }
            return Sort(count, foods);

        }

        public List<Food > Sort (int []count,Food[] foods)
        {
            for (int i = 0; i < foods.Length-1; i++)
            {
                for (int j = i+1; j < foods.Length; j++)
                {
                    if(count[i] < count[j])
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

        public double GetPrice ( int id)
        {
            return dbContext.Food.FirstOrDefault(s=>s.ID_Food == id).Price;
        }
    }
}
