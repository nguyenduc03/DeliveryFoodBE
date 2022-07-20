using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class ToppingCartInsertModel

    {
        public string SDT { get; set; }
        public string ID_Food { get; set; }
        public string ID_Topping { get; set; }
    }
}
