using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Clean14000716.Domain.Entities.Base;

namespace Clean14000716.Domain.Entities
{
    public class School : IBaseEntity, IAuditEntity,ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }

        public byte[] RowVersion { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}