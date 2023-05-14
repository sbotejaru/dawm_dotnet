﻿using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using Infrastructure.Exceptions;
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
                Price = payload.Price,
                Deleted = false
            };

            unitOfWork.Rooms.Insert(room);
            unitOfWork.SaveChanges();

            return payload;
        }

        public List<Room> GetAllFreeRooms()
        {
            return unitOfWork.Rooms.GetAllFreeRooms();
        }

        public List<Room> GetAllFreeRoomsForDate(DateTime date)
        {
            return unitOfWork.Rooms.GetAllFreeRoomsForDate(date);
        }

        public List<Room> GetAllFreeRoomsByType(string roomType)
        {
            return unitOfWork.Rooms.GetAllFreeRoomsByType(roomType);
        }

        public List<Room> GetAllFreeRoomsCheaperThan(double price)
        {
            return unitOfWork.Rooms.GetAllFreeRoomsCheaperThan(price);
        }

        public bool UpdateRoomIsAvailableFrom(RoomUpdateIsAvailableFromDto payload) 
        {
            if (payload == null)
            {
                return false;
            }

            var result = unitOfWork.Rooms.GetById(payload.ID);
            if (result == null)
                throw new ResourceMissingException($"Room with id {payload.ID} doesn't exist");


            result.IsAvailableFrom = payload.IsAvailableFrom;
            unitOfWork.SaveChanges();
            return true;


        }

        public bool UpdateRoomNumber(RoomUpdateNumberDto payload) 
        {
            if (payload == null || unitOfWork.Rooms.GetRoomByRoomNumber(payload.RoomNr) != null)
            {
                return false;
            }

            var result = unitOfWork.Rooms.GetById(payload.ID);
            if (result == null)
                throw new ResourceMissingException($"Room with id {payload.ID} doesn't exist");


            result.RoomNr = payload.RoomNr;
            unitOfWork.SaveChanges();
            return true;

        }

        public bool UpdateRoomPrice(RoomUpdatePriceDto payload)
        {
            if (payload == null)
            {
                return false;
            }

            var result = unitOfWork.Rooms.GetById(payload.ID);
            if (result == null)
                throw new ResourceMissingException($"Room with id {payload.ID} doesn't exist");



            result.Price = payload.Price;
            unitOfWork.SaveChanges();
            return true;

        }

        public bool UpdateRoomType(RoomUpdateTypeDto payload)
        {
            if (payload == null)
            {
                return false;
            }

            var result = unitOfWork.Rooms.GetById(payload.ID);
            if (result == null) 
                throw new ResourceMissingException($"Room with id {payload.ID} doesn't exist");

            result.RoomType = payload.RoomType;
            unitOfWork.SaveChanges();
            return true;

        }

        public bool DeleteRoom(int RoomID)
        {
            var result = unitOfWork.Rooms.GetById(RoomID);
            if (result == null)
                throw new ResourceMissingException($"Room with id {RoomID} doesn't exist");


            result.Deleted = true;
            unitOfWork.SaveChanges();
            return true;
        }

        public Room GetById(int RoomId)
        {
            return unitOfWork.Rooms.GetById(RoomId);
        }

    }
}
