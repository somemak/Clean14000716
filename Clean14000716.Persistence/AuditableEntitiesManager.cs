using System;
using Clean14000716.Domain.Entities.Base;
using Clean14000716.Persistence.EFCore.Context.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Clean14000716.Persistence
{
    public static  class AuditableEntitiesManager
    {
        public static void SetAuditableEntityOnBeforeSaveChanges(this ApplicationContext context)
        {
            var now = DateTime.UtcNow;

            foreach (var entry in context.ChangeTracker.Entries<ISoftDelete>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //TODO: ...
                        break;
                    case EntityState.Modified:
                        //TODO: ...
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged; //NOTE: For soft-deletes to work with the original `Remove` method.
                        entry.Entity.IsDeleted = true;
                        entry.Entity.DeletedAt = now;
                        break;
                }
            }
        }
    }
}