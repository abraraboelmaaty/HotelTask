namespace Hotel.Repositories
{
    public interface IRepositoryBooking<T>
    {
        public int booking(T entity ,int id);
    }
}
