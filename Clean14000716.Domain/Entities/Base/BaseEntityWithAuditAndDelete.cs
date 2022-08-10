using System;

namespace Clean14000716.Domain.Entities.Base
{
    public class BaseEntityWithAuditAndSoftDelete : IBaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
    }
}