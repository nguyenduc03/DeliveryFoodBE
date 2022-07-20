using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class Category
    {

        [Key]
        public int ID_Category { get; set; }
        public string Name_Category { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

    }
}
