using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Enums;
using Infrastructure.Exceptions;
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
        private AuthorizationService authService { get; set; }

        public UserService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            this.unitOfWork = unitOfWork;
            this.authService = authService;
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
                RoleID = payload.RoleID,
                Deleted = false
            };

            unitOfWork.Users.Insert(user);
            unitOfWork.SaveChanges();

            return payload;
        }

        public void RegisterUser(RegisterDto payload)
        {
            if (payload == null) return;

            var hashedPassword = authService.HashPassword(payload.Password);

            var user = new User
            {
                Username = payload.Username,
                Password = hashedPassword,
                RoleID = RoleType.Customer,
                Deleted = false
            };

            unitOfWork.Users.Insert(user);
            unitOfWork.SaveChanges();

            //return payload;
        }

        public string Validate(LoginDto payload)
        {
            var user = unitOfWork.Users.GetByUsername(payload.Username);

            var passwordFine = authService.VerifyHashedPassword(user.Password, payload.Password);

            if (passwordFine)
            {
                return authService.GetToken(user);
            }
            else
            {
                return null;
            }

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
            if (result == null) 
                      throw new ResourceMissingException($"User with id {payload.Id} doesn't exist");


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
            if (result == null) 
                throw new ResourceMissingException($"User with id {payload.Id} doesn't exist");


            result.RoleID = payload.Role;
            unitOfWork.SaveChanges();
            return true;

        }

        public bool DeleteUser(int UserID)
        {
            var result = unitOfWork.Users.GetById(UserID);
            if (result == null)
                throw new ResourceMissingException($"User with id {UserID} doesn't exist");


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
