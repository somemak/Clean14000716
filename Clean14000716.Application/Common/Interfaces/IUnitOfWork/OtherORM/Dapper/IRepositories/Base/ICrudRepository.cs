// Programmer : Mehdi Ahmadiyan Kaji -- Date : 1400/04/16 -- Time : 07:49 ق.ظ

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Clean14000716.Domain.Entities.Base;

namespace Clean14000716.Application.Common.Interfaces.IUnitOfWork.OtherORM.Dapper.IRepositories.Base
{
    public interface ICrudRepository<TEntity, TKey> where TEntity : IBaseEntity<TKey>
    {
        #region Read

        //*********************************************************************************    Read

        TEntity Get(TKey id);
        Task<TEntity> GetAsync(TKey id);
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(TKey id);
        Task<TEntity> FirstOrDefaultAsync(TKey id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Load(TKey id);
        List<TEntity> GetAllList();
        Task<List<TEntity>> GetAllListAsync();
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

        #endregion

        #region Create

        //*********************************************************************************    Create

        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        TKey InsertAndGetId(TEntity entity);
        Task<TKey> InsertAndGetIdAsync(TEntity entity);

        #endregion

        #region Create or Update

        //*********************************************************************************    Create or Update

        TEntity InsertOrUpdate(TEntity entity);
        Task<TEntity> InsertOrUpdateAsync(TEntity entity);
        TKey InsertOrUpdateAndGetId(TEntity entity);
        Task<TKey> InsertOrUpdateAndGetIdAsync(TEntity entity);

        #endregion

        #region Update

        //*********************************************************************************    Update

        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);


        #endregion

        #region Delete

        //*********************************************************************************    Delete

        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void Delete(TKey id);
        Task DeleteAsync(TKey id);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }

    public interface ICrudRepository<TEntity> : ICrudRepository<TEntity, int> where TEntity : IBaseEntity<int>
    {
    }
}