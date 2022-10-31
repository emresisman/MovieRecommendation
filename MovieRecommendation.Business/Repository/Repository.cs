using Microsoft.EntityFrameworkCore;
using MovieRecommendation.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MovieRecommendation.Business.Repository
{
    public class Repository<Type> : IRepository<Type> where Type : class
    {
        protected MovieRecommendationDbContext _movieRecommendationContext;

        public Repository(MovieRecommendationDbContext movieRecommendationContext)
        {
            _movieRecommendationContext = movieRecommendationContext;
        }

        public DbSet<Type> Table()
        {
            return Table<Type>();
        }

        public DbSet<A> Table<A>() where A : class
        {
            return _movieRecommendationContext.Set<A>();
        }

        public bool Add(Type model)
        {
            return Add<Type>(model);
        }

        public bool Add<A>(A model) where A : class
        {
            Table<A>().Add(model);
            Save();
            return true;
        }

        public List<Type> Get()
        {
            return Get<Type>();
        }

        public List<A> Get<A>() where A : class
        {
            return Table<A>().ToList();
        }

        public Type GetById(int id)
        {
            return GetById<Type>(id);
        }

        public A GetById<A>(int id) where A : class
        {
            return GetSingle<A>(t => typeof(A).GetProperty("Id").GetValue(t).ToString() == id.ToString());
        }

        public bool Remove(Type model)
        {
            return Remove<Type>(model);
        }

        public bool Remove<A>(A model) where A : class
        {
            Table<A>().Remove(model);
            return true;
        }

        public bool Remove(int id)
        {
            return Remove<Type>(id);
        }

        public bool Remove<A>(int id) where A : class
        {
            A silinecekData = GetSingle<A>(x => (int)typeof(A).GetProperty("Id").GetValue(x) == id);
            Remove<A>(silinecekData);
            Save();
            return true;
        }

        public int Save()
        {
            return _movieRecommendationContext.SaveChanges();
        }

        public bool Update(Type model, int id)
        {
            return Update<Type>(model, id);
        }

        public bool Update<A>(A model, int id) where A : class
        {
            A guncellenecekNesne = GetById<A>(id);
            var tumPropertyler = typeof(A).GetProperties();
            foreach (var property in tumPropertyler)
                if (property.Name != "Id")
                    property.SetValue(guncellenecekNesne, property.GetValue(model));
            Save();
            return true;
        }

        public List<Type> GetWhere(Expression<Func<Type, bool>> metot)
        {
            return GetWhere<Type>(metot);
        }

        public List<A> GetWhere<A>(Expression<Func<A, bool>> metot) where A : class
        {
            return Table<A>().Where(metot).ToList();
        }

        public Type GetSingle(Func<Type, bool> metot)
        {
            return GetSingle<Type>(metot);
        }

        public A GetSingle<A>(Func<A, bool> metot) where A : class
        {
            return Table<A>().FirstOrDefault(metot);
        }
    }
}