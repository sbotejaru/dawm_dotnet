using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Core.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;
        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<User> GetAll()
        {
            var result = unitOfWork.Users.GetAll();

            return result;
        }

        public UserAddDto AddUser(UserAddDto payload)
        {
            if (payload == null) return null;

            var user = new User
            {
                Username = payload.Username,
                Password = payload.Password,
                RoleID = payload.RoleID
            };

            unitOfWork.Users.Insert(user);
            unitOfWork.SaveChanges();

            return payload;
        }
    }
}
