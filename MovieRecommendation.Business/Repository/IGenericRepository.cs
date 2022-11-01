using MovieRecommendation.Business.Request.Pagination;
using MovieRecommendation.Entities.Abstract;
using MovieRecommendation.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRecommendation.Business.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity, IEntity, new()
    {
        Task<T> Get(Expression<Func<T, bool>> expression);

        Task<List<T>> GetList(Expression<Func<T, bool>> expression = null);

        Task<T> Find(Expression<Func<T, bool>> conditions);

        Task<T> Add(T entity);

        Task AddRange(List<T> entities);

        Task<T> Update(T entity);

        void UpdateRange(List<T> entities);

        void Delete(T entity);

        void DeleteById(int Id);

        void DeleteRange(IList<T> entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        List<T> GetWithPagination<A>(PaginationParameters paginationParameters);

        IEnumerable<T> GetEnumerable();

        IQueryable<T> GetQueryable();

        IQueryable<T> ExecuteSqlQuery(string sqlRaw);

        IQueryable<T> ExecuteSqlQuery(string sqlRaw, params object[] parameters);

        int ExecuteSqlCommand(string sqlRaw, params object[] parameters);

        int ExecuteSqlCommand(string sqlRaw);
    }
}
