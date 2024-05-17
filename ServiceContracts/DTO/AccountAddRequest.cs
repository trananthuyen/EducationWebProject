using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitites;

namespace ServiceContracts.DTO
{
    public class AccountAddRequest
    {
       
        public string? accountName { get; set; }

        
        public string? password { get; set; }

     
        public string? rpassword { get; set; }

        public Account ToAccount()
        {
            return new Account()
            {
                accountName = this.accountName,
                password = this.password

            };
        }
    }
}
