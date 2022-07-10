using Hotel.Data;

namespace Hotel.Repositories
{
    public interface IRepoGetByTpe<T>
    {
        public ICollection<T> getAllByType(RoomType type);
    }
}
