using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitites;

namespace ServiceContracts.DTO
{
    public class AccountResponse
    {
        public string? accountName { get; set; }
        public string? password { get; set; }

        
    }

    public static class AccountExtensions
    {
        public static AccountResponse ToAccountResponse(this Account account)
        {
            return new AccountResponse()
            {
                accountName = account.accountName,
                password = account.password
            };
        }
    }
}
