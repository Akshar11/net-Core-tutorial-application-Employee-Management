using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCoreApp.models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        IEnumerable<Employee> getAllEmployee();
        Employee Add(Employee emp);
        Employee Update(Employee employeeChanges);
        Employee Delete(int id);
    }
}
