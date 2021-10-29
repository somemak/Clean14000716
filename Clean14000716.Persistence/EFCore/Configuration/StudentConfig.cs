using Clean14000716.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean14000716.Persistence.EFCore.Configuration
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(student => student.Id);

            builder.HasOne(s => s.StudentDetail)
                .WithOne(detail => detail.Student)
                .HasForeignKey<StudentDetail>(detail => detail.StudentId);


            builder.HasMany(s => s.TeacherStudents)
                .WithOne(student => student.Student)
                .HasForeignKey(student => student.StudentId);
        }
    }
}