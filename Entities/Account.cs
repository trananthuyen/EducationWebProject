using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites
{
    public class Account
    {
        [Key]
        public string? accountName { get; set; }
        public string? password { get; set; }


    }
}
