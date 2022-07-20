using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Entity
{
    public class AccountInsertModel
    {

       
        public string SDT { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }

    }
}
