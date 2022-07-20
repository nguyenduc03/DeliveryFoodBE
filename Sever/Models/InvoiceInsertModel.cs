using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class InvoiceInsertModel
    {

        public int ID_Discount { get; set; }
        public string SDT { get; set; }
        public float Total_Money  { get; set; }

    }
}
