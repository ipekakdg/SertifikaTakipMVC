﻿using Entities;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IRepositoryManager _manager;

        public EmployeeManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateEmployee(Employee employee)
        {
            _manager.Employee.CreateEmployee(employee);
            _manager.Save();
        }

        public IEnumerable<Employee> GetAll(bool trackChanges)
        {
            return _manager.Employee.GetAll(trackChanges);
        }

        public Employee? GetOneEmployee(int id, bool trackChanges)
        {
            var employee= _manager.Employee.GetOneEmployee(id, trackChanges);
            if (employee == null)
            {
                throw new Exception("Personel bulunamadı");
            }
            return employee;
        }
    }
}
