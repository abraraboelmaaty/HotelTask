using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IRepository<Booking> BookingRepo;
        IRepoUpdateDelete<Booking> BookingUpdateDelete;
        public BookingController(IRepository<Booking> _BookingRepo, IRepoUpdateDelete<Booking> _BookingUpdateDelete)
        {
            BookingRepo = _BookingRepo;
            BookingUpdateDelete = _BookingUpdateDelete;
        }
        //getall
        [HttpGet]
        public ActionResult GetAll()
        {
            if (BookingRepo.getAll().Count > 0)
                return Ok(BookingRepo.getAll());
            else
                return NotFound();
        }
        
        //getById
        [HttpGet("{id:int}")]
        public ActionResult getById(int id)
        {
            Booking? booking = BookingRepo.getById(id);
            if (booking == null)
                return NotFound();
            else
                return Ok(booking);

        }
       
        //create
        [HttpPost]
        public ActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                BookingRepo.creat(booking);
                return Created("url", booking);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        //update
        [HttpPut("{id}")]
        public ActionResult edit(int id, Booking booking)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    BookingUpdateDelete.update(id, booking);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            else return BadRequest(ModelState);
        }
        //delete
        [HttpDelete("{id}")]
        public ActionResult delete(int id, Booking? booking)
        {
            int numOfRows = BookingUpdateDelete.Delete(id);
            if (numOfRows <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(booking);
            }
        }
    }
}
