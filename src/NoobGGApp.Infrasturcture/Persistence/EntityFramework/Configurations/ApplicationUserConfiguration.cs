using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NoobGGApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Infrastructure.Persistence.EntityFramework.Configurations
{
    public sealed class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
          
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

           
            builder.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");

        
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

     
            builder.Property(u => u.UserName).HasMaxLength(100);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(100);

          
            builder.Property(u => u.Email).IsRequired();
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(150);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(150);

            builder.Property(u => u.PhoneNumber).IsRequired(false);
            builder.Property(u => u.PhoneNumber).HasMaxLength(20);

   
            builder.Property(u => u.FullName).IsRequired();
            builder.Property(u => u.FullName).HasMaxLength(100);


            //FirstName
            //builder.Property(u => u.FirstName).IsRequired();
            //builder.Property(u => u.FirstName).HasMaxLength(100);

            ////LastName
            //builder.Property(u => u.LastName).IsRequired();
            //builder.Property(u => u.LastName).HasMaxLength(100);


            builder.HasMany<ApplicationUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();


            builder.HasMany<ApplicationUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

  
            builder.HasMany<ApplicationUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

       
            builder.HasMany<ApplicationUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            
            builder.Property(p => p.CreatedOn)
                .IsRequired();

            // CreatedByUserId
            builder.Property(p => p.CreatedByUserId)
                .IsRequired(false)
                .HasMaxLength(150);

            // ModifiedOn
            builder.Property(p => p.ModifiedOn)
                .IsRequired(false);

            // ModifiedByUserId
            builder.Property(p => p.ModifiedByUserId)
                .IsRequired(false)
                .HasMaxLength(150);

            builder.ToTable("application_users");
        }
    }
}