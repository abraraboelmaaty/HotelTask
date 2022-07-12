using Hotel.Models;

namespace Hotel.Repositories
{
    public class BookingRepo : IRepository<Booking>, IRepoUpdateDelete<Booking>
    {
        HotelEnteties context;
        public BookingRepo(HotelEnteties _context)
        {
            context = _context;
        }

        public int creat(Booking booking)
        {
            context.Add(booking);
            try
            {
                int raws = context.SaveChanges();
                return raws;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int Delete(int id)
        {
            Booking? booking = context.Bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return -1;
            else
            {
                try
                {
                    context.Bookings.Remove(booking);
                    int raws = context.SaveChanges();
                    return raws;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }

        public ICollection<Booking> getAll()
        {
            return context.Bookings.ToList();
        }

        public Booking getById(int id)
        {
            Booking? booking = context.Bookings.FirstOrDefault(b => b.Id == id);
            return booking;
        }

        public int update(int id, Booking booking)
        {
            Booking? oldbooking = context.Bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return -1;
            else
            {
                oldbooking.Id = booking.Id;
                oldbooking.startDate = booking.startDate;
                oldbooking.endDate = booking.endDate;
                try
                {
                    int raws = context.SaveChanges();
                    return raws;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }

        }
    }
}
