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
    public class AdminService
    {
        private readonly UnitOfWork unitOfWork;

        public AdminService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Admin> GetAll()
        {
            var results = unitOfWork.Admins.GetAll();

            return results;
        }

        public Admin GetByUserID(int userID)
        {
            return unitOfWork.Admins.GetAdminByUserID(userID);
        }

        public bool UpdateAdminName(AdminUpdateDto payload)
        {
            if (payload == null || payload.Name == null)
                return false;

            var result = unitOfWork.Admins.GetById(payload.Id);
            if (result == null)
                throw new ResourceMissingException($"Admin with ID {payload.Id} doesn't exist");

            result.Name = payload.Name;
            unitOfWork.SaveChanges();
            return true;
        }

        public Admin GetById(int adminId)
        {
            return unitOfWork.Admins.GetById(adminId);
        }
    }
}
