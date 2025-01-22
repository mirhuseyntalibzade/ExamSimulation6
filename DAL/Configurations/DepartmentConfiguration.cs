using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .Property(d => d.ImageURL)
                .IsRequired();

            builder
                .Property(d => d.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(d => d.Description)
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(d => d.UpdatedAt)
                .IsRequired(false);

            builder
                .Property(d => d.CreatedAt)
                .IsRequired();


            builder
        .HasMany(e => e.Doctors)
        .WithOne(e => e.Department)
        .HasForeignKey(e => e.DepartmentId)
        .IsRequired();
        }
    }
}
