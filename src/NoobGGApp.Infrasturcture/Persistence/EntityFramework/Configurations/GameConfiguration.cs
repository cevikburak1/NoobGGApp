﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NoobGGApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobGGApp.Infrastructure.Persistence.EntityFramework.Configurations
{
    public sealed class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Name
            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            // Description
            builder.Property(x => x.Description)
                .HasMaxLength(5000);

            // ImageUrl
            builder.Property(x => x.ImageUrl)
                .HasMaxLength(255);

            // Relationships
            builder.HasMany(x => x.GameRegions)
                .WithOne(x => x.Game)
                .HasForeignKey(x => x.GameId);

            // CreatedOn
            builder.Property(x => x.CreatedOn)
                .HasDefaultValue(DateTimeOffset.UtcNow)
                .IsRequired();

            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId)
                .HasMaxLength(100)
                .IsRequired(false);

            // ModifiedOn
            builder.Property(x => x.ModifiedOn)
                .IsRequired(false);

            // ModifiedByUserId
            builder.Property(x => x.ModifiedByUserId)
                .HasMaxLength(100)
                .IsRequired(false);
        }
    }
}
