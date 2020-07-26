using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netCoreApp.models;
using netCoreApp.viewModels;

namespace netCoreApp.controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public ViewResult Index()
        {
            IEnumerable<Employee> emps = _employeeRepository.getAllEmployees();
            return View(emps);
        }
        public ViewResult details() {
            Employee model = _employeeRepository.GetEmployeeById(1);
            HomeDetailViewModel homeDetailViewModel = new HomeDetailViewModel() { Employee = model,title="BAPS" };
            return View(homeDetailViewModel);
        }
    }
}