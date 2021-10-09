﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using Workshop.Calendar.Api;

#nullable disable

namespace Workshop.Calendar.Api.Configurations
{
    public partial class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> entity)
        {
            entity.HasKey(e => new { e.UserId, e.TeamId })
                .HasName("Membership_pkey");

            entity.HasOne(d => d.Team)
                .WithMany(p => p.Membership)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("Membership_teamId_fkey");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Membership)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Membership_userId_fkey");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Membership> entity);
    }
}
