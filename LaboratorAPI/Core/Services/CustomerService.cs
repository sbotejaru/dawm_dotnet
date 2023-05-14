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
    public class CustomerService
    {
        private readonly UnitOfWork unitOfWork;

        public CustomerService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public CustomerAddDto AddCustomer(CustomerAddDto payload)
        {
            if (payload == null) return null;

            var existingUserID = unitOfWork.Users.GetById(payload.UserID);
            if (existingUserID == null) return null;

            if (payload.Name == "" || payload.Name == null) return null;


            var newCustomer = new Customer
            {
                UserID = payload.UserID,
                Name = payload.Name
            };

            unitOfWork.Customers.Insert(newCustomer);
            unitOfWork.SaveChanges();

            return payload;
        }
        public List<Customer> GetAll()
        {
            var results = unitOfWork.Customers.GetAll();

            return results;
        }

        public Customer GetByUserID(int userID)
        {
            return unitOfWork.Customers.GetCustomerByUserID(userID);
        }
    }
}
