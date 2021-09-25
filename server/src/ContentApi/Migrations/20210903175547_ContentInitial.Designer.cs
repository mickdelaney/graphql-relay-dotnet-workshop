﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Workshop.Content.Api.Database;

namespace Workshop.ContentApi.Migrations
{
    [DbContext(typeof(ContentDbContext))]
    [Migration("20210903175547_ContentInitial")]
    partial class ContentInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Workshop.ContentApi.Domain.ContentItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ContentTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("content_type_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer")
                        .HasColumnName("owner_id");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("tag");

                    b.HasKey("Id")
                        .HasName("pk_content_items");

                    b.HasIndex("ContentTypeId")
                        .HasDatabaseName("ix_content_items_content_type_id");

                    b.ToTable("content_items", "content");
                });

            modelBuilder.Entity("Workshop.ContentApi.Domain.ContentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer")
                        .HasColumnName("owner_id");

                    b.HasKey("Id")
                        .HasName("pk_content_types");

                    b.ToTable("content_types", "content");
                });

            modelBuilder.Entity("Workshop.ContentApi.Domain.ContentItem", b =>
                {
                    b.HasOne("Workshop.ContentApi.Domain.ContentType", "ContentType")
                        .WithMany()
                        .HasForeignKey("ContentTypeId")
                        .HasConstraintName("fk_content_items_content_types_content_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContentType");
                });
#pragma warning restore 612, 618
        }
    }
}
