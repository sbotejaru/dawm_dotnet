using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class RoomService
    {
        private readonly UnitOfWork unitOfWork;

        public RoomService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Room> GetAll()
        {
            var result = unitOfWork.Rooms.GetAll();

            return result;
        }

        public RoomAddDto AddRoom(RoomAddDto payload)
        {
            if (payload == null) return null;

            var room = new Room
            {
                RoomNr = payload.RoomNr,
                RoomType = payload.RoomType,
                IsAvailableFrom = payload.IsAvailableFrom,
                Price = payload.Price
            };

            unitOfWork.Rooms.Insert(room);
            unitOfWork.SaveChanges();

            return payload;
        }
    }
}
