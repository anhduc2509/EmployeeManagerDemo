using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Project.Domain.Entity;

public partial class EmployeedbContext : DbContext
{
    public EmployeedbContext()
    {
    }

    public EmployeedbContext(DbContextOptions<EmployeedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Deparment> Deparments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySql("server=localhost;port=3306;user=AnhDuc;password=250902;database=demodatabase", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Deparment>(entity =>
        {
            entity.HasKey(e => e.DeparmentId).HasName("PRIMARY");

            entity.ToTable("deparment");

            entity.Property(e => e.DeparmentId).HasDefaultValueSql("''");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeparmentName)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.DeparmentId, "FK_users_DeparmentId");

            entity.Property(e => e.EmployeeId).HasDefaultValueSql("''");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmployeeAddress).HasMaxLength(255);
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(100)
                .HasDefaultValueSql("''");
            entity.Property(e => e.EmployeePosition)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.EmployeerPhone).HasMaxLength(20);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Deparment).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeparmentId)
                .HasConstraintName("FK_users_DeparmentId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
