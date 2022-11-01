using Microsoft.EntityFrameworkCore;
using MovieRecommendation.Business.Request.Pagination;
using MovieRecommendation.DAL;
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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, IEntity, new()
    {
        #region fields

        private readonly MovieRecommendationDbContext _context;
        private DbSet<TEntity> _entity;

        #endregion fields

        #region ctor

        public GenericRepository(MovieRecommendationDbContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }

        #endregion ctor

        #region methods

        public async Task<TEntity> Add(TEntity entity)
        {
            await _entity.AddAsync(entity);
            return entity;
        }

        public async Task AddRange(List<TEntity> entities)
        {
            await _entity.AddRangeAsync(entities);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            _entity.UpdateRange(entities);
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> conditions)
        {
            return await _entity.FirstOrDefaultAsync(conditions);
        }

        public void DeleteById(int id)
        {
            TEntity existing = _entity.Find(id);
            _entity.Remove(existing);
        }

        public void Delete(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void DeleteRange(IList<TEntity> entity)
        {
            _entity.RemoveRange(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            _entity.Update(entity);

            return entity;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public List<TEntity> GetWithPagination<A>(PaginationParameters paginationParameters)
        {
            return _entity.Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
            .Take(paginationParameters.PageSize).ToList();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return await _entity.FirstOrDefaultAsync(expression);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ?
               await _entity.ToListAsync() :
               await _entity.Where(expression).ToListAsync();
        }

        public IEnumerable<TEntity> GetEnumerable()
        {
            return _entity.AsEnumerable();
        }

        IQueryable<TEntity> IGenericRepository<TEntity>.GetQueryable()
        {
            return _entity.AsQueryable();
        }

        public IQueryable<TEntity> ExecuteSqlQuery(string sqlRaw, params object[] parameters)
        {
            return _entity.FromSqlRaw(sqlRaw, parameters);
        }

        public IQueryable<TEntity> ExecuteSqlQuery(string sqlRaw)
        {
            return _entity.FromSqlRaw(sqlRaw);
        }

        public int ExecuteSqlCommand(string sqlRaw, params object[] parameters)
        {
            return _context.Database.ExecuteSqlRaw(sqlRaw, parameters);
        }

        public int ExecuteSqlCommand(string sqlRaw)
        {
            return _context.Database.ExecuteSqlRaw(sqlRaw);
        }

        #endregion methods
    }
}
