using Core.Dtos;
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
            if (existingUserID == null)
                throw new ResourceMissingException($"User with id {payload.UserID} doesn't exist.");

            if (payload.Name == "" || payload.Name == null)
                throw new ResourceMissingException($"Name is missing.");

            var newCustomer = new Customer
            {
                UserID = payload.UserID,
                Name = payload.Name,
                Deleted = false
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

        public bool UpdateCustomerName(CustomerUpdateDto payload)
        {
            if (payload == null || payload.Name == null)
                return false;

            var result = unitOfWork.Customers.GetById(payload.Id);
            if (result == null)
                throw new ResourceMissingException($"Customer with id {payload.Id} doesn't exist.");

            result.Name = payload.Name;
            unitOfWork.SaveChanges();
            return true;
        }

        public bool DeleteCustomer(int customerID)
        {
            var result = unitOfWork.Customers.GetById(customerID);
            if (result == null)
                throw new ResourceMissingException($"Customer with id {customerID} doesn't exist.");

            result.Deleted = true;
            unitOfWork.SaveChanges();
            return true;
        }

        public Customer GetById(int CustomerId)
        {
            return unitOfWork.Customers.GetById(CustomerId);
        }
    }
}
