using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository 
    {
        public EmployeeRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateEmployee(Employee employee) => Create(employee);
        

        public IQueryable<Employee> GetAll(bool trackChanges)=>FindAll(trackChanges);
        

        public Employee? GetOneEmployee(int id, bool trackChanges)
        {
            return FindByCondition(p => p.EmployeeID.Equals(id), trackChanges);
        }
    }
}
