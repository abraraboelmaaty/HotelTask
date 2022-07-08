namespace Hotel.Repositories
{
    public interface IRepoGetByLocation<T>
    {
        public ICollection<T> getAllByLOcation(string location);
    }
}
