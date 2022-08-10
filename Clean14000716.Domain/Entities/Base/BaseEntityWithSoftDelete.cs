using System;

namespace Clean14000716.Domain.Entities.Base
{
    public class BaseEntityWithSoftDelete : IBaseEntity
    {        
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
    }


}