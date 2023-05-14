using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Enums;
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

        public User GetUserByUsername(string username)
        {
            var user = unitOfWork.Users.GetByUsername(username);

            return user;
        }

        public List<User> GetUsersByRole(RoleType role)
        {
            var users = unitOfWork.Users.GetByRole(role);

            return users;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var user = unitOfWork.Users.GetByUsernameAndPassword(username, password);

            return user;
        }

        public bool UpdateUserPassword (UserUpdatePasswordDTO payload)
        {
            if (payload == null || payload.Password == null || payload.Password == "")
            {
                return false;
            }

            var result = unitOfWork.Users.GetById(payload.Id);
            if (result == null) return false;

            result.Password = payload.Password;
            unitOfWork.SaveChanges();

            return true;
        }

        public bool UpdateUserRole (UserUpdateRoleDto payload)
        {
            if (payload == null || (int)payload.Role > 3 || (int)payload.Role < 0)
            {
                return false;
            }

            var result = unitOfWork.Users.GetById(payload.Id);
            if (result == null) return false;

            result.RoleID = payload.Role;
            unitOfWork.SaveChanges();
            return true;

        }

        public bool DeleteUser(int UserID)
        {
            var result = unitOfWork.Users.GetById(UserID);
            if (result == null)
                return false;

            result.Deleted = true;
            unitOfWork.SaveChanges();
            return true;
        }

        public User GetById(int UserId)
        {
            return unitOfWork.Users.GetById(UserId);
        }

    }
}
