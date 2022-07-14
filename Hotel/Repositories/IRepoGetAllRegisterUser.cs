using Hotel.DTO;
using Hotel.Models;

namespace Hotel.Repositories
{
    public interface IRepoGetAllRegisterUser
    {
        ICollection<ApplicationUser> getAll();
    }
}
