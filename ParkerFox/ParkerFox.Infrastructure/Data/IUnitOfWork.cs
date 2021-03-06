﻿using System.Collections.Generic;
using NHibernate;
using System;
using System.Linq.Expressions;
using ParkerFox.Core.Specifications;

namespace ParkerFox.Infrastructure.Data
{
    public interface IUnitOfWork
    {
        //TODO: this would allow anyone to query and bypass the repository all together
        EntitySet<T> Query<T>(Expression<Func<T, bool>> expression) where T : class;
        IQueryOver<T> QueryOver<T>() where T : class;
        IEnumerable<T> Query<T>(Specification<T> specification) where T : class;

        void SaveOrUpdate(object obj);

        void Commit();
        void RollBack();

        void BeginTransaction();
    }
}
