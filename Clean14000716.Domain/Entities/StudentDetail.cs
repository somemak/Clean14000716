using System;
using Clean14000716.Domain.Entities.Base;

namespace Clean14000716.Domain.Entities
{
    public class StudentDetail : BaseEntityWithAudit
    {      
        public string FatherName { get; set; }
       
        public int StudentId { get; set; }
        public Student Student { get; set; }    
    }
}