using Hotel.Models;

namespace Hotel.Repositories
{
    public interface IAvilableRooms
    {
        public ICollection<Room> getAvilableRooms();
    }
}
