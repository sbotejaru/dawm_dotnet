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
    public class BookingService
    {
        private readonly UnitOfWork unitOfWork;

        public BookingService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public BookingAddDto AddBooking(BookingAddDto payload)
        {
            if (payload == null) return null;

            var existingRoom = unitOfWork.Rooms.GetById(payload.RoomID);
            if (existingRoom == null) return null;        
            
            var existingCustomer = unitOfWork.Rooms.GetById(payload.CustomerID);
            if (existingCustomer == null) return null;


            var newBooking = new Booking
            {
                CustomerID = payload.CustomerID,
                RoomID = payload.RoomID,
                DateFrom = payload.DateFrom,
                DateTo = payload.DateTo,
                TotalPrice = payload.TotalPrice
            };

            unitOfWork.Bookings.Insert(newBooking);
            unitOfWork.SaveChanges();

            return payload;
        }
        public List<Booking> GetAll()
        {
            var results = unitOfWork.Bookings.GetAll();

            return results;
        }
    }
}
