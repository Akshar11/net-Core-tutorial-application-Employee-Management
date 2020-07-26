using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCoreApp.models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository() {
            _employeeList =new List<Employee>(){
                new Employee() { Id = 1,Department="bhajan",Email="a@a.com",Name="n1" },
                    new Employee() { Id = 2, Department = "bhajan", Email = "a@b.com", Name = "n2" },
                    new Employee() { Id = 3, Department = "bhajan", Email = "a@c.com", Name = "n3" },
            };
        }

        public IEnumerable<Employee> getAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
          return   _employeeList.FirstOrDefault(e=>e.Id==id);
        }

    }
}
