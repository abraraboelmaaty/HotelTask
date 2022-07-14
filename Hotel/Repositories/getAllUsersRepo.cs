using Hotel.DTO;
using Hotel.Models;

namespace Hotel.Repositories
{
    public class getAllUsersRepo:IRepoGetAllRegisterUser
    {
        HotelEnteties context;

        public getAllUsersRepo(HotelEnteties _context)
        {
            context = _context;

        }
        public ICollection<Booking> getAll()
        {
            return context.Bookings.ToList();
        }

        ICollection<ApplicationUser> IRepoGetAllRegisterUser.getAll()
        {
            return context.ApplicationUsers.ToList();
        }
    }
}
