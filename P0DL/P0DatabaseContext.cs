using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using P0Models;

#nullable disable

namespace P0DL
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

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<LineItems> LineItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<StoreFronts> StoreFronts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Customer__A1B71F90DDEFF9CE");

                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("cust_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_address"); //put one s if things go wrong

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_phonenumber");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Inventor__A8749C29C4B81E06");

                entity.ToTable("Inventory");

                entity.Property(e => e.Id).HasColumnName("inv_id");

                entity.Property(e => e.Product)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("inv_product");

                entity.Property(e => e.Quantity).HasColumnName("inv_quantity");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.StoreFronts)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.Cascade) // Original is ClientSetNull. Change it to Cascade to delete properly
                    .HasConstraintName("FK__Inventory__store__3F115E1A");
            });

            modelBuilder.Entity<LineItems>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__LineItem__1A6BDF65975CEFB2");

                entity.ToTable("LineItem");

                entity.Property(e => e.Id).HasColumnName("li_id");

                entity.Property(e => e.Product)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("li_product");

                entity.Property(e => e.Quantity).HasColumnName("li_quantity");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__LineItem__order___41EDCAC5");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__MyOrder__46596229FA8A6998");

                entity.ToTable("MyOrder");

                entity.Property(e => e.Id).HasColumnName("order_id");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.SLocation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("order_address");

                entity.Property(e => e.TotalPrice).HasColumnName("order_price");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Customers)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK__MyOrder__cust_id__151B244E");

                entity.HasOne(d => d.StoreFronts)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__MyOrder__store_i__160F4887");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Product__56958AB2AC479E44");

                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("prod_id");

                entity.Property(e => e.InvId).HasColumnName("inv_id");

                entity.Property(e => e.LiId).HasColumnName("li_id");

                entity.Property(e => e.PName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prod_name");

                entity.Property(e => e.Price).HasColumnName("prod_price");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.InvId)
                    .HasConstraintName("FK__Product__inv_id__503BEA1C");

                entity.HasOne(d => d.LineItems)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.LiId)
                    .HasConstraintName("FK__Product__li_id__51300E55");
            });

            modelBuilder.Entity<StoreFronts>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__StoreFro__A2F2A30CFE7A5882");

                entity.ToTable("StoreFront");

                entity.Property(e => e.Id).HasColumnName("store_id");

                entity.Property(e => e.SAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("store_address"); //change to one s if needed

                entity.Property(e => e.SName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("store_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
