using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MovieRecommendation.Business.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> Get();

        List<A> Get<A>() where A : class;

        List<T> GetWhere(Expression<Func<T, bool>> metot);

        List<A> GetWhere<A>(Expression<Func<A, bool>> metot) where A : class;

        T GetSingle(Func<T, bool> metot);

        A GetSingle<A>(Func<A, bool> metot) where A : class;

        T GetById(int id);

        A GetById<A>(int id) where A : class;

        bool Add(T model);

        bool Add<A>(A model) where A : class;

        bool Remove(T model);

        bool Remove<A>(A model) where A : class;

        bool Remove(int id);

        bool Remove<A>(int id) where A : class;

        bool Update(T model, int id);

        bool Update<A>(A model, int id) where A : class;

        int Save();

    }
}