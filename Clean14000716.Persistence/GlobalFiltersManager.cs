using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Clean14000716.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clean14000716.Persistence
{
    public static class GlobalFiltersManager
    {
        #region ApplySoftDeleteQueryFilters

        public static void ApplySoftDeleteQueryFilters(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model
                .GetEntityTypes()
                .Where(eType => typeof(BaseEntityWithSoftDelete).IsAssignableFrom(eType.ClrType)))
            {
                entityType.AddSoftDeleteQueryFilter();
            }
        }

        private static void AddSoftDeleteQueryFilter(this IMutableEntityType entityData)
        {
            var methodToCall = typeof(GlobalFiltersManager)
                .GetMethod(nameof(GetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)
                ?.MakeGenericMethod(entityData.ClrType);
            var filter = methodToCall?.Invoke(null, new object[] { });
            entityData.SetQueryFilter((LambdaExpression)filter);
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>() where TEntity : BaseEntityWithSoftDelete
        {
            return (Expression<Func<TEntity, bool>>)(entity => !entity.IsDeleted);
        }

        #endregion
    }
}
