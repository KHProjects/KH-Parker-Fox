using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagHag.Site.Components
{
    public class UserConnectionRepository : IUserConnectionRepository
    {
        private static readonly ConcurrentDictionary<string, UserConnected> users = new ConcurrentDictionary<string, UserConnected>();

        public UserConnected GetByUserName(string userName)
        {
            return users.GetOrAdd(userName, _ => new UserConnected {Name = userName});
        }
    }
}