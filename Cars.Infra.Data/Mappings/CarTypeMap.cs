using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cars.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Infra.Data.Mappings
{
    public class CarTypeMap : IEntityTypeConfiguration<CarType>
    {
        public void Configure(EntityTypeBuilder<CarType> builder)
        {

            /*
         Id - GUID, Code - Varchar(50), Name - Varchar (100), IsActive - BitIsDeleted- Bit, InsertionDate - DateTime, 
        LastUpdateDate - DateTime) (Hint: all boolean fields should have default value "False")
         */

            builder.Property(c => c.IdN)
                .IsRequired()
                .HasColumnName("IdN");

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("Id");

            builder.Property(c => c.Code)
                .IsRequired()
                .HasColumnType("varchar(25)")
                .HasColumnName("Code");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("Name");

            builder.Property(c => c.MainImg)
                .HasColumnType("varchar(max)")
                .HasColumnName("MainImg");


            builder.Property(c => c.IsActive)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(c => c.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

        
        }
    }
}
