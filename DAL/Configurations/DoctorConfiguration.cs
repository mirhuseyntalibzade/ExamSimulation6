using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .Property(d => d.ImageURL)
                .IsRequired();

            builder
                .Property(d => d.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(d => d.UpdatedAt)
                .IsRequired(false);

            builder
            .Property(d => d.CreatedAt)
            .IsRequired();

        }
    }
}
