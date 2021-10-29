using System;
using Clean14000716.Domain.Entities.Base;

namespace Clean14000716.Domain.Entities
{
    public class StudentDetail : IBaseEntity,IAuditEntity
    {
        public int Id { get; set; }
        public string FatherName { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }    
    }
}