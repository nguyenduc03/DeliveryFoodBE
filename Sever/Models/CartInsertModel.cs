using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class CartInsertModel
    {
        public string SDT { get; set; }
        public int ID_Food { get; set; }
        public float Total_Money { get; set; }
        public int Quantity { get; set; }
    }
}
