using Hotel.Data;
using Hotel.Models;
using Hotel.Repositories;
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
        public RoomController(IRepoGetByNumber<Room> _RoomRepoNumber , IRepository<Room> _RoomRepo, IRepoGetByTpe<Room> _RoomRepoByType)
        {
            RoomRepoNumber = _RoomRepoNumber;
            RoomRepo = _RoomRepo;
            RoomRepoByType = _RoomRepoByType;
        }
        [HttpGet]
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
        [HttpGet]
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
        [HttpGet("id")]
        public ActionResult getById(int id)
        {
            Room room = RoomRepo.getById(id);
            if (room == null)
                return NotFound();
            else 
                return Ok(room);
        }
        [HttpPost]
        public ActionResult Add(Room room)
        {
            RoomRepo.creat(room);
            return Created("uri", room);
        }
    }
}
