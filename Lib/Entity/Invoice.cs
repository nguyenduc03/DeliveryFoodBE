using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class Invoice
    {

        [Key]
        public int ID_invoice { get; set; }
        public int ID_Discount { get; set; }
        public string SDT { get; set; }
        public float Total_Money  { get; set; }
        public string Date_Create { get; set; }

    }
}
