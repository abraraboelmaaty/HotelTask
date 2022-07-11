using Hotel.Models;

namespace Hotel.Repositories
{
    public class CustomerRepo : IRepository<Customer>, IRepoUpdateDelete<Customer>
    {
        HotelEnteties context;
        public CustomerRepo(HotelEnteties _context)
        {
            context = _context;
        }
        public int creat(Customer entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> getAll()
        {
            throw new NotImplementedException();
        }

        public Customer getById(int id)
        {
            throw new NotImplementedException();
        }

        public int update(int id, Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
