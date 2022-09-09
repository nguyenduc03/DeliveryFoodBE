using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class Ward
    {

        [Key]
        public int Id_Ward { get; set; }
        public int Id_District { get; set; }
        public string Name_Ward { get; set; }

    }
}
