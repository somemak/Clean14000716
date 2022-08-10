using System;
using System.Linq;
using Clean14000716.Domain.Entities.Base;
using Clean14000716.Persistence.EFCore.Context.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Clean14000716.Persistence
{
    public static class AuditableEntitiesManager
    {
        public static void SetAuditableEntityOnBeforeSaveChanges(this ApplicationContext context)
        {
            var now = DateTime.UtcNow;

            //var deletedEntry = context.ChangeTracker.Entries().Where(e => e.Entity.GetType() == typeof(BaseEntityWithAuditAndSoftDelete) ||
            //e.Entity.GetType() == typeof(BaseEntityWithSoftDelete));

            foreach (var entry in context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Entity.GetType().GetProperties().Any(e => e.Name == "Created"))
                        {
                            (entry.Entity as BaseEntityWithAudit).Created = DateTimeOffset.UtcNow;
                            (entry.Entity as BaseEntityWithAudit).CreatedBy = "1";
                        }
                        break;
                    case EntityState.Modified:
                        if (entry.Entity.GetType().GetProperties().Any(e => e.Name == "LastModified"))
                        {
                            (entry.Entity as BaseEntityWithAudit).LastModified = DateTimeOffset.UtcNow;
                            (entry.Entity as BaseEntityWithAudit).LastModifiedBy = "1";
                        }
                        break;
                        break;
                    case EntityState.Deleted:
                        //entry.State = EntityState.Unchanged; //NOTE: For soft-deletes to work with the original `Remove` method.
                        //entry.Entity.IsDeleted = true;
                        //entry.Entity.DeletedAt = now;
                        break;


                        //var delPropName = "IsDeleted";
                        //var containIsDelete = entry.Entity.GetType().GetProperties().FirstOrDefault(e => e.Name == "IsDeleted") != null;
                        //if (containIsDelete)
                        //{
                        //    entry.State = EntityState.Unchanged; //NOTE: For soft-deletes to work with the original `Remove` method.
                        //    var delProp = entry.Property(delPropName);
                        //    delProp.CurrentValue = true;
                        //}
                        //entry.Entity.DeletedAt = now;
                        //break;
                }
            }
        }
    }
}