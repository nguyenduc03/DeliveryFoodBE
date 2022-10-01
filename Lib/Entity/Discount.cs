using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class Discount
    {
        [Key]
        public int ID_Discount { get; set; }
        public string Name { get; set; }
        public string Date_Start { get; set; }
        public string Date_End { get; set; }
        public string Description { get; set; }
        public int Percent { get; set; }
        public string Code { get; set; }
        public bool Available { get; set; }
        public bool ForFood { get; set; }   

    }
}
