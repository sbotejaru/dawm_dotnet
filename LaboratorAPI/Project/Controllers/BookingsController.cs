using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly BookingService bookingService;

        public BookingsController(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet("/get-all-bookings")]
        public ActionResult<List<Booking>> GetAll()
        {
            var result = bookingService.GetAll();

            return Ok(result);
        }

        [HttpPatch("/update-booking")]
        public ActionResult<bool> UpdateBookingName([FromBody] BookingUpdateDto bookingUpdateModel)
        {
            var result = bookingService.UpdateBooking(bookingUpdateModel);

            if (!result)
            {
                return BadRequest("Booking could not be updated.");
            }

            return Ok(result);
        }

        [HttpPatch("/update-room")]
        public ActionResult<bool> UpdateBookingRoom([FromBody] BookingUpdateRoomDto bookingUpdateModel)
        {
            var result = bookingService.UpdateBookingRoom(bookingUpdateModel);

            if (!result)
            {
                return BadRequest("Booking could not be updated");
            }

            return Ok(result);
        }

        [HttpPatch("/update-start-date")]
        public ActionResult<bool> UpdateBookingStartDate([FromBody] BookingUpdateStartDateDto bookingUpdateModel)
        {
            var result = bookingService.UpdateBookingStartDate(bookingUpdateModel);

            if (!result)
            {
                return BadRequest("Booking could not be updated");
            }

            return Ok(result);
        }

        [HttpPatch("/update-end-date")]
        public ActionResult<bool> UpdateBookingEndDate([FromBody] BookingUpdateEndDateDto bookingUpdateModel)
        {
            var result = bookingService.UpdateBookingEndDate(bookingUpdateModel);

            if (!result)
            {
                return BadRequest("Booking could not be updated");
            }

            return Ok(result);
        }

        [HttpGet("/get-booking/{bookingId}")]
        public ActionResult<Booking> GetById(int bookingId)
        {
            var result = bookingService.GetById(bookingId);

            if (result == null)
            {
                return BadRequest("Booking not found");
            }

            return Ok(result);
        }

        [HttpPatch("/delete/{bookingId}")]
        public ActionResult<bool> DeleteBooking(int bookingId)
        {
            var result = bookingService.DeleteBooking(bookingId);

            if (!result)
            {
                return BadRequest("Booking not found");
            }

            return Ok(result);
        }

        [HttpGet("/get-by-room-id/{roomId}")]
        public ActionResult<List<Booking>> GetAllByRoomID(int roomId)
        {
            var result = bookingService.GetByRoomID(roomId);

            if (result == null)
                return BadRequest("Bookings not found");

            return Ok(result);
        }

        [HttpGet("/get-by-customer-id/{customerId}")]
        public ActionResult<List<Booking>> GetAllByCustomerId(int customerId)
        {
            var result = bookingService.GetByCustomerID(customerId);

            if (result == null)
                return BadRequest("Bookings not found");

            return Ok(result);
        }

        [HttpGet("/get-after-start-date/{startDate}")]
        public ActionResult<List<Booking>> GetAllAfterStartDate(DateTime startDate)
        {
            var result = bookingService.GetAllAfterStartDate(startDate);

            if (result == null)
                return BadRequest("Bookings not found");

            return Ok(result);
        }

        [HttpGet("/get-by-date/{date}")]
        public ActionResult<List<Booking>> GetAllByDate(DateTime date)
        {
            var result = bookingService.GetAllByDate(date);

            if (result == null)
                return BadRequest("Bookings not found");

            return Ok(result);
        }

        [HttpPost("/add-booking")]
        public IActionResult Add([FromBody] BookingAddDto payload)
        {
            var result = bookingService.AddBooking(payload);

            if (result == null)
                return BadRequest("Booking cannot be added");

            return Ok(result);
        }
    }
}
