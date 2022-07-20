﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class InvoiceDetail
    {

        [Key]
        public int ID_invoice { get; set; }
        [Key]
        public int ID_Food { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total_Money { get; set; }

    }
}
