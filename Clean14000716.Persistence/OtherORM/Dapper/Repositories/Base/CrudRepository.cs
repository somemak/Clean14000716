// Programmer : Mehdi Ahmadiyan Kaji -- Date : 1400/04/16 -- Time : 08:42 ق.ظ

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Clean14000716.Application.Common.Interfaces.IUnitOfWork.OtherORM.Dapper.IRepositories.Base;
using Clean14000716.Domain.Entities;
using Clean14000716.Domain.Entities.Base;
using Dapper;

namespace Clean14000716.Persistence.OtherORM.Dapper.Repositories.Base
{
    public  class CrudRepository<TEntity,TKey> : ICrudRepository<TEntity,TKey> where TEntity : IBaseEntity<TKey>
    {
        protected IDbTransaction Transaction { get; }
        protected IDbConnection Connection => Transaction.Connection;

        protected CrudRepository(IDbTransaction transaction)
        {
            Transaction = transaction;
        }
        public TEntity Get(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// hi mr
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Load(TKey id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAllList()
        {
           
            throw new NotImplementedException();
        }
        ///
        public async Task<List<TEntity>> GetAllListAsync()
        {
            var name = typeof(TEntity).Name;
            var query = "select * from " + name;
            var res = await Connection.QueryAsync<TEntity>(query);
            return res.ToList();
             
        }

        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TKey InsertAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TKey> InsertAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TKey InsertOrUpdateAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }

     
}