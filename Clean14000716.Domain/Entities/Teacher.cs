using System;
using System.Collections.Generic;
using Clean14000716.Domain.Entities.Base;
using Clean14000716.Domain.Enums;

namespace Clean14000716.Domain.Entities
{
    public class Teacher : IBaseEntity, IAuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Job Job { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }


        public int SchoolId { get; set; }
        public School School { get; set; }


        public ICollection<TeacherStudent> TeacherStudents { get; set; }
    }
}