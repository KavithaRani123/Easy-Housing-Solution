using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EasyHousingSolution_WebAPI.Model
{
    public partial class EHSDBContext : DbContext
    {
        public EHSDBContext()
        {
        }

        public EHSDBContext(DbContextOptions<EHSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EhsBuyer> EhsBuyers { get; set; }
        public virtual DbSet<EhsCart> EhsCarts { get; set; }
        public virtual DbSet<EhsCity> EhsCities { get; set; }
        public virtual DbSet<EhsImage> EhsImages { get; set; }
        public virtual DbSet<EhsProperty> EhsProperties { get; set; }
        public virtual DbSet<EhsSeller> EhsSellers { get; set; }
        public virtual DbSet<EhsState> EhsStates { get; set; }
        public virtual DbSet<EhsUser> EhsUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.;Trusted_Connection=True;Database=EHSDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EhsBuyer>(entity =>
            {
                entity.HasKey(e => e.BuyerId)
                    .HasName("PK__EHS_Buye__4B81C62A43346936");

                entity.ToTable("EHS_Buyer");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EhsCart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__EHS_Cart__51BCD7B7D5B1689B");

                entity.ToTable("EHS_Cart");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.EhsCarts)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EHS_Cart__BuyerI__2D27B809");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.EhsCarts)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EHS_Cart__Proper__2E1BDC42");
            });

            modelBuilder.Entity<EhsCity>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__EHS_City__F2D21B7691F35482");

                entity.ToTable("EHS_City");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.EhsCities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EHS_City__StateI__1ED998B2");
            });

            modelBuilder.Entity<EhsImage>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__EHS_Imag__7516F70CE0402FA5");

                entity.ToTable("EHS_Images");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("image");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.EhsImages)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EHS_Image__Prope__2A4B4B5E");
            });

            modelBuilder.Entity<EhsProperty>(entity =>
            {
                entity.HasKey(e => e.PropertyId)
                    .HasName("PK__EHS_Prop__70C9A7357BF912AF");

                entity.ToTable("EHS_Property");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.InitialDeposit).HasColumnType("money");

                entity.Property(e => e.LandMark)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PriceRange).HasColumnType("money");

                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyOption)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyType)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.EhsProperties)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EHS_Prope__Selle__276EDEB3");
            });

            modelBuilder.Entity<EhsSeller>(entity =>
            {
                entity.HasKey(e => e.SellerId)
                    .HasName("PK__EHS_Sell__7FE3DB8190763972");

                entity.ToTable("EHS_Seller");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DateofBirth).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.EhsSellers)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EHS_Selle__CityI__22AA2996");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.EhsSellers)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EHS_Selle__State__21B6055D");
            });

            modelBuilder.Entity<EhsState>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .HasName("PK__EHS_Stat__C3BA3B3A29E64522");

                entity.ToTable("EHS_State");

                entity.Property(e => e.StateName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EhsUser>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__EHS_User__C9F28457C6F3D806");

                entity.ToTable("EHS_Users");

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
