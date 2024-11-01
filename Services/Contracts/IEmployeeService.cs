using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll(bool trackChanges);
        Employee? GetOneEmployee(int id,bool trackChanges);
        void CreateEmployee(Employee employee);
    }
}
