using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IEmployeeRepository:IRepositoryBase<Employee>
    {
        IQueryable<Employee> GetAll(bool trackChanges);
        Employee? GetOneEmployee(int id,bool trackChanges);
        void CreateEmployee(Employee employee);
    }
}
