﻿using Microsoft.EntityFrameworkCore;

namespace Hotel.Models
{
    public class HotelEnteties:DbContext
    {
        public HotelEnteties() : base()
        { }
        public HotelEnteties(DbContextOptions options) : base(options)
        { }
        public DbSet<Customer> Coustomers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Branch> Branches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasKey(b => new { b.CustomerId, b.RoomId });
            modelBuilder.Entity<Booking>()
                       .HasOne(B => B.Customer)
                       .WithMany(CU => CU.Bokings)
                       .HasForeignKey(B => B.CustomerId)
                       .OnDelete(DeleteBehavior.Restrict)
                       .IsRequired(false);
            modelBuilder.Entity<Booking>()
                      .HasOne(B => B.Room)
                      .WithMany(R => R.Bokings)
                      .HasForeignKey(B => B.RoomId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired(false);
            modelBuilder.Entity<Room>()
                    .HasOne(R => R.Branch)
                    .WithMany(Br => Br.Rooms)
                    .HasForeignKey(R => R.BranchId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(false);
            modelBuilder.Entity<Room>()
                      .HasOne(R => R.Type)
                      .WithMany(T => T.Rooms)
                      .HasForeignKey(R => R.TypeId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
