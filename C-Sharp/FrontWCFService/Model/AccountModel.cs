using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontWCFService.Model
{
    public class AccountModel
    {
        private List<Account> listAccounts = new List<Account>();

        public AccountModel()
        {
            listAccounts.Add(new Account { Username = "acc1", Password = "123" });
            listAccounts.Add(new Account { Username = "acc2", Password = "123" });
            listAccounts.Add(new Account { Username = "acc3", Password = "123" });
        }

        public bool Login(string username , string password)
        {
            return listAccounts.Count(acc => acc.Username.Equals(username) && acc.Password.Equals(password)) > 0;
        }
    }
}