﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PRS_With_Entity_Framework.Models;

public partial class PrsdbContext : DbContext
{
    public PrsdbContext()
    {
    }

    public PrsdbContext(DbContextOptions<PrsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LineItem> LineItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-VDMQ3OL\\SQLEXPRESS;Database=prsdb;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LineItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LineItem__3214EC073D8B3E6D");

            entity.HasOne(d => d.Product).WithMany(p => p.LineItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LineItem__Produc__398D8EEE");

            entity.HasOne(d => d.Request).WithMany(p => p.LineItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LineItem__Reques__38996AB5");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC076A1AB031");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__VendorI__300424B4");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Request__3214EC07E173869A");

            entity.Property(e => e.Status).HasDefaultValue("New");
            entity.Property(e => e.SubmittedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.Requests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Request__UserId__34C8D9D1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC078C1B6708");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vendor__3214EC07CFC1839A");

            entity.Property(e => e.State).IsFixedLength();
            entity.Property(e => e.Zip).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
