using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoobGGApp.Domain.Entities;
using NoobGGApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Infrastructure.Persistence.EntityFramework.Configurations
{
    public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //Id
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd().HasConversion(customerId => customerId.Value, value => new CustomerId(value));

            //Email
            builder.Property(c => c.Email).IsRequired().HasConversion(email => email.Value, value => new Email(value));
             
            //FullName
            builder.OwnsOne(c => c.FullName, fullNameBuilder =>
            {
                fullNameBuilder.Property(f => f.FirstName).IsRequired().HasMaxLength(50).HasColumnName("first_name");
                fullNameBuilder.Property(f => f.LastName).IsRequired().HasMaxLength(50).HasColumnName("last_name");
            });

            //Address
            builder.OwnsOne(c => c.Address, addressBuilder =>
            {
                addressBuilder.Property(a => a.Street).IsRequired().HasMaxLength(100).HasColumnName("street");
                addressBuilder.Property(a => a.City).IsRequired().HasMaxLength(100).HasColumnName("city");
                addressBuilder.Property(a => a.State).IsRequired().HasMaxLength(100).HasColumnName("state");
                addressBuilder.Property(a => a.ZipCode).IsRequired().HasMaxLength(10).HasColumnName("zip_code");
            });
        }
    }
   
}
