﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using ParkerFox.Core.Entities.Repository;

namespace ParkerFox.Infrastructure.Data
{
    public class EntitySet<T> : IEntitySet<T>
    {
        private readonly IQueryOver<T> _source; //TODO: this is coupled to NHibernate

        public EntitySet(IQueryOver<T> source)
        {
            _source = source;
        }

        public IEnumerable<T> Page(int index, int size)
        {
            return _source.Skip(index * size).Take(size).List();
        }

        public IEnumerable<T> All()
        {
            return _source.List();
        }

        public T SingleOrDefault()
        {
            return _source.SingleOrDefault();
        }

        public EntitySet<T> Include(Expression<Func<T, object>> include)
        {
            
            return this;
        }
    }
}
