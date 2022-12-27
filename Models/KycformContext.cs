using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kycdetails.Models;

public partial class KycformContext : DbContext
{
    public KycformContext()
    {
    }

    public KycformContext(DbContextOptions<KycformContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCustomerdetail> TbCustomerdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Data Source=ASTLPTWFH153\\SQLEXPRESS;Initial Catalog=kycform;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCustomerdetail>(entity =>
        {
            entity.HasKey(e => e.TbId).HasName("PK__TB_custo__B17B4D356FB04DAB");

            entity.ToTable("TB_customerdetails");

            entity.Property(e => e.TbId).HasColumnName("TB_ID");
            entity.Property(e => e.TbCustomerId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TB_Customer_ID");
            entity.Property(e => e.TbCustomername)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TB_customername");
            entity.Property(e => e.TbDocumentType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TB_document_type");
            entity.Property(e => e.TbGender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TB_gender");
            entity.Property(e => e.TbIdNumber).HasColumnName("TB_ID_Number");
            entity.Property(e => e.TbMobile)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TB_Mobile");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
