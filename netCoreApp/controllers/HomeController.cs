using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netCoreApp.models;
using netCoreApp.viewModels;

namespace netCoreApp.controllers
{
    
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

      //  [Route("~/Home")]// Home
      //  [Route("~/")] //   starting ignored
    //    [Route("[action]")] // Home/Index
        public ViewResult Index()
        {
            IEnumerable<Employee> emps = _employeeRepository.getAllEmployees();
            return View(emps);
        }

     //   [Route("{id?}")]
        public ViewResult Details(int? id) {
            Employee model = _employeeRepository.GetEmployeeById(id??1);
            HomeDetailViewModel homeDetailViewModel = new HomeDetailViewModel() { Employee = model,title="BAPS" };
            return View(homeDetailViewModel);
        }

        [HttpGet]
        public ViewResult Create() {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Employee emp) {
           Employee newEmp= _employeeRepository.addEmployee(emp);
            return RedirectToAction("create");
        }
    }
}