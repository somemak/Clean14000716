using Clean14000716.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean14000716.Persistence.EFCore.Configuration
{
    public class TeacherStudentConfig : IEntityTypeConfiguration<TeacherStudent>
    {
        public void Configure(EntityTypeBuilder<TeacherStudent> builder)
        {
            builder.HasKey(ts => new {ts.StudentId, ts.TeacherId});

            //builder.HasIndex(e => e.StudentId).HasDatabaseName("IX_BlogPostId");
            //builder.HasIndex(e => e.TeacherId).HasDatabaseName("IX_TagId");
        }
    }
}