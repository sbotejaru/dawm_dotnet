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
    }
}
