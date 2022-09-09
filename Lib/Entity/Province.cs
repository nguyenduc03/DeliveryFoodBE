using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class Province
    {

        [Key]
        public int Id_Province { get; set; }
        public string Name_Province { get; set; }

    }
}
