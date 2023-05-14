using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/room")]
    public class RoomsController : ControllerBase
    {
        private readonly RoomService RoomService;

        public RoomsController(RoomService RoomService)
        {
            this.RoomService = RoomService;
        }

        [HttpPost("/add")]
        public IActionResult Add([FromBody]RoomAddDto payload) 
        {
            var result = RoomService.AddRoom(payload);

            if (result == null)
            {
                return BadRequest("Room cannot be added");
            }

            return Ok(result);

        }

        [HttpGet("/get-all")]
        public ActionResult<List<Room>> GetAll()
        {
            var result = RoomService.GetAll();

            return Ok(result);
        }

        [HttpGet("/get/{RoomId}")]
        public ActionResult<Room> GetById(int RoomId)
        {
            var result = RoomService.GetById(RoomId);

            if (result == null)
            {
                return BadRequest("Room not found");
            }

            return Ok(result);
        }

        [HttpGet("/get-all-free-rooms")]
        public ActionResult<List<Room>> GetAllFreeRooms()
        {
            var result = RoomService.GetAllFreeRooms();

            return Ok(result);
        }

        [HttpGet("/get-all-free-rooms-for-date/{date}")]
        public ActionResult<List<Room>> GetAllFreeRoomsForDate(DateTime date)
        {
            var result = RoomService.GetAllFreeRoomsForDate(date);

            return Ok(result);
        }

        [HttpGet("/get-all-free-rooms-by-type/{type}")]
        public ActionResult<List<Room>> GetAllFreeRoomsByType(string type)
        {
            var result = RoomService.GetAllFreeRoomsByType(type);

            return Ok(result);
        }

        [HttpGet("/get-all-free-rooms-cheaper-than/{price}")]
        public ActionResult<List<Room>> GetAllFreeRoomsCheaperThan(float price)
        {
            var result = RoomService.GetAllFreeRoomsCheaperThan(price);

            return Ok(result);
        }


        [HttpPatch("/update-room-is-available-from")]
        public ActionResult<bool> UpdateRoomIsAvailableFrom([FromBody] RoomUpdateIsAvailableFromDto RoomUpdateModel)
        {
            var result = RoomService.UpdateRoomIsAvailableFrom(RoomUpdateModel);

            if (!result)
            {
                return BadRequest("Room availability date could not be updated.");
            }

            return Ok(result);
        }

        [HttpPatch("/update-room-number")]
        public ActionResult<bool> UpdateRoomNumber([FromBody] RoomUpdateNumberDto RoomUpdateModel)
        {
            var result = RoomService.UpdateRoomNumber(RoomUpdateModel);

            if (!result)
            {
                return BadRequest("Room number could not be updated.");
            }

            return Ok(result);
        }

        [HttpPatch("/update-room-price")]
        public ActionResult<bool> UpdateRoomPrice([FromBody] RoomUpdatePriceDto RoomUpdateModel)
        {
            var result = RoomService.UpdateRoomPrice(RoomUpdateModel);

            if (!result)
            {
                return BadRequest("Room price could not be updated.");
            }

            return Ok(result);
        }

        [HttpPatch("/update-room-type")]
        public ActionResult<bool> UpdateRoomType([FromBody] RoomUpdateTypeDto RoomUpdateModel)
        {
            var result = RoomService.UpdateRoomType(RoomUpdateModel);

            if (!result)
            {
                return BadRequest("Room type could not be updated.");
            }

            return Ok(result);
        }


        [HttpPatch("/delete/{roomId}")]
        public ActionResult<bool> DeleteRoom(int roomId)
        {
            var result = RoomService.DeleteRoom(roomId);

            if (!result)
            {
                return BadRequest("Room could not be deleted.");
            }

            return Ok(result);
        }

    }
}
