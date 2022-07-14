using Hotel.Data;
using Hotel.Models;

namespace Hotel.Repositories
{
    public class RoomRepo : IRepository<Room>  ,IRepoGetByNumber<Room>,IRepoGetByTpe<Room>,IAvilableRooms,IReposatoryGetByBransh<Room>
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

        //public int Delete(int id)
        //{
        //    Room? room = context.Rooms.FirstOrDefault(r=>r.Id == id);
        //    if (room == null)
        //        return -1;
        //    else
        //    {
        //        try
        //        {
        //            context.Rooms.Remove(room);
        //            int raws = context.SaveChanges();
        //            return raws;
        //        }
        //        catch (Exception ex)
        //        {
        //            return -1;
        //        }
        //    }
        //}

        
        public ICollection<Room> getAll()
        {
            return context.Rooms.ToList();
        }

        public ICollection<Room> getAllByNumber(int number)
        {
            return context.Rooms.Where(r => r.Number == number).ToList();
        }

        public ICollection<Room> getAllByType(RoomType type)
        {
            return context.Rooms.Where(r => r.RoomType == type).ToList();
        }

        public ICollection<Room> getAvilableRooms()
        {
            List<Room> rooms = context.Rooms.Where(r => r.Status == 0).ToList();
            return rooms;
        }

        public ICollection<Room> GetByBransh(int branchId)
        {
            return context.Rooms.Where(r => r.BranchId == branchId).ToList();

        }

        public Room getById(int id)
        {
            Room? room = context.Rooms.FirstOrDefault(r => r.Id == id);
            return room;
        }

        

        //public int update(int id, Room entity)
        //{
        //    Room? room = context.Rooms.FirstOrDefault(r=>r.Id==id);
        //    if (room == null)
        //        return -1;
        //    else
        //    {
        //        room.Id = id;
        //        room.
        //    }

        //}
    }
}
