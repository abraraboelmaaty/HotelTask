using Hotel.Models;

namespace Hotel.Repositories
{
    public class BranchRepo : IRepository<Branch>,IRepoGetByLocation<Branch>
    {
        HotelEnteties context;
        public BranchRepo(HotelEnteties _context)
        {
            context = _context;
        }
        public int creat(Branch branch)
        {
            context.Add(branch);
            try
            {
                int raws = context.SaveChanges();
                return raws;
            }
            catch(Exception ex)
            {
                return -1;
            }
            
        }

        public ICollection<Branch> getAll()
        {
            return context.Branches.ToList();
        }

        public ICollection<Branch> getAllByLOcation(string location)
        {
            return context.Branches.Where(b=>b.location.Contains(location)).ToList();
        }

        public Branch getById(int id)
        {
           
            Branch? branch = context.Branches.FirstOrDefault(b => b.Id == id);
            return branch;
        }
        
    }
}
