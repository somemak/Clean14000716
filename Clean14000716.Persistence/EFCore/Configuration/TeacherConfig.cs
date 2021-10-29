using Clean14000716.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean14000716.Persistence.EFCore.Configuration
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(teacher => teacher.Id);


            builder.HasMany(s => s.TeacherStudents)
                .WithOne(student => student.Teacher)
                .HasForeignKey(student => student.StudentId);
        }
    }
}