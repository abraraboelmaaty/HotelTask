using Hotel.Data;
using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        IRepository<Room> RoomRepo;
        IRepoGetByNumber<Room> RoomRepoNumber;
        IRepoGetByTpe<Room> RoomRepoByType;
        IAvilableRooms AvilableRooms;
        IReposatoryGetByBransh<Room> RoomBranch;
        public RoomController(IReposatoryGetByBransh<Room> _RoomBranch, IAvilableRooms _AvilableRooms, IRepoGetByNumber<Room> _RoomRepoNumber, IRepository<Room> _RoomRepo, IRepoGetByTpe<Room> _RoomRepoByType)
        {
            RoomRepoNumber = _RoomRepoNumber;
            RoomRepo = _RoomRepo;
            RoomRepoByType = _RoomRepoByType;
            AvilableRooms = _AvilableRooms;
            RoomBranch = _RoomBranch;
        }
        [HttpGet]
        //[Authorize]
        public ActionResult getAll()
        {
            if (RoomRepo.getAll().Count > 0)
            {
                return Ok(RoomRepo.getAll());
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public ActionResult getAllAvilableRooms()
        {
            if (AvilableRooms.getAvilableRooms().Count > 0)
            {
                return Ok(AvilableRooms.getAvilableRooms());
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{number}")]
        public ActionResult getAllByNumber(int number)
        {
            if (RoomRepoNumber.getAllByNumber(number).Count > 0)
            {
                return Ok(RoomRepoNumber.getAllByNumber(number));
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{BranchId}")]
        public ActionResult getAllByBranch(int BranchId)
        {
            if (RoomBranch.GetByBransh(BranchId).Count > 0)
            {
                return Ok(RoomBranch.GetByBransh(BranchId));
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{type}")]
        public ActionResult getAllByType(RoomType type)
        {
            if (RoomRepoByType.getAllByType(type).Count > 0)
            {
                return Ok(RoomRepoByType.getAllByType(type));
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public ActionResult getById( int id)
        {
            Room room = RoomRepo.getById(id);
            if (room == null)
                return NotFound();
            else 
                return Ok(room);
        }
        [HttpPost]
        public ActionResult Add([FromBody]Room room)
        {
            RoomRepo.creat(room);
            return Created("uri", room);
        }
    }
}
