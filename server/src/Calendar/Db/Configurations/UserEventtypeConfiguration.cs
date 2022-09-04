﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using Workshop.Calendar.Api;

#nullable disable

namespace Workshop.Calendar.Api.Configurations
{
    public partial class UserEventtypeConfiguration : IEntityTypeConfiguration<UserEventtype>
    {
        public void Configure(EntityTypeBuilder<UserEventtype> entity)
        {
            entity.HasOne(d => d.ANavigation)
                .WithMany()
                .HasForeignKey(d => d.A)
                .HasConstraintName("_user_eventtype_A_fkey");

            entity.HasOne(d => d.BNavigation)
                .WithMany()
                .HasForeignKey(d => d.B)
                .HasConstraintName("_user_eventtype_B_fkey");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<UserEventtype> entity);
    }
}