using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using FrontWCFService.Model;

namespace FrontWCFService.App_Code
{
    public class Validator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            AccountModel am = new AccountModel();

            if (am.Login(userName, password))
                return;

            throw new SecurityTokenException("Account's invalid");
        }
    }
}