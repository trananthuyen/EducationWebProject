using Entitites;
using ServiceContracts.DTO;
using Entitites;
using System.Linq;
using ServiceContracts;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly AccountsDbContext _dbAccounts;
        private Account? _accountHasLogin;
        public AccountService(AccountsDbContext accountsDbContext)
        {

            _dbAccounts = accountsDbContext;
            /*if(true)
            {
                _accounts = new List<Account>()
                {
                    new Account()
                    {
                        accountName = "trananthuyen37",
                        password = "7789234"
                    },

                    new Account()
                    {
                        accountName = "maithanhhoa22",
                        password = "77492"
                    }

                };
            }*/
        }

        public void LoginAccount(AccountAddRequest? accountAddRequest)
        {

            if (accountAddRequest.accountName == null)
            {
                throw new ArgumentException("Account name can't be blank!");
            }

            if (accountAddRequest.password == null)
            {
                throw new ArgumentException("please enter password!");
            }



            Account loginAccount = _dbAccounts.AccountName.FirstOrDefault(temp => temp.accountName == accountAddRequest.accountName);

            if (loginAccount == null)
            {
                throw new ArgumentException("Account Name is not exists");
            }
            else
            {
                Account loginAccountData = _dbAccounts.AccountName.FirstOrDefault(temp => temp.accountName == loginAccount.accountName);

                if (loginAccount.password.Equals(accountAddRequest.password))
                {
                    _accountHasLogin = loginAccountData;

                }
                else
                {

                    throw new ArgumentException("wrong password!");

                }
            }



        }

        public void LogOutAccount()
        {
            _accountHasLogin = null;
        }

        public void SignUpAccount(AccountAddRequest? accountAddRequest)
        {

            if (accountAddRequest.accountName == null)
            {
                throw new ArgumentException("Account name can't be blank!");
            }

            if (accountAddRequest.password == null)
            {
                throw new ArgumentException("please enter password!");
            }

            Account SignUpAccount = _dbAccounts.AccountName.FirstOrDefault(temp => temp.accountName == accountAddRequest.accountName);

            if (SignUpAccount != null)
            {
                throw new ArgumentException("Account Name already exists");
            }

            if (!accountAddRequest.password.Equals(accountAddRequest.rpassword))
            {
                throw new ArgumentException("password is not same");
            }

            Account newAccount = accountAddRequest.ToAccount();

            _dbAccounts.Add(newAccount);

            _dbAccounts.SaveChanges();


        }




    }
}