namespace Hotel.Repositories
{
    public interface IRepoUpdateDelete<T>
    {
        public int update(int id, T entity);
        public int Delete(int id);
    }
}
