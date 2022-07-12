using Hotel.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Models
{
    public class HotelEnteties:IdentityDbContext<ApplicationUser>
    {
        public HotelEnteties() : base()
        { }
        public HotelEnteties(DbContextOptions options) : base(options)
        { }
        //public DbSet<Customer> Coustomers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        //public DbSet<RoomType> Types { get; set; }
        public DbSet<Branch> Branches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Booking>()
            //    .HasKey(b => new { b.UserId, b.RoomId,b.BranchId });
            modelBuilder.Entity<Booking>()
                       .HasOne(B => B.ApplicationUser)
                       .WithMany(AP => AP.Bokings)
                       .HasForeignKey(B => B.UserId)
                       .OnDelete(DeleteBehavior.Restrict)
                       .IsRequired(false);
            modelBuilder.Entity<Booking>()
                      .HasOne(B => B.Room)
                      .WithMany(R => R.Bokings)
                      .HasForeignKey(B => B.RoomId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired(false);
            modelBuilder.Entity<Booking>()
                     .HasOne(BO => BO.Branch)
                     .WithMany(BR => BR.Bookings)
                     .HasForeignKey(BO => BO.BranchId)
                     .OnDelete(DeleteBehavior.Restrict)
                     .IsRequired(false);
            modelBuilder.Entity<Room>()
                      .Property(r => r.RoomType)
                      .HasConversion<string>()
                      .HasMaxLength(20);
            modelBuilder.Entity<Room>()
                      .Property(r => r.Status)
                      .HasConversion<string>()
                      .HasMaxLength(20);
            modelBuilder.Entity<Room>()
                      .Property(r => r.Status)
                      .HasDefaultValue(RoomStatus.available);
            modelBuilder.Entity<Room>()
                     .Property(r => r.CoustomerCount)
                     .HasDefaultValue(0);
            modelBuilder.Entity<Room>()
                     .Property(r => r.CanBookingmore)
                     .HasDefaultValue(false);
            //modelBuilder.Entity<Booking>()
            //          .Property(b => b.Id)
            //          .ValueGeneratedOnAdd();


            base.OnModelCreating(modelBuilder);
           

        }
    }
}
