using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Clean14000716.Domain.Entities.Base;

namespace Clean14000716.Domain.Entities
{
    public class School : BaseEntityWithAuditAndSoftDelete
    {        
        public string Name { get; set; }       
        public byte[] RowVersion { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }      
    }
}