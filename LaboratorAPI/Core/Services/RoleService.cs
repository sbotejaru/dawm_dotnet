﻿using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class RoleService
    {
        private readonly UnitOfWork unitOfWork;

        public RoleService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Role> GetAll()
        {
            var result = unitOfWork.Roles.GetAll();

            return result;
        }
    }
}
