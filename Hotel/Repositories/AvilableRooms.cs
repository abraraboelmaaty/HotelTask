using Hotel.Models;

namespace Hotel.Repositories
{
    public class AvilableRooms : IAvilableRooms
    {
        HotelEnteties context;
        public AvilableRooms(HotelEnteties _context)
        {
            context = _context;
        }
       

        public ICollection<Room> getAvilableRooms()
        {
            List<Room> rooms = context.Rooms.Where(r => r.Status == 0).ToList();
            return rooms;
        }
        public bool IsRoomAvilable(int id)
        {
            Room? room = context.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null)
                return false;
            else
            {
                if(room.Status == 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
