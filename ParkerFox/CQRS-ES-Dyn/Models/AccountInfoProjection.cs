using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_ES.Models
{
    public class AccountInfoProjection
    {
        public List<AccountInfo> AccountInfos { get; set; }

        public AccountInfoProjection()
        {
            AccountInfos = new List<AccountInfo>();
        }

        public void Handle(AccountRegisteredEvent @event)
        {
            if (AccountInfos.All(x => x.AccountId != @event.AccountId))
                AccountInfos.Add(new AccountInfo {AccountId = @event.AccountId});
        }
    }
}