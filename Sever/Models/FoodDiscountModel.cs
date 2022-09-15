using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class FoodDiscountModel
    {
        public int ID_Category { get; set; }
        public string Name_Food { get; set; }
        public string Name_Discount { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public float OldPrice { get; set; }
        public float DiscountPrice { get; set; }
    }
}
