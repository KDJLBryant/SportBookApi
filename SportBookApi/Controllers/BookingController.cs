using Microsoft.AspNetCore.Mvc;
using SportBookApi.Data.Interface;
using SportBookApi.Model.DTO;

namespace SportBookApi.Model
{
    [Route("api/Bookings")]
    [Controller]
    public class BookingController : ControllerBase
    {
        private readonly IRepository _repository;

        public BookingController(IRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<BookingDTO>>> GetBookings()
        {
            try
            {
                return Ok(await _repository.GetBookingsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<AddressDTO>> GetBooking(int id)
        {
            try
            {
                BookingDTO b = await _repository.GetBookingAsync(id);

                if (b == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(b);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDTO bookingDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Booking booking = await _repository.CreateBookingAsync(bookingDto);
                    return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Booking>> DeleteBooking(int id)
        {
            try
            {
                bool deletionSuccess = await _repository.DeleteBookingAsync(id);

                if (deletionSuccess)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
