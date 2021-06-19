using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SampleApiDocker.Business
{
    public interface IEntitieBehaviour<Data> where Data : class
    {
        IList<Data> GetAll();
        IList<Data> GetAll(Expression<Func<Data, bool>> query);
        Data Get(Expression<Func<Data, bool>> query);
        Data Insert(Data obj);
        Data Update(Data obj);
        void Delete(Data obj);
        bool Exists(Expression<Func<Data, bool>> query);
        long Count();
        long Count(Expression<Func<Data, bool>> query);
    }
}
