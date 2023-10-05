using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyBBSWebApi.Models.Models;

namespace MyBBSWebApi.DAL.Core;

public partial class MySecondDbContext : DbContext
{
    public MySecondDbContext()
    {
    }

    public MySecondDbContext(DbContextOptions<MySecondDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostReply> PostReplys { get; set; }

    public virtual DbSet<PostType> PostTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.;database=MySecondDb;uid=sa;pwd=WangYu0330;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(entity =>
        {
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Down).HasColumnType("text");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.LastReplyTime).HasColumnType("datetime");
            entity.Property(e => e.PostContent).HasColumnType("text");
            entity.Property(e => e.PostIcon).HasMaxLength(500);
            entity.Property(e => e.PostTitle).HasMaxLength(100);
            entity.Property(e => e.PostType).HasMaxLength(50);
            entity.Property(e => e.Up).HasColumnType("text");
        });

        modelBuilder.Entity<PostReply>(entity =>
        {
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Down).HasColumnType("text");
            entity.Property(e => e.EditTime).HasColumnType("datetime");
            entity.Property(e => e.ReplyContent).HasColumnType("text");
            entity.Property(e => e.Up).HasColumnType("text");
        });

        modelBuilder.Entity<PostType>(entity =>
        {
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.PostType1)
                .HasMaxLength(50)
                .HasColumnName("PostType");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07AE3806AC");

            entity.Property(e => e.AutoLoginLimitTime).HasColumnType("datetime");
            entity.Property(e => e.IsDelete).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserNo).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
