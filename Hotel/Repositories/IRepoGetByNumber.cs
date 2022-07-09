namespace Hotel.Repositories
{
    public interface IRepoGetByNumber<T>
    {
        public ICollection<T> getAllByNumber(int number);
    }
}
