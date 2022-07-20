using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class ToppingDetailCart
    {
        [Key]
        public string SDT { get; set; }
        [Key]
        public string ID_Food { get; set; }
        [Key]
        public string ID_Topping { get; set; }

    }
}
