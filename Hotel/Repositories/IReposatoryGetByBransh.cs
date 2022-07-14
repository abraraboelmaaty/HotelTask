namespace Hotel.Repositories
{
    public interface IReposatoryGetByBransh<T>
    {
        
        public ICollection<T> GetByBransh(int branchId);
    }
}
