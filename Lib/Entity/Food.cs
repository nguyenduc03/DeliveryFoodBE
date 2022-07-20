using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class Food
    {

        [Key]
        public int ID_Food { get; set; }
        public int ID_Category { get; set; }
        public string Name_Food { get; set; }
        public string DateAdd { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public float Price { get; set; }
        public bool Available { get; set; }
        public float Rating { get; set; }
        public int ID_Discount { get; set; }

    }
}
