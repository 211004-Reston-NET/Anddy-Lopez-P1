using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace P0DL.Entities
{
    public partial class P0DatabaseContext : DbContext
    {
        public P0DatabaseContext()
        {
        }

        public P0DatabaseContext(DbContextOptions<P0DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<StoreFront> StoreFronts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__Customer__A1B71F90DDEFF9CE");

                entity.ToTable("Customer");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.CustAddres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_addres");

                entity.Property(e => e.CustEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_email");

                entity.Property(e => e.CustName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_name");

                entity.Property(e => e.CustPhonenumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_phonenumber");
            });

            modelBuilder.Entity<StoreFront>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__StoreFro__A2F2A30CFE7A5882");

                entity.ToTable("StoreFront");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.StoreAddres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("store_addres");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("store_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
