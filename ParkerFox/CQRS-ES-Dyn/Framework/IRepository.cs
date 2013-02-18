using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_ES.Framework
{
    public interface IRepository
    {
        T GetById<T>(object id) where T : Aggregate;
        void Save(Aggregate aggregate);
    }
}