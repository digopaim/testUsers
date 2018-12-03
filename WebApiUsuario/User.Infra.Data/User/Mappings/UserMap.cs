using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using User.Domain.User.Model;

namespace User.Infra.Data.User.Mappings
{
    public class UserMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(m => m.Name).HasColumnName("Name");
            builder.Property(m => m.DocumentNumber).HasColumnName("DocumentNumber");
       
        builder.Property(m => m.Age).HasColumnName("Age");
        }
    }
}
