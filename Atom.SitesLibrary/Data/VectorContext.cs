using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Atom.VectorSiteLibrary.Models;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

#nullable disable

namespace Atom.VectorSiteLibrary.Data
{
    public partial class VectorContext : DbContext
    {
        private readonly string _connectionString;
        public VectorContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public VectorContext(DbContextOptions<VectorContext> options, string connectionString)
            : base(options)
        {
            _connectionString = connectionString;
        }

        public virtual DbSet<JosCategory> JosCategories { get; set; }
        public virtual DbSet<JosContent> JosContents { get; set; }
        public virtual DbSet<JosSection> JosSections { get; set; }
        public virtual DbSet<JosContentFrontpage> JosContentFrontpages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_connectionString, ServerVersion.Parse("8.0.25-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<JosContentFrontpage>(entity =>
            {
                entity.ToTable("jos_content_frontpage");
                entity.HasKey(e => e.ContentId);
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.ContentId).HasColumnName("content_id");
                entity.Property(e => e.Ordering).HasColumnName("ordering");
            });

            modelBuilder.Entity<JosCategory>(entity =>
            {
                entity.ToTable("jos_categories");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => new { e.Section, e.Published, e.Access }, "cat_idx");

                entity.HasIndex(e => e.Access, "idx_access");

                entity.HasIndex(e => e.CheckedOut, "idx_checkout");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Access).HasColumnName("access");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("alias")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CheckedOut).HasColumnName("checked_out");

                entity.Property(e => e.CheckedOutTime)
                    .HasColumnType("datetime")
                    .HasColumnName("checked_out_time")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Editor)
                    .HasMaxLength(50)
                    .HasColumnName("editor");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("image")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ImagePosition)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("image_position")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("params");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Section)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("section")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<JosContent>(entity =>
            {
                entity.ToTable("jos_content");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Access, "idx_access");

                entity.HasIndex(e => e.Catid, "idx_catid");

                entity.HasIndex(e => e.CheckedOut, "idx_checkout");

                entity.HasIndex(e => e.CreatedBy, "idx_createdby");

                entity.HasIndex(e => e.Sectionid, "idx_section");

                entity.HasIndex(e => e.State, "idx_state");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Access).HasColumnName("access");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("alias")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Attribs)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("attribs");

                entity.Property(e => e.Catid).HasColumnName("catid");

                entity.Property(e => e.CheckedOut).HasColumnName("checked_out");

                entity.Property(e => e.CheckedOutTime)
                    .HasColumnType("datetime")
                    .HasColumnName("checked_out_time")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedByAlias)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("created_by_alias")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Fulltext)
                    .IsRequired()
                    .HasColumnType("mediumtext")
                    .HasColumnName("fulltext");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.Images)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("images");

                entity.Property(e => e.Introtext)
                    .IsRequired()
                    .HasColumnType("mediumtext")
                    .HasColumnName("introtext");

                entity.Property(e => e.Mask).HasColumnName("mask");

                entity.Property(e => e.Metadata)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("metadata");

                entity.Property(e => e.Metadesc)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("metadesc");

                entity.Property(e => e.Metakey)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("metakey");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.Parentid).HasColumnName("parentid");

                entity.Property(e => e.PublishDown)
                    .HasColumnType("datetime")
                    .HasColumnName("publish_down")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PublishUp)
                    .HasColumnType("datetime")
                    .HasColumnName("publish_up")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Sectionid).HasColumnName("sectionid");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TitleAlias)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title_alias")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Urls)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("urls");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<JosSection>(entity =>
            {
                entity.ToTable("jos_sections");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Scope, "idx_scope");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Access).HasColumnName("access");

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("alias")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CheckedOut).HasColumnName("checked_out");

                entity.Property(e => e.CheckedOutTime)
                    .HasColumnType("datetime")
                    .HasColumnName("checked_out_time")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("image");

                entity.Property(e => e.ImagePosition)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("image_position")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("params");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Scope)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("scope")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
