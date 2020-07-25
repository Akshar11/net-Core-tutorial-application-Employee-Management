using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netCoreApp.models;

namespace netCoreApp.controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public string Index()
        {
            return _employeeRepository.GetEmployeeById(1).Name;
        }
        public JsonResult details() {
            Employee model = _employeeRepository.GetEmployeeById(1);
            return Json(model);
        }
    }
}