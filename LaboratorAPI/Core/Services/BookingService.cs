using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using Infrastructure.Exceptions;
using Infrastructure.Middlewares;
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
            if (existingRoom == null)
                throw new ResourceMissingException($"Room with id {payload.RoomID} doesn't exist.");

            var existingCustomer = unitOfWork.Rooms.GetById(payload.CustomerID);
            if (existingCustomer == null)
                throw new ResourceMissingException($"Customer with id {payload.CustomerID} doesn't exist.");

            var newBooking = new Booking
            {
                CustomerID = payload.CustomerID,
                RoomID = payload.RoomID,
                DateFrom = payload.DateFrom,
                DateTo = payload.DateTo,
                TotalPrice = payload.TotalPrice,
                Deleted = false
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

        public List<Booking> GetByCustomerID(int customerID)
        {
            return unitOfWork.Bookings.GetBookingsByCustomerID(customerID);
        }

        public List<Booking> GetByRoomID(int roomID)
        {
            return unitOfWork.Bookings.GetBookingsByRoomID(roomID);
        }

        public List<Booking> GetAllAfterStartDate(DateTime date)
        {
            return unitOfWork.Bookings.GetBookingsAfterStartDate(date);
        }

        public List<Booking> GetAllByDate(DateTime date)
        {
            return unitOfWork.Bookings.GetBookingsByCurrentDate(date);
        }

        public bool UpdateBooking(BookingUpdateDto payload)
        {
            if (payload == null)
                return false;

            var roomRes = unitOfWork.Rooms.GetById(payload.RoomID);
            if (roomRes == null)
                throw new ResourceMissingException($"Room with id {payload.RoomID} doesn't exist.");

            var result = unitOfWork.Bookings.GetById(payload.ID);
            if (result == null)
                throw new ResourceMissingException($"Booking with id {payload.ID} doesn't exist.");


            result.TotalPrice = payload.TotalPrice;
            result.DateFrom = payload.DateFrom;
            result.DateTo = payload.DateTo;
            result.RoomID = payload.RoomID;
            unitOfWork.SaveChanges();
            return true;
        }

        public bool UpdateBookingEndDate(BookingUpdateEndDateDto payload)
        {
            if (payload == null)
                return false;

            var result = unitOfWork.Bookings.GetById(payload.ID);
            if (result == null || payload.DateTo < result.DateFrom)
                throw new ResourceMissingException($"Booking with id {payload.ID} doesn't exist, or" +
                    $" the dates are invalid.");

            result.DateTo = payload.DateTo;
            result.TotalPrice = payload.TotalPrice;
            unitOfWork.SaveChanges();
            return true;
        }

        public bool UpdateBookingRoom(BookingUpdateRoomDto payload)
        {
            if (payload == null)
                return false;

            var roomRes = unitOfWork.Rooms.GetById(payload.RoomID);
            if (roomRes == null)
                throw new ResourceMissingException($"Room with id {payload.RoomID} doesn't exist.");

            var result = unitOfWork.Bookings.GetById(payload.ID);
            if (result == null)
                throw new ResourceMissingException($"Booking with id {payload.ID} doesn't exist.");

            result.RoomID = payload.RoomID;
            result.TotalPrice = payload.TotalPrice;
            unitOfWork.SaveChanges();
            return true;
        }

        public bool UpdateBookingStartDate(BookingUpdateStartDateDto payload)
        {
            if (payload == null)
                return false;

            var result = unitOfWork.Bookings.GetById(payload.ID);
            if (result == null || result.DateTo < payload.DateFrom)
                throw new ResourceMissingException($"Booking with id {payload.ID} doesn't exist, or " +
                    $"the dates are invalid.");

            result.DateFrom = payload.DateFrom;
            result.TotalPrice = payload.TotalPrice;
            unitOfWork.SaveChanges();
            return true;
        }

        public bool DeleteBooking(int bookingID)
        {
            var result = unitOfWork.Bookings.GetById(bookingID);
            if (result == null)
                throw new ResourceMissingException($"Booking with id {bookingID} doesn't exist.");

            result.Deleted = true;
            unitOfWork.SaveChanges();
            return true;
        }

        public Booking GetById(int BookingId)
        {
            return unitOfWork.Bookings.GetById(BookingId);
        }
    }
}
