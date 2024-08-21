using Arc_07_Project.Data;
using Arc_07_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arc_07_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_context.Bookings);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            var bookings = _context.Bookings.FirstOrDefault(e => e.BookingID == id);
            if (bookings == null)
                return Problem(detail: "Booking with id " + id + " is not found. ", statusCode: 404);
            return Ok(bookings);
        }

        [HttpPost]
        public IActionResult Post(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return CreatedAtAction("GetAll", new { id = booking.BookingID }, booking);
        }

        [HttpPut]
        public IActionResult Put(int? id, Booking booking)
        {
            var entity = _context.Bookings.FirstOrDefault(e => e.BookingID == id);
            if (entity == null)
                return Problem(detail: "Booking with id " + id + " is not found ", statusCode: 404);

            entity.FacilityDescription = booking.FacilityDescription;
            entity.BookingDateFrom = booking.BookingDateFrom;
            entity.BookingDateTo = booking.BookingDateTo;
            entity.BookedBy = booking.BookedBy;
            entity.BookingStatus = booking.BookingStatus;

            _context.SaveChanges();

            return Ok(entity);
        }

        [HttpDelete]
        public IActionResult Delete(int? id, Booking booking)
        {
            var entity = _context.Bookings.FirstOrDefault(e => e.BookingID == id);
            if (entity == null)
                return Problem(detail: "Booking with id " + id + " is not found ", statusCode: 404);

            _context.Bookings.Remove(entity);
            _context.SaveChanges();

            return Ok(entity);
        }
    }
}
