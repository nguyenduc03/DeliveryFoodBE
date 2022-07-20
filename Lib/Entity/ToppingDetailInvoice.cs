using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class ToppingDetailInvoice
    {
        [Key]
        public int ID_invoice { get; set; }
        [Key]
        public int ID_Food { get; set; }
        [Key]
        public int ID_Topping { get; set; }
        public float Amount { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

    }
}
