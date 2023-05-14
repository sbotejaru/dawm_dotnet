using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class EmployeeService
    {
        private readonly UnitOfWork unitOfWork;

        public EmployeeService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public EmployeeAddDto AddEmployee(EmployeeAddDto payload)
        {
            if (payload == null) return null;

            var existingUserID = unitOfWork.Users.GetById(payload.UserID);
            if (existingUserID == null)
                throw new ResourceMissingException($"User with id {payload.UserID} doesn't exist.");

            if (payload.Name == "" || payload.Name == null)
                throw new ResourceMissingException("Name is missing.");


            var newEmployee = new Employee
            {
                UserID = payload.UserID,
                Name = payload.Name,
                Deleted = false
            };

            unitOfWork.Employees.Insert(newEmployee);
            unitOfWork.SaveChanges();

            return payload;
        }
        public List<Employee> GetAll()
        {
            var results = unitOfWork.Employees.GetAll();

            return results;
        }

        public Employee GetByUserID(int userID)
        {
            return unitOfWork.Employees.GetEmployeeByUserID(userID);
        }

        public bool UpdateEmployeeName(EmployeeUpdateDto payload)
        {
            if (payload == null || payload.Name == null)
                return false;

            var result = unitOfWork.Employees.GetById(payload.Id);
            if (result == null)
                throw new ResourceMissingException($"Employee with id {payload.Id} doesn't exist.");

            result.Name = payload.Name;
            unitOfWork.SaveChanges();
            return true;
        }

        public bool DeleteEmployee(int employeeID)
        {
            var result = unitOfWork.Employees.GetById(employeeID);
            if (result == null)
                throw new ResourceMissingException($"Employee with id {employeeID} doesn't exist.");

            result.Deleted = true;
            unitOfWork.SaveChanges();
            return true;
        }

        public Employee GetById(int EmployeeId)
        {
            return unitOfWork.Employees.GetById(EmployeeId);
        }
    }
}
