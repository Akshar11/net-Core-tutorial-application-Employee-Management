using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using netCoreApp.models;
using netCoreApp.viewModels;

namespace netCoreApp.controllers
{
    
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository,
            IWebHostEnvironment hostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostEnvironment;
        }

      //  [Route("~/Home")]// Home
      //  [Route("~/")] //   starting ignored
    //    [Route("[action]")] // Home/Index
        public ViewResult Index()
        {
            IEnumerable<Employee> emps = _employeeRepository.getAllEmployee();
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
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFilename = null;
                if (model.Photo!=null) {
                  string uploadsFolder=  Path.Combine(_hostingEnvironment.WebRootPath , "images");
                   uniqueFilename= Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder,uniqueFilename);
                    using (FileStream fs=new FileStream(filePath, FileMode.Create)) {
                        model.Photo.CopyTo(fs);
                    }
                      
                }
                Employee newEmp = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = model.Photo.FileName
                };

                _employeeRepository.Add(newEmp);
                return RedirectToAction("detail", new { id = newEmp.Id });
            }

            return View();
        }
    }
}