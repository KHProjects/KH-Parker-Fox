using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace ParkerFox.Infrastructure.Data
{
    public class ActiveSessionManager : IActiveSessionManager
    {
        private const string sessionKey = "currentSession";
        private readonly IRequestState _requestState;

        public ActiveSessionManager(IRequestState requestState)
        {
            _requestState = requestState;
        }

        public ISession GetActiveSession()
        {
            if (Current == null)
            {
                var session = DataConfig.GetSession();
                Current = session;
                return session;
            }
            return Current;
        }

        protected ISession Current
        {
            get
            {
                return _requestState.Get<ISession>(sessionKey);
            }
            set
            {
                _requestState.Store(sessionKey, value);
            }
        }
    }
}
