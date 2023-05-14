using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
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
            if (existingUserID == null) return null;

            if (payload.Name == "" || payload.Name == null) return null;


            var newEmployee = new Employee
            {
                UserID = payload.UserID,
                Name = payload.Name
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
                return false;

            result.Name = payload.Name;

            return true;
        }

        public bool DeleteEmployee(int employeeID)
        {
            var result = unitOfWork.Employees.GetById(employeeID);
            if (result == null)
                return false;

            result.Deleted = true;

            return true;
        }

        public Employee GetById(int EmployeeId)
        {
            return unitOfWork.Employees.GetById(EmployeeId);
        }
    }
}
