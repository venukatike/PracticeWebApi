using System;
using System.Collections.Generic;
using EFCore.MyProjectDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.MyProjectInfrastructure.Data;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Patient> patient { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>(entity =>
        {
            entity
                .HasKey(e => e.Id);
               
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Col).HasColumnName("col");
            entity.Property(e => e.Coolie).HasColumnName("coolie");
            entity.Property(e => e.Coolie2).HasColumnName("coolie2");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
