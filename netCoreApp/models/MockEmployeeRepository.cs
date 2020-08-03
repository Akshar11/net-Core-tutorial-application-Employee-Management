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
                new Employee() { Id = 1,Department=Dept.FrontEnd,Email="a@a.com",Name="n1" },
                    new Employee() { Id = 2, Department = Dept.BackEnd, Email = "a@b.com", Name = "n2" },
                    new Employee() { Id = 3, Department = Dept.UI, Email = "a@c.com", Name = "n3" },
            };
        }

        public Employee Add(Employee emp)
        {
            emp.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(emp);
            return emp;
        }

        public Employee Delete(int id)
        {
          Employee employee= _employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null) {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> getAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
          return   _employeeList.FirstOrDefault(e=>e.Id==id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }
    }
}
