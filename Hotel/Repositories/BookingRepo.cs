using Hotel.Data;
using Hotel.Models;

namespace Hotel.Repositories
{
    public class BookingRepo : IRepository<Booking>, IRepoUpdateDelete<Booking>,IRepositoryBooking<Booking>
    {
        HotelEnteties context;
       
        public BookingRepo(HotelEnteties _context)
        {
            context = _context;
            
        }

        public bool IsRoomAvilable(int id)
        {
            Room? room = context.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null)
                return false;
            else
            {
                if (room.Status == 0)
                    return true;
                else
                    return false;
            }
        }
    
    public int booking(Booking booking, int id)
        {
            Room? room = context.Rooms.FirstOrDefault(r => r.Id == id);
            bool roomAvliable = IsRoomAvilable(id);
            if (roomAvliable)
            {
                 booking.RoomId = id;
                 booking.BranchId = room.BranchId; 
                 
                context.Add(booking);
                //Room? room = context.Rooms.FirstOrDefault(r => r.Id == id);
                if (room.RoomType == 0)
                {
                    room.Status = (RoomStatus)1;
                    room.CanBookingmore = false;
                    room.CoustomerCount++;
                }
                    
                else if (room.RoomType == (RoomType)1 && room.CoustomerCount != 2)
                {
                    //room.CanBookingmore = true;
                    room.CoustomerCount++;
                }
                    
                else if (room.RoomType == (RoomType)1 && room.CoustomerCount == 2)
                {
                    room.CanBookingmore = false;
                    room.Status = (RoomStatus)1;
                }
                else if (room.RoomType == (RoomType)2 && room.CoustomerCount != 3)
                {
                    //room.CanBookingmore = true;
                    room.CoustomerCount++;
                }

                else if (room.RoomType == (RoomType)2 && room.CoustomerCount == 3)
                {
                    room.CanBookingmore = false;
                    room.Status = (RoomStatus)1;
                }
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
            else
            {
                return -2;
            } 
            
        }

        public int creat(Booking booking)
        {
            throw new NotImplementedException();
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
