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
            modelBuilder.Entity<Booking>()
                .HasKey(b => new { b.UserId, b.RoomId });
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
            //modelBuilder.Entity<Room>()
            //        .HasOne(R => R.Branch)
            //        .WithMany(Br => Br.Rooms)
            //        .HasForeignKey(R => R.BranchId)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .IsRequired(false);
            //modelBuilder.Entity<Room>()
            //          .HasOne(R => R.Type)
            //          .WithMany(T => T.Rooms)
            //          .HasForeignKey(R => R.TypeId)
            //          .OnDelete(DeleteBehavior.Restrict)
            //          .IsRequired(false);
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Room>()
              .Property(r => r.RoomType)
              .HasConversion<string>()
              .HasMaxLength(20);
            modelBuilder.Entity<Room>()
              .Property(r => r.Avilable)
              .HasDefaultValue(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}
