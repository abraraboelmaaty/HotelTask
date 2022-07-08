namespace Hotel.Repositories
{
    public interface IRepository<T>
    {
        public ICollection<T> getAll();
        public T getById(int id);
        public int creat(T entity);
      
    }
}
