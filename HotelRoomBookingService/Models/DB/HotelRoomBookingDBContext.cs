using System;
using HotelRoomBookingLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelRoomBookingService.Models.DB
{
    public partial class HotelRoomBookingDBContext : DbContext
    {
        public HotelRoomBookingDBContext()
        {
        }

        public HotelRoomBookingDBContext(DbContextOptions<HotelRoomBookingDBContext> options)
            : base(options)
        {
        }

       // public virtual DbSet<SelectedRoomsViewModel> SelectedRoomsViewModel { get; set; }
        public virtual DbSet<SelectedRooms> SelectedRooms { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<BookingDetails> BookingDetails { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<HotelRoom> HotelRoom { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=HotelRoomBookingDB;trusted_connection=yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Checkin).HasColumnType("datetime");

                entity.Property(e => e.Checkout).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("Bookingfk");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("Bookingfk1");
            });

            modelBuilder.Entity<BookingDetails>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.HotelId, e.RoomId });

                entity.Property(e => e.RoomPrice).HasColumnType("money");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BookingDetailsfk");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BookingDetailsfk1");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BookingDetailsfk2");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerContact)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HotelContact)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HotelRoom>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.Property(e => e.AirConditioner)
                    .IsRequired()
                    .HasColumnName("Air_Conditioner")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RoomPrice).HasColumnType("money");

                entity.Property(e => e.WiFi)
                    .IsRequired()
                    .HasColumnName("Wi_fi")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelRoom)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("HotelRoomfk");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentInvoiceNo);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("Paymentfk");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("Paymentfk1");
            });
        }
    }
}
