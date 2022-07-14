using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        IRepository<Branch> BranchRepo;
        IRepoGetByLocation<Branch> BranchLocation;

        public BranchController(IRepoGetByLocation<Branch> _BranchLocation,IRepository<Branch> _BranchRepo)
        {
            BranchRepo = _BranchRepo;
            BranchLocation = _BranchLocation;
        }
        [HttpGet]
        public ActionResult getAll()
        {
            if (BranchRepo.getAll().Count > 0)
                return Ok(BranchRepo.getAll());
            else
                return NotFound();
        }
        [HttpGet]
        public ActionResult getAllByLocation(string location)
        {
            if (BranchLocation.getAllByLOcation(location).Count > 0)
               return Ok(BranchLocation.getAllByLOcation(location));
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult getById(int id)
        {
            Branch branch = BranchRepo.getById(id);
            if (branch == null)
                return NotFound();
            else
                return Ok(branch);
        }

        [HttpPost]
        public ActionResult Add([FromBody]Branch branch)
        {
            BranchRepo.creat(branch);
            return Created("url", branch);
        }

    }
}
