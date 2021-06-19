using SampleApiDocker.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SampleApiDocker.Business
{
    public class BaseBusiness<U> : IEntitieBehaviour<U> where U : class
    {
        internal FactoryDatabase<U> _factory { get; set; }

        public BaseBusiness()
        {
            _factory = new FactoryDatabase<U>();
        }

        public virtual IList<U> GetAll()
        {
            return _factory.Instance.FindAll();
        }

        public virtual IList<U> GetAll(Expression<Func<U, bool>> query)
        {
            return _factory.Instance.FindAll(query);
        }

        public virtual U Get(Expression<Func<U, bool>> query)
        {
            return _factory.Instance.Get(query);
        }

        public virtual U Insert(U obj)
        {
            return _factory.Instance.Insert(obj);
        }

        public virtual U Update(U obj)
        {
            return _factory.Instance.Update(obj);
        }

        public virtual void Delete(U obj)
        {
            _factory.Instance.Delete(obj);
        }

        public virtual bool Exists(Expression<Func<U, bool>> query)
        {
            return _factory.Instance.Exists(query);
        }

        public virtual long Count()
        {
            return _factory.Instance.Count();
        }

        public virtual long Count(Expression<Func<U, bool>> query)
        {
            return _factory.Instance.Count(query);
        }
    }
}
