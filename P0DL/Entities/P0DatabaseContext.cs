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
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<MyOrder> MyOrders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
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
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_addres");

                entity.Property(e => e.CustEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_email");

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_name");

                entity.Property(e => e.CustPhonenumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_phonenumber");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.InvId)
                    .HasName("PK__Inventor__A8749C29C4B81E06");

                entity.ToTable("Inventory");

                entity.Property(e => e.InvId).HasColumnName("inv_id");

                entity.Property(e => e.InvProduct)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("inv_product");

                entity.Property(e => e.InvQuantity).HasColumnName("inv_quantity");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__store__3F115E1A");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.HasKey(e => e.LiId)
                    .HasName("PK__LineItem__1A6BDF65975CEFB2");

                entity.ToTable("LineItem");

                entity.Property(e => e.LiId).HasColumnName("li_id");

                entity.Property(e => e.LiProduct)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("li_product");

                entity.Property(e => e.LiQuantity).HasColumnName("li_quantity");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__LineItem__order___41EDCAC5");
            });

            modelBuilder.Entity<MyOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__MyOrder__46596229FA8A6998");

                entity.ToTable("MyOrder");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.OrderAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("order_address");

                entity.Property(e => e.OrderPrice).HasColumnName("order_price");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.MyOrders)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK__MyOrder__cust_id__151B244E");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.MyOrders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__MyOrder__store_i__160F4887");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__Product__56958AB2CAE42C3E");

                entity.ToTable("Product");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.InvId).HasColumnName("inv_id");

                entity.Property(e => e.LiId).HasColumnName("li_id");

                entity.Property(e => e.ProdName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prod_name");

                entity.Property(e => e.ProdPrice).HasColumnName("prod_price");

                entity.HasOne(d => d.Inv)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.InvId)
                    .HasConstraintName("FK__Product__inv_id__489AC854");

                entity.HasOne(d => d.Li)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.LiId)
                    .HasConstraintName("FK__Product__li_id__498EEC8D");
            });

            modelBuilder.Entity<StoreFront>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK__StoreFro__A2F2A30CFE7A5882");

                entity.ToTable("StoreFront");

                entity.Property(e => e.StoreId).HasColumnName("store_id");

                entity.Property(e => e.StoreAddres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("store_addres");

                entity.Property(e => e.StoreName)
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
