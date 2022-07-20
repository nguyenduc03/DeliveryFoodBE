using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class Topping
    {

        [Key]
        public int ID_Topping { get; set; }
        public int ID_Category { get; set; }
        public string Name_Topping { get; set; }
        public float Price { get; set; }
        public string IMG { get; set; }

    }
}
