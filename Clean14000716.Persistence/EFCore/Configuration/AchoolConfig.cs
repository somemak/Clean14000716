using Clean14000716.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean14000716.Persistence.EFCore.Configuration
{
    public class SchoolConfig : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(school => school.Id);

            builder.Property(school => school.RowVersion).IsRowVersion();
         

           

            builder.HasMany(s => s.Students)
                .WithOne(student => student.School)
                .HasForeignKey(student => student.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);



            builder.HasMany(s => s.Teachers)
                .WithOne(student => student.School)
                .HasForeignKey(student => student.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}