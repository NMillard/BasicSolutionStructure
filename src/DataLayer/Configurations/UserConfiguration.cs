﻿using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations {
    public class UserConfiguration : IEntityTypeConfiguration<BetterUser> {
        public void Configure(EntityTypeBuilder<BetterUser> builder) {
            builder.ToTable("Users");

            builder.HasKey(nameof(BetterUser.Id));
            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100)
                .HasConversion(
                    username => username.Value,
                    converted => new Username(converted)
                );

            builder.HasIndex(u => u.Username).IsUnique();
        }
    }

    #region DomainUser

    public class DomainUserConfiguration : IEntityTypeConfiguration<DomainUserPersistence> {
        public void Configure(EntityTypeBuilder<DomainUserPersistence> builder) {
            builder.ToTable("DomainUsers");

            builder.HasKey(nameof(DomainUserPersistence.Id));
            builder.Property(u => u.Username).HasMaxLength(100);
            
            builder.HasIndex(u => u.Username).IsUnique();
        }
    }

    public class DomainUserPersistence {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public static implicit operator User(DomainUserPersistence persistence) => new User(persistence.Username);
    }

    #endregion
}