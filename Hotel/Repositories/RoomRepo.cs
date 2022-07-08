using Hotel.Models;

namespace Hotel.Repositories
{
    public class RoomRepo : IRepository<Room> , IRepoUpdateDelete<Room>
    {
        HotelEnteties context;
        public RoomRepo(HotelEnteties _context)
        {
            context = _context;

        }
        public int creat(Room room)
        {
            context.Add(room);
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
            throw new NotImplementedException();
        }

        public ICollection<Room> getAll()
        {
            throw new NotImplementedException();
        }

        public Room getById(int id)
        {
            throw new NotImplementedException();
        }

        public int update(int id, Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
