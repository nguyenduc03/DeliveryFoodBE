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
        public List<Food> GetTopFoodDiscount()
        {
            return FoodRepository.GetTopFoodDiscount();
        }
        public List<Food> GetFoodList(List<Food> input)
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
        public List<Food> GetTopFood()
        {
            return FoodRepository.GetTopFood();
        }
        public List<Food> GetMoreFood (int id)
        {
            return FoodRepository.GetMoreFood(id);
        }
        public string UpdateFood(Food food)
        {
            return FoodRepository.UpdateFood(food);
        }

        public List<Food> GetRecentFood()
        {
            return FoodRepository.GetRecentFood();
        }

        public string  InsertFood(Food st) {
            return FoodRepository.InsertFood(st);

        }

        public Food GetFoodByID(int ID_Input)
        {
            return FoodRepository.GetById(ID_Input);
        }

        public List<Food> GetPopularFoodList()
        {

            return FoodRepository.GetPopularFoodList();

        }
        public double GetPrice ( int id)
        {
            return FoodRepository.GetPrice(id);
        }

        public List<List<Food>> GetFoodDiscount()
        {
            return FoodRepository.GetFoodDiscount();
        }
    }
}
